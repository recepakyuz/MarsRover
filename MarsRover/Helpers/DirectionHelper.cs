using MarsRover.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helpers
{
    public static class DirectionHelper
    {
        static CircularList<Direction> directions;
        static DirectionHelper()
        {
            directions = new CircularList<Direction>();

            directions.Add(Direction.North);
            directions.Add(Direction.East);
            directions.Add(Direction.South);
            directions.Add(Direction.West);
        }
        public static Direction Left(this Direction direction)
        {
            return directions.SetPosition(direction).Previous();
        }
        public static Direction Right(this Direction direction)
        {
            return directions.SetPosition(direction).Next();
        }
    }
}
