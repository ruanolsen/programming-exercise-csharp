using ProgrammingTest.Interfaces;
using ProgrammingTest.Models;
using ProgrammingTest.Exceptions;

namespace ProgrammingTest.Services;

public class EndpointService : IEndpointService
{
    private readonly List<Endpoint> _endpoints;

    public EndpointService()
    {
        _endpoints = new List<Endpoint>();
    }

    public void AddEndpoint(Endpoint endpoint)
    {
        if (_endpoints.Any(e => e.EndpointSerialNumber == endpoint.EndpointSerialNumber))
        {
            throw new EndpointAlreadyExistsException();
        }

        _endpoints.Add(endpoint);
        
        Console.WriteLine(_endpoints);
    }

    public void EditEndpoint(string endpointSerialNumber, Endpoint updatedEndpoint)
    {
        var endpoint = FindEndpointBySerialNumber(endpointSerialNumber);
        endpoint.SwitchState = updatedEndpoint.SwitchState;
    }

    public void DeleteEndpoint(string serialNumber)
    {
        var endpoint = FindEndpointBySerialNumber(serialNumber);
        _endpoints.Remove(endpoint);
    }

    public Endpoint FindEndpointBySerialNumber(string serialNumber)
    {
        var endpoint = _endpoints.FirstOrDefault(e => e.EndpointSerialNumber == serialNumber);
        if (endpoint == null)
        {
            throw new EndpointNotFoundException();
        }

        return endpoint;
    }

    public List<Endpoint> ListAllEndpoints()
    {
        Console.WriteLine(_endpoints);
        return _endpoints.OrderBy(e => e.EndpointSerialNumber).ToList();
    }
}