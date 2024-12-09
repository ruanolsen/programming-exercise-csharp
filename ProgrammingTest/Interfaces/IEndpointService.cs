using ProgrammingTest.Models;

namespace ProgrammingTest.Interfaces;

public interface IEndpointService
{
    void AddEndpoint(Endpoint endpoint);
    void EditEndpoint(Endpoint endpoint, int switchState);
    void DeleteEndpoint(Endpoint endpoint);
    Endpoint FindEndpointBySerialNumber(string endpointSerialNumber);
    List<Endpoint> ListAllEndpoints();
}