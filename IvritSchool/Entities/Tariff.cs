using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Entities
{
    public class Tariff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool VIP { get; set; }
        public IEnumerable<Days> Days { get; set; }
    }
}
