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
    class PtTest
    {

        [Test]
        public void PtIntilizationUserString()
        {
            string expected = "pt=";
            Pt Pt = new Pt("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, Pt.GetPartUrl());
        }
    }
}
