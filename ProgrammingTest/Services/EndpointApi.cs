using ProgrammingTest.Interfaces;
using ProgrammingTest.Models;
using ProgrammingTest.Exceptions;
using System.Linq;

namespace ProgrammingTest.Services;

public class EndpointApi : IEndpointApi
{
    private readonly List<Endpoint> _endpoints;

    public EndpointApi()
    {
        _endpoints = new List<Endpoint>();
    }

    public void AddEndpoint(Endpoint endpoint)
    {
        if (_endpoints.Any(e => e.EndpointSerialNumber == endpoint.EndpointSerialNumber))
        {
            throw new InvalidInputException();
        }

        _endpoints.Add(endpoint);
    }

    public void EditEndpoint(string endpointSerialNumber, Endpoint updatedEndpoint)
    {
        var existingEndpoint = FindEndpointBySerialNumber(endpointSerialNumber);
        existingEndpoint.MeterModelId = updatedEndpoint.MeterModelId;
        existingEndpoint.MeterNumber = updatedEndpoint.MeterNumber;
        existingEndpoint.MeterFirmwareVersion = updatedEndpoint.MeterFirmwareVersion;
        existingEndpoint.SwitchState = updatedEndpoint.SwitchState;
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
            throw new EndpointNotFoundException($"Endpoint with serial number '{serialNumber}' not found.");
        }

        return endpoint;
    }

    public IEnumerable<Endpoint> ListAllEndpoints()
    {
        return _endpoints.OrderBy(e => e.EndpointSerialNumber);
    }
}