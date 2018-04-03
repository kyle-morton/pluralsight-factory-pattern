using Factory2.Autos;
using System;

namespace Factory2
{
    /// <summary>
    /// simple factory
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter car name: ");
                //bmw335xi
                var carName = Console.ReadLine();

                AutoFactory factory = new AutoFactory();

                IAuto car = factory.CreateInstance(carName);

                car.TurnOn();
                car.TurnOff();

                Console.ReadLine();
            }
        }
    }
}
