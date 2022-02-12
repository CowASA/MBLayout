using MBExample.App.Services.Exceptions;
using MBExample.App.Services.Interfaces;
using MBExample.App.Shared;
using MBExample.App.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace MBExample.App.Pages
{
    public partial class WalletInfo
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        [CascadingParameter]
        public Error Error { get; set; }

        [Parameter]
        public string? AccountId { get; set; }

        public string? AssetCount { get; set; }

        public string TextInputLabel { get; set; } = "Enter an Algorand wallet address...";

        private bool _isBusy = false;
        private bool _submit = false;
        private string _errorMessage = string.Empty;

        private IEnumerable<string> MaxCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && 58 < ch?.Length)
            {
                yield return "Wallet addresses are 58 characters";
            }
        }

        private async void SubmitInfo()
        {
            _submit = true;

            StateHasChanged();
        }
    }
}