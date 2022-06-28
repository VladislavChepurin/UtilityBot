using System;
using System.Text;

namespace UtilityBot.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Метод расширения String, парсит цифры в строке и складывает
        /// </summary>
        /// <param name="str"></param>
        /// <returns>
        /// int32
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static int SumParse(this string str)
        {
            StringBuilder sb = new StringBuilder();
            int value = default;

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    sb.Append(str[i]);
                }
                if (Char.IsWhiteSpace(str[i]) || i == str.Length - 1)
                {
                    if (int.TryParse(sb.ToString(), out int result))
                    {
                        value += result;
                        sb.Clear();
                    }
                }
                //Класс написан максимально отказаустойчиво.
                //Если закоментиовать вызов ошибки, то он просто будет проблем игнорировать буквы и парсить цифры.
                if (!Char.IsDigit(str[i]) && !Char.IsWhiteSpace(str[i]))
                {
                    throw new ArgumentException("В веденном сообщении есть буквы, пожайлуста попробуйте ввести цифры еще раз");                
                }
            }
            return value;
        }
    }
}
