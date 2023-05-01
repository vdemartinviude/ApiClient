using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class BradescoApiDbContext : DbContext
{
    public BradescoApiDbContext(DbContextOptions<BradescoApiDbContext> options) : base(options)
    {
        
    }
    public DbSet<VehicleModel> Vehicles { get; set; } = null!;
    public DbSet<YearInfoModel> Years {get; set;} = null!;
    public DbSet<VehicleApiQueryHistory> ApiQueryHistories {get; set;} = null!;
}