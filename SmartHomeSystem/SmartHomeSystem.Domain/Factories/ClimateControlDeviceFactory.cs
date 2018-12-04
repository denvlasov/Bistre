using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;

namespace SmartHomeSystem.Domain.Factories
{
    public class ClimateControlDeviceFactory : IDeviceFactory
    {
        public IBaseDevice Create(int deviceId, string deviceCode, string name)
        {
            return new ClimateControlDevice(deviceId, deviceCode, name);
        }
    }
}
