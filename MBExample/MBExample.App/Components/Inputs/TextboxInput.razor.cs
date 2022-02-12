using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using MBExample.App;
using MBExample.App.Shared;
using MBExample.App.Components;
using MBExample.App.Shared.Models;
using MudBlazor;

namespace MBExample.App.Components
{
    public partial class TextboxInput
    {
        [Parameter]
        public string TextInputLabel { get; set; }

        [Parameter]
        public string BoundItem { get; set; }

        [Parameter]
        public int Counter { get; set; }

        [Parameter]
        public int MaxLength { get; set; }

        [Parameter]
        public string HelperText { get; set; }

        private IEnumerable<string> MaxCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && 58 < ch?.Length)
            {
                yield return "Wallet addresses are 58 characters";
            }
        }
    }
}