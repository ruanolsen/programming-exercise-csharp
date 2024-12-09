namespace ProgrammingTest.Validators;

internal static class SwitchStateValidator
{
    internal static int ValidateSwitchState(string input, int minValue = 0, int maxValue = 2)
    {
        if (!int.TryParse(input, out var value))
        {
            throw new ArgumentException("Invalid input. The field must an integer.");
        }
        
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentException("Invalid input. Switch State must be one of the following: 0 (Disconnected), 1 (Connected) or 2 (Armed).");
        }

        return value;
    }
}