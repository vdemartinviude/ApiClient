namespace DataAccess.Model;

public class VehicleApiQueryHistory
{
    public Guid Id { get; set; }
    public DateTime QueryDate {get; set;}
    public DateTime MinEffectiness { get; set; }
    public DateTime MaxEffectiness { get; set; }
    public List<VehicleModel> VehicleModels {get; set;} = null!;
}