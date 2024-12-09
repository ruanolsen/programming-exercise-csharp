using ProgrammingTest.Interfaces;
using ProgrammingTest.Models;

namespace ProgrammingTest.Controllers;

public class EndpointController: IEndpointController
{
    private readonly IEndpointService _service;

    public EndpointController(IEndpointService service)
    {
        _service = service;
    }
    
    
    public void AddEndpoint(Endpoint endpoint)
    {
        if (endpoint.EndpointSerialNumber == "NSX1P2W")
        {
            endpoint.MeterModelId = 16;
        }
        
        if (endpoint.EndpointSerialNumber == "NSX1P3W")
        {
            endpoint.MeterModelId = 17;
        }
        
        if (endpoint.EndpointSerialNumber == "NSX2P3W")
        {
            endpoint.MeterModelId = 18;
        }
        
        if (endpoint.EndpointSerialNumber == "NSX3P4W")
        {
            endpoint.MeterModelId = 19;
        }
        _service.AddEndpoint(endpoint);
    }
    
    public void EditEndpoint(string endpointSerialNumber)
    {
        var endpoint = _service.FindEndpointBySerialNumber(endpointSerialNumber);
    }
    
    public void DeleteEndpoint(string endpointSerialNumber)
    {
        _service.DeleteEndpoint(endpointSerialNumber);
    }
    
    public List<Endpoint> ListAllEndpoints()
    {
        return _service.ListAllEndpoints();
    }
    
    public Endpoint FindEndpointBySerialNumber(string endpointSerialNumber)
    {
        return _service.FindEndpointBySerialNumber(endpointSerialNumber);
    }
}