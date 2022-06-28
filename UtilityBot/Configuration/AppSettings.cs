namespace UtilityBot.Configuration
{
    public class AppSettings
    {
        public string BotToken { get; set; }

        public static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "5484750036:AAHUPPiDQGqhLks6Y8PckUYwmrp6Az9-bRU"
            };
        }
    }
}
