using SW.Framework.Support;

namespace SW.Framework.Test.Support
{
    [TestClass]
    public class RegexExpressionsTests
    {
        [TestMethod]
        [DataRow("", false, DisplayName = "Empty")]
        [DataRow("testing", false, DisplayName = "testing")]
        [DataRow("test.ing", false, DisplayName = "test.ing")]
        [DataRow("test@ing", false, DisplayName = "test@ing")]
        [DataRow("test@in.g", false, DisplayName = "test@in.g")]
        [DataRow("tes@ti.ng", true, DisplayName = "tes@ti.ng")]
        [DataRow("a@b.com", true, DisplayName = "a@b.com")]
        [DataRow("1@2.com", true, DisplayName = "1@2.com")]
        [DataRow("hello@world.swiss", true, DisplayName = "hello@world.swiss")]
        public void ValidateMailRegexTest(string input, bool expected)
        {
            bool result = RegexExpressions.ValidateMailRegex().IsMatch(input);

            Assert.AreEqual(expected, result);
        }
    }
}
