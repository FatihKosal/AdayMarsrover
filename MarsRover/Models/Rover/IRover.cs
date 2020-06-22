using MarsRover.Models.MarsPlateau;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Rover
{
   public interface IRover
    {
        void Move(IEnumerable<RoverAction> actions);
        string Location();
    }
}
