using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class PuppetMaster : MonoBehaviour
    {
        public void SwitchToActiveMode()
        {
            throw new NotImplementedException();
        }

        public void SwitchToKinematicMode()
        {
            throw new NotImplementedException();
        }

        public void SwitchToDisabledMode()
        {
            throw new NotImplementedException();
        }

        public bool isSwitchingMode { get; private set; }

        public void DisableImmediately()
        {
            throw new NotImplementedException();
        }

        protected virtual void SwitchModes()
        {
            throw new NotImplementedException();
        }
    }
}