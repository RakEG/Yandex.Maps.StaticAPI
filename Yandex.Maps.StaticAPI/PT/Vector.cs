using System.ComponentModel;

namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Содержит описание одной метки, которую требуется отобразить на карте. 
    /// </summary>
    public class Vector : MarkBase
    {
        Mark _mark;

        /// <summary>
        /// Метка векторная (в том числе иконка дом, работа, я)
        /// </summary>
        /// <param name="lat">Широта метки</param>
        /// <param name="lon">Долгота метки</param>
        /// <param name="mark">Тип векторной метки</param>
        public Vector(double lat, double lon, Mark mark) : base(lat, lon)
        {
            _mark = mark;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public override string GetPartUrl()
        {
            string str = "";

            str += Lon.ToString().Replace(',', '.') + ",";
            str += Lat.ToString().Replace(',', '.') + ",";

            str += _mark.GetDescription();

            return str;
        }

        /// <summary>
        /// Перечень меток
        /// </summary>
        public enum Mark
        {
            [Description("org")] org,
            [Description("comma")] comma,
            [Description("round")] round,
            [Description("home")] home,
            [Description("work")] work,
            [Description("ya_ru")] ya_ru,
        };
    }

}
