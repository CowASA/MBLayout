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
        public int currentround { get; set; }
    }

    public class Account
    {
        public string address { get; set; }
        public ulong amount { get; set; }
        public int amountwithoutpendingrewards { get; set; }
        public AppsLocalState[] appslocalstate { get; set; }
        public AppsTotalSchema appstotalschema { get; set; }
        public int appstotalextrapages { get; set; }
        public Asset[] assets { get; set; }
        public CreatedApps[] createdapps { get; set; }
        public CreatedAssets[] createdassets { get; set; }
        public Participation participation { get; set; }
        public int pendingrewards { get; set; }
        public int rewardbase { get; set; }
        public int rewards { get; set; }
        public int round { get; set; }
        public string status { get; set; }
        public string sigtype { get; set; }
        public string authaddr { get; set; }
        public bool deleted { get; set; }
        public int createdatround { get; set; }
        public int closedatround { get; set; }
    }

    public class AppsTotalSchema
    {
        public int numuint { get; set; }
        public int numbyteslice { get; set; }
    }

    public class Participation
    {
        public string selectionparticipationkey { get; set; }
        public int votefirstvalid { get; set; }
        public int votekeydilution { get; set; }
        public int votelastvalid { get; set; }
        public string voteparticipationkey { get; set; }
    }

    public class AppsLocalState
    {
        public int id { get; set; }
        public bool deleted { get; set; }
        public int optedinatround { get; set; }
        public int closedoutatround { get; set; }
        public Schema schema { get; set; }
        public KeyValue[] keyvalue { get; set; }
    }

    public class Schema
    {
        public int numuint { get; set; }
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

    public class Asset
    {
        public ulong amount { get; set; }
        public int assetid { get; set; }
        public string creator { get; set; }
        public bool isfrozen { get; set; }
        public bool deleted { get; set; }
        public int optedinatround { get; set; }
        public int optedoutatround { get; set; }
    }

    public class CreatedApps
    {
        public int id { get; set; }
        public bool deleted { get; set; }
        public int createdatround { get; set; }
        public int deletedatround { get; set; }
        public Params _params { get; set; }
    }

    public class Params
    {
        public string creator { get; set; }
        public string approvalprogram { get; set; }
        public string clearstateprogram { get; set; }
        public LocalStateSchema localstateschema { get; set; }
        public GlobalStateSchema globalstateschema { get; set; }
        public GlobalState[] globalstate { get; set; }
        public int extraprogrampages { get; set; }
    }

    public class LocalStateSchema
    {
        public int numuint { get; set; }
        public int numbyteslice { get; set; }
    }

    public class GlobalStateSchema
    {
        public int numuint { get; set; }
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
        public int createdatround { get; set; }
        public int destroyedatround { get; set; }
        public Params1 _params { get; set; }
    }

    public class Params1
    {
        public string clawback { get; set; }
        public string creator { get; set; }
        public int decimals { get; set; }
        public bool defaultfrozen { get; set; }
        public string freeze { get; set; }
        public string manager { get; set; }
        public string metadatahash { get; set; }
        public string name { get; set; }
        public string nameb64 { get; set; }
        public string reserve { get; set; }
        public int total { get; set; }
        public string unitname { get; set; }
        public string unitnameb64 { get; set; }
        public string url { get; set; }
        public string urlb64 { get; set; }
    }

}