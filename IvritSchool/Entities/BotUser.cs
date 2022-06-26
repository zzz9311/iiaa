using IvritSchool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Entities
{
    public class BotUser
    {
        public int ID { get; set; }
        public bool IsBanned { get; set; }
        public long TID { get; set; }
        public UserStatus Status { get; set; }
        public DateTime FirstDate { get; set; }
        public string Name { get; set; }

        public virtual BotUser User { get; set; }
    }
}
