namespace DataAccess.Model;

public class VehicleModel
{
    public Guid Id { get; set;}
    public string Model {get; set;} = "";
    public string FipeCod { get; set; } = "";
    public string BradescoApiCode { get; set; } = "";
    public string GearMode { get; set; } = "";
    public string Manufactur { get; set; } = "";
    public string GasKind { get; set; } = "";
    public string VehicleGroup { get; set;} = "";
    public string VehicleKind { get; set; } = "";
    public int GearCod {get; set;} = 0;
    public int ManufacturCod {get;set;} = 0;
    public int GasCod {get;set;} = 0;
    public int GroupCod {get;set;} = 0;
    public int KindCod {get;set;} = 0;
    public List<YearInfoModel>? Years { get; set;}
}