using MarsRover.Models.Rover;

namespace MarsRover.Commands
{
    public interface IPlaceRoverCommand : ICommand
    {
        void Inject(IRoverManager _roverManager);
    }
}
