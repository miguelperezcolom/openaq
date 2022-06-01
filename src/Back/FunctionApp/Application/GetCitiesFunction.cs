using System.Threading.Tasks;
using FunctionApp.Domain.GetCities;
using FunctionApp.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Application;

public class GetCitiesFunction
{
    
    private readonly IOpenAQClient _openAqClient;

    public GetCitiesFunction(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }

    [FunctionName("GetCitiesFunction")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function GetCitiesFunction processed a request.");

        var cities = new GetCitiesQuery(_openAqClient).RunAsync();

        return new OkObjectResult(cities);
        
    }
}