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
            do
            {
                Time = DateTime.Now;
                FutureTime = Time.AddSeconds(10);

                foreach (var item in ParallelStreets)
                {
                    item.Status = "Red";
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                foreach (var item in PerpendicularStreets)
                {
                    item.Status = "Green";
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }
                Console.WriteLine("============================");
                while (Time.Second != FutureTime.Second)
                {
                    Time = DateTime.Now;
                }

                foreach (var item in ParallelStreets)
                {
                    item.Status = "Green";
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                foreach (var item in PerpendicularStreets)
                {
                    item.Status = "Red";
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                FutureTime = Time.AddSeconds(10);
                while (Time.Second != FutureTime.Second)
                {
                    Time = DateTime.Now;
                }
                Console.WriteLine("=============================");
            } while (true);
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
    }
}
