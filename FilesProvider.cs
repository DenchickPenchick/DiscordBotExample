using System.IO;
using System.Text.Json;

namespace DiscordBotExample
{
    public static class FilesProvider
    {
        public static void SetupFiles()
        {            
            if (!File.Exists("config.json"))
                using (FileStream fs = new FileStream("config.json", FileMode.Create)) { fs.Write(JsonSerializer.SerializeToUtf8Bytes(new Configuration())); }
        }

        public static string Token()
        {
            using StreamReader reader = new StreamReader("config.json");
            return JsonSerializer.Deserialize<Configuration>(reader.ReadToEnd()).Token;
        }

        public static string Prefix()
        {
            using StreamReader reader = new StreamReader("config.json");
            return JsonSerializer.Deserialize<Configuration>(reader.ReadToEnd()).Prefix;
        }

        public static string Status()
        {
            using StreamReader reader = new StreamReader("config.json");
            return JsonSerializer.Deserialize<Configuration>(reader.ReadToEnd()).Status;
        }
    }
}
