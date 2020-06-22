using MarsRover.Models.MarsPlateau;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
   public interface ICommandInvoker
    {
        void SetPlateau(IPlateau plateau);
        void SetRoverManager(IRoverManager roverManager);
        void SetCommands(IEnumerable<ICommand> commands);
        void InvokeAll();
    }
}
