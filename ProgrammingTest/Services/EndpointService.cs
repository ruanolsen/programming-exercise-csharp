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
    }

    public void EditEndpoint(Endpoint endpoint, int switchState)
    {
        endpoint.SwitchState = switchState;
    }

    public void DeleteEndpoint(Endpoint endpoint)
    {
        _endpoints.Remove(endpoint);
    }

    public Endpoint FindEndpointBySerialNumber(string endpointSerialNumber)
    {
        var endpoint = _endpoints.FirstOrDefault(e => e.EndpointSerialNumber == endpointSerialNumber);
        if (endpoint == null)
        {
            throw new EndpointNotFoundException();
        }

        return endpoint;
    }

    public List<Endpoint> ListAllEndpoints()
    {
        return _endpoints.OrderBy(e => e.EndpointSerialNumber).ToList();
    }
}