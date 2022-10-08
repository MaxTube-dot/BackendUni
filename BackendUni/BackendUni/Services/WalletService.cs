using VtbWallet;
using VtbWallet.Models;

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
    }
}
