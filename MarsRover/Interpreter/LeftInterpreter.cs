using MarsRover.Helpers;
using MarsRover.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interpreter
{
    public class LeftInterpreter : NavigationInterpreter
    {
        public override void Interpret(Position position)
        {
          position._Direction= position._Direction.Left();
        }
    }
}
