using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class SetDeviceNameCommand : ICommand
    {
        private BaseDevice _device;
        private string _name;

        public SetDeviceNameCommand(BaseDevice device, string name)
        {
            _device = device;
            _name = name;
        }
        public void Execute()
        {
            _device.SetName(_name);
        }
    }
}
