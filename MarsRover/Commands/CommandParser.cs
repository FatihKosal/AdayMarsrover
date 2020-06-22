using MarsRover.Models.MarsPlateau;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Commands
{
        public    class CommandParser: ICommandParser
    {
         readonly IDictionary<CommandType, Func<string, ICommand>> commandHandlers;
         readonly IDictionary<char, Direction> Directions;
         readonly IDictionary<char, RoverAction> RoverActions;
        public CommandParser()
        {
            commandHandlers = new Dictionary<CommandType, Func<string, ICommand>>
            {
                 {CommandType.CreatePlateau, CreatePlateauCommandHandler},
                 {CommandType.PlaceRover, PlaceRoverCommandHandler},
                 {CommandType.MoveRover, MoveRoverHandler}
            };

            Directions = new Dictionary<char, Direction>
            {
                 {'N', Direction.N},
                 {'S', Direction.S},
                 {'E', Direction.E},
                 {'W', Direction.W}
            };           
        }

        public IEnumerable<ICommand> Parse(string commandString)
        {
            var commands = commandString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands.Select(p => commandHandlers[Matcher(p)].Invoke(p)).ToList();
        }

        private ICommand CreatePlateauCommandHandler(string input)
        {
            var letters = input.Split(' ');
            var width = int.Parse(letters[0]);
            var height = int.Parse(letters[1]);
            var size = new Size(width, height);
            return new CreatePlateauCommand(size);
        }

        private ICommand PlaceRoverCommandHandler(string input)
        {
            var letters = input.Split(' ');

            var x = int.Parse(letters[0]);
            var y = int.Parse(letters[1]);

            var directionLatter = letters[2][0];

            var direction = Directions[directionLatter];

            return new PlaceRoverCommand(new Position(direction, x, y));
        }

        private ICommand MoveRoverHandler(string input)
        {
            var letters = input.ToCharArray();
            var actions = letters.Select(p => RoverActions[p]).ToList();
            return new MoveRoverCommand(actions);
        }

        public CommandType Matcher(string command)
        {
            
                if (new Regex(@"^\d+ \d+$").Match(command).Success)
                {
                    return CommandType.CreatePlateau;
                }
                else if (new Regex(@"^\d+ \d+ [NSEW]$").Match(command).Success)
                {
                    return CommandType.PlaceRover;
                }
                else if (new Regex(@"^[LRM]+$").Match(command).Success)
                {
                    return CommandType.MoveRover;
                }
                throw new Exception("Undifined Command");
         
            
        }
    }
}
