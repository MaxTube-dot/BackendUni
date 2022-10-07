using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Responses
{
    public class GetHistoryResponse
    {
        [JsonProperty("history")]
        public List<History> Histories { get; set; }

    }

    public class History
    {
        public bool IsNFT { get { return TokenId > 0; } }

        [JsonProperty("blockNumber")]
        public int BlockNumber { get; set; }


        [JsonProperty("timeStamp")]
        public int TimeStamp { get; set; }


        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }


        [JsonProperty("from")]
        public string From { get; set; }


        [JsonProperty("to")]
        public string To { get; set; }


        [JsonProperty("value")]
        public double Value { get; set; }




        [JsonProperty("tokenId")]
        public double TokenId { get; set; }



        [JsonProperty("tokenName")]
        public string TokenName { get; set; }


        [JsonProperty("tokenSymbol")]
        public string TokenSymbol { get; set; }


        [JsonProperty("gasUsed")]
        public double GasUsed { get; set; }


        [JsonProperty("confirmations")]
        public double Confirmations { get; set; }


    }
}
