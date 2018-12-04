using SmartHomeSystem.Domain.DomainBase;
using System;
using System.Collections.Generic;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    [AggregateRoot]
    public class Hub : EntityBase
    {
        //Assumption: Devices can not work without hub
        private List<IBaseDevice> _devices = new List<IBaseDevice>();
        public IReadOnlyCollection<IBaseDevice> Devices => _devices.AsReadOnly();
        public string Name { get; private set; }

        public Hub(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Hub Name is required");
            }
            Name = name;
        }

        public void AddDevice(IBaseDevice device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device), "Device is required");
            }
            if (_devices.Contains(device))
            {
                throw new ArgumentException("Hub already contains this Device");
            }
            _devices.Add(device);
        }

        public void RemoveDevice(IBaseDevice device)
        {
            _devices.Remove(device);
        }
    }
}
