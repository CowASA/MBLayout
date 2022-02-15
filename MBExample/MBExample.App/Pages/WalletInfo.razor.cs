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
        int _maxPapers = 12;
        int _papers = 7;
        int papers { get { return _papers; } set { UpdatePapers(value); } }

        int[] breaks = new int[7] { 3, 4, 2, 3, 3, 2, 4 };

        string[] height = new string[7] { "height: 200px;", "height: 200px;", "height: 200px;", "height: 200px;", "height: 200px;", "height: 200px;", "height: 200px;" };

        //int[] height = new int[7] { 100, 200, 400, 300, 300, 800, 500 };

        Justify justification = Justify.FlexStart;

        string Words = "Select View";
        string Things = "Idk";

        void UpdatePapers(int value)
        {
            if (value <= _maxPapers && value >= 1)
            {
                int[] newbreaks = Enumerable.Repeat(3, value).ToArray();
                string[] newheight = Enumerable.Repeat("height: 200px;", value).ToArray();

                for (int i = 0; i < newbreaks.Length; i++)
                {
                    if (i < breaks.Length)
                    {
                        newbreaks[i] = breaks[i];
                    }
                    if (i < height.Length)
                    {
                        newheight[i] = height[i];
                    }
                }

                breaks = newbreaks;
                height = newheight;

                _papers = value;

                StateHasChanged();
            }
        }

        void UpdateBreaks(int index, int changeamount)
        {
            List<int> newbreaks = breaks.ToList();

            newbreaks[index] = newbreaks[index] += changeamount;

            if (newbreaks[index] <= _minBreaks)
            {
                newbreaks[index] = _minBreaks;
            }
            else if (newbreaks[index] >= _maxBreaks)
            {
                newbreaks[index] = _maxBreaks;
            }

            breaks = newbreaks.ToArray();

            StateHasChanged();
        }

        void UpdateHeight(int index, int changeamount)
        {
            List<string> newheight = height.ToList();

            string splitHeight = newheight[index].Split(" ")[1].Replace("px;", "");

            bool conversion = int.TryParse(splitHeight, out int number);

            if (conversion)
            {
                int cardheight = number + changeamount;

                if (cardheight >= _maxHeight)
                {
                    cardheight = _maxHeight;
                }
                else if (cardheight <= _minHeight)
                {
                    cardheight = _minHeight;
                }
                else
                {
                    cardheight = number + changeamount;
                }
                newheight[index] = "height: " + cardheight.ToString() + "px;";
            }

            height = newheight.ToArray();

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