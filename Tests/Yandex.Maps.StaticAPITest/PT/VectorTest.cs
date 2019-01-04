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
    class VectorTest
    {
        double lat = 53.1565165498;
        double lon = 93.5611612361;

        [Test]
        public void PtVectorGetPartUrlDefaultComma()
        {
            Vector Vector = new Vector(lat, lon, Vector.mark.comma);

            string result = $"{Vector.Lon.ToString().Replace(',', '.')}" +
                $",{Vector.Lat.ToString().Replace(',', '.')}," +
                $"comma";

            Assert.AreEqual(result, Vector.GetPartUrl());
        }

        [Test]
        public void PtVectorGetPartUrlDefaultYa_ru()
        {
            Vector Vector = new Vector(lat, lon, Vector.mark.ya_ru);

            string result = $"{Vector.Lon.ToString().Replace(',', '.')}" +
                $",{Vector.Lat.ToString().Replace(',', '.')}," +
                $"ya_ru";

            Assert.AreEqual(result, Vector.GetPartUrl());
        }

    }
}
