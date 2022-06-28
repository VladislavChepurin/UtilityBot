using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using UtilityBot.Models;

namespace UtilityBot.Servises
{
    public class MemoryStorage: IStorage
    {
        /// <summary>
        /// Хранилище сессий
        /// </summary>
        private readonly ConcurrentDictionary<long, UserSesion> _sessions;

        public MemoryStorage()
        {
            _sessions = new ConcurrentDictionary<long, UserSesion>();
        }

        public UserSesion GetSession(long chatId)
        {
            // Возвращаем сессию по ключу, если она существует
            if (_sessions.ContainsKey(chatId))
                return _sessions[chatId];

            // Создаем и возвращаем новую, если такой не было
            var newSession = new UserSesion() { ModeSesion = "length" };
            _sessions.TryAdd(chatId, newSession);
            return newSession;
        }
    }
}
