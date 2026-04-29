using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public static class Warning
    {
        public static bool logged;
        public delegate void Logger(string message);
        public static void Log(string message, Logger logger, bool logInEditMode = false)
        {
            throw new NotImplementedException();
        }

        public static void Log(string message, Transform context, bool logInEditMode = false)
        {
            throw new NotImplementedException();
        }
    }
}