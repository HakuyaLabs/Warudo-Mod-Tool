using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class PuppetMasterSettings : Singleton<PuppetMasterSettings>
    {
        public class PuppetUpdateLimit
        {
            public int puppetsPerFrame;
            public PuppetUpdateLimit()
            {
                throw new NotImplementedException();
            }

            public void Step(int puppetCount)
            {
                throw new NotImplementedException();
            }

            public bool Update(List<PuppetMaster> puppets, PuppetMaster puppetMaster)
            {
                throw new NotImplementedException();
            }
        }

        public PuppetUpdateLimit kinematicCollidersUpdateLimit = new PuppetUpdateLimit();
        public PuppetUpdateLimit freeUpdateLimit = new PuppetUpdateLimit();
        public PuppetUpdateLimit fixedUpdateLimit = new PuppetUpdateLimit();
        public bool collisionStayMessages = true;
        public bool collisionExitMessages = true;
        public float activePuppetCollisionThresholdMlp = 0f;
        public int currentlyActivePuppets { get; private set; }

        public int currentlyKinematicPuppets { get; private set; }

        public int currentlyDisabledPuppets { get; private set; }

        public List<PuppetMaster> puppets
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Register(PuppetMaster puppetMaster)
        {
            throw new NotImplementedException();
        }

        public void Unregister(PuppetMaster puppetMaster)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMoveToTarget(PuppetMaster puppetMaster)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFree(PuppetMaster puppetMaster)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFixed(PuppetMaster puppetMaster)
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void FixedUpdate()
        {
            throw new NotImplementedException();
        }
    }
}