using MBExample.App.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MBExample.App.Components.DataDisplay
{
    public partial class AssetsTable
    {
        private int selectedRowNumber = -1;
        private MudTable<WalletAssetInfoModel>? mudTable;
        private List<string> clickedEvents = new();
        private bool _loading;

        [Parameter]
        public IEnumerable<WalletAssetInfoModel>? Assets { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadPage();
        }

        private async Task LoadPage()
        {
            do
            {
                _loading = true;
            } while (Assets == null);
            _loading = false;
        }

        private void RowClickEvent(TableRowClickEventArgs<WalletAssetInfoModel> tableRowClickEventArgs)
        {
            clickedEvents.Add("Row has been clicked");
            Console.WriteLine("Row has been clicked");
        }

        private string SelectedRowClassFunc(WalletAssetInfoModel asset, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (mudTable.SelectedItem != null && mudTable.SelectedItem.Equals(asset))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}