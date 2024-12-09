using ProgrammingTest.Models;

namespace ProgrammingTest.Interfaces;

public interface IEndpointController
{
    void AddEndpoint(Endpoint endpoint);
    void EditEndpoint(string endpointSerialNumber);
    void DeleteEndpoint(string endpointSerialNumber);
    Endpoint FindEndpointBySerialNumber(string endpointSerialNumber);
    List<Endpoint> ListAllEndpoints();
}