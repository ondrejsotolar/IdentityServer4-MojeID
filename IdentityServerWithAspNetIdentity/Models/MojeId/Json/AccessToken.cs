using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechniServIT.MyeID.epoxid.Models.MojeId.Json
{
    [JsonObject]
    public class AccessToken
    {
        [JsonProperty]
        public string access_token { get; set; }

        [JsonProperty]
        public string id_token { get; set; }

        [JsonProperty]
        public string state { get; set; }

        [JsonProperty]
        public string token_type { get; set; }

        [JsonProperty]
        public string scope { get; set; }
    }
}
