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
    class PmTest
    {
        double lat = 53.1565165498;
        double lon = 93.5611612361;

        [Test]
        public void PtPmGetPartUrlDefault()
        {
            Pm Pm = new Pm(lat, lon);

            string result = $"{Pm.Lon.ToString().Replace(',', '.')}" +
                $",{Pm.Lat.ToString().Replace(',', '.')}," +
                $"pmwtm";

            Assert.AreEqual(result, Pm.GetPartUrl());
        }

        [Test]
        public void PtPmGetPartUrlFull()
        {
            Pm Pm = new Pm(lat, lon, Pm.Color.yw,Pm.Size.s,5);

            string result = $"{Pm.Lon.ToString().Replace(',', '.')}" +
                $",{Pm.Lat.ToString().Replace(',', '.')}," +
                $"pmyws5";

            Assert.AreEqual(result, Pm.GetPartUrl());
        }

        [Test]
        public void PtPmGetPartUrlAb()
        {
            Pm Pm = new Pm(lat, lon, Pm.AB.b);

            string result = $"{Pm.Lon.ToString().Replace(',', '.')}" +
                $",{Pm.Lat.ToString().Replace(',', '.')}," +
                $"pmb";

            Assert.AreEqual(result, Pm.GetPartUrl());
        }

        [Test]
        public void PtPmGetPartUrlFullContentMin()
        {
            Pm Pm = new Pm(lat, lon, Pm.Color.do_, Pm.Size.l, 0);

            string result = $"{Pm.Lon.ToString().Replace(',', '.')}" +
                $",{Pm.Lat.ToString().Replace(',', '.')}," +
                $"pmdol";

            Assert.AreEqual(result, Pm.GetPartUrl());
        }

        [Test]
        public void PtPmGetPartUrlFullContentMax()
        {
            Pm Pm = new Pm(lat, lon, Pm.Color.or, Pm.Size.m, 100);

            string result = $"{Pm.Lon.ToString().Replace(',', '.')}" +
                $",{Pm.Lat.ToString().Replace(',', '.')}," +
                $"pmorm";

            Assert.AreEqual(result, Pm.GetPartUrl());
        }
    }
}
