using Client;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<BradescoApiDbContext>(opt =>
                opt.UseSqlServer("Server=localhost;Database=BradescoApiDbContext;User Id=SA;Password=M#str@d0;Trusted_Connection=False;TrustServerCertificate=true",
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
    })
    .Build();

host.Run();
