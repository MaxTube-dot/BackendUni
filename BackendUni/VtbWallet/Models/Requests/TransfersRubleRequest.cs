using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Requests
{
    public class TransfersRubleRequest
    {
        [JsonProperty("fromPrivateKey")]
        public string FromPrivateKey { get; set; }

        [JsonProperty("toPublicKey")]
        public string ToPublicKey { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        public TransfersRubleRequest(string fromPrivateKey, string toPublicKey, double amount)
        {
            FromPrivateKey = fromPrivateKey;
            ToPublicKey = toPublicKey;
            Amount = amount;
        }
    }
}
