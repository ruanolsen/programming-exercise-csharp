namespace ProgrammingTest.Exceptions;

public class EndpointAlreadyExistsException : Exception
{
    public EndpointAlreadyExistsException() : base("Endpoint already exists.")
    {
    }
}