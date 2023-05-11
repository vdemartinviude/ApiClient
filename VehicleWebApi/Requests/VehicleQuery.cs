namespace VehicleWebApi.Requests;

public class VehicleQuery
{
    public string CodFipe {get; set;} = null!;
    public string Modelo { get; set; } = null!;
    public string Complemento { get; set; } = null!;
}