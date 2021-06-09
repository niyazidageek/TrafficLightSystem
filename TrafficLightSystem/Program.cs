using System;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            do
            {
                Console.WriteLine("1.Add street");
                Console.WriteLine("2.Remove street");
                Console.WriteLine("3.Start the traffic lights");
                Console.WriteLine("4.Stop the traffic lights by street");
                Console.WriteLine("5.Start the traffic lights by street");
                Console.WriteLine("6.Stop the traffic lights");
                Console.WriteLine("Enter a selection");
                string selectionstr = Console.ReadLine();
                while (!int.TryParse(selectionstr, out selection))
                {
                    Console.WriteLine("Enter a number please!");
                    selectionstr = Console.ReadLine();
                }
                switch (selection)
                {
                    case 1:
                        MenuService.AddStreetMenu();
                        break;
                    case 2:
                        MenuService.RemoveStreetMenu();
                        break;
                    case 3:
                        MenuService.StartSystemMenu();
                        break;
                    case 4:
                        MenuService.StopLightByStreetMenu();
                        break;
                    case 5:
                        MenuService.StartLightByStreetMenu();
                        break;
                    case 6:
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (selection!=6);
        }
    }
}
