using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.MotionCapture
{
    public abstract class GenericFullBodyTrackerAsset : GenericTrackerAsset
    {
        public override bool UseCharacterDaemon => throw new NotImplementedException();
        public override bool UseHeadIK => throw new NotImplementedException();
        public override bool UseCharacterDaemonBones => throw new NotImplementedException();
        public override bool CanCalibrate => throw new NotImplementedException();
        public override bool UseEyeInputs => throw new NotImplementedException();
        public override bool ProvideHeadTracking => throw new NotImplementedException();
    }
}