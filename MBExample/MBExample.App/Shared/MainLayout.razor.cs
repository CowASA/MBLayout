using MudBlazor;

namespace MBExample.App.Shared
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        bool _box1Visible = false;
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
    }
}
