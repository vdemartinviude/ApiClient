namespace Classlib.Model;

public class Veiculo
{
    public string? Modelo { get; set;}
    public string? Fipe { get; set; }
    public string? Codigo { get; set; }
    public List<AnoTabela>? Anos {get; set;}
}

public class AnoTabela
{
    public int Ano { get; set; }
    public DateTime Vigencia {get; set;}
    public double ValorFipe { get; set; }
}