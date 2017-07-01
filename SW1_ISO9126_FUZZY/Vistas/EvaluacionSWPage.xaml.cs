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
    /// Lógica de interacción para EvaluacionSWPage.xaml
    /// </summary>
    public partial class EvaluacionSWPage : Page {
        public EvaluacionSWPage() {
            InitializeComponent();
        }

        private void btnFuncInterna_Click(object sender, RoutedEventArgs e)
        {
            // Cambia de página
            this.NavigationService.Navigate(new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.Relative));
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
