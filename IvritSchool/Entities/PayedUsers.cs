using IvritSchool.Enums;
using System;

namespace IvritSchool.Entities
{
    public class PayedUsers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public PasswordType PasswordType { get; set; }

        public Tariff Tariff { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public DateTime? LearnStartsFrom { get; set; }
        public BotUser User { get; set; }

        public Days CurrentDay { get; set; }

    }
}
