using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
   public interface ICommandInitializer
    {
        void Execute(string commandString);
    }
}
