using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public static class BipedNaming
    {
        public enum BoneType
        {
            Unassigned,
            Spine,
            Head,
            Arm,
            Leg,
            Tail,
            Eye
        }

        public enum BoneSide
        {
            Center,
            Left,
            Right
        }

        public static string[] typeLeft = {" L ", "_L_", "-L-", " l ", "_l_", "-l-", "Left", "left", "CATRigL"}, typeRight = {" R ", "_R_", "-R-", " r ", "_r_", "-r-", "Right", "right", "CATRigR"}, typeSpine = {"Spine", "spine", "Pelvis", "pelvis", "Root", "root", "Torso", "torso", "Body", "body", "Hips", "hips", "Neck", "neck", "Chest", "chest"}, typeHead = {"Head", "head"}, typeArm = {"Arm", "arm", "Hand", "hand", "Wrist", "Wrist", "Elbow", "elbow", "Palm", "palm"}, typeLeg = {"Leg", "leg", "Thigh", "thigh", "Calf", "calf", "Femur", "femur", "Knee", "knee", "Foot", "foot", "Ankle", "ankle", "Hip", "hip"}, typeTail = {"Tail", "tail"}, typeEye = {"Eye", "eye"}, typeExclude = {"Nub", "Dummy", "dummy", "Tip", "IK", "Mesh"}, typeExcludeSpine = {"Head", "head"}, typeExcludeHead = {"Top", "End"}, typeExcludeArm = {"Collar", "collar", "Clavicle", "clavicle", "Finger", "finger", "Index", "index", "Mid", "mid", "Pinky", "pinky", "Ring", "Thumb", "thumb", "Adjust", "adjust", "Twist", "twist"}, typeExcludeLeg = {"Toe", "toe", "Platform", "Adjust", "adjust", "Twist", "twist"}, typeExcludeTail = {}, typeExcludeEye = {"Lid", "lid", "Brow", "brow", "Lash", "lash"}, pelvis = {"Pelvis", "pelvis", "Hip", "hip"}, hand = {"Hand", "hand", "Wrist", "wrist", "Palm", "palm"}, foot = {"Foot", "foot", "Ankle", "ankle"};
        public static Transform[] GetBonesOfType(BoneType boneType, Transform[] bones)
        {
            throw new NotImplementedException();
        }

        public static Transform[] GetBonesOfSide(BoneSide boneSide, Transform[] bones)
        {
            throw new NotImplementedException();
        }

        public static Transform[] GetBonesOfTypeAndSide(BoneType boneType, BoneSide boneSide, Transform[] bones)
        {
            throw new NotImplementedException();
        }

        public static Transform GetFirstBoneOfTypeAndSide(BoneType boneType, BoneSide boneSide, Transform[] bones)
        {
            throw new NotImplementedException();
        }

        public static Transform GetNamingMatch(Transform[] transforms, params string[][] namings)
        {
            throw new NotImplementedException();
        }

        public static BoneType GetBoneType(string boneName)
        {
            throw new NotImplementedException();
        }

        public static BoneSide GetBoneSide(string boneName)
        {
            throw new NotImplementedException();
        }

        public static Transform GetBone(Transform[] transforms, BoneType boneType, BoneSide boneSide = BoneSide.Center, params string[][] namings)
        {
            throw new NotImplementedException();
        }
    }
}