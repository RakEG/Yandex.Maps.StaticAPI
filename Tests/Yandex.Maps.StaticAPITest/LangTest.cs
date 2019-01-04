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
    class LangTest
    {
        [Test]
        public void LangIntilization()
        {
            string expected = "lang=";
            Lang Lang = new Lang(Lang.Lang_reg.en_RU);
            expected+= "en_RU";
            Assert.AreEqual(expected, Lang.GetPartUrl());
        }

        [Test]
        public void LangIntilizationUserString()
        {
            string expected = "lang=";
            Lang Lang = new Lang("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, Lang.GetPartUrl());
        }
    }
}
