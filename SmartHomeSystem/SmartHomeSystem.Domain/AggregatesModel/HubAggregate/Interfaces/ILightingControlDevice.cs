namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public interface ILightingControlDevice : IBaseDevice
    {
        int LightingIntensityPercent { get; }
        void SetLightingIntensityPercent(int lightingIntensityPercent);
    }
}
