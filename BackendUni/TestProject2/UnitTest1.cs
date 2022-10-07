using VtbWallet;

namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
         
        }

        [Test]
        public void Test1()
        {
            var res = WalletApi.CreateWallet();

            if (string.IsNullOrWhiteSpace(res.PublicKey))
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);
        }
    }
}