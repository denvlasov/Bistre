using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class GetDeviceStateCommand : ICommandWithResult<string>
    {
        private BaseDevice _device;
        public string Result { get; private set; }

        public GetDeviceStateCommand(BaseDevice device)
        {
            _device = device;
        }
        public void Execute()
        {
            Result = _device.GetState();
        }
    }
}
