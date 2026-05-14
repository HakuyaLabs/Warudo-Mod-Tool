using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public static class VRIKCalibrator
    {
        public class Settings
        {
            public float scaleMlp = 1f;
            public Vector3 headTrackerForward = Vector3.forward;
            public Vector3 headTrackerUp = Vector3.up;
            public Vector3 handTrackerForward = Vector3.forward;
            public Vector3 handTrackerUp = Vector3.up;
            public Vector3 footTrackerForward = Vector3.forward;
            public Vector3 footTrackerUp = Vector3.up;
            public Vector3 headOffset;
            public Vector3 handOffset;
            public float footForwardOffset;
            public float footInwardOffset;
            public float footHeadingOffset;
            public float pelvisPositionWeight = 1f;
            public float pelvisRotationWeight = 1f;
        }

        public static void RecalibrateScale(VRIK ik, CalibrationData data, Settings settings)
        {
            throw new NotImplementedException();
        }

        public static void RecalibrateScale(VRIK ik, CalibrationData data, float scaleMlp)
        {
            throw new NotImplementedException();
        }

        public static CalibrationData Calibrate(VRIK ik, Settings settings, Transform headTracker, Transform bodyTracker = null, Transform leftHandTracker = null, Transform rightHandTracker = null, Transform leftFootTracker = null, Transform rightFootTracker = null)
        {
            throw new NotImplementedException();
        }

        public class CalibrationData
        {
            public class Target
            {
                public bool used;
                public Vector3 localPosition;
                public Quaternion localRotation;
                public Target(Transform t)
                {
                    throw new NotImplementedException();
                }

                public void SetTo(Transform t)
                {
                    throw new NotImplementedException();
                }
            }

            public float scale;
            public Target head, leftHand, rightHand, pelvis, leftFoot, rightFoot, leftLegGoal, rightLegGoal;
            public Vector3 pelvisTargetRight;
            public float pelvisPositionWeight;
            public float pelvisRotationWeight;
        }

        public static void Calibrate(VRIK ik, CalibrationData data, Transform headTracker, Transform bodyTracker = null, Transform leftHandTracker = null, Transform rightHandTracker = null, Transform leftFootTracker = null, Transform rightFootTracker = null)
        {
            throw new NotImplementedException();
        }

        public static CalibrationData Calibrate(VRIK ik, Transform centerEyeAnchor, Transform leftHandAnchor, Transform rightHandAnchor, Vector3 centerEyePositionOffset, Vector3 centerEyeRotationOffset, Vector3 handPositionOffset, Vector3 handRotationOffset, float scaleMlp = 1f)
        {
            throw new NotImplementedException();
        }

        public static void CalibrateHead(VRIK ik, Transform centerEyeAnchor, Vector3 anchorPositionOffset, Vector3 anchorRotationOffset)
        {
            throw new NotImplementedException();
        }

        public static void CalibrateBody(VRIK ik, Transform pelvisTracker, Vector3 trackerPositionOffset, Vector3 trackerRotationOffset)
        {
            throw new NotImplementedException();
        }

        public static void CalibrateHands(VRIK ik, Transform leftHandAnchor, Transform rightHandAnchor, Vector3 anchorPositionOffset, Vector3 anchorRotationOffset)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GuessWristToPalmAxis(Transform hand, Transform forearm)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GuessPalmToThumbAxis(Transform hand, Transform forearm)
        {
            throw new NotImplementedException();
        }
    }
}