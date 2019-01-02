using SmartHomeSystem.Domain.DomainBase;
using System.Collections.Generic;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public interface IBaseDevice : IEntity
    {
        bool IsTurnedOn { get; set; }
        string DeviceCode { get; }
        string Name { get; }
        void Reboot();
        void Register(Hub hub);
        void SetName(string name);
        string GetState();
        IEnumerable<string> GetCommands();
    }
}
