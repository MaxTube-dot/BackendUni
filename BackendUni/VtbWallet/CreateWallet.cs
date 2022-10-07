using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VtbWallet.Helpers;
using VtbWallet.Models;
using VtbWallet.Models.Responses;

namespace VtbWallet
{
    public static class WalletApi
    {
        private static WalletHelper WalletHelper = new WalletHelper(); 
        public static Wallet CreateWallet()
        {
           var keys =  WalletHelper.CreateWallet();
            return new Wallet() { PrivateKey = keys.PrivateKey, PublicKey = keys.PublicKey };
        }

        public static Wallet GetBalance(string publicKey)
        {
            var result = WalletHelper.GetBalance(publicKey);
            return new Wallet() { MaticAmount = result.MaticAmount, CoinsAmount = result.CoinsAmount };
        }

        public static Wallet GetBalance(Wallet wallet)
        {
            var result = WalletHelper.GetBalance(wallet.PublicKey);
            wallet.MaticAmount = result.MaticAmount;
            wallet.CoinsAmount = result.CoinsAmount;
            return wallet;
        }

        public static TransactionCustom TransfersRuble(string fromPrivateKey, string toPublicKey,double amount)
        {
            var result = WalletHelper.TransfersRuble(fromPrivateKey, toPublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash};
        }

        public static TransactionCustom TransfersRuble(Wallet walletFrom, Wallet walletTo, double amount)
        {
            var result = WalletHelper.TransfersRuble(walletFrom.PrivateKey, walletTo.PublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash };
        }


        public static TransactionCustom TransfersMatic(string fromPrivateKey, string toPublicKey, double amount)
        {
            var result = WalletHelper.TransfersMatic(fromPrivateKey, toPublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash };
        }

        public static TransactionCustom TransfersMatic(Wallet walletFrom, Wallet walletTo, double amount)
        {
            var result = WalletHelper.TransfersRuble(walletFrom.PrivateKey, walletTo.PublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash };
        }


        public static List<History> GetHistory(string publicKey, int page = 0, int offset = 0, string sort = "asc")
        {
            var result = WalletHelper.GetHistory(publicKey, page, offset, sort).Histories;
            return result;
        }

        public static Wallet GetHistory(Wallet wallet, int page = 0, int offset = 0, string sort = "asc")
        {
            var result = WalletHelper.GetHistory(wallet.PublicKey, page, offset, sort).Histories;
            wallet.Histories = result;
            return wallet;
        }

        public static TransactionCustom GenerateNFT(string publicKey, string uri, int nftCount)
        {
            var result = WalletHelper.GenerateNFT(publicKey, uri, nftCount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash};
        }

        public static Wallet GenerateNFT(Wallet wallet, string uri, int nftCount)
        {
            var result = WalletHelper.GenerateNFT(wallet.PublicKey, uri, nftCount);
            return wallet;
        }



    }
}
