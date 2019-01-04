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
    class LTest
    {
        [Test]
        public void LGetPartUrlMap1()
        {
            L L = new L(true, false, true, true, true);
            string result = "l=map,trf,skl";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlMap2()
        {
            L L = new L(true, false, false, true, true);
            string result = "l=map,trf";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlMap3()
        {
            L L = new L(true, false, true, false, true);
            string result = "l=map,skl";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlMap4()
        {
            L L = new L(true, false, true, true, false);
            string result = "l=map,skl,trf";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlMap5()
        {
            L L = new L(true, false, false, false, false);
            string result = "l=map";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlSat1()
        {
            L L = new L(false, true, true, true, true);
            string result = "l=sat,trf,skl";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlSat2()
        {
            L L = new L(false, true, false, true, true);
            string result = "l=sat,trf";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlSat3()
        {
            L L = new L(false, true, true, false, true);
            string result = "l=sat,skl";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlSat4()
        {
            L L = new L(false, true, true, true, false);
            string result = "l=sat,skl,trf";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LGetPartUrlSat5()
        {
            L L = new L(false, true, false, false, false);
            string result = "l=sat";

            Assert.AreEqual(result, L.GetPartUrl());
        }

        [Test]
        public void LIntilizationUserString()
        {
            string expected = "l=";
            L L = new L("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, L.GetPartUrl());
        }
    }
}
