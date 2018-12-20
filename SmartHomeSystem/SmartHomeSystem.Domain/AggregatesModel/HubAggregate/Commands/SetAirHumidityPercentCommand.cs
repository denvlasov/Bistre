using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class SetAirHumidityPercentCommand : ICommand
    {
        private IHumidifierDevice _humidifierDevice;
        private readonly int _airHumidityPercent;

        public SetAirHumidityPercentCommand(IHumidifierDevice device, int airHumidityPercent)
        {
            _humidifierDevice = device;
            _airHumidityPercent = airHumidityPercent;
        }

        public void Execute()
        {
            _humidifierDevice.SetAirHumidityPercent(_airHumidityPercent);
        }
    }
}
