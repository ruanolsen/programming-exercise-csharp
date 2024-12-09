using ProgrammingTest.Interfaces;
using ProgrammingTest.Models;
using ProgrammingTest.Validators;

namespace ProgrammingTest.Controllers;

public class EndpointController : IEndpointController
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
        Console.WriteLine($"***********   ENDPOINT ADDED   ***********");
        Console.WriteLine(endpoint.ToString());
        Console.WriteLine($"*******************************************");
    }

    public void EditEndpoint(string endpointSerialNumber)
    {
        var endpoint = _service.FindEndpointBySerialNumber(endpointSerialNumber);
        Console.WriteLine("Enter Switch State: ");
        var switchState = SwitchStateValidator.ValidateSwitchState(Console.ReadLine() ?? string.Empty);
        _service.EditEndpoint(endpoint, switchState);
        Console.WriteLine($"***********   ENDPOINT EDITED   ***********");
    }

    public void DeleteEndpoint(string endpointSerialNumber)
    {
        var endpoint = _service.FindEndpointBySerialNumber(endpointSerialNumber);
        Console.WriteLine($"Do you want to delete endpoint {endpointSerialNumber}? (y/n)");
        if (Console.ReadLine()?.ToLower() == "y")
        {
            _service.DeleteEndpoint(endpoint);
            Console.WriteLine($"**********   ENDPOINT DELETED   ***********");
        }
    }

    public List<Endpoint> ListAllEndpoints()
    {
        var endpoints = _service.ListAllEndpoints();
        if (endpoints.Count == 0)
        {
            Console.WriteLine($"*******   NO ENDPOINTS REGISTERED   *******");
            return new List<Endpoint>();
        }

        Console.WriteLine($"************   ALL ENDPOINTS   ************");
        foreach (var endpoint in endpoints)
        {
            Console.WriteLine(endpoint.ToString());
        }

        Console.WriteLine($"*******************************************");

        return endpoints;
    }

    public Endpoint FindEndpointBySerialNumber(string endpointSerialNumber)
    {
        var endpoint = _service.FindEndpointBySerialNumber(endpointSerialNumber);
        Console.WriteLine($"***********   ENDPOINT FOUND   ************");
        Console.WriteLine(endpoint.ToString());
        Console.WriteLine($"*******************************************");
        return endpoint;
    }
}