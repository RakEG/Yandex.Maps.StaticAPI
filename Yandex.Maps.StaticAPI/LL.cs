namespace Yandex.Maps.StaticAPI
{
    /// <summary>
    /// Долгота и широта центра карты в градусах
    /// </summary>
    public class LL
    {
        string _userString = "";//для конструктора с полностью пользовательской строкой
        Point _mapCenterPoint;

        /// <summary>
        /// Долгота и широта центра карты в градусах
        /// </summary>
        /// <param name="latMapCenter">Широта центра карты в гралусах</param>
        /// <param name="lonMapCenter">Долгота центра карты в гралусах</param>
        public LL(double latMapCenter, double lonMapCenter)
        {
            _mapCenterPoint = new Point(latMapCenter, lonMapCenter);
        }

        /// <summary>
        /// Передача параметров в виде сформированной строки (все остальные объекты класса игнорируются)
        /// </summary>
        /// <param name="userString">Строка с параметрами</param>
        public LL(string userString)
        {
            _userString = userString;
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        /// <returns></returns>
        public string GetPartUrl()
        {
            string str = "ll=";

            if (_userString == "")
            {
                str += _mapCenterPoint.Lon.ToString().Replace(',', '.') +
                "," +
                _mapCenterPoint.Lat.ToString().Replace(',', '.');
            }
            else
                str += _userString;

            return str;
        }

        /// <summary>
        /// Широта центра карты
        /// </summary>
        public double LatMapCenter
        {
            get { return _mapCenterPoint.Lat; }
            set { _mapCenterPoint.Lat = value; }
        }

        /// <summary>
        /// Долгота центра карты
        /// </summary>
        public double LonMapCenter
        {
            get { return _mapCenterPoint.Lon; }
            set { _mapCenterPoint.Lon = value; }
        }
    }

}
