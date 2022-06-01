using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionApp.Domain.Shared;

public interface IOpenAQClient
{

    public Task<List<City>> GetCities();
    
    public Task<List<Measurement>> GetMeasurements(string city);
    
}

public class Measurement
{
    
    public string Id { get; set; }

    public string Position { get; set; }

    public string Name { get; set; }
    
    public string Value { get; set; }
    
    public string Unit { get; set; }

}

public class City
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
}