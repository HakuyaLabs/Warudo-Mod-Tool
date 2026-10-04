using System;
using System;
using Object = UnityEngine.Object;

namespace CommandUndoRedo
{
    public static class UndoRedoManager
    {
        static UndoRedo undoRedo = new UndoRedo();
        public static int maxUndoStored
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public static void Clear()
        {
            throw new NotImplementedException();
        }

        public static void Undo()
        {
            throw new NotImplementedException();
        }

        public static void Redo()
        {
            throw new NotImplementedException();
        }

        public static void Insert(ICommand command)
        {
            throw new NotImplementedException();
        }

        public static void Execute(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}