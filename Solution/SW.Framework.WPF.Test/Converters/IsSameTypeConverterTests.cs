using SW.Framework.WPF.Converters;

namespace SW.Framework.WPF.Test.Converters
{
    [TestClass]
    public class IsSameTypeConverterTests
    {
        [TestMethod]
        [DataRow("hello", typeof(string), true)]
        [DataRow("hello", typeof(int), false)]
        public void ConversionTest(object input, Type referenceType, bool result)
        {
            IsSameTypeConverter converter = new();

            object output = converter.Convert(input, typeof(bool), referenceType, System.Globalization.CultureInfo.CurrentCulture);

            Assert.AreEqual(output, result);
        }
    }
}
