using Newtonsoft.Json;

namespace VtbWallet.Models
{
    public class NFT
    {
        [JsonProperty("URI")]
        public string URI { get; set; }

        [JsonProperty("tokens")]
        public List<int> Tokens { get; set; }
    }
}