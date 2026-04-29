using UnityEngine;
using System;
using Object = UnityEngine.Object;

public class DynamicBonePlaneCollider : DynamicBoneColliderBase
{
    Plane m_Plane;
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

    void OnDrawGizmosSelected()
    {
        throw new NotImplementedException();
    }
}