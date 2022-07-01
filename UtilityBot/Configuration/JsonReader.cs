using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace UtilityBot.Configuration
{
    internal class JsonReader
    {
        public static Settings ReadJson()
        {
            using FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate);
            return JsonSerializer.Deserialize<Settings>(fs);
        }
    }
}
