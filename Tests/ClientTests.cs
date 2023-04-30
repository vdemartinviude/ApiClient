using Classlib;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace Tests;

public class ClientTests
{
    private readonly IHost _host;
    private readonly ITestOutputHelper _outputhelper;

    private readonly BradescoApiDbContext _dbContext;

    public ClientTests(ITestOutputHelper outputhelper)
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                config.AddJsonFile("SettingsForTests.json");
            })
            .ConfigureServices(srv =>
            {
                srv.AddSingleton<ApiService>();
                srv.AddHttpClient();
                srv.AddDbContext<BradescoApiDbContext>(opt =>
                opt.UseSqlServer("Server=localhost;Database=BradescoApiDbContext;User Id=SA;Password=M#str@d0;Trusted_Connection=False;TrustServerCertificate=true"));
            }).Build();
        _outputhelper = outputhelper;
        _dbContext = _host.Services.GetRequiredService<BradescoApiDbContext>();

    }
    [Fact]
    public void AssureCanCreateTheClassLibrary()
    {
        ApiService apiService = _host.Services.GetRequiredService<ApiService>();
    }

    [Fact]
    public async void AssureCanGetAnAuthorizationCode()
    {
        ApiService apiService = _host.Services.GetRequiredService<ApiService>();
        var response = await apiService.Authenticate();
        _outputhelper.WriteLine(response);
        Assert.True(apiService.IsConnect);
    }

    [Fact]
    public async void AssureCanGetVehiclesList()
    {
        ApiService apiService = _host.Services.GetRequiredService<ApiService>();
        await apiService.Authenticate();
        var vehicles = await apiService.GetVehiclesList();
        Assert.InRange(vehicles.Count(),10000,20000);
    }

    [Fact]
    public async void AssureCanConnectOnDb()
    {
        Assert.True(await _dbContext.Database.CanConnectAsync());
    }

    [Fact]
    public async void AssureCanPopulateVehicleTables()
    {
        ApiService apiService = _host.Services.GetRequiredService<ApiService>();
        await apiService.Authenticate();
        await apiService.PopulateVehicleTable();
    }
}