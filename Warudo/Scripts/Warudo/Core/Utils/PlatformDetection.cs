using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Warudo.Core.Utils
{
    public class PlatformDetection
    {
        public static PlatformDetection Instance { get; } = new PlatformDetection();

        public bool IsProtonOrWine { get; private set; }
        public bool IsSkipProtonOrWineDetection { get; private set; }

        private PlatformDetection()
        {
            IsSkipProtonOrWineDetection = Environment.GetEnvironmentVariable("WARUDO_SKIP_PROTON_WINE_DETECTION") != null;
            if (IsSkipProtonOrWineDetection)
            {
                IsProtonOrWine = false;
            }
            else
            {
                IsProtonOrWine = Environment.GetEnvironmentVariable("WINEPREFIX") != null;
            }
        }

        public void PrintDetection()
        {
            Debug.Log(
                $"Platform Detection: \n" +
                $"  IsProtonOrWine: {IsProtonOrWine}" +
                $"{(IsSkipProtonOrWineDetection ? " (Skipped Detection)" : "")}"
            );
        }
    }

}
