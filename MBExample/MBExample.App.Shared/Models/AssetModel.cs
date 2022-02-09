using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBExample.App.Shared.Models
{

    public class AssetInfo
    {
        public Asset[] assets { get; set; }
        [JsonProperty(PropertyName = "current-round")]
        public int currentround { get; set; }
        [JsonProperty(PropertyName = "next-token")]
        public string nexttoken { get; set; }
    }

    public class Asset
    {
        public int index { get; set; }
        public bool deleted { get; set; }
        [JsonProperty(PropertyName = "created-at-round")]
        public int createdatround { get; set; }
        [JsonProperty(PropertyName = "destroyed-at-round")]
        public int destroyedatround { get; set; }
        [JsonProperty(PropertyName = "params")]
        public AssetParams assetparams { get; set; }
    }

    public class AssetParams
    {
        public string clawback { get; set; }
        public string creator { get; set; }
        public int decimals { get; set; }
        public bool defaultfrozen { get; set; }
        public string freeze { get; set; }
        public string manager { get; set; }
        [JsonProperty(PropertyName = "metadata-hash")]
        public string metadatahash { get; set; }
        public string name { get; set; }
        [JsonProperty(PropertyName = "name-b64")]
        public string nameb64 { get; set; }
        public string reserve { get; set; }
        public ulong total { get; set; }
        [JsonProperty(PropertyName = "unit-name")]
        public string unitname { get; set; }
        [JsonProperty(PropertyName = "unit-name-b64")]
        public string unitnameb64 { get; set; }
        public string url { get; set; }
        [JsonProperty(PropertyName = "url-b64")]
        public string urlb64 { get; set; }
    }
}
