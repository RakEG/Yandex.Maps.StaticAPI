using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Yandex.Maps.StaticAPI;
using Yandex.Maps.StaticAPI.PT;
using Yandex.Maps.StaticAPI.PL;

namespace YandexMapsStaticApiTest.PL
{
    [TestFixture]
    class PolygonTest
    {
        List<List<Point>> _listlistPoint;
        List<Point> _listPoint1;
        Point p1 = new Point(53.15954894, 93.984847416);
        Point p2 = new Point(54.15954894, 93.984847416);
        Point p3 = new Point(54.15954894, 94.984847416);
        Point p4 = new Point(53.15954894, 94.984847416);
        Point p5 = new Point(53.15954894, 93.984847416);

        List<Point> _listPoint2;
        Point p6 = new Point(63.15954894, 83.984847416);
        Point p7 = new Point(64.15954894, 83.984847416);
        Point p8 = new Point(64.15954894, 84.984847416);
        Point p9 = new Point(63.15954894, 84.984847416);
        Point p10 = new Point(63.15954894, 83.984847416);

        public PolygonTest()
        {
            _listPoint1 = new List<Point>() { p1, p2, p3, p4, p5 };
            _listPoint2 = new List<Point>() { p6, p7, p8, p9, p10 };
            _listlistPoint = new List<List<Point>>() { _listPoint1, _listPoint2 };
        }

        [Test]
        public void PlPolygonIntilizationStandart()
        {
            Polygon Polygon = new Polygon(_listPoint1, _listPoint2);
            string expected = $"c:{Polygon.Color},f:{Polygon.BackgroundColor},w:{Polygon.Width},";

            foreach (List<Point> polCol in _listlistPoint)
            {
                foreach (Point pol in polCol)
                {
                    expected += $"{pol.Lon.ToString().Replace(',', '.')}" +
                    $",{pol.Lat.ToString().Replace(',', '.')},";
                }
                expected = expected.TrimEnd(',');
                expected += ";";
            }
            expected = expected.TrimEnd(';');
            //string sdf = Polygon.GetPartUrl();
            Assert.AreEqual(expected, Polygon.GetPartUrl());
        }
    }
}
