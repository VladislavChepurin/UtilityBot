using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UtilityBot.Extensions;
using UtilityBot.Servises;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                       InlineKeyboardButton.WithCallbackData($"Подсчитать длинну сообщения" , $"length"),
                       InlineKeyboardButton.WithCallbackData($"Сложить числа" , $"summ")
                    });

                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Выбирите необходимое действие.</b> {Environment.NewLine}",
                        cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
                default:
                    //Внутреняя логика
                    switch (_memoryStorage.GetSession(message.Chat.Id).ModeSesion)
                    {
                        case "length":
                            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Длина сообщения: {message.Text.Length} знаков", cancellationToken: ct);
                            break;
                        case "summ":
                            //Здесь парсим и складыаем 
                            try
                            {
                                await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Сумма введенных значений: {message.Text.SumParse()}", cancellationToken: ct);
                            }
                            catch (ArgumentException e)
                            {
                                await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"{e.Message}", cancellationToken: ct);
                            }     
                            break;
                        default:
                            // Такого быть недолжно
                            throw new Exception("Ошибка пользовательской сессии");
                    }      
                    break;
            }
        }
    }
}