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
        public IAssetInfo AccountAssetInfo { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [CascadingParameter]
        public Error Error { get; set; }

        [Parameter]
        public string AccountId { get; set; }

        private List<AssetInfo> _assetsList = new List<AssetInfo>();
        private List<WalletAssetInfoModel> _walletAssets = new List<WalletAssetInfoModel>();
        public string? AssetCount { get; set; }

        private AccountInfo? _account = new AccountInfo();
        private bool _gatheringAccountInfo;
        private bool _gatheringAssetInfo;
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
            _gatheringAccountInfo = true;
            
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

                    _gatheringAssetInfo = true;
                    Console.WriteLine($"Gathering asset info: {_gatheringAssetInfo}");
                    foreach (var a in _account.account.assets)
                    {
                        
                        Console.WriteLine($"Asset ID: {a.assetid}");
                        Console.WriteLine("Fetching asset...");
                        await FetchAssetInfoAsync(a.assetid.ToString());
                    }
                    _gatheringAssetInfo = false;
                    Console.WriteLine($"Gathering asset info: {_gatheringAssetInfo}");

                    if (_account != null)
                    {
                        AssetCount = _account.account.assets.Count().ToString();
                    }
                    Console.WriteLine($"Asset Count: {AssetCount}");
                    _gatheringAccountInfo = false;

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

            _gatheringAccountInfo = false;
        }

        private async Task FetchAssetInfoAsync(string id)
        {
            AssetInfo assetInfo = await AccountAssetInfo.GetAssetInfoByIdAsync(id);
            //NOT POPULATING BECAUSE ASSET MODEL DIFFERENT THAN ASSET PROPERTIES FROM ACCOUNT MODEL?
            _assetsList.Add(assetInfo);

            WalletAssetInfoModel walletModel = new WalletAssetInfoModel();

            foreach (var a in assetInfo.assets)
            {
                Console.WriteLine($"Index: {a.index}");

                walletModel.Index = a.index.ToString();
                walletModel.Name = a.assetparams.name.ToString();
                walletModel.Total = a.assetparams.total.ToString();


                // TODO: Make this a component and then bolt the component into the wallet info page
                //Console.WriteLine($"Name: {a._params.name}");

            }
            _walletAssets.Add(walletModel);
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