using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace UtilityBot.Configuration
{
    internal class JsonReader
    {
        public void WriteJson(string data)
        {
            using (FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
                Settings token = new Settings(data);
                JsonSerializer.Serialize<Settings>(fs, token);
                Console.WriteLine("Data has been saved to file");
            }
        }

        public string ReadJson(string key)
        {
            using (FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
                Settings? token = JsonSerializer.Deserialize<Settings>(fs);
                Console.WriteLine($"Name: {token?.BotToken}");
                return token?.BotToken;
            }            
        }
    }
}
