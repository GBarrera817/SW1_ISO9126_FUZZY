using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Etiquetas;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para FormularioEvaluacionPage.xaml
    /// </summary>
    
    public partial class FormularioEvaluacionPage : Page
    {
        // Estado caracteristicas
        private bool isFunIntAct;
        private bool isFunExtAct;
        private bool isUsaIntAct;
        private bool isUsaExtAct;
        private bool isManIntAct;
        private bool isManExtAct;

        // Listas de caracteristicas
        private List<JMetrica> funcionalidadInterna;
        private List<JMetrica> funcionalidadExterna;
        private List<JMetrica> usabilidadInterna;
        private List<JMetrica> usabilidadExterna;
        private List<JMetrica> mantenibilidadInterna;
        private List<JMetrica> mantenibilidadExterna;

        // Listas de caracteristicas seleccionadas
        private List<MTSeleccion> MTSfuncionalidadInterna;
        private List<MTSeleccion> MTSfuncionalidadExterna;
        private List<MTSeleccion> MTSusabilidadInterna;
        private List<MTSeleccion> MTSusabilidadExterna;
        private List<MTSeleccion> MTSmantenibilidadInterna;
        private List<MTSeleccion> MTSmantenibilidadExterna;

        // Listas de caracteristicas evaluadas
        private List<MTEvaluacion> MTEfuncionalidadInterna;
        private List<MTEvaluacion> MTEfuncionalidadExterna;
        private List<MTEvaluacion> MTEusabilidadInterna;
        private List<MTEvaluacion> MTEusabilidadExterna;
        private List<MTEvaluacion> MTEmantenibilidadInterna;
        private List<MTEvaluacion> MTEmantenibilidadExterna;

        private FormEvaluacionPage paginaEvaluacion;
        private Evaluacion miEvaluacion;

        public FormularioEvaluacionPage(Evaluacion nueva) {

            InitializeComponent();

            this.paginaEvaluacion = new FormEvaluacionPage();
            this.miEvaluacion = nueva;

            // Componentes necesarios
            inicializarEstadoCaracteristica();
            inicializarListasEvaluacion();
        }

        // Inicializar estados caracteristicas Interna/Externa

        private void inicializarEstadoCaracteristica()
        {
            this.isFunIntAct = false;
            this.isFunExtAct = false;
            this.isUsaIntAct = false;
            this.isUsaExtAct = false;
            this.isManIntAct = false;
            this.isManExtAct = false;
        }

        // Crea las listas para guardar la evaluacion

        private void inicializarListasEvaluacion()
        {
            this.MTEfuncionalidadInterna = new List<MTEvaluacion>();
            this.MTEfuncionalidadExterna = new List<MTEvaluacion>();
            this.MTEusabilidadInterna = new List<MTEvaluacion>();
            this.MTEusabilidadExterna = new List<MTEvaluacion>();
            this.MTEmantenibilidadInterna = new List<MTEvaluacion>();
            this.MTEmantenibilidadExterna = new List<MTEvaluacion>();
        }

        // Cambia las letras y los colores de las etiquetas de estado

        public void cambiarEtiquetaGraficaEstado(ColorEstado estado, Label etiqueta)
        {
            var bc = new BrushConverter();

            etiqueta.Background = (Brush)bc.ConvertFrom(estado.Color);
            etiqueta.Content = estado.Etiqueta;
        }

        // Eventos botones menu flotante (flyout)

        private void btnTileClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Button clickedButton = (Button)e.Source;

            //Comprobar el estado de la seleccion de metricas

            switch (clickedButton.Name)
            {
                case "btnFuncInterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                    MTSfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnUsabInterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna, MTEusabilidadInterna);
                    MTSusabilidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnMantInterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna, MTEmantenibilidadInterna);
                    MTSmantenibilidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnFuncExterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Externa", funcionalidadExterna, MTSfuncionalidadExterna, MTEfuncionalidadExterna);
                    MTSfuncionalidadExterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnUsabExterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna, MTEusabilidadExterna);
                    MTSusabilidadExterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnMantExterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna, MTEmantenibilidadExterna);
                    MTSmantenibilidadExterna = paginaEvaluacion.evaluacionMetrica();
                break;

                default:
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                    MTSfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;
            }

            this.NavigationService.Navigate(paginaEvaluacion);
        }
    }
}
