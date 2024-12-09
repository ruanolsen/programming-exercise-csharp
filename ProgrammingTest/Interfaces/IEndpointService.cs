using ProgrammingTest.Models;

namespace ProgrammingTest.Interfaces;

public interface IEndpointService
{
    void AddEndpoint(Endpoint endpoint);
    void EditEndpoint(string endpointSerialNumber, Endpoint updatedEndpoint);
    void DeleteEndpoint(string endpointSerialNumber);
    Endpoint FindEndpointBySerialNumber(string endpointSerialNumber);
    List<Endpoint> ListAllEndpoints();
}