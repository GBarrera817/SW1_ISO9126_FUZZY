using System;
using System.Windows;
using System.Windows.Controls;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para FormularioEvaluacionPage.xaml
    /// </summary>
    public partial class FormularioEvaluacionPage : Page {
        public FormularioEvaluacionPage() {
            InitializeComponent();
        }

        private void btnFuncInterna_Click(object sender, RoutedEventArgs e)
        {
			
            // Cambia de página
            //this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnMantInterna_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn mant interna");
        }

        private void btnUsabInterna_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn usab interna");
        }

        private void btnFuncExterna_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn func externa");
        }

        private void btnMantExterna_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn mant externa");
        }

        private void btnUsabExterna_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("btn usab externa");
        }
    }
}
