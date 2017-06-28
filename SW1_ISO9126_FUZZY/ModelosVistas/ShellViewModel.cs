using MahApps.Metro.IconPacks;
using System;

namespace SW1_ISO9126_FUZZY.ModelosVistas {

    internal class ShellViewModel : ViewModelBase {

        public ShellViewModel() {
            // Build the menus
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Book }, Text = "Evaluación de Calidad", NavigationDestination = new Uri("Vistas/EvaluacionPage.xaml", UriKind.RelativeOrAbsolute) });

            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Cogs }, Text = "Configuración de Métricas", NavigationDestination = new Uri("Vistas/ConfiguracionMetricasPage.xaml", UriKind.RelativeOrAbsolute) });
            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircle }, Text = "Acerca", NavigationDestination = new Uri("Vistas/AcercaPage.xaml", UriKind.RelativeOrAbsolute) });
        }
    }
}
