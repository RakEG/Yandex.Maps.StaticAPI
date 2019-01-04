using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Maps.StaticAPI;

namespace YandexMapsStaticApiTest
{
    [TestFixture]
    class SizeTest
    {
        int h_def = 450;
        int h_max = 450;
        int w_def = 450;
        int w_max = 650;

        [Test]
        public void SizeGetPartUrlStandart()
        {
            int h = 400;
            int w = 350;

            Size Size = new Size(h, w);
            string result = $"size={w},{h}";

            Assert.AreEqual(result, Size.GetPartUrl());
        }

        [Test]
        public void SizeGetPartUrlNegative()
        {
            int h = -400;
            int w = -350;

            Size Size = new Size(h,w);
            string result = $"size={w_def},{h_def}";

            Assert.AreEqual(result, Size.GetPartUrl());
        }

        [Test]
        public void SizeGetPartUrlMax()
        {
            int h = 700;
            int w = 800;

            Size Size = new Size(h, w);
            string result = $"size={w_max},{h_max}";

            Assert.AreEqual(result, Size.GetPartUrl());
        }

        [Test]
        public void SizeIntilizationUserString()
        {
            string expected = "size=";
            Size Size = new Size("UserString");
            expected += "UserString";
            Assert.AreEqual(expected, Size.GetPartUrl());
        }
    }
}
