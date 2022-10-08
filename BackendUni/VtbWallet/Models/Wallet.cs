using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VtbWallet.Models.Responses;

namespace VtbWallet.Models
{
    public class Wallet
    {
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        #region Balance
        public double MaticAmount { get; set; }

        public double CoinsAmount { get; set; }
        #endregion

        public List<History> Histories { get; set; }

        public List<NFT> NFTs { get; set; }

        public Wallet(string publicKey)
        {
            PublicKey = publicKey;
            {
                var wallet = WalletApi.GetBalance(this);
                MaticAmount = wallet.MaticAmount;
                CoinsAmount = wallet.CoinsAmount;
            }

            {
                var wallet = WalletApi.GetNftBalance(this);
                NFTs = wallet.NFTs;
            }

            {
                var wallet = WalletApi.GetHistory(this);
                Histories = wallet.Histories;
            }
        }

        public Wallet()
        {

        }
    }
}
