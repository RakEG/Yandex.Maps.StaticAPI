using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yandex.Maps.StaticAPI.PL
{
    /// <summary>
    /// Ломаная линия состоит из набора вершин, последовательно соединенных отрезками прямой. 
    /// </summary>
    public class Polyline
    {
        const string _colorDefault= "8822DDC0";//RGBA
        string _color;//RGBA
        const int _widthDefault = 5;
        int _width;
        List<Point> _listPoint = new List<Point>();

        /// <summary>
        /// Линия (полилиния)
        /// </summary>
        /// <param name="colorRGBA">Шестнадцатеричное представление цвета линии в формате RGBA (вида 0xFFFFFFFF). Первые 6 символов задают цвет в системе RGB, последующие два - прозрачность линии. Значение прозрачности лежит в диапазоне от 00 (прозрачная) до FF (непрозрачная)</param>
        /// <param name="width">Толщина линии (в пикселах)</param>
        /// <param name="listPoint">Коллекция точек</param>
        public Polyline(string colorRGBA, int width, List<Point> listPoint)
        {
            Color = colorRGBA;
            Width = width;
            _listPoint = listPoint;
        }

        /// <summary>
        /// Линия (полилиния)
        /// </summary>
        /// <param name="listPoint">Коллекция точек</param>
        public Polyline(List<Point> listPoint) : this(_colorDefault, _widthDefault, listPoint) { }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public virtual string GetPartUrl()
        {
            string str = "";

            str += "c:" + _color + ",";
            str += "w:" + _width + ",";

            //проверка на количество точек, и неравенство первой и второй точки
            if (_listPoint.Count >= 2 && _listPoint.ElementAt(0) != _listPoint.ElementAt(1))
            {
                foreach (Point p in _listPoint)
                {
                    str += p.Lon.ToString().Replace(',', '.') + ",";
                    str += p.Lat.ToString().Replace(',', '.') + ",";
                }
                str = str.TrimEnd(',');
            }
            else
            {
                str = "";
            }

            return str;
        }

        /// <summary>
        /// Шестнадцатеричное представление цвета линии в формате RGBA (вида 0xFFFFFFFF). Первые 6 символов задают цвет в системе RGB, последующие два - прозрачность линии. Значение прозрачности лежит в диапазоне от 00 (прозрачная) до FF (непрозрачная).
        /// </summary>
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                Regex regex = new Regex(@"([a-fA-F]|[0-9])");
                MatchCollection matches = regex.Matches(value);

                if (matches.Count == 8 & value.Count() == 8)
                {
                    _color = value;
                }
                else
                {
                    _color = _colorDefault;
                }
            }
        }

        /// <summary>
        /// Толщина линии (в пикселах).
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > 0)
                    _width = value;
                else
                    _width = _widthDefault;
            }
        }

        /// <summary>
        /// Коллекция точек (координат ломаной)
        /// </summary>
        private List<Point> ListPoint
        {
            get
            {
                return _listPoint;
            }
            set
            {
                if (value.Count > 1)
                    _listPoint = value;
                else
                    _listPoint = new List<Point>();
            }
        }
    }
}
