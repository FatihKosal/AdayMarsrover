using MarsRover.Models.Rover;

namespace MarsRover.Models.MarsPlateau
{
    public interface IPlateau
    {
        void SetSize(Size size);
        bool IsValidPosition(Point point);
    }
}
