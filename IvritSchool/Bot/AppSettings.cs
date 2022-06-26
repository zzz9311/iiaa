
using System.Configuration;

namespace IvritSchool.Bot
{
    public class AppSettings
    {
        public static string baseUrl = "https://localhost:44357/";
        public static string Url { get; set; } = baseUrl + "{0}";

        public static string Name { get; set; } = "";

        public static string Key { get; set; } = "1128939110:AAGwl7zUHnVhsbLebRCOBs3ka2mrcpTjTgk";
    }
}