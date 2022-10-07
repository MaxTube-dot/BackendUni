using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Responses
{
    public class GetBalanceResponse
    {
        [JsonProperty("maticAmount")]
        public double MaticAmount { get; set; }

        [JsonProperty("coinsAmount")]
        public double CoinsAmount { get; set; }
    }
}
