using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Responses
{
    public class GetNftInfoResponse
    {
        [JsonProperty("history")]
        public List<History> Histories { get; set; }

    }

}
