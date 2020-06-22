using MarsRover.Models.MarsPlateau;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
    public class PlaceRoverCommand : IPlaceRoverCommand
    {
        private readonly Position position;
        private IRoverManager roverManager;

        public PlaceRoverCommand(Position _position)
        {

            position = _position;
        }
        public void Execute()
        {
            roverManager.Place(position);
        }

        public void Inject(IRoverManager _roverManager)
        {
            roverManager = _roverManager;
        }



        CommandType ICommand.GetType()
        {
            return CommandType.PlaceRover;
        }
    }
}
