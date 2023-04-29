using Classlib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests;

public class ClientTests
{
    private readonly IHost _host;

    public ClientTests()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(srv => 
            {
                srv.AddSingleton<ApiService>();
            }).Build();
    } 
    [Fact]
    public void AssureCanCreateTheClassLibrary()
    {
        ApiService apiService = _host.Services.GetRequiredService<ApiService>();
    }
}