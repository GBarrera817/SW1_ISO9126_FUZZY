using SW1_ISO9126_FUZZY.Modelo_Datos;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using SW1_ISO9126_FUZZY.Archivos;
using System.IO;
using System;

namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para EvaluacionCalidadPage.xaml
	/// </summary>
	public partial class EvaluacionCalidadPage : Page
	{
      /*  private Calculo metricas;
        private EstadoModulo resulMetricas;*/
        private Evaluacion miEvaluacion;

        public EvaluacionCalidadPage(Evaluacion nueva)
		{
			InitializeComponent();
           /* this.metricas = new Calculo();
            this.resulMetricas = new EstadoModulo();*/
            this.miEvaluacion = nueva;
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
            if (txtNombreArchivo.Text == string.Empty)
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

        private void btnCalcCalidadFinal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
           // if (datosReporte())
          //  {
           //     if (configPDF())
            //    {
					Stream myStream = null;
			
					SaveFileDialog saveFileDialog1 = new SaveFileDialog();
					string ruta = saveFileDialog1.FileName;
					saveFileDialog1.InitialDirectory = "c:\\Documentos";
					saveFileDialog1.FileName = txtNombreArchivo.Text;
					saveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
					saveFileDialog1.DefaultExt = "pdf";
					saveFileDialog1.AddExtension = true;
					saveFileDialog1.FilterIndex = 2;
					saveFileDialog1.RestoreDirectory = true;

					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					{
						Reportes r = new Reportes(saveFileDialog1.FileName);
				Xceed.Wpf.Toolkit.MessageBox.Show("El archivo se ha creado correctamente");
					}
			//	}
             //   else
            //    {
            //        Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el nombre del archivo para generar el reporte", "Configuración reporte calidad", MessageBoxButton.OK, MessageBoxImage.Error);
				//}
           // }
           // else
           // {
           //     Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el objetivo de la evaluación para generar el reporte", "Reporte calidad final software", MessageBoxButton.OK, MessageBoxImage.Warning);
           // }
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
