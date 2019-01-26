using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace SmartHomeSystem.DAL.DataModels
{
    public class Device
    {
        int Id { get; set; }

        bool IsTurnedOn { get; set; }

        string DeviceCode { get; set; }

        string Name { get; set; }
    }
}
