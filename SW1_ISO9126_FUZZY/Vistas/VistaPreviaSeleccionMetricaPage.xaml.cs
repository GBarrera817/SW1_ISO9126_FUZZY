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
	/// Lógica de interacción para VistaPreviaSeleccionMetricaPage.xaml
	/// </summary>
	public partial class VistaPreviaSeleccionMetricaPage : Page
	{
		public VistaPreviaSeleccionMetricaPage()
		{
			InitializeComponent();
		}


		private void btnAbrirFlyout_Click(object sender, RoutedEventArgs e)
		{
			//flyoutSeleccionMetricas.IsOpen = true;
			this.NavigationService.Navigate(new Uri("Vistas/SeleccionMetricasPage.xaml", UriKind.Relative));
		}

		private void btnEstadoFuncInterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoUsabInterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoMantInterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoFuncExterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoUsabExterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoMantExterna_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
