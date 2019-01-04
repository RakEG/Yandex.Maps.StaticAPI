namespace Yandex.Maps.StaticAPI.PT
{
    /// <summary>
    /// Базовый класс для меток
    /// </summary>
    abstract public class MarkBase
    {
        /// <summary>
        /// Координаты метки
        /// </summary>
        protected Point _point;

        /// <summary>
        /// Базовая метка
        /// </summary>
        /// <param name="lat">Широта метки</param>
        /// <param name="lon">Долгота метки</param>
        public MarkBase(double lat, double lon)
        {
            _point = new Point(lat, lon);
        }

        /// <summary>
        /// Получить часть URL
        /// </summary>
        abstract public string GetPartUrl();

        /// <summary>
        /// Широта метки
        /// </summary>
        public double Lat
        {
            get { return _point.Lat; }
            set { _point.Lat = value; }
        }

        /// <summary>
        /// Долгота метки
        /// </summary>
        public double Lon
        {
            get { return _point.Lon; }
            set { _point.Lon = value; }
        }
    }
}
