using System;
using System.Reflection;
using Factory3.Autos;
using Factory3.Factories;
using Factory4.Autos.BMW;

namespace Factory3
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("hit enter to create a car...");
                Console.ReadLine();

                IAutoFactory autoFactory = LoadFactory();

                IAuto car = autoFactory.CreateAutomobile();

                var myCar = new BMW328i();

                car.TurnOn();
                car.TurnOff();
            }
        }

        static IAutoFactory LoadFactory()
        {
            string factoryName = Properties.Settings.Default.AutoFactory;
            return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as IAutoFactory;
        }
    }

}