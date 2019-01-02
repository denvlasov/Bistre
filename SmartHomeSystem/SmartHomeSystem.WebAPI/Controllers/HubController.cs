using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;
using SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHomeSystem.WebAPI.Controllers
{
    public class HubController : ApiController
    {
        //Return 405 (method not allowed), values and other controllers - not needed
        [HttpGet]
        [Route("hubs/")]
        public IEnumerable<Hub> GetAllHubs()
        {
            //Retrieve from DB
            return new List<Hub>() { new Hub("Hub1") };
        }

        [HttpGet]
        [Route("hubs/{hubId}")]
        public Hub GetHub(int hubId)
        {
            //Retrieve hub from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            return hubs.Where(h => h.Id == hubId).First();
        }

        [HttpGet]
        [Route("hubs/{hubId}/devices/")]
        public IEnumerable<IBaseDevice> GetHubDevices(int hubId)
        {
            //Retrieve hub from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            return hub.Devices;
        }

        [HttpPut]
        [Route("hubs/{hubId}/devices/{deviceId}/Registration")]
        public void RegisterDeviceToHub(int hubId, int deviceId)
        {
            //Retrieve hub and device from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            // Get Device: var devices = 
            hub.AddDevice(device);
        }
        /*
        [HttpPut]
        [Route("hubs/{hubId}/devices/{deviceId}")]
        */
        [HttpGet]
        [Route("hubs/{hubId}/devices/{deviceId}/State")]
        public string GetDeviceState(int hubId, int deviceId)
        {
            //Retrieve hub and device from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            var device = hub.Devices.Where(d => d.Id == deviceId).First();
            return device.GetState();
        }

        [HttpGet]
        [Route("hubs/{hubId}/devices/{deviceId}/Commands")]
        public IEnumerable<string> GetDeviceCommands(int hubId, int deviceId)
        {
            //Retrieve hub and device from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            var device = hub.Devices.Where(d => d.Id == deviceId).First();
            return device.GetCommands();
        }

        [HttpPost]
        [Route("hubs/{hubId}/devices/{deviceId}/Commands/{name}")]
        public HttpResponseMessage ExecuteCommand(int hubId, int deviceId, string name, [FromBody]object args)
        {
            //var device = new object(); //
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            var device = hub.Devices.Where(d => d.Id == deviceId).First();
            if !(device.GetCommands().Contains(name, IgnoreCase))
                { }
            switch (name)
            {
                case CommandNameConstants.GetDeviceState:
                    break;
                case CommandNameConstants.RebootDevice:
                    break;
                case CommandNameConstants.RegisterDevice:
                    break;
                case CommandNameConstants.SetAirHumidityPercent:
                    break;
                case CommandNameConstants.SetDeviceName:
                    break;
                case CommandNameConstants.SetLightingIntensityPercent:
                    break;
                case CommandNameConstants.SetTemperature:
                    break;
                default:
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

    }
}
