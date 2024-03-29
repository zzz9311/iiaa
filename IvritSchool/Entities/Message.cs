﻿using IvritSchool.Enums;
using System;
using System.Collections.Generic;

namespace IvritSchool.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public bool VIP { get; set; }
        public Days Day { get; set; }
        public int ForwardedMessage { get; set; }
        public long ForwardedGroup { get; set; }
        public DateTime SendTime { get; set; }
    }
}
