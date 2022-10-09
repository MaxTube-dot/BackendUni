using Newtonsoft.Json;

namespace VtbWallet.Models
{
    // Информация о NFT
    public class NftInfo
    {
        
        [JsonProperty("tokenId")]
        public string TokenId { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }
    }
}