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
    class BboxTest
    {
        double latTopLeft = 53.1565165498;
        double lonTopLeft = 93.5611612361;
        double latDownRigth = 52.1565165498;
        double lonDownRigth = 94.5611612361;

        [Test]
        public void BboxGetPartUrlStandart1()
        {
            Bbox Bbox = new Bbox(new Point(latTopLeft, lonTopLeft), new Point(latDownRigth, lonDownRigth));

            string result = $"bbox={Bbox.TopLeftPointLon.ToString().Replace(',', '.')}" +
                $",{Bbox.TopLeftPointLat.ToString().Replace(',', '.')}~" +
                $"{Bbox.DownRightPointLon.ToString().Replace(',', '.')}" +
                $",{Bbox.DownRightPointLat.ToString().Replace(',', '.')}";

            Assert.AreEqual(result, Bbox.GetPartUrl());
        }

        [Test]
        public void BboxGetPartUrlStandart2()
        {
            Bbox Bbox = new Bbox(latTopLeft, lonTopLeft,latDownRigth, lonDownRigth);

            string result = $"bbox={Bbox.TopLeftPointLon.ToString().Replace(',', '.')}" +
                $",{Bbox.TopLeftPointLat.ToString().Replace(',', '.')}~" +
                $"{Bbox.DownRightPointLon.ToString().Replace(',', '.')}" +
                $",{Bbox.DownRightPointLat.ToString().Replace(',', '.')}";

            Assert.AreEqual(result, Bbox.GetPartUrl());
        }

        [Test]
        public void BboxIntilizationUserString()
        {
            string expected = "bbox=";
            Bbox Bbox = new Bbox("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, Bbox.GetPartUrl());
        }
    }
}
