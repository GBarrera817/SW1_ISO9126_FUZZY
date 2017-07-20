using SW1_ISO9126_FUZZY.Modelo_Datos;
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

        private FormEvaluacionPage paginaEvaluacion;
        private Respuesta metricas;
        private EstadoModulo evalMetricas;
        private Evaluacion miEvaluacion;

        public FormularioEvaluacionPage(Evaluacion nueva) {

            InitializeComponent();
            this.paginaEvaluacion = new FormEvaluacionPage();
            this.metricas = new Respuesta();
            this.evalMetricas = new EstadoModulo();
            this.miEvaluacion = nueva;

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

            paginaEvaluacion.FuncInterna_Activar(this);
            this.NavigationService.Navigate(paginaEvaluacion);
            // Navigation.Navigation.Navigate(paginaEvaluacion);

        }

        private void btnUsabInterna_Click(object sender, RoutedEventArgs e)
        {
            paginaEvaluacion.UsabInterna_Activar(this);
            this.NavigationService.Navigate(paginaEvaluacion);
        }

        private void btnMantInterna_Click(object sender, RoutedEventArgs e)
        {
            paginaEvaluacion.MantInterna_Activar(this);
            this.NavigationService.Navigate(paginaEvaluacion);
        }


        private void btnFuncExterna_Click(object sender, RoutedEventArgs e)
        {
            paginaEvaluacion.FuncExterna_Activar(this);
            this.NavigationService.Navigate(paginaEvaluacion);
        }


        private void btnUsabExterna_Click(object sender, RoutedEventArgs e)
        {
            paginaEvaluacion.UsabExterna_Activar(this);
            this.NavigationService.Navigate(paginaEvaluacion);
        }


        private void btnMantExterna_Click(object sender, RoutedEventArgs e)
        {
            paginaEvaluacion.MantExterna_Activar(this);
            this.NavigationService.Navigate(paginaEvaluacion);
        }
    }
}
