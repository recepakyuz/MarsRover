using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Navigation
{
    public interface INavigation
    {
        void SetPlateau(string plateuInput);
        Plateau GetPlateau();
        void SetPosition(string positionInput);
        Position GetPosition();
        void SetInput(string plateuInput);
        void Navigate();
    }
}
