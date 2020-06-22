using MarsRover.Models.MarsPlateau;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
   public class CommandInvoker:ICommandInvoker
    {

        private readonly IDictionary<CommandType, Action<ICommand>> setInjectorMethodList;

        private IPlateau plateau;
        private IRoverManager roverManager;
        private IEnumerable<ICommand> commands;

        public CommandInvoker()
        {

            setInjectorMethodList = new Dictionary<CommandType, Action<ICommand>>
            {
                {CommandType.CreatePlateau, InjectCreatePlateauCommand},
                {CommandType.PlaceRover, InjectPlaceRoverCommand},
                {CommandType.MoveRover, InjectMoveRoverCommand}
            };
        }

        public void SetPlateau(IPlateau _plateau)
        {
            plateau = _plateau;
        }

        public void SetRoverManager(IRoverManager _roverManager)
        {
            roverManager = _roverManager;
        }

        public void SetCommands(IEnumerable<ICommand> _commands)
        {
            commands = _commands;
        }
        public void InvokeAll()
        {
            foreach (var command in commands)
            {
                setInjector(command);
                command.Execute();
            }
        }
        private void setInjector(ICommand command)
        {
            setInjectorMethodList[command.GetType()].Invoke(command);
        }

        private void InjectCreatePlateauCommand(ICommand command)
        {
            var landingSurfaceSizeCommand = (ICreatePlataeuCommand)command;
            landingSurfaceSizeCommand.Inject(plateau);
        }

        private void InjectPlaceRoverCommand(ICommand command)
        {
            var roverDeployCommand = (IPlaceRoverCommand)command;
         
            roverDeployCommand.Inject(roverManager);
        }

        private void InjectMoveRoverCommand(ICommand command)
        {
            var roverExploreCommand = (IMoveRoverCommand)command;
            roverExploreCommand.Inject(roverManager);
        }

    }
}
