namespace ProgrammingTest.Exceptions;

public class EndpointNotFoundException : Exception
{
    public EndpointNotFoundException() : base("Endpoint not found.")
    {
    }
}