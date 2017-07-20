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


        public MainPage(Evaluacion nueva)
        {
            InitializeComponent();
            this.miEvaluacion = nueva;
            this.estadoEvaluacion = false;
        }

        public Evaluacion MiEvaluacion { get => miEvaluacion; set => miEvaluacion = value; }

        private void btnComenzarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (!estadoEvaluacion)
            {               
                estadoEvaluacion = true;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new RegistroSWPage(miEvaluacion));
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

		private void btnCargarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Navigation.Navigation.Navigate(new Uri("https://www.messenger.com/login.php"));
/*
            if (!estadoEvaluacion)
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
                    // Cargar evaluacion desde JSON, json object to .net object

                    estadoEvaluacion = true;

                    Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);

                    Navigation.Navigation.Navigate(new Uri("Vistas/RegistroSWPage.xaml", UriKind.Relative));
                }

                if (resultado == DialogResult.Cancel)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Carga de evaluación desde archivo cancelada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
*/
        }

        /* Ejemplos de MessageBox
         
            MessageBoxResult result4 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result1 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            MessageBoxResult result7 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            MessageBoxResult result5 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        */
    }
}
