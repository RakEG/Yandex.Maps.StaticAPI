using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Maps.StaticAPI;

namespace YandexMapsStaticApiTest
{
    [TestFixture]
    class SpnTest
    {
        double dLat_max = 90;
        double dLat_def = 0.01;
        double dLon_max = 180;
        double dLon_def = 0.01;

        [Test]
        public void SpnGetPartUrlStandart()
        {
            double dLat = 53.1235654456;
            double dLon = 93.5498495156;

            Spn Spn = new Spn(dLat, dLon);
            string result = $"spn={dLon.ToString().Replace(',', '.')}" +
                $",{dLat.ToString().Replace(',', '.')}";

            Assert.AreEqual(result, Spn.GetPartUrl());
        }

        [Test]
        public void SpnGetPartUrlNegative()
        {
            double dLat = -1;
            double dLon = -0.005;

            Spn Spn = new Spn(dLat, dLon);
            string result = $"spn={dLon_def.ToString().Replace(',', '.')}" +
                $",{dLat_def.ToString().Replace(',', '.')}";

            Assert.AreEqual(result, Spn.GetPartUrl());
        }

        [Test]
        public void SpnGetPartUrlMax()
        {
            double dLat = 91;
            double dLon = 181;

            Spn Spn = new Spn(dLat, dLon);
            string result = $"spn={dLon_max.ToString().Replace(',', '.')}" +
                $",{dLat_max.ToString().Replace(',', '.')}";

            Assert.AreEqual(result, Spn.GetPartUrl());
        }

        [Test]
        public void SpnIntilizationUserString()
        {
            string expected = "spn=";
            Spn Spn = new Spn("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, Spn.GetPartUrl());
        }
    }
}
