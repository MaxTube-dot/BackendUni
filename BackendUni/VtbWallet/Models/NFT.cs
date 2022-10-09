using Newtonsoft.Json;

namespace VtbWallet.Models
{
    /// <summary>
    /// NFT объект
    /// </summary>
    public class NFT
    {
        // Ссылка на объект 
        [JsonProperty("URI")]
        public string URI { get; set; }

        // Токен объекта 
        [JsonProperty("tokens")]
        public List<int> Tokens { get; set; }
    }
}