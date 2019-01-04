using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Yandex.Maps.StaticAPI.PL
{
    /// <summary>
    /// Многоугольник задается одной или несколькими замкнутыми ломаными.
    /// </summary>
    public class Polygon : Polyline
    {
        const string _backgroundColorDefault = "00FF00A0";//RGBA
        string _backgroundColor;
        List<List<Point>> _listListPoint = new List<List<Point>>();

        /// <summary>
        /// Многоугольник
        /// </summary>
        /// <param name="colorRGBA">Шестнадцатеричное представление цвета линии в формате RGBA (вида 0xFFFFFFFF). Первые 6 символов задают цвет в системе RGB, последующие два - прозрачность линии. Значение прозрачности лежит в диапазоне от 00 (прозрачная) до FF (непрозрачная)</param>
        /// <param name="backgroundColorRGBA">Шестнадцатеричное представление цвета заливки в формате RGBA (вида 0xFFFFFFFF). Первые 6 символов задают цвет в системе RGB, последующие два - прозрачность линии. Значение прозрачности лежит в диапазоне от 00 (прозрачная) до FF (непрозрачная)</param>
        /// <param name="width">Толщина линии (в пикселах)</param>
        /// <param name="arrListPoint">Массив коллекций точек</param>
        public Polygon(string colorRGBA, string backgroundColorRGBA, int width, params List<Point>[] arrListPoint) : base(colorRGBA, width, null)
        {
            BackgroundColor = backgroundColorRGBA;
            _listListPoint = arrListPoint.ToList();
        }

        /// <summary>
        /// Многоугольник
        /// </summary>
        /// <param name="arrListPoint">Коллекция точек</param>
        public Polygon(params List<Point>[] arrListPoint) : this("", _backgroundColorDefault, 0, arrListPoint) { }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public override string GetPartUrl()
        {
            string str = "";

            str += "c:" + Color + ",";
            str += "f:" + BackgroundColor + ",";
            str += "w:" + Width + ",";

            foreach (List<Point> lp in _listListPoint)
            {
                foreach (Point p in lp)
                {
                    str += p.Lon.ToString().Replace(',', '.') + ",";
                    str += p.Lat.ToString().Replace(',', '.') + ",";
                }

                //Если первая и последняя точки не совпадают то замкнуть
                Point ff = lp.First();
                Point f2 = lp.Last();
                bool dfff = ff.Equals(f2);


                if (ff != f2)
                {

                }
                if (lp.First() != lp.Last())
                {
                    Point p = lp.First();
                    str += p.Lon.ToString().Replace(',', '.') + ",";
                    str += p.Lat.ToString().Replace(',', '.') + ",";
                }
                str = str.TrimEnd(',');
                str += ";";
            }
            str = str.TrimEnd(';');

            return str;
        }

        /// <summary>
        /// Шестнадцатеричное представление цвета линии в формате RGBA (вида 0xFFFFFFFF). Первые 6 символов задают цвет в системе RGB, последующие два - прозрачность линии. Значение прозрачности лежит в диапазоне от 00 (прозрачная) до FF (непрозрачная).
        /// </summary>
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                Regex regex = new Regex(@"([a-fA-F]|[0-9])");
                MatchCollection matches = regex.Matches(value);

                if (matches.Count == 8 & value.Count() == 8)
                {
                    _backgroundColor = value;
                }
                else
                {
                    _backgroundColor = _backgroundColorDefault;
                }
            }
        }
    }
}
