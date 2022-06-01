using System;
using System.IO;
using System.Threading.Tasks;
using FunctionApp.Domain.GetMeasurements;
using FunctionApp.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.Application;

public class GetMeasurementsFunction
{
    
    private readonly IOpenAQClient _openAqClient;

    public GetMeasurementsFunction(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }

    [FunctionName("GetMeasurementsFunction")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function GetMeasurementsFunction processed a request.");

        string city = req.Query["city"];
        
        var measurements = await new GetMeasurementsQuery(_openAqClient, city).RunAsync();

        return city != null
            ? (ActionResult) new OkObjectResult(measurements)
            : new BadRequestObjectResult("Please pass a city name on the query string");
        
    }
}