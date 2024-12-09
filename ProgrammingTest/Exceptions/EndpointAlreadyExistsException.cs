namespace ProgrammingTest.Exceptions;

internal sealed class EndpointAlreadyExistsException : Exception
{
    internal EndpointAlreadyExistsException() : base("Endpoint already exists.")
    {
    }
}