using System;
using System.IO;
using System.Text.Json;

namespace UtilityBot.Configuration
{
    internal class JsonReader
    {
        public static Settings ReadJson()
        {
            try
            {
                using FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate);
                return JsonSerializer.Deserialize<Settings>(fs);
            }
            catch (JsonException)
            {
                Console.WriteLine("Файл settings.json отсутствует или поврежден. Обратитесь к администратору ресурса.");
                return null;
            }    
        }
    }
}
