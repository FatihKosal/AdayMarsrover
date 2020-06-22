using MarsRover.Models.MarsPlateau;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Rover
{
    public interface IRoverManager
    {
        Rover GetActiveRover();
        void Place(Position position);
        List<Rover> GetAllRovers();
    }
}
