using SW.Framework.Security;

namespace SW.Framework.Test.Security
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void HashTest()
        {
            Random random = new();
            string origin = Guid.NewGuid().ToString();
            PasswordHasher hasher = new(new HashingOptions(random.Next(1000000)));

            string hashedPassword = hasher.Hash(origin);

            Assert.IsTrue(hashedPassword != origin);
        }

        [TestMethod]
        public void CheckFailTest()
        {
            Random random = new();
            PasswordHasher hasher = new(new HashingOptions(random.Next(1000000)));

            (bool verified, bool _) = hasher.Check("781219.0D0EavItjr6jETDiGkrTQA==.Kl+fKjN5ZLtOCFIWdnCGfnLlAbKRuBIcnd5nbOUrVjI=", Guid.NewGuid().ToString());

            Assert.IsFalse(verified);
        }

        [TestMethod]
        public void CheckSuccessTest()
        {
            Random random = new();
            string origin = Guid.NewGuid().ToString();
            PasswordHasher hasher = new(new HashingOptions(random.Next(1000000)));

            string hash = hasher.Hash(origin);
            (bool verified, bool needsUpdate) = hasher.Check(hash, origin);

            Assert.IsTrue(verified);
            Assert.IsFalse(needsUpdate);
        }

        [TestMethod]
        public void CheckSuccessWithNeedsUpdateTest()
        {
            Random random = new();
            string origin = Guid.NewGuid().ToString();
            int iterationsA = random.Next(1000000);
            PasswordHasher hasher = new(new HashingOptions(iterationsA));

            string hash = hasher.Hash(origin);

            int iterationsB = random.Next(1000000);
            hasher = new(new HashingOptions(iterationsB));
            (bool verified, bool needsUpdate) = hasher.Check(hash, origin);

            Assert.IsTrue(verified);
            Assert.IsTrue(needsUpdate != (iterationsA == iterationsB));
        }
    }
}
