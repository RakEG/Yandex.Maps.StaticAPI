using System.ComponentModel;

namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Локализация карт с надписями на различных языках.
    /// </summary>
    public class Lang
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        /// <summary>
        /// Локаль задается в формате RFC-3066
        /// </summary>
        public Lang_reg _language_region;

        /// <summary>
        /// Локализация карт с надписями на различных языках.
        /// lang=language_region.
        /// language - двузначный код языка. Указывается в формате ISO 639-1. Задает язык объектов на карте (топонимов, элементов управления).
        /// region - двузначный код страны. Указывается в формате ISO 3166-1. Определяет региональные особенности, например единицу измерения (для обозначения расстояния между объектами или скорости движения по маршруту). 
        /// </summary>
        /// <param name="lang_reg">Локаль задается в формате RFC-3066</param>
        public Lang(Lang_reg lang_reg)
        {
            _language_region = lang_reg;
        }

        /// <summary>
        /// Локализация карт с надписями на различных языках.
        /// Вызов конструктора без параметра соответствует вызову с параметром lang_reg.none
        /// </summary>
        public Lang() : this(Lang_reg.none) { }

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public Lang(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "lang=";

            if (_userString == "")
            {
                //if (_language_region == lang_reg.none)
                //    return "";
                //else
                str += _language_region.GetDescription();
            }

            else
                str += _userString;

            return str;
        }

        /// <summary>
        /// Перечень локалей в формате RFC-3066
        /// </summary>
        public enum Lang_reg
        {
            [Description("")]
            none,
            [Description("ru_RU")]
            ru_RU,
            [Description("en_US")]
            en_US,
            [Description("en_RU")]
            en_RU,
            [Description("ru_UA")]
            ru_UA,
            [Description("uk_UA")]
            uk_UA,
            [Description("tr_TR")]
            tr_TR
        };
    }
}
