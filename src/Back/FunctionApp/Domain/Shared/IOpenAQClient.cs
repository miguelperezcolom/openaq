using System.Collections.Generic;

namespace FunctionApp.Domain.Shared;

public interface IOpenAQClient
{

    public List<City> GetCities();
    
    public List<Measurement> GetMeasurements(string city);
    
}

public class Measurement
{
    
    public string Id { get; set; }

    public string Position { get; set; }

    public string Name { get; set; }
    
    public string Value { get; set; }
    
}

public class City
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
}