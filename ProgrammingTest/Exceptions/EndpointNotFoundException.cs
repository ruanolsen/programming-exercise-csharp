namespace ProgrammingTest.Exceptions;

internal sealed class EndpointNotFoundException : Exception
{
    internal EndpointNotFoundException() : base("Endpoint not found.")
    {
    }
}