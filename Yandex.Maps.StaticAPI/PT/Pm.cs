using System.ComponentModel;

namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Содержит описание одной метки, которую требуется отобразить на карте. 
    /// </summary>
    public class Pm : MarkBase
    {
        Color _color;
        Size _size;
        int _content = -1;
        AB _ab;
        bool _metAB = false;//использование метки типа АБ

        /// <summary>
        /// Метка в виде прямоугольника
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="color">Цвет</param>
        /// <param name="size">Размер</param>
        /// <param name="content">Контент, целое число от 1 до 99</param>
        public Pm(double lat, double lon, Color color, Size size, int content=-1):base(lat, lon)
        {
            _color = color;
            _size = size;
            Content = content;
        }

        /// <summary>
        /// Метка в виде прямоугольника
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        public Pm(double lat, double lon) : this(lat, lon, Color.wt, Size.m) { }

        /// <summary>
        /// Метка в виде прямоугольника
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="ab">Метка АБ</param>
        public Pm(double lat, double lon, AB ab) : base(lat, lon)
        {
            _ab = ab;
            _metAB = true;
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

            str += "pm";
            if (_metAB)
            {
                str += _ab.GetDescription();
            }
            else
            {
                str += _color.GetDescription();
                str += _size.GetDescription();

                if (_content > 0)
                    str += _content.ToString().Replace(',', '.');
            }

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
            [Description("yw")] yw
        };

        /// <summary>
        /// Перечень размеров меток
        /// </summary>
        public enum Size
        {
            [Description("s")] s,
            [Description("m")] m,
            [Description("l")] l
        };

        /// <summary>
        /// Перечень меток А и Б
        /// </summary>
        public enum AB
        {
            [Description("a")] a,
            [Description("b")] b
        };


    }

}
