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
    class LLTest
    {
        [Test]
        public void LLGetPartUrlStandart()
        {
            double lat = 53.1565165498;
            double lon = 93.5611612361;

            LL LL = new LL(lat,lon);

            string result = $"ll={LL.LonMapCenter.ToString().Replace(',', '.')}" +
                $",{LL.LatMapCenter.ToString().Replace(',', '.')}";

            Assert.AreEqual(result, LL.GetPartUrl());
        }

        [Test]
        public void LLIntilizationUserString()
        {
            string expected = "ll=";
            LL LL = new LL("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, LL.GetPartUrl());
        }
    }
}
