using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;

namespace SmartHomeSystem.Domain.Factories
{
    public class HumidifierDeviceFactory : IDeviceFactory
    {
        public IBaseDevice Create(int deviceId, string deviceCode, string name)
        {
            return new HumidifierDevice(deviceId, deviceCode, name);
        }
    }
}
