using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtbWallet.Helpers;
using VtbWallet.Models;

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
            return new Wallet() { MaticAmount = result.MaticAmount, CoinsAmount = result.CoinsAmount };
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


    }
}
