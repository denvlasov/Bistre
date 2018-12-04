using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;

namespace SmartHomeSystem.Domain.Factories
{
    public class LightingControlDeviceFactory : IDeviceFactory
    {
        public IBaseDevice Create(int deviceId, string deviceCode, string name)
        {
            return new LightingControlDevice(deviceId, deviceCode, name);
        }
    }
}
