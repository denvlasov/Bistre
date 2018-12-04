using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;

namespace SmartHomeSystem.Domain.Factories
{
    public interface IDeviceFactory
    {
        IBaseDevice Create(int deviceId, string deviceCode, string name);
    }
}
