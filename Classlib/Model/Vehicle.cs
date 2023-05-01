namespace Classlib.Model;

public class Veiculo
{
    public string? Modelo { get; set;}
    public string? Fipe { get; set; }
    public string? Codigo { get; set; }
    public int CodCambio { get; set;}
    public int CodFabricante { get; set; }
    public int CodCombustivel { get; set; }
    public int CodGrupo { get; set; }
    public int CodTipo { get; set;}
    public List<AnoTabela>? Anos {get; set;}

}

public class AnoTabela
{
    public int Ano { get; set; }
    public DateTime Vigencia {get; set;}
    public double ValorFipe { get; set; }
}