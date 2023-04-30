using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class BradescoApiDbContext : DbContext
{
    public BradescoApiDbContext(DbContextOptions<BradescoApiDbContext> options) : base(options)
    {
        
    }
    public DbSet<VehicleModel>? Vehicles { get; set; }
    public DbSet<YearInfoModel>? Years {get; set;}
}