using System.ComponentModel;

namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Содержит описание одной метки, которую требуется отобразить на карте. 
    /// </summary>
    public class Vk : MarkBase
    {
        Color _color;
        Size _size;

        /// <summary>
        /// Метка кнопка (черная или серая)
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="color">Цвет</param>
        public Vk(double lat, double lon, Color color) : base(lat, lon)
        {
            _color = color;
            _size = Size.m;
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

            str += "vk";

            str += _color.GetDescription();
            str += _size.GetDescription();

            return str;
        }

        /// <summary>
        /// Перечень цветов меток
        /// </summary>
        public enum Color
        {
            [Description("bk")] bk,
            [Description("gr")] gr
        };

        /// <summary>
        /// Перечень размеров меток
        /// </summary>
        public enum Size
        {
            [Description("m")] m
        };
    }

}
