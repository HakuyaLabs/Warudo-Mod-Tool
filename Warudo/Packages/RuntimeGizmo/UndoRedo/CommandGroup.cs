using System;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace CommandUndoRedo
{
    public class CommandGroup : ICommand
    {
        List<ICommand> commands = new List<ICommand>();
        public CommandGroup()
        {
            throw new NotImplementedException();
        }

        public CommandGroup(List<ICommand> commands)
        {
            throw new NotImplementedException();
        }

        public void Set(List<ICommand> commands)
        {
            throw new NotImplementedException();
        }

        public void Add(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void Remove(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}