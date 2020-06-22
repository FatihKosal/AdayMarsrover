using MarsRover.Models.MarsPlateau;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
   public interface IMoveRoverCommand:ICommand
    {
        void Inject(IRoverManager _roverManager);
    }
}
