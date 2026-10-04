using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class VirtualCamSender : MonoBehaviour
    {
        public enum EResizeMode
        {
            Disabled = 0,
            LinearResize = 1
        }

        public enum EMirrorMode
        {
            Disabled = 0,
            MirrorHorizontally = 1
        }

        public enum ECaptureSendResult
        {
            SUCCESS = 0,
            WARNING_FRAMESKIP = 1,
            WARNING_CAPTUREINACTIVE = 2,
            ERROR_UNSUPPORTEDGRAPHICSDEVICE = 100,
            ERROR_PARAMETER = 101,
            ERROR_TOOLARGERESOLUTION = 102,
            ERROR_TEXTUREFORMAT = 103,
            ERROR_READTEXTURE = 104,
            ERROR_INVALIDCAPTUREINSTANCEPTR = 200
        }

        public EResizeMode ResizeMode = EResizeMode.LinearResize;
        public int Timeout = 1000;
        public EMirrorMode MirrorMode = EMirrorMode.Disabled;
        public bool DoubleBuffering = false;
        public bool HideWarnings = false;
        public Device Device { get; private set; }

        public Texture SourceTexture { get; set; }

        Interface CaptureInterface;
        public void CreateCaptureInterface(Device device)
        {
            throw new NotImplementedException();
        }

        public class Interface
        {
            extern static System.IntPtr CaptureCreateInstance(int CapNum);
            extern static void CaptureDeleteInstance(System.IntPtr instance);
            extern static ECaptureSendResult CaptureSendTexture(System.IntPtr instance, System.IntPtr nativetexture, int Timeout, bool UseDoubleBuffering, EResizeMode ResizeMode, EMirrorMode MirrorMode, bool IsLinearColorSpace);
            System.IntPtr CaptureInstance;
            public Interface(int CaptureDevice)
            {
                throw new NotImplementedException();
            }

            ~Interface()
            {
                throw new NotImplementedException();
            }

            public void Close()
            {
                throw new NotImplementedException();
            }

            public ECaptureSendResult SendTexture(Texture Source, int Timeout = 1000, bool DoubleBuffering = false, EResizeMode ResizeMode = EResizeMode.Disabled, EMirrorMode MirrorMode = EMirrorMode.Disabled)
            {
                throw new NotImplementedException();
            }
        }
    }
}