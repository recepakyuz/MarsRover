using Ninject;
using System;

namespace MarsRover
{
    public class Program
    {
        public static IKernel kernel;
        static void Main(string[] args)
        {
            kernel = new StandardKernel(new RegisterNinjectModule());

            var marsRover = new MarsRover();
            marsRover._Navigation.SetPlateau("5 5");

            marsRover._Navigation.SetPosition("1 2 N");
            marsRover._Navigation.SetInput("LMLMLMLMM");
            marsRover._Navigation.Navigate();
            Console.WriteLine(marsRover._Navigation.GetPosition().ToString());


            marsRover._Navigation.SetPosition("3 3 E");
            marsRover._Navigation.SetInput("MMRMMRMRRM");
            marsRover._Navigation.Navigate();
            Console.WriteLine(marsRover._Navigation.GetPosition().ToString());

            Console.ReadKey();
        }
    }
}
