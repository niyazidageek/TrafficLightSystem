using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class Methods : Timer
    {
        public List<Street> ParallelStreets { get; set; }
        public List<Street> PerpendicularStreets { get; set; }
        public Methods()
        {
            ParallelStreets = new();
            PerpendicularStreets = new();
        }
        public static int check = 0;
        public void AddStreet(string name, string type)
        {
            Street street = new(type);
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            if (string.IsNullOrEmpty(type))
                throw new ArgumentNullException("Type is null");
            street.Name = name;
            street.Type = type;
            if (type == "parallel")
            {
                ParallelStreets.Add(street);
            }
            else
            {
                PerpendicularStreets.Add(street);
            }
        }
        public void StartSystem()
        {
            
            while(check!=1)
            {
                if (check == 1)
                    throw new Exception("System has stopped.");
                Time = DateTime.Now;
                FutureTime = Time.AddSeconds(10);               
                foreach (var item in ParallelStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Red";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                foreach (var item in PerpendicularStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Green";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }
                Console.WriteLine("============================");
                
                while (Time.Second != FutureTime.Second)
                {
                    if (check == 1)
                        throw new Exception("System has stopped.");
                    Time = DateTime.Now;                   
                }

                foreach (var item in ParallelStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Green";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                foreach (var item in PerpendicularStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Red";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }
                
                FutureTime = Time.AddSeconds(10);                   
                while (Time.Second != FutureTime.Second)                  
                {
                    if (check == 1)
                        throw new Exception("System has stopped.");
                    Time = DateTime.Now;                
                }        
                Console.WriteLine("=============================");
               
                
                
            }          
        }
        public void RemoveStreet(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            var result = ParallelStreets.RemoveAll(s => s.Name == name);
            var result1 = PerpendicularStreets.RemoveAll(s => s.Name == name);
            if (result == -1 || result1 == -1)
                throw new KeyNotFoundException("There is no such street in the data base");
        }
        public void StopLightByStreet(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            var result = ParallelStreets.Find(s => s.Name == name);
            var result1 = PerpendicularStreets.Find(s => s.Name == name);
            if (result == null && result1 == null)
                throw new KeyNotFoundException("There is no such street in the data base");
            if (result != null)
            {
                result.Status = "Disabled";
            }
            else
            {
                result1.Status = "Disabled";
            }
        }
        public void StartLightByStreet(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            var result = ParallelStreets.Find(s => s.Name == name);
            var result1 = PerpendicularStreets.Find(s => s.Name == name);
            if (result == null && result1 == null)
                throw new KeyNotFoundException("There is no such street in the data base");
            if (result != null)
            {
                result.Status = string.Empty;
            }
            else
            {
                result1.Status = string.Empty;
            }
        }
        public void HiddenMenu()
        {
            int selection = 0;
            do
            {
                Console.WriteLine("1.Add street");
                Console.WriteLine("2.Remove street");
                Console.WriteLine("3.Stop the traffic lights by street");
                Console.WriteLine("4.Start the traffic lights by street");
                Console.WriteLine("5.Stop the traffic lights");
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
                        MenuService.StopLightByStreetMenu();
                        break;
                    case 4:
                        MenuService.StartLightByStreetMenu();
                        break;
                    case 5:
                        Console.WriteLine("Good bye!");
                        check = 1;
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (selection != 5);
        }
        public void Lights()
        {
           Parallel.Invoke(HiddenMenu, StartSystem);
        }
    }
}
