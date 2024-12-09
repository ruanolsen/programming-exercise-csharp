namespace ProgrammingTest.Validators;

internal static class StringValidator
{
    internal static string ValidateString(string input, int minLength = 1)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length < minLength)
        {
            throw new ArgumentException("Invalid input. The field must be a string and have at least one character.");
        }

        return input;
    }
}