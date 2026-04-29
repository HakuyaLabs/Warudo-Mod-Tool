using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Data;
using Warudo.Core.Utils;
using Debug = UnityEngine.Debug;
using Event = Warudo.Core.Events.Event;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class VideoDevicesInitializeEvent : Event
    {
        public List<Device> Devices { get; }

        public VideoDevicesInitializeEvent(List<Device> devices)
        {
            throw new NotImplementedException();
        }
    }

    public class VideoDeviceForceReleaseEvent : Event
    {
        public Device Device { get; }

        public VideoDeviceForceReleaseEvent(Device device)
        {
            throw new NotImplementedException();
        }
    }

    public static class VideoDevices
    {
        public const string InternalDeviceNamePrefix = "WarudoCam";
        public const int InternalDeviceCount = 4;
        public static string GetInternalDeviceNameByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public static bool TryParseInternalDeviceIndex(string name, out int index)
        {
            throw new NotImplementedException();
        }

        public static List<Device> Devices { get; }

        public static List<DeviceDuplicator> DeviceDuplicators { get; }

        public static bool Initialize()
        {
            throw new NotImplementedException();
        }

        public static async UniTask<AutoCompleteList> AutoCompleteVideoDevices(bool includeInternal = false)
        {
            throw new NotImplementedException();
        }

        public static string GetDefaultDeviceName()
        {
            throw new NotImplementedException();
        }

        public static Device UseDevice(string deviceName)
        {
            throw new NotImplementedException();
        }

        public static Device UseInternalDevice(int preferredIndex = -1)
        {
            throw new NotImplementedException();
        }

        public static void ReleaseDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public static void ReleaseDeviceByInternalIndex(int internalDeviceIndex)
        {
            throw new NotImplementedException();
        }

        public static void ReleaseAll()
        {
            throw new NotImplementedException();
        }
    }

    public class Device : IEquatable<Device>
    {
        public int Id { get; }

        public string Name { get; }

        public int InternalIndex { get; }

        public bool IsInternal => throw new NotImplementedException();
        public bool IsInUse { get; set; }

        public Device(int id, string name, int internalIndex)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Device other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Device left, Device right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Device left, Device right)
        {
            throw new NotImplementedException();
        }
    }

    public class DeviceDuplicator
    {
        public Device FromDevice;
        public List<Device> ToDevices { get; }

        public DeviceDuplicator(Device device)
        {
            throw new NotImplementedException();
        }

        public void StartDuplicateTo(Device internalDevice)
        {
            throw new NotImplementedException();
        }

        public void StopDuplicateTo(Device internalDevice)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicatingTo(Device internalDevice)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}