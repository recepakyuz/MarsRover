using MarsRover.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interpreter
{
    public class MoveInterpreter : NavigationInterpreter
    {
        public override void Interpret(Position position)
        {
            switch (position._Direction)
            {
                case Direction.North:
                    position.Y += 1;
                    break;
                case Direction.West:
                    position.X -= 1;
                    break;
                case Direction.South:
                    position.Y -= 1;
                    break;
                case Direction.East:
                    position.X += 1;
                    break;
            }
        }
    }
}
