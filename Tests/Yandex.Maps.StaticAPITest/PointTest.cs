using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Yandex.Maps.StaticAPI;

namespace YandexMapsStaticApiTest
{
    [TestFixture]
    class PointTest
    {
        double _lat_min=-84.99;
        double _lat_max = 84.99;
        double _lon_min=-179.99;
        double _lon_max = 179.99;

        Point p1 = new Point(56.013076, 92.844363);
        Point p2 = new Point(56.012805, 92.860652);
        Point p3 = new Point(56.035243, 92.803918);
        Point p4 = new Point(56.026938, 92.811484);

        Point p1d = new Point(56.013076, 92.844363);
        Point p2d = new Point(56.012805, 92.860652);

        [Test]
        public void PointIntilizationStandart()
        {
            double lat = 53.1235654456;
            double lon = 93.5498495156;

            Point Point = new Point(lat, lon);

            Assert.AreEqual(lat, Point.Lat);
            Assert.AreEqual(lon, Point.Lon);
        }

        [Test]
        public void PointIntilizationNegative()
        {
            double lat = -90;
            double lon = -180;

            Point Point = new Point(lat, lon);

            Assert.AreEqual(_lat_min, Point.Lat);
            Assert.AreEqual(_lon_min, Point.Lon);
        }

        [Test]
        public void PointIntilizationMax()
        {
            double lat = 90;
            double lon = 180;

            Point Point = new Point(lat, lon);

            Assert.AreEqual(_lat_max, Point.Lat);
            Assert.AreEqual(_lon_max, Point.Lon);
        }

        [Test]
        public void PointEquality()
        {
            Assert.AreEqual(p1,p1d);
            Assert.AreEqual(p2, p2d);
        }

        [Test]
        public void PointInequality()
        {
            Assert.AreNotEqual(p1, p2);
            Assert.AreNotEqual(p1, p3);
            Assert.AreNotEqual(p1, p4);
            Assert.AreNotEqual(p2, p1);
            Assert.AreNotEqual(p2, p3);
            Assert.AreNotEqual(p2, p4);
            Assert.AreNotEqual(p3, p1);
            Assert.AreNotEqual(p3, p2);
            Assert.AreNotEqual(p3, p4);
            Assert.AreNotEqual(p4, p1);
            Assert.AreNotEqual(p4, p2);
            Assert.AreNotEqual(p4, p3);
        }

    }
}
