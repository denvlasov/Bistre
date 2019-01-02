using SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands;
using SmartHomeSystem.Domain.DomainBase;
using System;
using System.Collections.Generic;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public abstract class BaseDevice : EntityBase, IBaseDevice
    {
        public bool IsTurnedOn { get; set; }
        public string DeviceCode { get; }
        public string Name { get; private set; }

        public BaseDevice(int deviceId, string deviceCode, string name)
        {
            Id = deviceId;
            DeviceCode = deviceCode;
            SetName(name);
        }

        public void Reboot()
        {
            Reset();
            IsTurnedOn = true;
        }

        public void Register(Hub hub)
        {
            if (hub == null)
            {
                throw new ArgumentNullException(nameof(hub), "Hub is required");
            }
            hub.AddDevice(this);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Device Name is required");
            }
            Name = name;
        }

        public IEnumerable<string> GetCommands()
        {
            return GetDeviceCommands();
        }

        public string GetState()
        {
            return GetDeviceInfo();
        }

        protected virtual void Reset()
        {
            IsTurnedOn = false;
        }

        protected virtual string GetDeviceInfo()
        {
            return $"Device Code: {DeviceCode}; Name: {Name}; Is Turned ON: {IsTurnedOn}";
        }

        protected virtual List<string> GetDeviceCommands()
        {
            return new List<string>()
            {
                CommandNameConstants.GetDeviceState,
                CommandNameConstants.RebootDevice,
                CommandNameConstants.RegisterDevice,
                CommandNameConstants.SetDeviceName
            };
        }
    }
}
