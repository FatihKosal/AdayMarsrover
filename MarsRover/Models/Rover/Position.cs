using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Rover
{
   public class Position
    {
        public Point Point { get; set; }
        public Direction Direction { get; set; }

        public Position(Direction direction=Direction.N,int x=0, int y=0)
        {
            Point = new Point(x, y);
            Direction = direction;
        }


    }
}
