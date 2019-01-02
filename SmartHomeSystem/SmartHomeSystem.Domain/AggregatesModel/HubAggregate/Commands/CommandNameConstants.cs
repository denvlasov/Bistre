namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public static class CommandNameConstants
    {
        public const string GetDeviceState = "GETDEVICESTATE";
        public const string RebootDevice = "REBOOTDEVICE";
        public const string RegisterDevice = "REGISTERDEVICE";
        public const string SetDeviceName = "SETDEVICENAME";
        public const string SetAirHumidityPercent = "SETAIRHUMIDITYPERCENT";
        public const string SetLightingIntensityPercent = "SETLIGHTINGINTENCITYPERCENT";
        public const string SetTemperature = "SETTEMPERATURE";
    }
}
