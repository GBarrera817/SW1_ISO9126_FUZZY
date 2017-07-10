using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para FormEvaluacionPage.xaml
	/// </summary>
	public partial class FormEvaluacionPage : Page
	{
		public FormEvaluacionPage()
		{
			InitializeComponent();
		}

		private void txtParam1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void txtParam0_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void sliderParam0_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

		}

		private void sliderParam1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

		}

		private void btnSiguiente_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnAnterior_Click(object sender, RoutedEventArgs e)
		{
			/*if(e.OriginalSource != sender)
			{
				e.Handled = true;
			}
			else{
				MessageBox.Show("Hola");
			}*/
		}

		private void btnFinalizarCuestionario_Click(object sender, RoutedEventArgs e)
		{

		}
    
		private void btnGuardar_Click(object sender, RoutedEventArgs e)
		{
            this.NavigationService.Navigate(new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.Relative));
        }
    
	}
}
