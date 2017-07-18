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
        private Evaluacion miEvaluacion;
        private bool estadoEvaluacion;

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
                miEvaluacion = new Evaluacion();
                estadoEvaluacion = true;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);

                Navigation.Navigation.Navigate(new Uri("Vistas/RegistroSWPage.xaml", UriKind.Relative));
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

		private void btnCargarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{

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
        }
	}
}
