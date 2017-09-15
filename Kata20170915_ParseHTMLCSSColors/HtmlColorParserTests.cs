using System;
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
        public RGB Parse(string color)
        {
            return new RGB(0, 0, 0);
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
