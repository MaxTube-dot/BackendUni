﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Responses
{
    public class GenerateNFTResponse
    {
        [JsonProperty("transaction_hash")]
        public string TransactionHash { get; set; }

    }
}
