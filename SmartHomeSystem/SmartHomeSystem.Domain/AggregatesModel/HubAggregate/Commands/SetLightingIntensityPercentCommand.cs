using SmartHomeSystem.Domain.DomainBase;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands
{
    public class SetLightingIntensityPercentCommand : ICommand
    {
        private ILightingControlDevice _lightingControlDevice;
        private readonly int _lightingIntensityPercent;

        public SetLightingIntensityPercentCommand(ILightingControlDevice device, int lightingIntensityPercent)
        {
            _lightingControlDevice = device;
            _lightingIntensityPercent = lightingIntensityPercent;
        }

        public void Execute()
        {
            _lightingControlDevice.SetLightingIntensityPercent(_lightingIntensityPercent);
        }
    }
}
