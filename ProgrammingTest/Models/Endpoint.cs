namespace ProgrammingTest.Models;

public class Endpoint
{
    public required string EndpointSerialNumber { get; set; }
    public required int MeterModelId { get; set; }
    public required int MeterNumber { get; set; }
    public required string MeterFirmwareVersion { get; set; }
    public required int SwitchState { get; set; }

    // Overriding ToString() method, so I can return the data in a 'prettier' way
    public override string ToString()
    {
        return
            $"Endpoint Serial Number: {EndpointSerialNumber}, Model Id: {MeterModelId}, Meter Number: {MeterNumber}, Firmware Version: {MeterFirmwareVersion}, Switch State: {SwitchState}";
    }
}