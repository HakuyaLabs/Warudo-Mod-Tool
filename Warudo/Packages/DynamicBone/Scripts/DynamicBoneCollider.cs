using UnityEngine;
using System;
using Object = UnityEngine.Object;

public class DynamicBoneCollider : DynamicBoneColliderBase
{
    public float m_Radius = 0.5f;
    public float m_Height = 0;
    public float m_Radius2 = 0;
    float m_ScaledRadius;
    float m_ScaledRadius2;
    Vector3 m_C0;
    Vector3 m_C1;
    float m_C01Distance;
    int m_CollideType;
    void OnValidate()
    {
        throw new NotImplementedException();
    }

    public override void Prepare()
    {
        throw new NotImplementedException();
    }

    public override bool Collide(ref Vector3 particlePosition, float particleRadius)
    {
        throw new NotImplementedException();
    }

    static bool OutsideSphere(ref Vector3 particlePosition, float particleRadius, Vector3 sphereCenter, float sphereRadius)
    {
        throw new NotImplementedException();
    }

    static bool InsideSphere(ref Vector3 particlePosition, float particleRadius, Vector3 sphereCenter, float sphereRadius)
    {
        throw new NotImplementedException();
    }

    static bool OutsideCapsule(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius, float dirlen)
    {
        throw new NotImplementedException();
    }

    static bool InsideCapsule(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius, float dirlen)
    {
        throw new NotImplementedException();
    }

    static bool OutsideCapsule2(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius0, float capsuleRadius1, float dirlen)
    {
        throw new NotImplementedException();
    }

    static bool InsideCapsule2(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius0, float capsuleRadius1, float dirlen)
    {
        throw new NotImplementedException();
    }

    void OnDrawGizmosSelected()
    {
        throw new NotImplementedException();
    }

    static void DrawCapsule(Vector3 c0, Vector3 c1, float radius0, float radius1)
    {
        throw new NotImplementedException();
    }
}