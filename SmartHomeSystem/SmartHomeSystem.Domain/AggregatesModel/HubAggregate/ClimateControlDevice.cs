using System;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public class ClimateControlDevice : BaseDevice, IClimateControlDevice
    {
        private const int MaxTemperature = 40;
        private const int MinTemperature = 0;
        private const int DefaultTemperature = 20;

        public int Temperature { get; private set; }

        public ClimateControlDevice(int deviceId, string deviceCode, string name) : base(deviceId, deviceCode, name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(int temperature)
        {
            if (temperature < MinTemperature || temperature > MaxTemperature)
            {
                throw new ArgumentException($"Temperature can not be below {MinTemperature}C or over {MaxTemperature}C");
            }
            Temperature = temperature;
        }

        protected override void Reset()
        {
            base.Reset();
            Temperature = DefaultTemperature;
        }

        protected override string GetDeviceInfo()
        {
            return base.GetDeviceInfo() + $"; Temperature: {Temperature}C";
        }
    }
}
