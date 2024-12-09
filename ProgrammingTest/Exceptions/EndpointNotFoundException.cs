namespace ProgrammingTest.Exceptions;

internal sealed class EndpointNotFoundException : BaseEndpointException
{
    internal EndpointNotFoundException() : base("Endpoint not found.")
    {
    }
}