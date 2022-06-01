using System.Collections.Generic;
using FunctionApp.Domain.Shared;

namespace FunctionApp.Infrastructure;

public class OpenAQClient : IOpenAQClient
{
    public List<City> GetCities()
    {
        
        return new List<City>()
        {
            new City()
            {
                Id = "Palma",
                Name = "Palma de Mallorca"
            },
            new City()
            {
                Id = "Madrid",
                Name = "Madrid"
            }
        };
        
    }

    public List<Measurement> GetMeasurements(string city)
    {
        return new List<Measurement>()
        {
            new Measurement()
            {
                Id = "1",
                Position = "Centro",
                Name = "co2",
                Value = "0.223"
            },
            new Measurement()
            {
                Id = "2",
                Position = "Afueras",
                Name = "co2",
                Value = "0.002"
            },
        };    
    }
}