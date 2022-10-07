using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<NFT> MyProperty { get; set; }
    }
}
