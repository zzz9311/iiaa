using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Entities
{
    public class Days
    {
        public int ID { get; set; }
        public int DayNumber { get; set; }
        public List<Message> Messages { get; set; } 
    }
}
