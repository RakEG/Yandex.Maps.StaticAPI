using System.ComponentModel;

namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Содержит описание одной метки, которую требуется отобразить на карте. 
    /// </summary>
    public class Pm2 : MarkBase
    {
        Color _color;
        Size _size;
        int _content = -1;

        /// <summary>
        /// Метка в виде круга
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="color">Цвет</param>
        /// <param name="size">Размер</param>
        /// <param name="content">Контент, целое число от 1 до 99</param>
        public Pm2(double lat, double lon, Color color, Size size, int content = -1) : base(lat, lon)
        {
            _color = color;
            _size = size;
            Content = content;
        }

        /// <summary>
        /// Метка в виде круга (color.wt, size.m)
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        public Pm2(double lat, double lon) : this(lat, lon, Color.wt, Size.m) { }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public override string GetPartUrl()
        {
            string str = "";

            str += Lon.ToString().Replace(',', '.') + ",";
            str += Lat.ToString().Replace(',', '.') + ",";

            str += "pm2";
            str += _color.GetDescription();
            str += _size.GetDescription();

            if (_content > 0)
                str += _content.ToString().Replace(',', '.');

            return str;
        }

        /// <summary>
        ///  Содержимое метки от 1 до 99
        /// </summary>
        public int Content
        {
            get { return _content; }
            set
            {
                if ((value >= 1) & (value <= 99))
                {
                    _content = value;
                }
            }
        }

        /// <summary>
        /// Перечень цветов меток
        /// </summary>
        public enum Color
        {
            [Description("wt")] wt,
            [Description("do")] do_,
            [Description("db")] db,
            [Description("bl")] bl,
            [Description("gn")] gn,
            [Description("gr")] gr,
            [Description("lb")] lb,
            [Description("nt")] nt,
            [Description("or")] or,
            [Description("pn")] pn,
            [Description("rd")] rd,
            [Description("vv")] vv,
            [Description("yw")] yw,
            [Description("a")] a,
            [Description("b")] b,
            [Description("org")] org,
            [Description("dir")] dir,
            [Description("blyw")] blyw
        };

        /// <summary>
        /// Перечень размеров меток
        /// </summary>
        public enum Size
        {
            [Description("m")] m,
            [Description("l")] l
        };
    }

}
