using MarsRover.Models.Rover;

namespace MarsRover.Models.MarsPlateau
{
    public class Plateau : IPlateau
    {
        public Size Size { get; set; }

        public bool IsValidPosition(Point point)
        {
            if ((point.X >= 0 && point.X <= Size.Width) && 
                (point.Y >= 0 && point.Y <= Size.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetSize(Size size)
        {
            Size = size;
        }
    }
}
