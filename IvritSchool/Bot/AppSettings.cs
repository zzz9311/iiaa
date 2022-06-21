
using System.Configuration;

namespace IvritSchool.Bot
{
    public class AppSettings
    {
        private static string baseUrl = "https://baseUrl.ru/";
        public static string Url { get; set; } = baseUrl+"{0}";

        public static string Name { get; set; } = "";

        public static string Key { get; set; } = "asd";
    }
}