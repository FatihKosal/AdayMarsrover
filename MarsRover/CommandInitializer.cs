using MarsRover.Commands;
using MarsRover.Models.MarsPlateau;
using MarsRover.Models.Rover;



namespace MarsRover
{
    public class CommandInitializer : ICommandInitializer
    {
        private readonly IPlateau plateau;
        private readonly ICommandParser commandParser;
        private readonly ICommandInvoker commandInvoker;


        public CommandInitializer(IPlateau _plateau,IRoverManager _roverManager, ICommandParser aCommandParser, ICommandInvoker aCommandInvoker)
        {
            plateau = _plateau;
            commandParser = aCommandParser;
            commandInvoker = aCommandInvoker;
            commandInvoker.SetPlateau(plateau);
            commandInvoker.SetRoverManager(_roverManager);
        }

        public void Execute(string commandString)
        {
            var commandList = commandParser.Parse(commandString);
            commandInvoker.SetCommands(commandList);
            commandInvoker.InvokeAll();
        }
    }
}
