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
    }
}
