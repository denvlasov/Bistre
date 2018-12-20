using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class RebootDeviceCommand : ICommand
    {
        private BaseDevice _device;

        public RebootDeviceCommand(BaseDevice device)
        {
            _device = device;
        }
        public void Execute()
        {
            _device.Reboot();
        }
    }
}
