using System.Runtime.CompilerServices;
using VtbWallet;
using VtbWallet.Models;
using VtbWallet.Models.Responses;

namespace BackendUni.Services
{
    public class WalletService
    {
        public Wallet GetBalance(string publicKey)
        {
            return WalletApi.GetBalance(publicKey);
        }

        public Wallet CreateWallet()
        {
            return WalletApi.CreateWallet();
        }

        public List<History> GetHistory(string publicKey)
        {
            return WalletApi.GetHistory(publicKey);
        }

        public TransactionCustom SentTokens(string privateKeyFrom, string publicKeyTo, double count )
        {
            return WalletApi.TransfersRuble(privateKeyFrom, publicKeyTo, count);
        }

        public TransactionCustom RemoveTokens(string privateKeyFrom, double count )
        {
            return WalletApi.TransfersRuble(privateKeyFrom, "0xEFD60fC339921FD27E1056a5c245aE260e3096E5", count);
        }


    }
}
