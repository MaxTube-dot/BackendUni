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
    }
}
