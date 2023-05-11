namespace QuickType;


public partial class CalculationRequest
{
    public Autenticacao Autenticacao { get; set; }
    public CalculoVoIn CalculoVoIn { get; set; }
}

public partial class Autenticacao
{
    public long Provedor { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
}

public partial class CalculoVoIn
{
    public long CdInspetoria { get; set; }
    public string CdModalidade { get; set; }
    public long CdProdutoCliente { get; set; }
    public long CdSucursal { get; set; }
    public long CdTipoSistema { get; set; }
    public CondutorVo CondutorVo { get; set; }
    public long DtFinalVigencia { get; set; }
    public long DtInicioVigencia { get; set; }
    public long DtProcessamento { get; set; }
    public ECoberturaVo ECoberturaVo { get; set; }
    public EParametroVo EParametroVo { get; set; }
    public EVeiculoVo EVeiculoVo { get; set; }
    public long PcComissaoApp { get; set; }
    public long PcComissaoAuto { get; set; }
    public long PcComissaoRcf { get; set; }
    public string PctDescontoPromocional { get; set; }
    public Produto Produto { get; set; }
    public ProprietarioVo ProprietarioVo { get; set; }
    public string SeguradoEoCondutor { get; set; }
    public string SeguradoEoProprietario { get; set; }
    public SeguradoVo SeguradoVo { get; set; }
}

public partial class CondutorVo
{
    public long AtividadeCondutor { get; set; }
    public string CepPernoite { get; set; }
    public long CondutorEntre18E25 { get; set; }
    public string CpfCondutor { get; set; }
    public string DataNascimentoCondutor { get; set; }
    public long EstadoCivilCondutor { get; set; }
    public long GaragemLocalEstudo { get; set; }
    public long GaragemLocalTrabalho { get; set; }
    public long GaragemPernoite { get; set; }
    public long KmMediaMensal { get; set; }
    public string SexoCondutor { get; set; }
    public long RamoAtividadeCondutor { get; set; }
    public long UtilizacaoEstudo { get; set; }
    public long UtilizacaoTrabalho { get; set; }
    public string MaisDeUmVeiculo { get; set; }
}

public partial class ECoberturaVo
{
    public long CdClausulaAssistencia { get; set; }
    public long CdClausulaCarroReserva { get; set; }
    public long CdClausulaVidros { get; set; }
    public long CdClausulaMartelinho { get; set; }
    public long CdClausulaReparoRapido { get; set; }
    public long CdZeroKm { get; set; }
    public string FlDespesasExtraordinarias { get; set; }
    public string FlExtensaoRcfVeiculo { get; set; }
    public string IsCarroceria { get; set; }
    public string IsEquipamentos { get; set; }
    public string IsAppInvalidez { get; set; }
    public string IsAppMorte { get; set; }
    public string IsDanosCorporais { get; set; }
    public string IsDanosMateriais { get; set; }
    public string IsDanosMorais { get; set; }
    public string IsBlindagem { get; set; }
    public string IsKitGas { get; set; }
    public long NuDiasDiariaParalisacao { get; set; }
    public long VlDiariaParalisacao { get; set; }
}

public partial class EParametroVo
{
    public long CdCorretor { get; set; }
    public long CdFormaPagamento { get; set; }
    public string CdTipoPessoaCorretor { get; set; }
    public string FlAdicionalFracionamento { get; set; }
    public string FlCartaoBradesco { get; set; }
    public string FlCartaoCredito { get; set; }
    public string FlCcb { get; set; }
    public string FlCustoApolice { get; set; }
    public string FlIof { get; set; }
    public string FlPessoaCorretor { get; set; }
    public string FlProRata { get; set; }
    public string NuCpfCnpjCorretor { get; set; }
}

public partial class EVeiculoVo
{
    public long CdAntiFurto { get; set; }
    public long CdCambio { get; set; }
    public long CdCombustivel { get; set; }
    public string CdFabricante { get; set; }
    public long CdFranquia { get; set; }
    public long CdKmRodadoMes { get; set; }
    public long CdProduto { get; set; }
    public long CdUsoVeiculo { get; set; }
    public long CdVeiculo { get; set; }
    public string CdVeiculoFipe { get; set; }
    public long CdVeiculoTransformado { get; set; }
    public string FlChassiRemarcado { get; set; }
    public string FlComodato { get; set; }
    public string FlIdenticar { get; set; }
    public string FlValorMercado { get; set; }
    public object ListaAcessorios { get; set; }
    public long NuAnoFabricacao { get; set; }
    public long NuAnoModelo { get; set; }
    public long NuEixo { get; set; }
    public long NuPassageiros { get; set; }
    public string NuPlaca { get; set; }
    public long NuPortas { get; set; }
    public long PcAjusteValorVeiculo { get; set; }
}

public partial class Produto
{
    public long CdCanalDeVenda { get; set; }
    public long Codigo { get; set; }
}

public partial class ProprietarioVo
{
    public string CpfCnpjProprietario { get; set; }
    public string NomeProprietario { get; set; }
    public string TipoProprietario { get; set; }
}

public partial class SeguradoVo
{
    public string NomeSegurado { get; set; }
    public string CpfCnpjSegurado { get; set; }
    public string DataNascimentoSegurado { get; set; }
    public string SexoSegurado { get; set; }
    public long EstadoCivilSegurado { get; set; }
    public string TipoSegurado { get; set; }
}
