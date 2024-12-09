namespace ProgrammingTest.Exceptions;

internal sealed class EndpointAlreadyExistsException : BaseEndpointException
{
    internal EndpointAlreadyExistsException() : base("Endpoint already exists.")
    {
    }
}