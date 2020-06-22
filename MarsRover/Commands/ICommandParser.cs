using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
    public interface ICommandParser
    {
        IEnumerable<ICommand> Parse(string command);
    }
}
