namespace UtilityBot.Configuration
{
    public class Settings
    {
        public string BotToken { get; set; }

        public Settings(string botToken)
        {
            BotToken = botToken;
        }
    }
}
