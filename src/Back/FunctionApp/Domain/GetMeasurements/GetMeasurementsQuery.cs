using System.Collections.Generic;
using FunctionApp.Domain.Shared;

namespace FunctionApp.Domain.GetMeasurements;

public class GetMeasurementsQuery
{

    private readonly string _city;
    private readonly IOpenAQClient _openAqClient;

    public GetMeasurementsQuery(IOpenAQClient openAqClient, string city)
    {
        _openAqClient = openAqClient;
        _city = city;
    }

    public List<Measurement> RunAsync()
    {
        return _openAqClient.GetMeasurements(_city);
    }
    
}