using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBExample.App.Shared.Models
{
    public class AccountInfo
    {
        public Account account { get; set; }
        [JsonProperty(PropertyName = "current-round")]
        public int currentround { get; set; }
    }

    public class Account
    {
        public string address { get; set; }
        public ulong amount { get; set; }
        [JsonProperty(PropertyName = "amount-without-pending-rewards")]
        public ulong amountwithoutpendingrewards { get; set; }
        [JsonProperty(PropertyName = "apps-local-state")]
        public AppsLocalState[] appslocalstate { get; set; }
        [JsonProperty(PropertyName = "apps-total-schema")]
        public AppsTotalSchema appstotalschema { get; set; }
        [JsonProperty(PropertyName = "apps-total-extra-pages")]
        public int appstotalextrapages { get; set; }
        public AccountAssetInfo[] assets { get; set; }
        [JsonProperty(PropertyName = "created-apps")]
        public CreatedApps[] createdapps { get; set; }
        [JsonProperty(PropertyName = "created-assets")]
        public CreatedAssets[] createdassets { get; set; }
        public Participation participation { get; set; }
        [JsonProperty(PropertyName = "pending-rewards")]
        public int pendingrewards { get; set; }
        [JsonProperty(PropertyName = "reward-base")]
        public int rewardbase { get; set; }
        public int rewards { get; set; }
        public int round { get; set; }
        public string status { get; set; }
        [JsonProperty(PropertyName = "sig-type")]
        public string sigtype { get; set; }
        [JsonProperty(PropertyName = "auth-addr")]
        public string authaddr { get; set; }
        public bool deleted { get; set; }
        [JsonProperty(PropertyName = "created-at-round")]
        public int createdatround { get; set; }
        [JsonProperty(PropertyName = "closed-at-round")]
        public int closedatround { get; set; }
    }

    public class AppsTotalSchema
    {
        [JsonProperty(PropertyName = "num-uint")]
        public int numuint { get; set; }
        [JsonProperty(PropertyName = "num-byte-slice")]
        public int numbyteslice { get; set; }
    }

    public class Participation
    {
        [JsonProperty(PropertyName = "selection-participation-key")]
        public string selectionparticipationkey { get; set; }
        [JsonProperty(PropertyName = "vote-first-valid")]
        public int votefirstvalid { get; set; }
        [JsonProperty(PropertyName = "vote-key-dilution")]
        public int votekeydilution { get; set; }
        [JsonProperty(PropertyName = "vote-last-valid")]
        public int votelastvalid { get; set; }
        [JsonProperty(PropertyName = "vote-participation-key")]
        public string voteparticipationkey { get; set; }
    }

    public class AppsLocalState
    {
        public int id { get; set; }
        public bool deleted { get; set; }
        [JsonProperty(PropertyName = "opted-in-at-round")]
        public int optedinatround { get; set; }
        [JsonProperty(PropertyName = "closed-out-at-round")]
        public int closedoutatround { get; set; }
        public Schema schema { get; set; }
        [JsonProperty(PropertyName = "key-value")]
        public KeyValue[] keyvalue { get; set; }
    }

    public class Schema
    {
        [JsonProperty(PropertyName = "num-uint")]
        public int numuint { get; set; }
        [JsonProperty(PropertyName = "num-byte-slice")]
        public int numbyteslice { get; set; }
    }

    public class KeyValue
    {
        public string key { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public int type { get; set; }
        public string bytes { get; set; }
        public int _uint { get; set; }
    }

    public class AccountAssetInfo
    {
        public ulong amount { get; set; }
        [JsonProperty(PropertyName = "asset-id")]
        public ulong assetid { get; set; }
        public string creator { get; set; }
        [JsonProperty(PropertyName = "is-frozen")]
        public bool isfrozen { get; set; }
        public bool deleted { get; set; }
        [JsonProperty(PropertyName = "opted-in-at-round")]
        public int optedinatround { get; set; }
        [JsonProperty(PropertyName = "opted-out-at-round")]
        public int optedoutatround { get; set; }
    }

    public class CreatedApps
    {
        public int id { get; set; }
        public bool deleted { get; set; }
        [JsonProperty(PropertyName = "created-at-round")]
        public int createdatround { get; set; }
        [JsonProperty(PropertyName = "deleted-at-round")]
        public int deletedatround { get; set; }
        public AccountParams _params { get; set; }
    }

    public class AccountParams
    {
        public string creator { get; set; }
        [JsonProperty(PropertyName = "approval-program")]
        public string approvalprogram { get; set; }
        [JsonProperty(PropertyName = "clear-state-program")]
        public string clearstateprogram { get; set; }
        [JsonProperty(PropertyName = "local-state-schema")]
        public LocalStateSchema localstateschema { get; set; }
        [JsonProperty(PropertyName = "global-state-schema")]
        public GlobalStateSchema globalstateschema { get; set; }
        [JsonProperty(PropertyName = "global-state")]
        public GlobalState[] globalstate { get; set; }
        [JsonProperty(PropertyName = "extra-program-pages")]
        public int extraprogrampages { get; set; }
    }

    public class LocalStateSchema
    {
        [JsonProperty(PropertyName = "num-uint")]
        public int numuint { get; set; }
        [JsonProperty(PropertyName = "num-byte-slice")]
        public int numbyteslice { get; set; }
    }

    public class GlobalStateSchema
    {
        [JsonProperty(PropertyName = "num-uint")]
        public int numuint { get; set; }
        [JsonProperty(PropertyName = "num-byte-slice")]
        public int numbyteslice { get; set; }
    }

    public class GlobalState
    {
        public string key { get; set; }
        public Value1 value { get; set; }
    }

    public class Value1
    {
        public int type { get; set; }
        public string bytes { get; set; }
        public int _uint { get; set; }
    }

    public class CreatedAssets
    {
        public int index { get; set; }
        public bool deleted { get; set; }
        [JsonProperty(PropertyName = "created-at-round")]
        public int createdatround { get; set; }
        [JsonProperty(PropertyName = "destroyed-at-round")]
        public int destroyedatround { get; set; }
        public AccountParams1 _params { get; set; }
    }

    public class AccountParams1
    {
        public string clawback { get; set; }
        public string creator { get; set; }
        public int decimals { get; set; }
        [JsonProperty(PropertyName = "default-frozen")]
        public bool defaultfrozen { get; set; }
        public string freeze { get; set; }
        public string manager { get; set; }
        [JsonProperty(PropertyName = "metadata-hash")]
        public string metadatahash { get; set; }
        public string name { get; set; }
        [JsonProperty(PropertyName = "name-b64")]
        public string nameb64 { get; set; }
        public string reserve { get; set; }
        public int total { get; set; }
        [JsonProperty(PropertyName = "unit-name")]
        public string unitname { get; set; }
        [JsonProperty(PropertyName = "unit-name-b64")]
        public string unitnameb64 { get; set; }
        public string url { get; set; }
        [JsonProperty(PropertyName = "url-b64")]
        public string urlb64 { get; set; }
    }

}