using System.Collections.Generic;
using FunctionApp.Domain.Shared;

namespace FunctionApp.Domain.GetCities;

public class GetCitiesQuery
{
    
    private readonly IOpenAQClient _openAqClient;

    public GetCitiesQuery(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }

    public List<City> RunAsync()
    {
        return _openAqClient.GetCities();
    }
}