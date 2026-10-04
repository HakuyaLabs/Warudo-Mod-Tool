using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public class DelegateState : IState
    {
        public Func<bool> canEnter;
        public virtual bool CanEnterState => throw new NotImplementedException();
        public Func<bool> canExit;
        public virtual bool CanExitState => throw new NotImplementedException();
        public Action onEnter;
        public virtual void OnEnterState() => throw new NotImplementedException();
        public Action onExit;
        public virtual void OnExitState() => throw new NotImplementedException();
    }
}