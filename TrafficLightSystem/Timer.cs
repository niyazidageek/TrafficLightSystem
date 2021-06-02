using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public abstract class Timer
    {
        public DateTime Time { get; set; }
        public DateTime FutureTime { get; set; }  
    }
}
