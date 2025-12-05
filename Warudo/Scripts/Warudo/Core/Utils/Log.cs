using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Warudo.Core.Utils {
    public static class Log {
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UserError(Exception e) {
            if (IsUnknownAssembly(Assembly.GetCallingAssembly())) {
                Debug.LogError(e);
            } else {
                Debug.LogException(new UserException(e));
            }
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UserError(string message) {
            if (IsUnknownAssembly(Assembly.GetCallingAssembly())) {
                Debug.LogError(message);
            } else {
                Debug.LogException(new UserException(message));
            }
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UserError(string message, Exception e) {
            if (IsUnknownAssembly(Assembly.GetCallingAssembly())) {
                Debug.LogError(message);
                Debug.LogError(e.ToString());
            } else {
                Debug.LogException(new UserException(message, e));
            }
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(Exception e) {
            if (IsUnknownAssembly(Assembly.GetCallingAssembly())) {
                Debug.LogError(e);
            } else {
                Debug.LogException(e);
            }
        }
        
        public static void Error(string message) {
            Debug.LogError(message);
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(string message, Exception e) {
            if (IsUnknownAssembly(Assembly.GetCallingAssembly())) {
                Debug.LogError(message);
                Debug.LogError(e);
            } else {
                Debug.LogException(new Exception(message, e));
            }
        }

        // Debug.LogException on UMod assemblies will cause the game to crash.
        private static bool IsUnknownAssembly(Assembly assembly) {
            if (Application.isEditor) return true;
            
            Debug.Log(assembly.GetName().Name);
            return Guid.TryParse(assembly.GetName().Name, out _);
        }
    }
}
