using System.Text;
using System.Text.Json;
using Ticketing.Entities.Dtos.Requests;
using Ticketing.Entities.Dtos.Responses;
using Ticketing.Web.Services.Interfaces;

namespace Ticketing.App.Services;

public class DriverService : IDriverService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _serializerOptions;

    public DriverService(HttpClient http)
    {
        _http = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<GetDriverResponse>?> GetDrivers()
    {
        try
        {
            var apiResponse = await _http.GetStreamAsync("api/drivers");

            var drivers = await JsonSerializer.DeserializeAsync<List<GetDriverResponse>>(apiResponse, _serializerOptions);

            return drivers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<GetDriverResponse?> GetDriverById(Guid id)
    {
        try
        {
            var driver = await _http.GetFromJsonAsync<GetDriverResponse>($"api/driver/{id}");
            return driver;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<GetDriverResponse?> AddDriver(CreateDriverRequest driver)
    {
        try
        {
            var driverJson = new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/drivers", driverJson);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseBody = await response.Content.ReadAsStreamAsync();
            var newDriver = await JsonSerializer.DeserializeAsync<GetDriverResponse?>(responseBody, _serializerOptions);

            return newDriver;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateDriver(UpdateDriverRequest driver)
    {
        try
        {
            var driverJson = new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            var response = await _http.PutAsync("api/drivers", driverJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public async Task<bool> DeleteDriver(Guid id)
    {
        try
        {
            var response = await _http.DeleteAsync($"/api/drivers/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }
}
