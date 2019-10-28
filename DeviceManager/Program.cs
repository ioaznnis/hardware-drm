using System;
using System.Management;
using System.Threading.Tasks;

namespace DeviceManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await UsbDeviceInsertWatcher(TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// Watcher for new usb Device
        /// </summary>
        /// <param name="delay">Time to register connected device</param>
        /// <returns></returns>
        private static async Task UsbDeviceInsertWatcher(TimeSpan delay)
        {
            // Create event query to be notified within 3 second of 
            // a new USB device inserted
            var query = new WqlEventQuery("__InstanceCreationEvent",
                TimeSpan.FromSeconds(3),
                "TargetInstance ISA 'Win32_USBHub'");

            // Initialize an event watcher and subscribe to events 
            // that match this query
            using (var insertWatcher = new ManagementEventWatcher(query))
            {
                insertWatcher.EventArrived += DeviceInsertedEvent;
                insertWatcher.Start();
                //Wait for connected device
                await Task.Delay(delay);
                insertWatcher.Stop();
            }
        }

        /// <summary>
        /// Отображение информации о подключенном device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            using (var managementBaseObject = (ManagementBaseObject) e.NewEvent["TargetInstance"])
            {
                foreach (var property in managementBaseObject.Properties)
                {
                    Console.WriteLine($"{property.Name} {property.Value}");
                }
            }

            Console.WriteLine();
        }
    }
}