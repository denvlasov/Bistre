using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class RegisterDeviceCommand : ICommand
    {
        private BaseDevice _device;
        private readonly Hub _hub;

        public RegisterDeviceCommand(BaseDevice device, Hub hub)
        {
            _device = device;
            _hub = hub;
        }
        public void Execute()
        {
            _device.Register(_hub);
        }
    }
}
