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
            var balance = WalletHelper.GetBalance(publicKey);
            return new Wallet() { MaticAmount = balance.MaticAmount, CoinsAmount = balance.CoinsAmount };
        }

        public static Wallet GetBalance(Wallet wallet)
        {
            var balance = WalletHelper.GetBalance(wallet.PublicKey);
            return new Wallet() { MaticAmount = balance.MaticAmount, CoinsAmount = balance.CoinsAmount };
        }
    }
}
