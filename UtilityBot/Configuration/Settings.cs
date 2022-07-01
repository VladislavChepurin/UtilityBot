namespace UtilityBot.Configuration
{
    public class Settings
    {
        public string BotToken { get; set; }

        public Settings(string botToken)
        {
            BotToken = botToken;
        }

        /*
        public static Settings BuildAppSettings()
        {
            return new Settings()
            {
                BotToken = "5484750036:AAHUPPiDQGqhLks6Y8PckUYwmrp6Az9-bRU"
            };
        }
        */
    }
}
