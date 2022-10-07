using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtbWallet.Models.Requests
{
    public class GetHistoryRequest
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("offset")]
        public int? Offset { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        public GetHistoryRequest(int page, int offset, string sort)
        {
            Page = page;
            Offset = offset;
            Sort = sort;
        }

    }
}
