using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial class ManualMixerState
    {
        protected virtual int ParameterCount => throw new NotImplementedException();
        protected virtual string GetParameterName(int index) => throw new NotImplementedException();
        protected virtual UnityEngine.AnimatorControllerParameterType GetParameterType(int index) => throw new NotImplementedException();
        protected virtual object GetParameterValue(int index) => throw new NotImplementedException();
        protected virtual void SetParameterValue(int index, object value) => throw new NotImplementedException();
    }
}