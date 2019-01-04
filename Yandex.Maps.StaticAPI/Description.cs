using System;
using System.ComponentModel;

namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Для получения описаний перечисления
    /// </summary>
    public static class Description
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            var fi = type.GetField(value.ToString());

            var descriptions = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            return descriptions.Length > 0 ? descriptions[0].Description : value.ToString();
        }
    }
}
