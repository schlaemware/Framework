using SW.Framework.WPF.Converters;

namespace SW.Framework.WPF.Test.Converters
{
    [TestClass]
    public class UpperStringConverterTests
    {
        [TestMethod]
        [DataRow("hello", "HELLO")]
        public void ConversionTest(string input, string result)
        {
            UpperStringConverter converter = new();

            object output = converter.Convert(input, typeof(string), new(), System.Globalization.CultureInfo.CurrentCulture);

            Assert.AreEqual(output, result);
        }
    }
}
