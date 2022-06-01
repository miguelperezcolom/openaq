using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionApp.Domain.Shared.Model;

namespace FunctionApp.Domain.Shared;

public interface IOpenAQClient
{

    public Task<List<City>> GetCities();
    
    public Task<List<Measurement>> GetMeasurements(string city);
    
}