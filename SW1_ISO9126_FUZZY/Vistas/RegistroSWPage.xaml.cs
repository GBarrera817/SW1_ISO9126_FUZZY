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

        public bool validar_grados()
        {
            if((lblFuncionalidad.IsChecked == false ) && (lblUsabilidad.IsChecked == false ) && (lblMantenibilidad.IsChecked == false))
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar al menos una característica para la evaluación del software", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

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

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (validar_grados())
            {

            }
            else
            {

            }
        }

        // Eventos checkbox grandes

        private void lblFuncionalidad_Checked(object sender, RoutedEventArgs e)
        {
            dudFuncionalidad.IsEnabled = true;

            lblAdecuacion.IsEnabled = true;
            lblExactitud.IsEnabled = true;
            lblInteroperabilidad.IsEnabled = true;
            lblSeguridad.IsEnabled = true;
            lblCumpFuncionalidad.IsEnabled = true;

        }

        private void lblFuncionalidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudFuncionalidad.IsEnabled = false;
            dudFuncionalidad.Value = 0;

            lblAdecuacion.IsEnabled = false;
            lblAdecuacion.IsChecked = false;
            dudAdecuacion.IsEnabled = false;
            dudAdecuacion.Value = 0;
            lblExactitud.IsEnabled = false;
            lblExactitud.IsChecked = false;
            dudExactitud.IsEnabled = false;
            dudExactitud.Value = 0;
            lblInteroperabilidad.IsEnabled = false;
            lblInteroperabilidad.IsChecked = false;
            dudInteroperabilidad.IsEnabled = false;
            dudInteroperabilidad.Value = 0;
            lblSeguridad.IsEnabled = false;
            lblSeguridad.IsChecked = false;
            dudSeguridad.IsEnabled = false;
            dudSeguridad.Value = 0;
            lblCumpFuncionalidad.IsEnabled = false;
            lblCumpFuncionalidad.IsChecked = false;
            dudCumpFuncionalidad.IsEnabled = false;
            dudCumpFuncionalidad.Value = 0;

        }

        private void lblUsabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudUsabilidad.IsEnabled = true;

            lblAprendizaje.IsEnabled = true;           
            lblComprensibilidad.IsEnabled = true;        
            lblOperabilidad.IsEnabled = true;
            lblAtractividad.IsEnabled = true;            
            lblCumpUsabilidad.IsEnabled = true;            

        }

        private void lblUsabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudUsabilidad.IsEnabled = false;
            dudUsabilidad.Value = 0;

            lblAprendizaje.IsEnabled = false;
            lblAprendizaje.IsChecked = false;
            dudAprendizaje.IsEnabled = false;
            dudAprendizaje.Value = 0;
            lblComprensibilidad.IsEnabled = false;
            lblComprensibilidad.IsChecked = false;
            dudComprensibilidad.IsEnabled = false;
            dudComprensibilidad.Value = 0;
            lblOperabilidad.IsEnabled = false;
            lblOperabilidad.IsChecked = false;
            dudOperabilidad.IsEnabled = false;
            dudOperabilidad.Value = 0;
            lblAtractividad.IsEnabled = false;
            lblAtractividad.IsChecked = false;
            dudAtractividad.IsEnabled = false;
            dudAtractividad.Value = 0;
            lblCumpUsabilidad.IsEnabled = false;
            lblCumpUsabilidad.IsChecked = false;
            dudCumpUsabilidad.IsEnabled = false;
            dudCumpUsabilidad.Value = 0;

        }

        private void lblMantenibilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudMantenibilidad.IsEnabled = true;

            lblFacAnalisis.IsEnabled = true;
            lblModificabilidad.IsEnabled = true;
            lblEstabilidad.IsEnabled = true;
            lblTesteabilidad.IsEnabled = true;
            lblCumpMantenibilidad.IsEnabled = true;

        }

        private void lblMantenibilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudMantenibilidad.IsEnabled = false;
            dudMantenibilidad.Value = 0;

            lblFacAnalisis.IsEnabled = false;
            lblFacAnalisis.IsChecked = false;
            dudFacAnalisis.IsEnabled = false;
            dudFacAnalisis.Value = 0;
            lblModificabilidad.IsEnabled = false;
            lblModificabilidad.IsChecked = false;
            dudModificabilidad.IsEnabled = false;
            dudModificabilidad.Value = 0;
            lblEstabilidad.IsEnabled = false;
            lblEstabilidad.IsChecked = false;
            dudEstabilidad.IsEnabled = false;
            dudEstabilidad.Value = 0;
            lblTesteabilidad.IsEnabled = false;
            lblTesteabilidad.IsChecked = false;
            dudTesteabilidad.IsEnabled = false;
            dudTesteabilidad.Value = 0;
            lblCumpMantenibilidad.IsEnabled = false;
            lblCumpMantenibilidad.IsChecked = false;
            dudCumpMantenibilidad.IsEnabled = false;
            dudCumpMantenibilidad.Value = 0;
        }

        // Eventos checkbox chicos funcionalidad

        private void lblAdecuacion_Checked(object sender, RoutedEventArgs e)
        {
            dudAdecuacion.IsEnabled = true;
        }

        private void lblAdecuacion_UnChecked(object sender, RoutedEventArgs e)
        {
            dudAdecuacion.IsEnabled = false;
            dudAdecuacion.Value = 0;
        }

        private void lblExactitud_Checked(object sender, RoutedEventArgs e)
        {
            dudExactitud.IsEnabled = true;
        }

        private void lblExactitud_UnChecked(object sender, RoutedEventArgs e)
        {
            dudExactitud.IsEnabled = false;
            dudExactitud.Value = 0;
        }

        private void lblInteroperabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudInteroperabilidad.IsEnabled = true;
        }

        private void lblInteroperabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudInteroperabilidad.IsEnabled = false;
            dudInteroperabilidad.Value = 0;
        }

        private void lblSeguridad_Checked(object sender, RoutedEventArgs e)
        {
            dudSeguridad.IsEnabled = true;
        }

        private void lblSeguridad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudSeguridad.IsEnabled = false;
            dudSeguridad.Value = 0;
        }

        private void lblCumpFuncionalidad_Checked(object sender, RoutedEventArgs e)
        {
            dudCumpFuncionalidad.IsEnabled = true;
        }

        private void lblCumpFuncionalidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudCumpFuncionalidad.IsEnabled = false;
            dudCumpFuncionalidad.Value = 0;
        }

        // Eventos checkbox chicos usabilidad

        private void lblAprendizaje_Checked(object sender, RoutedEventArgs e)
        {
            dudAprendizaje.IsEnabled = true;
        }

        private void lblAprendizaje_UnChecked(object sender, RoutedEventArgs e)
        {
            dudAprendizaje.IsEnabled = false;
            dudAprendizaje.Value = 0;
        }

        private void lblComprensibilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudComprensibilidad.IsEnabled = true;
        }

        private void lblComprensibilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudComprensibilidad.IsEnabled = false;
            dudComprensibilidad.Value = 0;
        }

        private void lblOperabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudOperabilidad.IsEnabled = true;
        }

        private void lblOperabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudOperabilidad.IsEnabled = false;
            dudOperabilidad.Value = 0;
        }

        private void lblAtractividad_Checked(object sender, RoutedEventArgs e)
        {
            dudAtractividad.IsEnabled = true;
        }

        private void lblAtractividad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudAtractividad.IsEnabled = false;
            dudAtractividad.Value = 0;
        }

        private void lblCumpUsabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudCumpUsabilidad.IsEnabled = true;
        }

        private void lblCumpUsabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudCumpUsabilidad.IsEnabled = false;
            dudCumpUsabilidad.Value = 0;
        }

        // Eventos checkbox chicos mantenibilidad

        private void lblFacAnalisis_Checked(object sender, RoutedEventArgs e)
        {
            dudFacAnalisis.IsEnabled = true;
        }

        private void lblFacAnalisis_UnChecked(object sender, RoutedEventArgs e)
        {
            dudFacAnalisis.IsEnabled = false;
            dudFacAnalisis.Value = 0;
        }

        private void lblModificabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudModificabilidad.IsEnabled = true;
        }

        private void lblModificabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudModificabilidad.IsEnabled = false;
            dudModificabilidad.Value = 0;
        }

        private void lblEstabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudEstabilidad.IsEnabled = true;        
        }

        private void lblEstabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudEstabilidad.IsEnabled = false;
            dudEstabilidad.Value = 0;
        }

        private void lblTesteabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudTesteabilidad.IsEnabled = true; 
        }

        private void lblTesteabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudTesteabilidad.IsEnabled = false;
            dudTesteabilidad.Value = 0;
        }

        private void lblCumpMantenibilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudCumpMantenibilidad.IsEnabled = true;
        }

        private void lblCumpMantenibilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudCumpMantenibilidad.IsEnabled = false;
            dudCumpMantenibilidad.Value = 0;
        }

        /*
            MessageBoxResult result4 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result1 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            MessageBoxResult result7 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBoxResult result5 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Question);
        */
    }
}
