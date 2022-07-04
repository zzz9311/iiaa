using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Entities
{
    public class MessagesToSend
    {
        public int ID { get; set; }
        public BotUser User { get; set; }
        public Message Messages { get; set; }
        public bool Sent { get; set; }
        public bool Error { get; set; }
        public DateTime SendTime { get; set; }
    }
}
