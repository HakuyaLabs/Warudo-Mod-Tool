using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public interface IQuickCalibratable
    {
        string TrackerName { get; }

        void QuickCalibrate();
    }
}