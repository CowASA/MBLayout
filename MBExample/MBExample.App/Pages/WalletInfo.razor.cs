using MBExample.App.Services.Exceptions;
using MBExample.App.Services.Interfaces;
using MBExample.App.Shared;
using MBExample.App.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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

        int _maxBreaks = 12;
        int _minBreaks = 2;
        int _maxHeight = 600;
        int _minHeight = 200;
        int _maxCards = 12;
        int _cards = 7;
        int cards { get { return _cards; } set { UpdatePapers(value); } }

        int[] breaks = new int[7] { 3, 4, 2, 3, 3, 2, 4 };
        string[] heights = new string[7] { "height: 300px;", "height: 300px;", "height: 300px;", "height: 300px;", "height: 300px;", "height: 300px;", "height: 300px;" };
        Type[] components = new Type[7] { typeof(Counter), typeof(Counter), typeof(FetchData), typeof(FetchData), typeof(Counter), typeof(FetchData), typeof(Counter) };

        Justify justification = Justify.FlexStart;

        string Words = "Select View";
        string Things = "Idk";

        void UpdatePapers(int value)
        {
            if (value <= _maxCards && value >= 1)
            {
                int[] newBreaks = Enumerable.Repeat(3, value).ToArray();
                string[] newHeight = Enumerable.Repeat("height: 300px;", value).ToArray();

                for (int i = 0; i < newBreaks.Length; i++)
                {
                    if (i < breaks.Length)
                    {
                        newBreaks[i] = breaks[i];
                    }
                    if (i < heights.Length)
                    {
                        newHeight[i] = heights[i];
                    }
                }

                breaks = newBreaks;
                heights = newHeight;

                _cards = value;

                StateHasChanged();
            }
        }

        void UpdateBreaks(int index, int changeamount)
        {
            List<int> newBreaks = breaks.ToList();

            newBreaks[index] = newBreaks[index] += changeamount;

            if (newBreaks[index] <= _minBreaks)
            {
                newBreaks[index] = _minBreaks;
            }
            else if (newBreaks[index] >= _maxBreaks)
            {
                newBreaks[index] = _maxBreaks;
            }

            breaks = newBreaks.ToArray();

            StateHasChanged();
        }

        void UpdateHeight(int index, int changeAmount)
        {
            List<string> newHeight = heights.ToList();

            string splitHeight = newHeight[index].Split(" ")[1].Replace("px;", "");

            bool conversion = int.TryParse(splitHeight, out int number);

            if (conversion)
            {
                int cardHeight = number + changeAmount;

                if (cardHeight >= _maxHeight)
                {
                    cardHeight = _maxHeight;
                }
                else if (cardHeight <= _minHeight)
                {
                    cardHeight = _minHeight;
                }
                else
                {
                    cardHeight = number + changeAmount;
                }
                newHeight[index] = "height: " + cardHeight.ToString() + "px;";
            }

            heights = newHeight.ToArray();

            StateHasChanged();
        }


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