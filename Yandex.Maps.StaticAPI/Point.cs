using System;

namespace Yandex.Maps.StaticAPI
{
    public class Point : IEquatable<Point>/*, IComparer<Point>*/
    {
        protected double _lat;
        protected double _lon;

        double _lat_min = -84.99;
        double _lat_max = 84.99;
        double _lon_min = -179.99;
        double _lon_max = 179.99;

        /// <summary>
        /// Создание точки по координатам
        /// </summary>
        /// <param name="lat">Широта точки от -84.99 до 84.99</param>
        /// <param name="lon">Долгота точки от -179.99 до 179.99</param>
        public Point(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }

        /// <summary>
        /// Широта точки
        /// </summary>
        public double Lat
        {
            get { return _lat; }
            set
            {
                if (value > _lat_min & value < _lat_max)
                {
                    _lat = value;
                }
                else if (value <= _lat_min)
                {
                    _lat = _lat_min;
                }
                else if (value >= _lat_max)
                {
                    _lat = _lat_max;
                }
            }
        }

        /// <summary>
        /// Долгота точки
        /// </summary>
        public double Lon
        {
            get { return _lon; }
            set
            {
                if (value > _lon_min & value < _lon_max)
                {
                    _lon = value;
                }
                else if (value <= _lon_min)
                {
                    _lon = _lon_min;
                }
                else if (value >= _lon_max)
                {
                    _lon = _lon_max;
                }
            }
        }

        //public int Compare(Point x, Point y)
        //{
        //    throw new NotImplementedException();
        //}

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;

            Point Point = (Point)obj;
            return Equals((Point)obj);
        }

        //вроде как не лучшая реализация
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + _lat.GetHashCode();
            hash = hash * 31 + _lon.GetHashCode();
            return hash;
        }

        public bool Equals(Point Point)
        {
            return (this._lat == Point.Lat && this._lon == Point.Lon);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if (p1._lat == p2._lat && p1._lon == p2._lon)
                return true;
            else
                return false;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            if (!(p1._lat == p2._lat && p1._lon == p2._lon))
                return true;
            else
                return false;
        }
    }
}
