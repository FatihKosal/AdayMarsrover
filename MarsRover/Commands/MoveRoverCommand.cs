using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
 public    class MoveRoverCommand : IMoveRoverCommand
    {
        public IList<RoverAction> Actions { get; private set; }
        private IRoverManager RoverManager;

        public MoveRoverCommand(IList<RoverAction> actions)
        {
            Actions = actions;
        }

        public void Execute()
        {
            var rover = RoverManager.GetActiveRover();
            rover.Move(Actions);
        }

        public void Inject(IRoverManager _roverManager)
        {
            RoverManager = _roverManager;
        }

        CommandType ICommand.GetType()
        {
            return CommandType.MoveRover;
        }
    }
}
