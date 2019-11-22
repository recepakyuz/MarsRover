using MarsRover.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class PositionChangingEventArg:EventArgs
    {
        public Position OldValue { get; set; }
        public Position NewValue { get; set; }
    }
}
