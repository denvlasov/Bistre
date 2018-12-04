namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public interface IClimateControlDevice : IBaseDevice 
    {
        int Temperature { get; }
        void SetTemperature(int temperature);
    }
}
