using ProgrammingTest.Validators;
using ProgrammingTest.Services;
using ProgrammingTest.Controllers;
using ProgrammingTest.Models;

namespace ProgrammingTest.Presentation
{
    internal static class Program
    {
        private static void Main()
        {
            var service = new EndpointService();
            var controller = new EndpointController(service);


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
                            Console.WriteLine("Enter Endpoint Serial Number: ");
                            var endpointSerialNumber =
                                StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);

                            // From the description, I wasn't sure if I could allow different serial numbers from those of the list or if I needed to force the user to select the right Model ID, so I chose to provide the information and override the value in the controller, if needed 
                            Console.WriteLine(
                                "(note: Serial Numbers NSX1P2W, NSX1P3W, NSX2P3W, NSX3P4W have fixed Meter Model Ids. The value wil be overwritten!)");
                            Console.WriteLine("Enter Meter Model ID: ");
                            var meterModelId = IntegerValidator.ValidateInteger(Console.ReadLine() ?? string.Empty);

                            Console.WriteLine("Enter Meter Number: ");
                            var meterNumber = IntegerValidator.ValidateInteger(Console.ReadLine() ?? string.Empty);

                            Console.WriteLine("Enter Meter Firmware Version: ");
                            var meterFirmwareVersion =
                                StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);

                            Console.WriteLine("Enter Switch State: ");
                            var switchState = SwitchStateValidator.ValidateSwitchState(Console.ReadLine() ?? string.Empty);

                            var endpoint = new Endpoint
                            {
                                EndpointSerialNumber = endpointSerialNumber,
                                MeterModelId = meterModelId,
                                MeterNumber = meterNumber,
                                MeterFirmwareVersion = meterFirmwareVersion,
                                SwitchState = switchState
                            };

                            controller.AddEndpoint(endpoint);
                            break;
                        case "2":
                            Console.WriteLine("Enter Endpoint Serial Number: ");
                            var editEndpointSerialNumber =
                                StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);

                            controller.EditEndpoint(editEndpointSerialNumber);
                            break;
                        case "3":
                            Console.WriteLine("Enter Endpoint Serial Number: ");
                            var deleteEndpointSerialNumber =
                                StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);

                            controller.DeleteEndpoint(deleteEndpointSerialNumber);
                            break;
                        case "4":
                            controller.ListAllEndpoints();
                            break;
                        case "5":
                            Console.WriteLine("Enter Endpoint Serial Number: ");
                            var findEndpointSerialNumber =
                                StringValidator.ValidateString(Console.ReadLine() ?? string.Empty);

                            controller.FindEndpointBySerialNumber(findEndpointSerialNumber);
                            break;
                        case "6":
                            Console.WriteLine("Do you want to exit the app? (y/n): ");
                            if (Console.ReadLine()?.ToLower() == "y")
                            {
                                Console.WriteLine("Application terminated.");
                                return;
                            }

                            break;
                        default:
                            Console.WriteLine("Invalid action. Please, try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}