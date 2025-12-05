using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class TQ
    {
        public TQ()
        {
            throw new NotImplementedException();
        }

        public TQ(Vector3 translation, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public Vector3 t;
        public Quaternion q;
    }

    public class AvatarUtility
    {
        public static Quaternion GetPostRotation(Avatar avatar, AvatarIKGoal avatarIKGoal)
        {
            throw new NotImplementedException();
        }

        public static TQ GetIKGoalTQ(Avatar avatar, float humanScale, AvatarIKGoal avatarIKGoal, TQ bodyPositionRotation, TQ boneTQ)
        {
            throw new NotImplementedException();
        }

        public static TQ WorldSpaceIKGoalToBone(TQ goalTQ, Avatar avatar, AvatarIKGoal avatarIKGoal)
        {
            throw new NotImplementedException();
        }

        public static TQ GetWorldSpaceIKGoal(BakerHumanoidQT ikQT, BakerHumanoidQT rootQT, float time, float humanScale)
        {
            throw new NotImplementedException();
        }

        public static HumanBodyBones HumanIDFromAvatarIKGoal(AvatarIKGoal avatarIKGoal)
        {
            throw new NotImplementedException();
        }
    }
}