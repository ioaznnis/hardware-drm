using System;
using System.Management;

namespace SampleDrmApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert key.");
            Console.WriteLine(@"Example: USB\\VID_***&PID_***\\***");

            var key = Console.ReadLine();

            using var searcher = new ManagementObjectSearcher($"Select * From Win32_USBHub where DeviceID='{key}'");
            using var deviceCollection = searcher.Get();
            Console.WriteLine(deviceCollection.Count == 0 ? "Wrong key!" : "Key accept!");

            // You DRM data here...

            Console.ReadLine();
        }
    }
}