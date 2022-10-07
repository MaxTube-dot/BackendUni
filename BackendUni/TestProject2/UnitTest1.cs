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


        [Test]
        public void Test2()
        {
            var res = WalletApi.GetBalance("0xc732096eC1278f9B5DaAFf3621535fD623E931dd");

            if (res.CoinsAmount > 0)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }
    }
}