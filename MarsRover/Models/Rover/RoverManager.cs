using MarsRover.Models.MarsPlateau;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Rover
{
    public  class RoverManager: IRoverManager
    {
        private List<Rover> Rovers;

        private readonly IPlateau Plateau;

        public RoverManager(IPlateau plateau)
        {
            Rovers = new List<Rover>();

            Plateau = plateau;
        }

        public Rover GetActiveRover()
        {
            return Rovers[Rovers.Count - 1];
        }

        public List<Rover> GetAllRovers()
        {
            return Rovers;
        }

        public void Place(Position position)
        {
            if (Plateau.IsValidPosition(position.Point))
            {
                var rover = new Rover(Plateau,position);
                Rovers.Add(rover);
                
                return;

            }

            throw new Exception("Out of boundries!!!");
        }
    }
}
