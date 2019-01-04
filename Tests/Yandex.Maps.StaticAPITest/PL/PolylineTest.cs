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
    class PolylineTest
    {
        List<Point> _listPoint;
        Point p1 = new Point(53.15954894, 93.984847416);
        Point p2 = new Point(54.15954894, 93.984847416);
        Point p3 = new Point(54.15954894, 94.984847416);
        Point p4 = new Point(53.15954894, 94.984847416);

        public PolylineTest()
        {
            _listPoint = new List<Point>() { p1, p2, p3, p4 };
            //_listPoint = new List<Point>();
            //_listPoint.Add(new Point());
        }

        [Test]
        public void PlPolylineIntilizationStandart()
        {
            Polyline Polyline = new Polyline(_listPoint);
            string expected = $"c:{Polyline.Color},w:{Polyline.Width},";

            foreach (Point pol in _listPoint)
            {
                expected += $"{pol.Lon.ToString().Replace(',', '.')}" +
                $",{pol.Lat.ToString().Replace(',', '.')},";
            }
            expected = expected.TrimEnd(',');

            Assert.AreEqual(expected, Polyline.GetPartUrl());
        }

        [Test]
        public void PlPolylineIntilizationFull()
        {
            string color = "22DDC088";
            int width = 3;

            Polyline Polyline = new Polyline(color, width, _listPoint);
            string expected = $"c:{color},w:{width},";

            foreach (Point pol in _listPoint)
            {
                expected += $"{pol.Lon.ToString().Replace(',', '.')}" +
                $",{pol.Lat.ToString().Replace(',', '.')},";
            }
            expected = expected.TrimEnd(',');

            Assert.AreEqual(expected, Polyline.GetPartUrl());
        }
    }
}
