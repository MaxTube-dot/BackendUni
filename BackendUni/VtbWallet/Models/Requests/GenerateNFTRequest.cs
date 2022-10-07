using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Requests
{
    public class GenerateNFTRequest
    {
        [JsonProperty("toPublicKey")]
        public string ToPublicKey { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("nftCount")]
        public int NftCount { get; set; }

        public GenerateNFTRequest(string toPublicKey, string uri, int nftCount)
        {
            ToPublicKey = toPublicKey;
            Uri = uri;
            NftCount = nftCount;
        }
    }
}
