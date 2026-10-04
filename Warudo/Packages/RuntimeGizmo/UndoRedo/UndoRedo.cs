using System;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace CommandUndoRedo
{
    public class UndoRedo
    {
        public int maxUndoStored
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

        DropoutStack<ICommand> undoCommands = new DropoutStack<ICommand>();
        DropoutStack<ICommand> redoCommands = new DropoutStack<ICommand>();
        public UndoRedo()
        {
            throw new NotImplementedException();
        }

        public UndoRedo(int maxUndoStored)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Insert(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void Execute(ICommand command)
        {
            throw new NotImplementedException();
        }

        void SetMaxLength(int max)
        {
            throw new NotImplementedException();
        }
    }
}