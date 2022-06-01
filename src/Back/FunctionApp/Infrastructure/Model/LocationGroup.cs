namespace FunctionApp.Infrastructure.Model;

public class LocationGroup
{

    public string Location { get; set; }
    
    public OpenMeasurement[] Measurements { get; set; }

}