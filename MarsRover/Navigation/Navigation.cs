using MarsRover.Exceptions;
using MarsRover.Interpreter;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Navigation
{
    public class Navigation:INavigation
    {
        public Plateau _Plateau;
        public Position _Position;
        string _Input;
        public Navigation()
        {
            _Plateau = new Plateau();
            _Position = new Position();
            _Position.PositionChanging += _Position_PositionChanging;
        }

        private void _Position_PositionChanging(object sender, PositionChangingEventArg e)
        {
            if (e.NewValue.X < 0 || e.NewValue.Y < 0 || e.NewValue.X > _Plateau.Width || e.NewValue.Y > _Plateau.Height)
            {
                throw new OutOfPlateauException();
            }
        }

        public void SetPlateau(string plateauInput)
        {
            var array = plateauInput.Split(' ');
            int width;
            int height;
            if (array.Length != 2 || !int.TryParse(array[0], out width) || !int.TryParse(array[1], out height))
            {
                throw new BadFormatException();
            }
            _Plateau = new Plateau() { Width = width, Height = height };
        }      

        public void SetPosition(string positionInput)
        {
            if (string.IsNullOrEmpty(positionInput))
            {
                throw new BadFormatException();
            }
            var array = positionInput.Split(' ');
            int x, y;
            if (array.Length != 3 || !int.TryParse(array[0], out x) || !int.TryParse(array[1], out y) || !"NWSE".Contains(array[2]) || array[2].Length != 1) throw new BadFormatException();

            _Position._Direction = (Direction)Convert.ToChar(array[2]);
            _Position.X = x;
            _Position.Y = y;           
        }        

        public void SetInput(string input)
        {
            _Input = input;
        }
        public void Navigate()
        {
            List<NavigationInterpreter> list = new List<NavigationInterpreter>();
            foreach (var item in _Input)
            {
                switch (item)
                {
                    case 'M': list.Add(new MoveInterpreter()); break;
                    case 'L': list.Add(new LeftInterpreter()); break;
                    case 'R': list.Add(new RightInterpreter()); break;
                    default: throw new Exception("Undefined Command");
                }
            }
            foreach (var item in list)
            {
                item.Interpret(_Position);
            }
        }

        public Position GetPosition()
        {
            return _Position;
        }

        public Plateau GetPlateau()
        {
            return _Plateau;
        }
    }
}
