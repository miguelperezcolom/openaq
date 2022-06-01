using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionApp.Domain.Shared;

namespace FunctionApp.Domain.GetCities;

public class GetCitiesQuery
{
    
    private readonly IOpenAQClient _openAqClient;

    public GetCitiesQuery(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }

    public async Task<List<City>> RunAsync()
    {
        return await _openAqClient.GetCities();
    }
}