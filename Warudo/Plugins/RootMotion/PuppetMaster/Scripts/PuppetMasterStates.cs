using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class PuppetMaster : MonoBehaviour
    {
        public enum State
        {
            Alive,
            Dead,
            Frozen
        }

        public struct StateSettings
        {
            public float killDuration;
            public float deadMuscleWeight;
            public float deadMuscleDamper;
            public float maxFreezeSqrVelocity;
            public bool freezePermanently;
            public bool enableAngularLimitsOnKill;
            public bool enableInternalCollisionsOnKill;
            public StateSettings(float killDuration, float deadMuscleWeight = 0.01f, float deadMuscleDamper = 2f, float maxFreezeSqrVelocity = 0.02f, bool freezePermanently = false, bool enableAngularLimitsOnKill = true, bool enableInternalCollisionsOnKill = true)
            {
                throw new NotImplementedException();
            }

            public static StateSettings Default
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        public bool isSwitchingState
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool isKilling { get; private set; }

        public bool isAlive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool isFrozen
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Kill()
        {
            throw new NotImplementedException();
        }

        public void Kill(StateSettings stateSettings)
        {
            throw new NotImplementedException();
        }

        public void Freeze()
        {
            throw new NotImplementedException();
        }

        public void Freeze(StateSettings stateSettings)
        {
            throw new NotImplementedException();
        }

        public void Resurrect()
        {
            throw new NotImplementedException();
        }

        public UpdateDelegate OnFreeze;
        public UpdateDelegate OnUnfreeze;
        public UpdateDelegate OnDeath;
        public UpdateDelegate OnResurrection;
        protected virtual void SwitchStates()
        {
            throw new NotImplementedException();
        }
    }
}