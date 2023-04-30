using Classlib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace Tests;

public class ClientTests
{
    private readonly IHost _host;
    private readonly ITestOutputHelper _outputhelper;

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
            }).Build();
        _outputhelper = outputhelper;
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
        _outputhelper.WriteLine(vehicles);
    }
}