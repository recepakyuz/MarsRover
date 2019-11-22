using MarsRover.Navigation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsRover
    {
        [Inject]
        public INavigation _Navigation { get; set; }
        public MarsRover()
        {
            Program.kernel.Inject(this); //for auto activate has inject attribute properties

        }
    }
}
