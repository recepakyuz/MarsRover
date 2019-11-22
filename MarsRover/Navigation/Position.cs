using MarsRover.Exceptions;
using MarsRover.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Navigation
{
    public class Position
    {
        int x;
        public int X
        {
            get { return x; }
            set
            {
                if (PositionChanging != null)
                {
                    var arg = new PositionChangingEventArg() { OldValue = this, NewValue = new Position() { X = value, Y = Y, _Direction = _Direction } };
                    PositionChanging?.Invoke(this, arg);
                }
                x = value;

            }
        }
        int y;
        public int Y
        {
            get { return y; }
            set
            {
                if (PositionChanging != null)
                {

                    var arg = new PositionChangingEventArg() { OldValue = this, NewValue = new Position() { X = X, Y = value, _Direction = _Direction } };
                    PositionChanging?.Invoke(this, arg);
                }
                y = value;
            }
        }
        public Direction _Direction { get; set; }
        public override string ToString()
        {
            return X + " " + Y + " " + _Direction.ToString();
        }
        public delegate void PositionChangingEventHandler(object sender, PositionChangingEventArg e);
        public event PositionChangingEventHandler PositionChanging;
    }
}
