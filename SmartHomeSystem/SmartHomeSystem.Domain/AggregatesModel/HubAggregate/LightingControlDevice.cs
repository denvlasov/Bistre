using SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands;
using System;
using System.Collections.Generic;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public class LightingControlDevice : BaseDevice, ILightingControlDevice
    {
        private const int MaxLightingIntensityPercent = 100;
        private const int MinLightingIntensityPercent = 0;
        private const int DefaultLightingIntensityPercent = 100;

        public int LightingIntensityPercent { get; private set; }

        public LightingControlDevice(int deviceId, string deviceCode, string name) : base(deviceId, deviceCode, name)
        {
            LightingIntensityPercent = DefaultLightingIntensityPercent;
        }

        public void SetLightingIntensityPercent(int lightingIntensityPercent)
        {
            if (lightingIntensityPercent < 0 || lightingIntensityPercent > 100)
            {
                throw new ArgumentException(
                    $"Lightening Intensity can not be below {MinLightingIntensityPercent}% or over {MaxLightingIntensityPercent}%");
            }
            LightingIntensityPercent = lightingIntensityPercent;
        }

        protected override void Reset()
        {
            base.Reset();
            LightingIntensityPercent = DefaultLightingIntensityPercent;
        }

        protected override string GetDeviceInfo()
        {
            return base.GetDeviceInfo() + $"; Lighting Intensity: {LightingIntensityPercent}%";
        }

        protected override List<string> GetDeviceCommands()
        {
            var commands = base.GetDeviceCommands();
            commands.Add(CommandNameConstants.SetLightingIntensityPercent);
            return commands;
        }
    }
}
