using UtilityBot.Models;

namespace UtilityBot.Servises
{
    public interface IStorage
    {
        /// <summary>
        /// Получение сессии пользователя по идентификатору
        /// </summary>
        UserSesion GetSession(long chatId);
    }
}
