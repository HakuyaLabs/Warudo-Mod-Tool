using UnityEngine;
using System;
using Object = UnityEngine.Object;

public class DynamicBoneColliderBase : MonoBehaviour
{
    public enum Direction
    {
        X,
        Y,
        Z
    }

    public Direction m_Direction = Direction.Y;
    public Vector3 m_Center = Vector3.zero;
    public enum Bound
    {
        Outside,
        Inside
    }

    public Bound m_Bound = Bound.Outside;
    public int PrepareFrame { get; set; }

    public virtual void Start()
    {
        throw new NotImplementedException();
    }

    public virtual void Prepare()
    {
        throw new NotImplementedException();
    }

    public virtual bool Collide(ref Vector3 particlePosition, float particleRadius)
    {
        throw new NotImplementedException();
    }
}