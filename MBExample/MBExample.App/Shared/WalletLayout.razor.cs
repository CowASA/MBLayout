using MudBlazor;

namespace MBExample.App.Shared
{
    public partial class WalletLayout
    {
        bool _drawerOpen = true;
        bool _box1Visible = true;

        public string TextInputLabel { get; set; } = "Enter an Algorand wallet address...";

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        private void ToggleBox()
        {
            _box1Visible = true ? !_box1Visible : _box1Visible;
        }
        private void ToggleBox(MudCard card)
        {
            _box1Visible = true ? !_box1Visible : _box1Visible;
        }

        private IEnumerable<string> MaxCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && 58 < ch?.Length)
            {
                yield return "Wallet addresses are 58 characters";
            }
        }
    }
}
