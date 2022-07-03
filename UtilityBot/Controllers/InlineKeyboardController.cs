using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using UtilityBot.Servises;

namespace UtilityBot.Controllers
{
    public class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;

        public InlineKeyboardController(ITelegramBotClient telegramClient, IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(CallbackQuery callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null) return;

            // Обновление пользовательской сессии новыми данными
            _memoryStorage.GetSession(callbackQuery.From.Id).ModeSesion = callbackQuery.Data;

            string languageText = callbackQuery.Data switch
            {
                "length" => "вычисление длинны сообщения",
                "summ" => "сложение чисел",
                _ => String.Empty
            };                     

            Console.WriteLine($"Пользователь нажал на кнопку, {languageText}");
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Выбрано, {languageText}", cancellationToken: ct);
        }
    }
}
