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
using MBExample.App.Services.Interfaces;
using MBExample.App.Services.Exceptions;

namespace MBExample.App.Components.Layouts
{
    public partial class AssetInfoPage
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
        public string? AccountId { get; set; }

        private bool _loading;
        private List<AssetInfo> _assetsList = new List<AssetInfo>();
        private List<WalletAssetInfoModel> _walletAssets = new List<WalletAssetInfoModel>();
        public string? AssetCount { get; set; }
        private AccountInfo? _account = new AccountInfo();
        private bool _gatheringAccountInfo;
        private bool _gatheringAssetInfo;
        private string _errorMessage = string.Empty;

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

            //_assetsList.Add(assetInfo);

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