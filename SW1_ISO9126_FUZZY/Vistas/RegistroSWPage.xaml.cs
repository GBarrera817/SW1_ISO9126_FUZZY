using System.Windows.Controls;


namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class RegistroSWPage : Page {
        public RegistroSWPage() {
            InitializeComponent();
        }

        private void btnSigSW_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tabInfoSoftware.SelectedIndex = tabInfoSoftware.SelectedIndex + 1;
        }
    }
}
