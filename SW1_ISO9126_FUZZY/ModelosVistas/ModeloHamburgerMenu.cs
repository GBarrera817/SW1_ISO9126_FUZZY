using MahApps.Metro.IconPacks;
using System;

namespace SW1_ISO9126_FUZZY.ModelosVistas {

    internal class ModeloHamburgerMenu : ModeloVistaBase {

        public ModeloHamburgerMenu() {
			// Construcción de los menús que se ven en Hamburger Menu

			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Home }, Text = "Inicio", NavigationDestination = new Uri("Vistas/MainPage.xaml", UriKind.RelativeOrAbsolute) });
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.IdCard }, Text = "Registro de Software", NavigationDestination = new Uri("Vistas/RegistroSWPage.xaml", UriKind.RelativeOrAbsolute) });			
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.ListAlt }, Text = "Selección de Métricas", NavigationDestination = new Uri("Vistas/SeleccionMetricasPage.xaml", UriKind.RelativeOrAbsolute) });
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Clipboard }, Text = "Formulario de Evaluación", NavigationDestination = new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.RelativeOrAbsolute) });
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.AreaChart}, Text = "Evaluación de Calidad", NavigationDestination = new Uri("Vistas/EvaluacionCalidadPage.xaml", UriKind.RelativeOrAbsolute) });
				


			//Contrucción de las opciones del menú que se ven en el Hamburger Menu
			this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircle }, Text = "Acerca", NavigationDestination = new Uri("Vistas/AcercaPage.xaml", UriKind.RelativeOrAbsolute) });
        }
    }
}
