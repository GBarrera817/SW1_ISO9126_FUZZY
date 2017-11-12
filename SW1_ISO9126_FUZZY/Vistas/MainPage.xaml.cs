using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private bool estadoEvaluacion;
        private Evaluacion miEvaluacion;
        private RegistroSWPage paginaRegistro;

        public MainPage(Evaluacion nueva, RegistroSWPage pagina)
        {
            InitializeComponent();
            this.miEvaluacion = nueva;
            this.estadoEvaluacion = false;
            this.paginaRegistro = pagina;
        }

        private void btnComenzarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (!estadoEvaluacion)
            {               
                estadoEvaluacion = true;
                miEvaluacion.Estado = estadoEvaluacion;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(paginaRegistro);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

		private void btnCargarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            MessageBoxResult respuesta;

            if (!estadoEvaluacion)
            {
                cargarJson();
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

               if (respuesta == MessageBoxResult.Yes)
                {
                    cargarJson();
                }
            }
        }

        private void cargarJson()
        {
            //string filtro "Archivos JSON (.json)|*.json|Todos los archivos (*.*)|*.*";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string filtro = "Archivos JSON (.json)|*.json";
            openFileDialog1.Filter = filtro;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            var resultado = openFileDialog1.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                /* validar Json
                if (validarJson())
                {
                    // Cargar evaluacion desde JSON, json object to .net object
                }else{
                    mensaje de error
                }*/


                // Cargar evaluacion desde JSON, json object to .net object

                estadoEvaluacion = true;
                miEvaluacion.Estado = estadoEvaluacion;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación cargada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(paginaRegistro);
            }

            if (resultado == DialogResult.Cancel)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Carga de evaluación desde archivo cancelada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool validarJson()
        {
            // Verifica la estructura del json
            return true;
        }

        private void loadMessenger()
        {
            Navigation.Navigation.Navigate(new Uri("https://www.messenger.com/login.php"));
        }

        /* Ejemplos de MessageBox
         
            MessageBoxResult result4 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result1 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            MessageBoxResult result7 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            MessageBoxResult result5 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            Windows.MessageBox

		        MessageBoxResult respuesta;

		        respuesta = System.Windows.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

		        if (respuesta == MessageBoxResult.Yes)

            Windows.Forms.MessageBox
			
			    DialogResult  respuesta;

                respuesta = System.Windows.Forms.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
			
            Xceed.Wpf.ToolKit.MessageBox
			
				MessageBoxResult respuesta;

				respuesta = System.Windows.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

				if (respuesta == MessageBoxResult.Yes)
        */
    }
}
