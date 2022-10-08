using Backend.DAL.DbContexts;
using BackendUni.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VtbWallet;
using VtbWallet.Models;
using BackendUni.Services;
using VtbWallet.Models.Responses;

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

        [Test]
        public void Test3()
        {
            var res = WalletApi.TransfersRuble("6a9125ec2ac9bd4396faaa0dff1bfa57098352ee3a4734c7670a321e7f98a870", "0xca070fF6a7Bc1D60705e776100dca50Bba95AB50",0.05d);

            if (string.IsNullOrWhiteSpace(res.TransactionHash))
            {
                Assert.IsTrue(false);
                return;
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void Test4()
        {
            var res = WalletApi.TransfersMatic("6a9125ec2ac9bd4396faaa0dff1bfa57098352ee3a4734c7670a321e7f98a870", "0xca070fF6a7Bc1D60705e776100dca50Bba95AB50", 0.005);

            if (!string.IsNullOrWhiteSpace(res.TransactionHash))
            {
                Assert.IsTrue(false);
                return;
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void Test5()
        {
            var res = WalletApi.GetHistory("0xc732096eC1278f9B5DaAFf3621535fD623E931dd");

            
            Assert.IsTrue(res.Count > 5);
        }

        [Test]
        public void Test6()
        {
            var res = WalletApi.GenerateNFT("0xc732096eC1278f9B5DaAFf3621535fD623E931dd", Guid.NewGuid().ToString(), 2);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(res.TransactionHash));
        }


        [Test]
        public void Test7()
        {
            var res = WalletApi.GetNftBalance("0xc732096eC1278f9B5DaAFf3621535fD623E931dd");
            Assert.IsTrue((res.Count > 0));
        }

        [Test]
        public void Test8()
        {
            var res = new Wallet("0xc732096eC1278f9B5DaAFf3621535fD623E931dd");
            Assert.IsTrue(res.Histories.Count > 1);
        }



        [Test]
        public void Test9()
        {
            var res =  WalletApi.GetNftInfo(563);
            Assert.IsTrue(res.Uri == "81933ff2-cef0-45b9-b691-07a1e5901915");
        }



        [Test]
        public  void TestAuth()
        {
            
            var context = GetDbContext();
            AuthController authController = new AuthController(context);
            JsonResult result = (JsonResult)authController.Login("ilya", "0000");
            Assert.IsTrue(result.Value != null);

        }

        [Test]
        public void GetHistory()
        {
            GamificationDbContext gamificationDbContext = GetDbContext();
            string token  = gamificationDbContext.Users.Where(x => x.Id == 32).Select(x=>x.Token).FirstOrDefault();
            UsersController authController = new UsersController(GetDbContext(), new WalletService());
            var h = authController.GetHistory(token);
            Assert.IsTrue(true);
        }


        [Test]
        public void Transfer()
        {
            GamificationDbContext gamificationDbContext = GetDbContext();
            string token = gamificationDbContext.Users.Where(x => x.Id == 32).Select(x => x.Token).FirstOrDefault();
            UsersController authController = new UsersController(GetDbContext(), new WalletService());
            var h = authController.Transfer(token,31,1 );
            Assert.IsTrue(true);
        }


        private GamificationDbContext GetDbContext()
        {
            string confString = "Host=192.168.1.4;Port=5432;Database=GamificationDB;Username=postgres;Password=110011";

            var optionBuilder = new DbContextOptionsBuilder<GamificationDbContext>();
            optionBuilder.UseNpgsql(confString);
            var context = new GamificationDbContext(optionBuilder.Options);

            return context;
        }

        
    }
}