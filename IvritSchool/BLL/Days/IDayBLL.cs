using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.Days
{
    public interface IDayBLL
    {
        public void Insert(Entities.Days day);
        public Entities.Days[] GetDays(string daysPredicate);
    }
}
