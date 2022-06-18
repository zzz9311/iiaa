﻿using IvritSchool.Enums;

namespace IvritSchool.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public bool VIP { get; set; }
    }
}
