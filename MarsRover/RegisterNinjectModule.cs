using MarsRover.Navigation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RegisterNinjectModule:NinjectModule
    {
        public override void Load()
        {
            this.Bind<INavigation>().To<Navigation.Navigation>().InTransientScope();
        }
    }
}
