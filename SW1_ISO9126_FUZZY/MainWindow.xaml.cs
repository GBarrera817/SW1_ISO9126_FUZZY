using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using MahApps.Metro.Controls;
using SW1_ISO9126_FUZZY.Vistas;
using MenuItem = SW1_ISO9126_FUZZY.ModelosVistas.MenuItem;
using SW1_ISO9126_FUZZY.Modelo_Datos;

namespace SW1_ISO9126_FUZZY {

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public partial class MainWindow
    {
        private MainPage principal;
        private RegistroSWPage registro;
        private VistaPreviaSeleccionMetricaPage previaSeleccion;
        private FormularioEvaluacionPage previaEvaluacion;
        private EvaluacionCalidadPage calidad;
        private AcercaPage acerca;

        private Evaluacion proyecto;

        public MainWindow()
        {
            InitializeComponent();
            inicializarEvaluacion();
            inicializarPaginas();

            //this.HamburgerMenuControl.IsPaneOpen = false;

            // Navigate to the home page.
            Navigation.Navigation.Frame = new Frame(); //SplitViewFrame;
            Navigation.Navigation.Frame.Navigated += SplitViewFrame_OnNavigated;
            this.Loaded += (sender, args) => Navigation.Navigation.Navigate(principal);
            //this.SplitViewFrame_OnNavigated.ShowTitleBar = true;
        }

        private void inicializarEvaluacion()
        {
            proyecto = new Evaluacion();
        }

        private void inicializarPaginas()
        {
            acerca = new AcercaPage();
            calidad = new EvaluacionCalidadPage(proyecto);
            previaEvaluacion = new FormularioEvaluacionPage(proyecto);
            previaSeleccion = new VistaPreviaSeleccionMetricaPage(proyecto);
            registro = new RegistroSWPage(proyecto, previaSeleccion);
            principal = new MainPage(proyecto,registro);

            //HamburgerMenuItemCollection itemCollection = HamburgerMenuControl.ItemsSource as HamburgerMenuItemCollection;
            // itemCollection[0].Label = "Hola";
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            HamburgerMenuControl.Content = e.Content;
            //btnAtrás.Visibility = Navigation.Navigation.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;

            //if (menuItem != null && menuItem.IsNavigation)
            //{
            //    Navigation.Navigation.Navigate(menuItem.NavigationDestination);
            //}

            if (menuItem.Text == "Inicio")
            {
                Navigation.Navigation.Navigate(principal);
            }

            if (menuItem.Text == "Registro de Evaluación")
            {             
                Navigation.Navigation.Navigate(registro);
            }

            if (menuItem.Text == "Selección de Métricas")
            {
                Navigation.Navigation.Navigate(previaSeleccion);
            }

            if (menuItem.Text == "Formulario de Evaluación")
            {
                Navigation.Navigation.Navigate(previaEvaluacion);
            }

            if (menuItem.Text == "Evaluación de Calidad")
            {
                Navigation.Navigation.Navigate(calidad);
            }

            if (menuItem.Text == "Acerca")
            {
                Navigation.Navigation.Navigate(acerca);
                Xceed.Wpf.Toolkit.MessageBox.Show(proyecto.Informacion.ToString(), "Datos del software", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /* 
        private void IrAtras_OnClick(object sender, RoutedEventArgs e) {
            Navigation.Navigation.GoBack();
        }
        */
    }
}
