using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    class MenuService
    {
        static Methods method = new();
        public static void AddStreetMenu()
        {
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Available street types: 'Parallel', 'Perpendicular' ");
            Console.WriteLine("============================");
            Console.WriteLine("Enter the type of the street");
            string type = Console.ReadLine().ToLower();
            try
            {
                method.AddStreet(name, type);
                Console.WriteLine("Street added");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void RemoveStreetMenu()
        {
            Console.WriteLine("Available streets are shown below:");
            foreach (var item in method.ParallelStreets)
            {
                Console.WriteLine(item.Name); 
            }
            foreach (var item in method.PerpendicularStreets)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("============================");
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            try
            {
                method.RemoveStreet(name);
                Console.WriteLine("Street removed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void StartSystemMenu()
        {
            try
            {
                method.Lights();
            }
            catch (Exception)
            {
                Console.WriteLine("Traffic lights have stopped");
                
            }
                       
        }
        public static void StopLightByStreetMenu()
        {
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            try
            {
                method.StopLightByStreet(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void StartLightByStreetMenu()
        {
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            try
            {
                method.StartLightByStreet(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
