﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
namespace Classlib;
public class ApiService
{
    public bool IsConnect { get; private set; }
    private readonly string _baseUrl;
    private readonly AuthenticateParameters _authenticateParamters;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private AuthenticateResult? _authenticateResult;
    private readonly ILogger<ApiService> _logger;
    public ApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<ApiService> logger)
    {
        _httpClientFactory = httpClientFactory;
        IsConnect = false;
        _configuration = configuration;
        _authenticateParamters = new();
        _configuration.GetSection("AuthenticationParameters").Bind(_authenticateParamters);
        _baseUrl = _configuration.GetRequiredSection("ApiParameters").GetValue<string>("BaseUrl")!;
        _logger = logger;
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

    public string GetVehiclesList()
    {
        var xmlData = GetEmbeddedXmlFromResource.GetEmbeddedXmlContent("Classlib.Resources.VehicleListXmlRequest.xml");
        _logger.LogInformation(xmlData);
        return xmlData;
    }
}
