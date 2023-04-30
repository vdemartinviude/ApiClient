namespace DataAccess.Model;

public class YearInfoModel
{
    public Guid Id { get;set;}
    public int Year { get; set; }
    public double Value {get; set;}
    public DateTime Effectiveness {get; set;}
    public VehicleModel? VehicleModel {get; set;}
}