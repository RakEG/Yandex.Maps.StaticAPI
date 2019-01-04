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
    class Pm2Test
    {
        double lat = 53.1565165498;
        double lon = 93.5611612361;

        [Test]
        public void PtPm2GetPartUrlDefault()
        {
            Pm2 Pm2 = new Pm2(lat, lon);

            string result = $"{Pm2.Lon.ToString().Replace(',', '.')}" +
                $",{Pm2.Lat.ToString().Replace(',', '.')}," +
                $"pm2wtm";

            Assert.AreEqual(result, Pm2.GetPartUrl());
        }

        [Test]
        public void PtPm2GetPartUrlFull()
        {
            Pm2 Pm2 = new Pm2(lat, lon, Pm2.Color.yw, Pm2.Size.l, 99);

            string result = $"{Pm2.Lon.ToString().Replace(',', '.')}" +
                $",{Pm2.Lat.ToString().Replace(',', '.')}," +
                $"pm2ywl99";

            Assert.AreEqual(result, Pm2.GetPartUrl());
        }

        [Test]
        public void PtPm2GetPartUrlBlyw()
        {
            Pm2 Pm2 = new Pm2(lat, lon, Pm2.Color.blyw,Pm2.Size.m,1);

            string result = $"{Pm2.Lon.ToString().Replace(',', '.')}" +
                $",{Pm2.Lat.ToString().Replace(',', '.')}," +
                $"pm2blywm1";

            Assert.AreEqual(result, Pm2.GetPartUrl());
        }

        [Test]
        public void PtPm2GetPartUrlFullContentMin()
        {
            Pm2 Pm2 = new Pm2(lat, lon, Pm2.Color.do_, Pm2.Size.l, 0);

            string result = $"{Pm2.Lon.ToString().Replace(',', '.')}" +
                $",{Pm2.Lat.ToString().Replace(',', '.')}," +
                $"pm2dol";

            Assert.AreEqual(result, Pm2.GetPartUrl());
        }

        [Test]
        public void PtPm2GetPartUrlFullContentMax()
        {
            Pm2 Pm2 = new Pm2(lat, lon, Pm2.Color.or, Pm2.Size.m, 100);

            string result = $"{Pm2.Lon.ToString().Replace(',', '.')}" +
                $",{Pm2.Lat.ToString().Replace(',', '.')}," +
                $"pm2orm";

            Assert.AreEqual(result, Pm2.GetPartUrl());
        }
    }
}
