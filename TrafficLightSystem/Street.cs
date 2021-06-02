using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class Street
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public Street(string type)
        {
            Type = type;
        }
    }
}
