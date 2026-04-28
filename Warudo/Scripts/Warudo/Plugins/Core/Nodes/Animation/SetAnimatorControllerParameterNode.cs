using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class SetAnimatorControllerParameterNode : Node
    {
        public GameObjectAsset Asset;
        public string Parameter;
        protected bool FilterAsset(GameObjectAsset asset)
        {
            throw new NotImplementedException();
        }

        protected async UniTask<AutoCompleteList> AutoCompleteParameter()
        {
            throw new NotImplementedException();
        }

        protected abstract AnimatorControllerParameterType ParameterType { get; }

        protected abstract void OnSetParameter(Animator animator);
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }

    public class SetAnimatorControllerIntegerNode : SetAnimatorControllerParameterNode
    {
        public int Integer;
        protected override AnimatorControllerParameterType ParameterType => throw new NotImplementedException();
        protected override void OnSetParameter(Animator animator)
        {
            throw new NotImplementedException();
        }
    }

    public class SetAnimatorControllerFloatNode : SetAnimatorControllerParameterNode
    {
        public float Float;
        protected override AnimatorControllerParameterType ParameterType => throw new NotImplementedException();
        protected override void OnSetParameter(Animator animator)
        {
            throw new NotImplementedException();
        }
    }

    public class SetAnimatorControllerBoolNode : SetAnimatorControllerParameterNode
    {
        public bool Boolean;
        protected override AnimatorControllerParameterType ParameterType => throw new NotImplementedException();
        protected override void OnSetParameter(Animator animator)
        {
            throw new NotImplementedException();
        }
    }

    public class ToggleAnimatorControllerBoolNode : SetAnimatorControllerParameterNode
    {
        protected override AnimatorControllerParameterType ParameterType => throw new NotImplementedException();
        protected override void OnSetParameter(Animator animator)
        {
            throw new NotImplementedException();
        }
    }

    public class SetAnimatorControllerTriggerNode : SetAnimatorControllerParameterNode
    {
        protected override AnimatorControllerParameterType ParameterType => throw new NotImplementedException();
        protected override void OnSetParameter(Animator animator)
        {
            throw new NotImplementedException();
        }
    }
}