using System.Windows;
using System.Windows.Controls;
using SW1_ISO9126_FUZZY.Archivos;
using Xceed.Wpf.Toolkit;


namespace SW1_ISO9126_FUZZY.Vistas {
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        public MainPage() {
            InitializeComponent();
        }

        private void btnFuncInterna_Click(object sender, RoutedEventArgs e) {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn func interna");
        }

        private void btnMantInterna_Click(object sender, RoutedEventArgs e) {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn mant interna");
        }

        private void btnUsabInterna_Click(object sender, RoutedEventArgs e) {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn usab interna");
        }

        private void btnFuncExterna_Click(object sender, RoutedEventArgs e) {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn func externa");
        }

        private void btnMantExterna_Click(object sender, RoutedEventArgs e) {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn mant externa");
        }

        private void btnUsabExterna_Click(object sender, RoutedEventArgs e) {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn usab externa");
        }
    }
}
