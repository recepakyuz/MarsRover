using MarsRover.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interpreter
{
    public abstract class NavigationInterpreter
    {
        public abstract void Interpret(Position position);
    }
}
