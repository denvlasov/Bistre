namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public interface IBaseDevice
    {
        bool IsTurnedOn { get; set; }
        string DeviceCode { get; }
        string Name { get; }
        void Reboot();
        void Register(Hub hub);
        void SetName(string name);
    }
}
