using ProgrammingTest.Validators;

namespace ProgrammingTest
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("*************************************************");
                Console.WriteLine("Hello, energy company user!");
                Console.WriteLine("*************************************************");
                Console.WriteLine("1) Insert a new endpoint");
                Console.WriteLine("2) Edit an existing endpoint");
                Console.WriteLine("3) Delete an existing endpoint");
                Console.WriteLine("4) List all endpoints");
                Console.WriteLine("5) Find an endpoint by 'Endpoint Serial Number'");
                Console.WriteLine("6) Exit");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Please, enter the desired option number:");
                
                var action = Console.ReadLine();
                try
                {
                    switch (action)
                    {
                        case "1":
                            Console.Write("Enter Endpoint Serial Number: ");
                            var endpointSerialNumber = StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);
                            Console.Write("Enter Meter Model ID: ");
                            var meterModelId = IntegerValidator.ValidateInteger(Console.ReadLine() ?? string.Empty);
                            Console.Write("Enter Meter Number: ");
                            var meterNumber = IntegerValidator.ValidateInteger(Console.ReadLine() ?? string.Empty);
                            Console.Write("Enter Meter Firmware Version: ");
                            var meterFirmwareVersion = StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);
                            Console.Write("Enter Switch State: ");
                            var switchState = IntegerValidator.ValidateInteger(Console.ReadLine() ?? string.Empty);
                            
                            break;
                        case "2":
                            Console.Write("Enter Endpoint Serial Number: ");
                            var editEndpointSerialNumber = StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);
                            break;
                        case "3":
                            Console.Write("Enter Endpoint Serial Number: ");
                            var deleteEndpointSerialNumber = StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);
                            break;
                        case "4":
                            break;
                        case "5":
                            Console.Write("Enter Endpoint Serial Number: ");
                            var findEndpointSerialNumber = StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);
                            break;
                        case "6":
                            Console.Write("Do you want to exit the app? (y/n): ");
                            if (Console.ReadLine()?.ToLower() == "y")
                            {
                                Console.WriteLine("Application terminated.");
                                return;
                            }

                            break;
                        default:
                            Console.WriteLine("Invalid action. Please, try again:");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}