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
        public IAccountInfo AccountInfo { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [CascadingParameter]
        public Error Error { get; set; }

        [Parameter]
        public string AccountId { get; set; }

        public string? AssetCount { get; set; }

        private AccountInfo? _account = new AccountInfo();
        private bool _isBusy;
        private string _errorMessage = string.Empty;
        //TO DO Add private list accounts 

        public string TextInputLabel { get; set; } = "Enter an Algorand wallet address...";

        private IEnumerable<string> MaxCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && 58 < ch?.Length)
            {
                yield return "Wallet addresses are 58 characters";
            }
        }

        protected async override Task OnInitializedAsync()
        {
            await FetchWalletInfoAsync();
        }

        private async Task FetchWalletInfoAsync()
        {
            _isBusy = true;
            Console.WriteLine("In fetch wallet info async");
            if (AccountId == null)
			{
                Console.WriteLine("Account Id is null");
			}
            else
			{
                try
                {
                    Console.WriteLine($"Account Id we are fetching for is {AccountId}");
                    var result = await AccountInfo.GetAccountInfoByIdAsync(AccountId);
                    _account = result;
                    foreach (var a in _account.account.assets)
                    {
                        Console.WriteLine($"Asset ID: {a.assetid}");
                    }

                    if (_account != null)
                    {
                        AssetCount = _account.account.assets.Count().ToString();
                    }
                    Console.WriteLine($"Asset Count: {AssetCount}");
                    _isBusy = false;

                    StateHasChanged();
                }
                catch (ApiException ex)
                {
                    // TODO : Log errors
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Error.HandleError(ex);
                }
            }

            Console.WriteLine("Leaving Fetch");

            _isBusy = false;
        }

        private async void RedirectToAccountInfo()
        {
            Console.WriteLine($"Redirection for {AccountId}");
            Navigation.NavigateTo($"/wallet/{AccountId}");
            Console.WriteLine("Fetching again");
            await FetchWalletInfoAsync();
        }
    }
}