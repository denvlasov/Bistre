﻿using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;
using SmartHomeSystem.Domain.AggregatesModel.HubAggregate.Commands;
using SmartHomeSystem.DAL.DataModels;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hub = SmartHomeSystem.DAL.DataModels.Hub;

namespace SmartHomeSystem.WebAPI.Controllers
{
    public class HubController : ApiController
    {
        [HttpGet]
        [Route("hubs/")]
        [SwaggerOperation("GetAllHubs")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<IEnumerable<Hub>> GetAllHubs()
        {
            return await DocumentDBRepository<Hub>.GetItemsAsync(null);
        }

        [HttpGet]
        [Route("hubs/{hubId}")]
        [SwaggerOperation("GetHubById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<Hub> GetHub(int hubId)
        {
            return await DocumentDBRepository<Hub>.GetItemAsync(hubId.ToString());
        }

        [HttpGet]
        [Route("hubs/{hubId}/devices/")]
        [SwaggerOperation("GetAllDevices")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<IBaseDevice> GetHubDevices(int hubId)
        {
            //Retrieve hub from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            return hub.Devices;
        }

        [HttpPut]
        [Route("hubs/{hubId}/devices/{deviceId}/Registration")]
        [SwaggerOperation("RegisterDevice")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void RegisterDeviceToHub(int hubId, int deviceId)
        {
            //Retrieve hub and device from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            // Get Device: var devices = 
            hub.AddDevice(device);
        }

        [HttpGet]
        [Route("hubs/{hubId}/devices/{deviceId}/State")]
        [SwaggerOperation("GetDeviceState")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public string GetDeviceState(int hubId, int deviceId)
        {
            return RetrieveDeviceState(hubId, deviceId);
        }

        [HttpGet]
        [Route("hubs/{hubId}/devices/{deviceId}/Commands")]
        [SwaggerOperation("GetDeviceCommands")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
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
        [SwaggerOperation("ExecuteCommand")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.MethodNotAllowed)]
        public HttpResponseMessage ExecuteCommand(int hubId, int deviceId, string name, [FromBody]object args)
        {
            //var device = new object(); //
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            var device = hub.Devices.Where(d => d.Id == deviceId).First();
            if (!device.GetCommands().Contains(name.ToUpper()))
            {
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            }
            
            switch (name)
            {
                case CommandNameConstants.GetDeviceState:
                    return Request.CreateResponse(HttpStatusCode.OK, RetrieveDeviceState(hubId, deviceId));
                case CommandNameConstants.RebootDevice:
                    device.Reboot();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                case CommandNameConstants.RegisterDevice:
                    device.Register(hub);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                case CommandNameConstants.SetDeviceName:
                    device.SetName((string)args);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                case CommandNameConstants.SetAirHumidityPercent:
                    ((IHumidifierDevice)device).SetAirHumidityPercent((int)args);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                case CommandNameConstants.SetLightingIntensityPercent:
                    ((ILightingControlDevice)device).SetLightingIntensityPercent((int)args);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                case CommandNameConstants.SetTemperature:
                    ((IClimateControlDevice)device).SetTemperature((int)args);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                default:
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        private string RetrieveDeviceState(int hubId, int deviceId)
        {
            //Retrieve hub and device from DB
            var hubs = new List<Hub>() { new Hub("Hub1") };
            var hub = hubs.Where(h => h.Id == hubId).First();
            var device = hub.Devices.Where(d => d.Id == deviceId).First();
            return device.GetState();
        }
    }
}