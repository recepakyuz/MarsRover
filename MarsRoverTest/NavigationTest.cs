using MarsRover;
using MarsRover.Exceptions;
using MarsRover.Navigation;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTest
{
    [TestFixture]
    public class NavigationTest
    {
        public NavigationTest()
        {
            Program.kernel = new StandardKernel(new RegisterNinjectModule());
        }
        [Test]
        public void SetPlateauCorrectCheck()
        {
            var rover=new MarsRover.MarsRover();
            rover._Navigation.SetPlateau("1 2");
            var plateau= rover._Navigation.GetPlateau();
            Assert.IsTrue(plateau.Width==1 && plateau.Height==2);
        }
        [Test]
        public void SetPlateauBadFormatCheck()
        {
            try
            {
                var rover = new MarsRover.MarsRover();
                rover._Navigation.SetPlateau("a 2");

            }
            catch (BadFormatException)
            {
                Assert.Pass();
            }          
        }
        [Test]
        public void SetPositionCorrectCheck()
        {
            var rover = new MarsRover.MarsRover();
            rover._Navigation.SetPlateau("5 5");
            rover._Navigation.SetPosition("1 2 W");
            var position = rover._Navigation.GetPosition();
            Assert.IsTrue(position.X==1 && position.Y==2 && position._Direction==Direction.West);
        }
        [Test]
        public void SetPositionBadFormatCheck()
        {
            try
            {
                var rover = new MarsRover.MarsRover();
                rover._Navigation.SetPlateau("5 5");
                rover._Navigation.SetPosition("a 2 W");
            }
            catch (BadFormatException)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void SetPositionOutOfPlateauCheck()
        {
            try
            {
                var rover = new MarsRover.MarsRover();
                rover._Navigation.SetPlateau("1 1");
                rover._Navigation.SetPosition("2 2 W");
            }
            catch (OutOfPlateauException)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void Navigation1Check()
        {
            var marsRover = new MarsRover.MarsRover();
            marsRover._Navigation.SetPlateau("5 5");
            marsRover._Navigation.SetPosition("1 2 N");
            marsRover._Navigation.SetInput("LMLMLMLMM");
            marsRover._Navigation.Navigate();
            var position = marsRover._Navigation.GetPosition();
            Assert.IsTrue(position.X == 1 && position.Y == 3 && position._Direction == Direction.North);

        }
        [Test]
        public void Navigation2Check()
        {
            var marsRover = new MarsRover.MarsRover();
            marsRover._Navigation.SetPlateau("5 5");
            marsRover._Navigation.SetPosition("3 3 E");
            marsRover._Navigation.SetInput("MMRMMRMRRM");
            marsRover._Navigation.Navigate();
            var position = marsRover._Navigation.GetPosition();
            Assert.IsTrue(position.X == 5 && position.Y == 1 && position._Direction == Direction.East);

        }
    }
}
