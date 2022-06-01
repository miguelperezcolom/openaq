using FunctionApp.Domain.GetCities;
using FunctionApp.Domain.GetMeasurements;
using FunctionApp.Infrastructure;

namespace Tests;

public class ClientTest
{
    [Fact]
    public async Task getCities_run_cities()
    {
        //given
        var client = new OpenAQClient(new HttpClient());
        var query = new GetCitiesQuery(client);

        //when
        var cities = await query.RunAsync();

        //then
        Assert.True(cities.Count > 0);
    }
    
    [Fact]
    public async Task getMeasurements_run_measurements()
    {
        //given
        var client = new OpenAQClient(new HttpClient());
        var query = new GetMeasurementsQuery(client, "Madrid");

        //when
        var measurements = await query.RunAsync();

        //then
        Assert.True(measurements.Count > 0);
    }

}