using System;
using System;
using Object = UnityEngine.Object;

namespace CommandUndoRedo
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}