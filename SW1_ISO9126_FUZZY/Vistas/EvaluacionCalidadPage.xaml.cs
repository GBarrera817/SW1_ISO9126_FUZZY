using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para EvaluacionCalidadPage.xaml
	/// </summary>
	public partial class EvaluacionCalidadPage : Page
	{
		public EvaluacionCalidadPage()
		{
			InitializeComponent();
		}

        // Eventos de movimiento

		private void retrocederTabControl(object sender, RoutedEventArgs e)
		{
			tabControlEvaluacionCalidad.SelectedIndex = tabControlEvaluacionCalidad.SelectedIndex - 1;
		}

        private void avanzarTabControl(object sender, RoutedEventArgs e)
        {
            tabControlEvaluacionCalidad.SelectedIndex = tabControlEvaluacionCalidad.SelectedIndex + 1;
        }

        // PAGINA CALIDAD SUBCARACTERISTICAS

        private void btnCalcSubInterna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalcSubExterna_Click(object sender, RoutedEventArgs e)
        {

        }


        // PAGINA CALIDAD CARACTERISTICAS

        private void btnCalcCaractInterna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalcCaractExterna_Click(object sender, RoutedEventArgs e)
        {

        }

        // PAGINA CALIDAD FINAL

        // Validar datos
        
        private bool configPDF()
        {
            if (txtNombreArchivor.Text == string.Empty)
                return false;
            return true;
        }

        private bool datosReporte()
        {
            if (txtObjetivos.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        // Eventos botones

        private void btnCalcCalidadInterna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            if (datosReporte())
            {
                if (configPDF())
                {

                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el nombre del archivo para generar el reporte", "Configuración reporte calidad", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el objetivo de la evaluación para generar el reporte", "Reporte calidad final software", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // FIN 

		private void tileGenerarPDF_Click(object sender, RoutedEventArgs e)
		{
			// Contruir el archivo pdf

			// Guardar Archivo PDF

			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			// Set filter options and filter index.
			openFileDialog1.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;

			openFileDialog1.Multiselect = true;

			// Call the ShowDialog method to show the dialog box.


			// Process input if the user clicked OK.
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{

			}
		}
    }
}
