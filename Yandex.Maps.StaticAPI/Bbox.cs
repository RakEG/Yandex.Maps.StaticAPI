namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// В параметре bbox задаются географические координаты углов прямоугольника, ограничивающего область просмотра. Указываются координаты левого нижнего и правого верхнего углов
    /// </summary>
    public class Bbox
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        Point _topLeftPoint;
        Point _downRightPoint;

        /// <summary>
        /// Углы прямоугольника ограничивающего область просмотра
        /// </summary>
        /// <param name="topLeftPoint">Точка верхнего левого угла области просмотра</param>
        /// <param name="downRightPoint">Точка нижнего правого угла области просмотра</param>
        public Bbox(Point topLeftPoint, Point downRightPoint)
        {
            _topLeftPoint = topLeftPoint;
            _downRightPoint = downRightPoint;
        }

        /// <summary>
        /// Углы прямоугольника ограничивающего область просмотра
        /// </summary>
        /// <param name="lat1">Широта верхнего левого угла области просмотра</param>
        /// <param name="lon1">Долгота верхнего левого угла области просмотра</param>
        /// <param name="lat2">Широта нижнего правого угла области просмотра</param>
        /// <param name="lon2">Долгота нижнего правого угла области просмотра</param>
        public Bbox(double lat1, double lon1, double lat2, double lon2) :this(new Point(lat1, lon1), new Point(lat2, lon2)) { }

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public Bbox(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "bbox=";

            if (_userString == "")
            {
                str += _topLeftPoint.Lon.ToString().Replace(',', '.') + ",";
                str += _topLeftPoint.Lat.ToString().Replace(',', '.') + "~";
                str += _downRightPoint.Lon.ToString().Replace(',', '.') + ",";
                str += _downRightPoint.Lat.ToString().Replace(',', '.');
            }
            else
                str += _userString;

            return str;
        }

        /// <summary>
        /// Широта верхней левой границы
        /// </summary>
        public double TopLeftPointLat
        {
            get { return _topLeftPoint.Lat; }
            set { _topLeftPoint.Lat = value; }
        }

        /// <summary>
        /// Долгота верхней левой границы
        /// </summary>
        public double TopLeftPointLon
        {
            get { return _topLeftPoint.Lon; }
            set { _topLeftPoint.Lon = value; }
        }

        /// <summary>
        /// Широта нижней правой границы
        /// </summary>
        public double DownRightPointLat
        {
            get { return _downRightPoint.Lat; }
            set { _downRightPoint.Lat = value; }
        }

        /// <summary>
        /// Долгота нижней правой границы
        /// </summary>
        public double DownRightPointLon
        {
            get { return _downRightPoint.Lon; }
            set { _downRightPoint.Lon = value; }
        }
    }
}
