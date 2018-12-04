using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;
using SmartHomeSystem.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHomeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example of usage
            var lightingDeviceFactory = new LightingControlDeviceFactory();
            var humidifierDeviceFactory = new HumidifierDeviceFactory();
            var climateDeviceFactory = new ClimateControlDeviceFactory();

            var devices = new List<IBaseDevice>() {
                lightingDeviceFactory.Create(1, "111xIndustryCode", "Light Room"),
                lightingDeviceFactory.Create(2, "112xIndustryCode", "Light Kitchen"),
                lightingDeviceFactory.Create(3, "113xIndustryCode", "Light Bathroom"),
                humidifierDeviceFactory.Create(4, "211xIndustryCode", "Humidier Room"),
                humidifierDeviceFactory.Create(5, "212xIndustryCode", "Humidier Kitchen"),
                climateDeviceFactory.Create(6, "311xIndustryCode", "Climate Room"),
                climateDeviceFactory.Create(7, "312xIndustryCode", "Climate Kitchen")
            };

            var hub = new Hub("44 Ridge Ave Bloomfield, NJ 07002 USA");
            foreach (var device in devices)
            {
                hub.AddDevice(device); //Add device to hub. Other option:   device.Register(hub);
            }

            hub.Devices.Where(d => d is ILightingControlDevice).ToList().ForEach(d => d.IsTurnedOn = true); // turn on all light devices

            (devices.First() as ILightingControlDevice).SetLightingIntensityPercent(60); //Change light intencity for first Light

            devices.First().IsTurnedOn = false; //Turn of light1
            hub.Devices.First(d => d.DeviceCode == "111xIndustryCode").Reboot(); //Reboot device

            //Print current state of hub
            foreach (var device in hub.Devices)
            {
                var specificInfo = "";

                if (device is IClimateControlDevice) specificInfo = $"Temperature: {(device as IClimateControlDevice).Temperature}C";
                else if (device is IHumidifierDevice) specificInfo = $"Humidifier: {(device as IHumidifierDevice).AirHumidityPercent}%";
                else if (device is ILightingControlDevice) specificInfo = $"Lighting Intencity : {(device as ILightingControlDevice).LightingIntensityPercent}%";

                Console.WriteLine($"Device: {device.DeviceCode} {device.Name} - Is Turned on: {device.IsTurnedOn} - {specificInfo}");
            }
            Console.ReadKey();
        }
    }
}
