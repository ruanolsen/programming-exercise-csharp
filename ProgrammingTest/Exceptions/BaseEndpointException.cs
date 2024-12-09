namespace ProgrammingTest.Exceptions;

internal class BaseEndpointException : Exception
{
    internal BaseEndpointException(string message) : base(message)
    {
    }
}