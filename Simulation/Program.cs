using System;
using AutoClassLibrary;
namespace Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Car SimulatedCar = new Car("WP0AB2A75AL036949", "WO73564", "Ferrari");
            SimulatedCar.Speed = 100;
            SimulatedCar.Lights = EnumLights.DRLs;
            Car.SaveXML("test", SimulatedCar);
            while (true)
            {
               
              
            }
            
            
        }
    }
}
