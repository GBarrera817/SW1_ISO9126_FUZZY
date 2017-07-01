using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using MahApps.Metro.Controls;
using SW1_ISO9126_FUZZY.Vistas;
using MenuItem = SW1_ISO9126_FUZZY.ModelosVistas.MenuItem;

namespace SW1_ISO9126_FUZZY {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();

            // Navigate to the home page.
            Navigation.Navigation.Frame = new Frame(); //SplitViewFrame;
            Navigation.Navigation.Frame.Navigated += SplitViewFrame_OnNavigated;
            this.Loaded += (sender, args) => Navigation.Navigation.Navigate(new MainPage());
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e) {
            HamburgerMenuControl.Content = e.Content;
            GoBackButton.Visibility = Navigation.Navigation.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e) {
            var menuItem = e.ClickedItem as MenuItem;
            if (menuItem != null && menuItem.IsNavigation) {
                Navigation.Navigation.Navigate(menuItem.NavigationDestination);
            }
            
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e) {
            Navigation.Navigation.GoBack();
        }
    }
}
