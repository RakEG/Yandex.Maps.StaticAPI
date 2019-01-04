using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Yandex.Maps.StaticAPI;
using Yandex.Maps.StaticAPI.PT;

namespace YandexMapsStaticApiTest.PT
{
    [TestFixture]
    class FlagTest
    {
        double lat = 53.1565165498;
        double lon = 93.5611612361;

        [Test]
        public void PtFlagGetPartUrlDefault()
        {
            Flag Flag = new Flag(lat, lon);

            string result = $"{Flag.Lon.ToString().Replace(',', '.')}" +
                $",{Flag.Lat.ToString().Replace(',', '.')}," +
                $"flag";

            Assert.AreEqual(result, Flag.GetPartUrl());
        }
    }
}
