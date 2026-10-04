using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public abstract class StateBehaviour : MonoBehaviour, IState
    {
        public virtual bool CanEnterState => throw new NotImplementedException();
        public virtual bool CanExitState => throw new NotImplementedException();
        public virtual void OnEnterState()
        {
            throw new NotImplementedException();
        }

        public virtual void OnExitState()
        {
            throw new NotImplementedException();
        }
    }
}