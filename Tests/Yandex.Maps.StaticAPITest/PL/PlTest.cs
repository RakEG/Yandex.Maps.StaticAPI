using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Yandex.Maps.StaticAPI;
using Yandex.Maps.StaticAPI.PL;

namespace YandexMapsStaticApiTest.PL
{
    [TestFixture]
    class PlTest
    {
        [Test]
        public void PlIntilizationUserString()
        {
            string expected = "pl=";
            Pl Pl = new Pl("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, Pl.GetPartUrl());
        }
    }
}