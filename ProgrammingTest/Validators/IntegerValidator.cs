namespace ProgrammingTest.Validators;

public static class IntegerValidator
{
    public static int ValidateInteger(string input, int minValue = 0)
    {
        if (!int.TryParse(input, out var value))
        {
            throw new ArgumentException("Invalid input. The field must an integer.");
        }
        
        // I'm assuming that the numbers cannot be negative
        if (value < minValue)
        {
            throw new ArgumentException($"Invalid input. The field must be an integer higher than 0.");
        }

        return value;
    }
}