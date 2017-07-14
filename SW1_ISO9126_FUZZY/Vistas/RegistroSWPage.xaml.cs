using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class RegistroSWPage : Page {


        public RegistroSWPage() {

            InitializeComponent();


        }

        public bool validar_datos_sw()
        {
            if(txtNombreEvaluador.Text == string.Empty)
                return false;

            if(txtnombreSW.Text == string.Empty)
                return false;

            if (txtDesarrolladores.Text == string.Empty)
                return false;

            if (rdbManual.IsChecked == false)
                return false;

            if(txtDescripcion.Text == string.Empty)
                return false;

            return true;
        }

        public bool validar_gi()
        {


            return true;
        }

        // Eventos botones

        private void btnSigSW_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validar_datos_sw())
            {
                tabInfoSoftware.SelectedIndex = tabInfoSoftware.SelectedIndex + 1;
            }
            else 
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe completar todos los datos del evaluador y del software para realizar la evaluación", "Datos del software", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /*
            MessageBoxResult result4 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result1 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            MessageBoxResult result7 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBoxResult result5 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Question);
        */
    }
}
