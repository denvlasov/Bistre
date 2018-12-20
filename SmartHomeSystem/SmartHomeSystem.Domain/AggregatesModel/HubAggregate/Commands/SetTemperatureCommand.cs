using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class SetTemperatureCommand : ICommand
    {
        private IClimateControlDevice _climateControlDevice;
        private readonly int _temperature;

        public SetTemperatureCommand(IClimateControlDevice device, int temperature)
        {
            _climateControlDevice = device;
            _temperature = temperature;
        }

        public void Execute()
        {
            _climateControlDevice.SetTemperature(_temperature);
        }
    }
}
