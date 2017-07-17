using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

		
		private void btnComenzarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new Uri("Vistas/RegistroSWPage.xaml", UriKind.Relative));
		}

		private void btnCargarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			// Set filter options and filter index.
			openFileDialog1.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;

			openFileDialog1.Multiselect = true;

			// Process input if the user clicked OK.
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				
			}
		}
	}
}
