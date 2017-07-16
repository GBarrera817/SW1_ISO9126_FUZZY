using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para FormularioEvaluacionPage.xaml
    /// </summary>
    public partial class FormularioEvaluacionPage : Page {
        public FormularioEvaluacionPage() {
            InitializeComponent();
        }


        private void cambiarEstado(int estado, Label etiqueta)
        {
            var bc = new BrushConverter();
            string[] estados = new string[] { "INACTIVA", "REALIZAR", "COMPLETAR", "FINALIZADO" };
            string[] colores = new string[] { "#FF000033", "#FFCC0000", "#FFE6E600", "#FF00802B" };

            etiqueta.Background = (Brush)bc.ConvertFrom(colores[estado]);
            etiqueta.Content = estados[estado];
        }

        // Eventos botones

        private void btnFuncInterna_Click(object sender, RoutedEventArgs e)
        {
			
            // Cambia de página
            this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnMantInterna_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnUsabInterna_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnFuncExterna_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnMantExterna_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnUsabExterna_Click(object sender, RoutedEventArgs e)
        {
            // Xceed.Wpf.Toolkit.MessageBox.Show("btn usab externa");
            this.NavigationService.Navigate(new Uri("Vistas/FormEvaluacionPage.xaml", UriKind.Relative));
        }

        private void btnEstadoMantInterna_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
