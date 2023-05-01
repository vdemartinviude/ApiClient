using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Xml;
using Classlib.Model;
using System.Globalization;
using DataAccess.Data;
using Classlib.Dictionaries;

namespace Classlib;
public class ApiService
{
    public bool IsConnect { get; private set; }
    private readonly string _baseUrl;
    private readonly ILogger<ApiService> _logger;
    private readonly AuthenticateParameters _authenticateParamters;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private AuthenticateResult? _authenticateResult;
    private readonly BradescoApiDbContext _dbContext;
    public ApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<ApiService> logger, BradescoApiDbContext dbContext)
    {
        _httpClientFactory = httpClientFactory;
        IsConnect = false;
        _configuration = configuration;
        _authenticateParamters = new();
        _configuration.GetSection("AuthenticationParameters").Bind(_authenticateParamters);
        _baseUrl = _configuration.GetRequiredSection("ApiParameters").GetValue<string>("BaseUrl")!;
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<string> Authenticate()
    {
        
        using (var httpClient = _httpClientFactory.CreateClient()) 
        {
            var keyValues = new List<KeyValuePair<string,string>>() 
            {
                new KeyValuePair<string,string>("client_id",_authenticateParamters.client_id),
                new KeyValuePair<string,string>("client_secret",_authenticateParamters.client_secret),
                new KeyValuePair<string,string>("grant_type",_authenticateParamters.grant_type),
                new KeyValuePair<string,string>("scope",_authenticateParamters.scope),
                new KeyValuePair<string,string>("token",_authenticateParamters.token)
            } ;

            var content = new FormUrlEncodedContent(keyValues);
            var uriBuilder = new UriBuilder(_baseUrl);
            uriBuilder.Path = _configuration.GetRequiredSection("ApiParameters").GetValue<string>("AuthRoute");
            var request = new HttpRequestMessage(HttpMethod.Post,uriBuilder.Uri);
            request.Content = content;

            var response = await httpClient.SendAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException("Was not possible to authenticate with API Provider!");
            }
            _authenticateResult = await response.Content.ReadFromJsonAsync<AuthenticateResult>();
            _logger.LogInformation(_authenticateResult!.access_token!);
            IsConnect = true;
            return _authenticateResult!.access_token!;
            
        }
    }

    public async Task<List<Veiculo>> GetVehiclesList()
    {
        if (!IsConnect)
        {
            throw new Exception("Not authenticated with API");
        }
        string vehicleList;
        var xmlData = GetEmbeddedXmlFromResource.GetEmbeddedXmlContent("Classlib.Resources.VehicleListXmlRequest.xml");
        using (var httpClient = _httpClientFactory.CreateClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",_authenticateResult!.access_token!);
                       
            var content = new StringContent(xmlData,new MediaTypeHeaderValue("application/xml"));
            var uriBuilder = new UriBuilder(_baseUrl);
            uriBuilder.Path = _configuration.GetRequiredSection("ApiParameters").GetValue<string>("ListVehicleRoute");
            var request = new HttpRequestMessage(HttpMethod.Post,uriBuilder.Uri); 
            request.Content = content;

            var response = await httpClient.SendAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException("Was not possible to get vehicles list");
            }

            vehicleList = await response.Content.ReadAsStringAsync();
            //vehicleList = "<ns2:listaVeiculosVo xmlns:ns2=\"http://webservice.cotacaocsp.wsbl.bradseg.com.br/service/VeiculoService\"><erro><cdErro>0</cdErro><cdSQLCode>0</cdSQLCode></erro></ns2:listaVeiculosVo>";
            XmlDocument doc = new();
            doc.LoadXml(vehicleList);

            var xmllist = doc.SelectNodes("//veiculos");
            var nodelist = xmllist!.Cast<XmlNode>();

            return nodelist.Select(x => {
                var anos = new List<AnoTabela>();
                var anosxml = x.SelectNodes("anos");
                var anosnodes = anosxml!.Cast<XmlNode>();
                anos.AddRange(anosnodes.Select(y => new AnoTabela 
                {
                    Ano = Convert.ToInt32(y.SelectSingleNode("ano")!.InnerText),
                    ValorFipe = Convert.ToDouble(y.SelectSingleNode("valorFipe")!.InnerText,new CultureInfo("en-us")),
                    Vigencia = DateTime.ParseExact(y.SelectSingleNode("dataVigencia")!.InnerText,"yyyyMMdd",new CultureInfo("pt-BR"))
                }).ToList());
                
                return new Veiculo 
                {
                    Modelo = x.SelectSingleNode("modelo")!.InnerText,
                    Fipe = x.SelectSingleNode("fipe")!.InnerText,
                    Codigo = x.SelectSingleNode("codigo")!.InnerText,
                    CodCambio = Convert.ToInt32(x.SelectSingleNode("cambio")!.InnerText),
                    CodCombustivel = Convert.ToInt32(x.SelectSingleNode("combustivel")!.InnerText),
                    CodFabricante = Convert.ToInt32(x.SelectSingleNode("codigoFabricante")!.InnerText),
                    CodGrupo = Convert.ToInt32(x.SelectSingleNode("grupoVeiculo")!.InnerText),
                    CodTipo = Convert.ToInt32(x.SelectSingleNode("tipoVeiculo")!.InnerText),
                    Anos = anos
                };
            }).ToList();
        }
    }

    public async Task PopulateVehicleTable()
    {
        var vehicleList = await GetVehiclesList();

        var MinEffectiness = vehicleList.SelectMany(x => x.Anos).Min(x => x.Vigencia);
        var MaxEffectiness = vehicleList.SelectMany(x => x.Anos).Max(x => x.Vigencia);

        var newquery = _dbContext.ApiQueryHistories.Add(new ()
        {
            QueryDate = DateTime.UtcNow,
            MaxEffectiness = MaxEffectiness,
            MinEffectiness = MinEffectiness
        });
        foreach (var vec in vehicleList)
        {
            var vehicle = _dbContext.Vehicles.Add(new()
            {
                Model = vec.Modelo,
                FipeCod = vec.Fipe,
                BradescoApiCode = vec.Codigo,
                GasCod = vec.CodCombustivel,
                GearCod = vec.CodCambio,
                KindCod = vec.CodTipo,
                GroupCod = vec.CodGrupo,
                ManufacturCod = vec.CodFabricante,
                GasKind = DomainDictionaries.GetCombustivel(vec.CodCombustivel),
                GearMode = DomainDictionaries.GetCambio(vec.CodCambio),
                Manufactur = DomainDictionaries.GetFabricante(vec.CodFabricante),
                VehicleGroup = DomainDictionaries.GetGrupo(vec.CodGrupo),
                VehicleKind = DomainDictionaries.GetTipo(vec.CodTipo),
                QueryHistory = newquery.Entity
            });
            foreach(var year in vec.Anos)
            {
                _dbContext.Years.Add(new ()
                {
                    Year = year.Ano,
                    Value = year.ValorFipe,
                    Effectiveness = year.Vigencia,
                    VehicleModel = vehicle.Entity
                });
            }

        }
        await _dbContext.SaveChangesAsync();
    }
}
