using MarsRover.Models.MarsPlateau;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Rover
{
   public class Rover:IRover
    {
        private readonly IPlateau plateau;
        public Position position { get; set; }

        private readonly IDictionary<RoverAction, Action> actionList;
        private readonly IDictionary<Direction, Action> lefMovetList;
        private readonly IDictionary<Direction, Action> rightMoveList;
        private readonly IDictionary<Direction, Action> forwardMoveList;


        public Rover(IPlateau _plateau,Position _position)
        {
            plateau = _plateau;
            position = _position;

            actionList = new Dictionary<RoverAction, Action>
            {
                {RoverAction.L, () => lefMovetList[position.Direction].Invoke()},
                {RoverAction.R, () => rightMoveList[position.Direction].Invoke()},
                {RoverAction.M, () => forwardMoveList[position.Direction].Invoke()}
            };

            lefMovetList = new Dictionary<Direction, Action>
            {
                {Direction.N, () => position.Direction = Direction.W},
                {Direction.E, () => position.Direction = Direction.N},
                {Direction.S, () => position.Direction = Direction.E},
                {Direction.W, () => position.Direction = Direction.S}
            };

            rightMoveList = new Dictionary<Direction, Action>
            {
                {Direction.N, () => position.Direction = Direction.E},
                {Direction.E, () => position.Direction = Direction.S},
                {Direction.S, () => position.Direction = Direction.W},
                {Direction.W, () => position.Direction = Direction.N}
            };

            forwardMoveList = new Dictionary<Direction, Action>
            {
                {Direction.N, () => {SetPosition(new Position(position.Direction,position.Point.X, position.Point.Y + 1)); }},
                {Direction.E, () => {SetPosition(new Position(position.Direction,position.Point.X + 1, position.Point.Y)); }},
                {Direction.S, () => {SetPosition(new Position(position.Direction,position.Point.X, position.Point.Y - 1)); }},
                {Direction.W, () => {SetPosition( new Position(position.Direction,position.Point.X - 1, position.Point.Y)); }}
            };
        }

        public void Move(IEnumerable<RoverAction> actions)
        {
            foreach (var movement in actions)
            {
                actionList[movement].Invoke();
            }
        }

        void SetPosition(Position _position)
        {
            if (plateau.IsValidPosition(_position.Point))
            {
                position = _position;
            }
            else
            {
                throw new Exception("Out of boundries!!!");
            }
        }

        public string Location()
        {
            return $"{position.Point.X} {position.Point.Y} {position.Direction.ToString()}";
        }
    }
}
