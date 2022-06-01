using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FunctionApp.Domain.Shared;

namespace FunctionApp.Infrastructure;

public class OpenAQClient : IOpenAQClient
{

    private readonly HttpClient _httpClient;

    public OpenAQClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<City>> GetCities()
    {

        var httpResponse = await _httpClient.GetAsync("https://api.openaq.org/v2/cities?limit=500&page=1&offset=0&sort=asc&country_id=ES&order_by=city");

        httpResponse.EnsureSuccessStatusCode();
        
        var response = await httpResponse.Content.ReadAsAsync<GetCitiesResponse>();
        
        return response.Results.Select(city => new City() {
            Id = city.City,
            Name = city.City
        }).ToList();
        
    }

    public async Task<List<Measurement>> GetMeasurements(string city)
    {
        
        var httpResponse = await _httpClient.GetAsync("https://api.openaq.org/v2/latest?limit=5000&page=1&offset=0&sort=desc&radius=1000&city="
                                                      + HttpUtility.UrlEncode(city) + "&order_by=lastUpdated&dumpRaw=false");
        
        httpResponse.EnsureSuccessStatusCode();
        
        var response = await httpResponse.Content.ReadAsAsync<GetMeasurementsResponse>();
        
        return response.Results.SelectMany(group => group.Measurements.Select(measurement => new Measurement() {
            Id = $"{group.Location}-{measurement.Parameter}",
            Position = group.Location,
            Name = measurement.Parameter,
            Value = measurement.Value,
            Unit = measurement.Unit
        })).ToList();
    }
}

public class GetCitiesResponse
{

    public OpenCity[] Results { get; set; }

}

public class OpenCity
{

    public string City { get; set; }

}

public class GetMeasurementsResponse
{

    public LocationGroup[] Results { get; set; }

}

public class LocationGroup
{

    public string Location { get; set; }
    
    public OpenMeasurement[] Measurements { get; set; }

}

public class OpenMeasurement
{

    public string Parameter { get; set; }

    public string Value { get; set; }
    
    public string Unit { get; set; }

}