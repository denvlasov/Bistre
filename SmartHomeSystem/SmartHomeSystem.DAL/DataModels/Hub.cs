using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartHomeSystem.DAL.DataModels
{
    public class Hub
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Devices")]
        public IEnumerable<Device> Devices { get; set; } 
    }
}
