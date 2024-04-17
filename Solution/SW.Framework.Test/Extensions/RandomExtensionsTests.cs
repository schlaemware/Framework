using SW.Framework.Extensions;

namespace SW.Framework.Test.Extensions
{
    [TestClass]
    public class RandomExtensionsTests
    {
        [TestMethod]
        [Timeout(1000)]
        public void NextBooleanTest()
        {
            Random random = new();
            bool checkTrue = false;
            bool checkFalse = false;

            while (!checkTrue || !checkFalse) {
                if (random.NextBoolean()) {
                    checkTrue = true;
                }
                else {
                    checkFalse = true;
                }
            }
        }

        [TestMethod]
        public void NextDateTimeTest()
        {
            Random random = new();

            DateTime result = random.NextDateTime();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NextDateTimePastTest()
        {
            Random random = new();

            DateTime result = random.NextDateTimePast();

            Assert.IsTrue(result < DateTime.Now);
        }

        [TestMethod]
        [DataRow(2020, 1, 1)]
        [DataRow(2021, 1, 1)]
        [DataRow(2022, 1, 1)]
        public void NextDateTimePastExplicitTest(int year, int month, int day)
        {
            Random random = new();
            DateTime from = new(year, month, day);

            DateTime result = random.NextDateTimePast(from);

            Assert.IsTrue(from <= result);
            Assert.IsTrue(result < DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDateTimePastInvalidDateTest()
        {
            Random random = new();
            DateTime from = DateTime.Now.AddYears(1);

            DateTime result = random.NextDateTimePast(from);

            Assert.Fail();
        }

        [TestMethod]
        public void NextDateTimeFutureTest()
        {
            Random random = new();

            DateTime result = random.NextDateTimeFuture();

            Assert.IsTrue(result >= DateTime.Now);
        }

        [TestMethod]
        [DataRow(3020, 1, 1)]
        [DataRow(3021, 1, 1)]
        [DataRow(3022, 1, 1)]
        public void NextDateTimeFutureExplicitTest(int year, int month, int day)
        {
            Random random = new();
            DateTime until = new(year, month, day);

            DateTime result = random.NextDateTimeFuture(until);

            Assert.IsTrue(until >= result);
            Assert.IsTrue(result >= DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDateTimeFutureInvalidDateTest()
        {
            Random random = new();
            DateTime from = DateTime.Now.AddYears(-1);

            _ = random.NextDateTimeFuture(from);

            Assert.Fail();
        }

        [TestMethod]
        public void NextDateTimeRangeTest()
        {
            Random random = new();
            DateTime from = DateTime.Now;
            DateTime until = from.AddSeconds(1);

            DateTime result = random.NextDateTime(from, until);

            Assert.IsTrue(from <= result && result < until);
        }

        [TestMethod]
        public void NextStringTest()
        {
            Random random = new();

            string result = random.NextString();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(10, 10)]
        [DataRow(10, 11)]
        [DataRow(10, 100)]
        [DataRow(-10, 100)]
        [DataRow(10, -100)]
        public void NextStringRangeTest(int min, int max)
        {
            Random random = new();

            string result = random.NextString(min, max);

            if (min > max) {
                (min, max) = (max, min);
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(min <= result.Length);
            if (min == max) {
                Assert.IsTrue(result.Length == max);
            }
            else {
                Assert.IsTrue(result.Length < max);
            }
        }

        [TestMethod]
        [DataRow(-10, -10)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextStringRangeInvalidTest(int min, int max)
        {
            Random random = new();

            _ = random.NextString(min, max);

            Assert.Fail();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(1000)]
        public void NextStringLengthTest(int length)
        {
            Random random = new();

            string result = random.NextString(length);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == length);
        }

        [TestMethod]
        [DataRow(int.MinValue)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextStringInvalidLengthTest(int length)
        {
            Random random = new();

            string result = random.NextString(length);

            Assert.Fail();
        }

        [TestMethod]
        public void NextFirstNameTest()
        {
            Random random = new();

            string result = random.NextFirstname();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void NextLastNameTest()
        {
            Random random = new();

            string result = random.NextLastname();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void NextNameTest()
        {
            Random random = new();

            (string Firstname, string Lastname) result = random.NextName();

            Assert.IsFalse(string.IsNullOrEmpty(result.Firstname));
            Assert.IsFalse(string.IsNullOrEmpty(result.Lastname));
        }

        [TestMethod]
        public void NextPersonTest()
        {
            Random random = new();

            (string Firstname, string Lastname, DateOnly Birthdate) result = random.NextPerson();

            Assert.IsFalse(string.IsNullOrEmpty(result.Firstname));
            Assert.IsFalse(string.IsNullOrEmpty(result.Lastname));
            Assert.IsTrue(result.Birthdate <= DateOnly.FromDateTime(DateTime.Now));
        }
    }
}