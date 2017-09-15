using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170915_ParseHTMLCSSColors
{
    [TestClass]
    public class HtmlColorParserTests
    {
        [TestMethod]
        public void input_000000_should_return_0_0_0()
        {
            ColorParserShouldbe(new RGB(0, 0, 0), "#000000");
        }

        [TestMethod]
        public void input_010101_should_return_1_1_1()
        {
            ColorParserShouldbe(new RGB(1, 1, 1), "#010101");
        }

        [TestMethod]
        public void input_0A0A0A_should_return_10_10_10()
        {
            ColorParserShouldbe(new RGB(10, 10, 10), "#0A0A0A");
        }

        [TestMethod]
        public void input_FFFFFF_should_return_255_255_255()
        {
            ColorParserShouldbe(new RGB(255, 255, 255), "#FFFFFF");
        }

        [TestMethod]
        public void input_111_should_return_17_17_17()
        {
            ColorParserShouldbe(new RGB(17, 17, 17), "#111");
        }

        [TestMethod]
        public void input_FFF_should_return_255_255_255()
        {
            ColorParserShouldbe(new RGB(255, 255, 255), "#FFF");
        }

        [TestMethod]
        public void input_LimeGreen_should_return_50_205_50()
        {
            ColorParserShouldbe(new RGB(50, 205, 50), "LimeGreen");
        }

        private static void ColorParserShouldbe(RGB expected, string color)
        {
            var parser = new HtmlColorParser();
            var actual = parser.Parse(color);
            Assert.AreEqual(expected.r, actual.r);
            Assert.AreEqual(expected.g, actual.g);
            Assert.AreEqual(expected.b, actual.b);
        }
    }

    public class HtmlColorParser
    {
        private readonly IDictionary<string, string> presetColors;

        public HtmlColorParser()
        {
            this.presetColors = new Dictionary<string, string>
            {
                {"limegreen", "#32CD32"}
            };
        }

        public RGB Parse(string color)
        {
            color = color.StartsWith("#") ? color : presetColors[color.ToLower()];

            var rString = color.Length == 7 ? color.Substring(1, 2) : new string(color[1], 2);
            var gString = color.Length == 7 ? color.Substring(3, 2) : new string(color[2], 2);
            var bString = color.Length == 7 ? color.Substring(5, 2) : new string(color[3], 2);

            var r = Convert.ToByte(rString, 16);
            var g = Convert.ToByte(gString, 16);
            var b = Convert.ToByte(bString, 16);

            return new RGB(r, g, b);
        }
    }

    public class RGB
    {
        public readonly byte r;
        public readonly byte g;
        public readonly byte b;

        public RGB(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
