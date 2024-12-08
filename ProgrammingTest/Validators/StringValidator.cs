namespace ProgrammingTest.Validators;

public static class StringValidator
{
    public static string ValidateString(string input, int minLength = 1)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length < minLength)
        {
            throw new ArgumentException($"Invalid input. The field must be a string and have at least one character.");
        }

        return input;
    }
}