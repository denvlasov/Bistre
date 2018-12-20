namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public interface IHumidifierDevice : IBaseDevice
    {
        int AirHumidityPercent { get; }
        void SetAirHumidityPercent(int humidityPercent);
    }
}
