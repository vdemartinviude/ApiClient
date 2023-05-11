using Classlib;
using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Requests;

[Route("api")]
public class VehicleController
{
    private readonly ApiService _apiService;

    public VehicleController(ApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetVehicleData([FromQuery] VehicleQuery request, CancellationToken token)
    {
        if(!_apiService.IsConnect) await _apiService.Authenticate();
        return await _apiService.GetListOfModels(request.Modelo,request.Complemento);
    }
}