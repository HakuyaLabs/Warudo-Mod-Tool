using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class PropMuscle : MonoBehaviour
    {
        public PuppetMaster puppetMaster;
        public PuppetMasterProp currentProp;
        public Vector3 additionalPinOffset = Vector3.forward;
        public Muscle muscle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PuppetMasterProp activeProp { get; private set; }

        public delegate void PropDelegate(PuppetMasterProp prop);
        public PropDelegate OnPickUpProp;
        public PropDelegate OnDropProp;
        public bool AddAdditionalPin()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAdditionalPin()
        {
            throw new NotImplementedException();
        }

        public void OnInitiate()
        {
            throw new NotImplementedException();
        }

        public void TakeOver()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmosSelected()
        {
            throw new NotImplementedException();
        }
    }
}