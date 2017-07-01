using MahApps.Metro.IconPacks;
using System;

namespace SW1_ISO9126_FUZZY.ModelosVistas {

    internal class ShellViewModel : ViewModelBase {

        public ShellViewModel() {
            // Build the menus
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Book }, Text = "Registro de Software", NavigationDestination = new Uri("Vistas/RegistroSWPage.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CheckSquare }, Text = "Evaluación de Calidad", NavigationDestination = new Uri("Vistas/EvaluacionSWPage.xaml", UriKind.RelativeOrAbsolute) });

            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CheckSquare }, Text = "Fondo", NavigationDestination = new Uri("Vistas/MuestraPage.xaml", UriKind.RelativeOrAbsolute) });
            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Cogs }, Text = "Configuración de Métricas", NavigationDestination = new Uri("Vistas/ConfiguracionMetricasPage.xaml", UriKind.RelativeOrAbsolute) });
            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircle }, Text = "Acerca", NavigationDestination = new Uri("Vistas/AcercaPage.xaml", UriKind.RelativeOrAbsolute) });
        }
    }
}
