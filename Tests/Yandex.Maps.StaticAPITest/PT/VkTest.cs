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
    class VkTest
    {
        double lat = 53.1565165498;
        double lon = 93.5611612361;

        [Test]
        public void PtFlagGetPartUrlDefaultBk()
        {
            Vk Vk = new Vk(lat, lon,Vk.Color.bk);

            string result = $"{Vk.Lon.ToString().Replace(',', '.')}" +
                $",{Vk.Lat.ToString().Replace(',', '.')}," +
                $"vkbkm";

            Assert.AreEqual(result, Vk.GetPartUrl());
        }

        [Test]
        public void PtFlagGetPartUrlDefaultGr()
        {
            Vk Vk = new Vk(lat, lon, Vk.Color.gr);

            string result = $"{Vk.Lon.ToString().Replace(',', '.')}" +
                $",{Vk.Lat.ToString().Replace(',', '.')}," +
                $"vkgrm";

            Assert.AreEqual(result, Vk.GetPartUrl());
        }
    }
}
