using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Etiquetas;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using System.Collections.Generic;
using System.Windows;
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

        // Crea las listas para mostrar y guardar las metricas respondidas

        private void inicializarListas()
        {
            if (isFunIntAct)
            {
                this.funcionalidadInterna = new List<JMetrica>();
                this.MTSfuncionalidadInterna = new List<MTSeleccion>();
                this.MTEfuncionalidadInterna = new List<MTEvaluacion>();
            }

            if (isFunExtAct)
            {
                this.funcionalidadExterna = new List<JMetrica>();
                this.MTSfuncionalidadExterna = new List<MTSeleccion>();
                this.MTEfuncionalidadExterna = new List<MTEvaluacion>();
            }

            if (isUsaIntAct)
            {
                this.usabilidadInterna = new List<JMetrica>();
                this.MTSusabilidadInterna = new List<MTSeleccion>();
                this.MTEusabilidadInterna = new List<MTEvaluacion>();
            }

            if (isUsaExtAct)
            {
                this.usabilidadExterna = new List<JMetrica>();
                this.MTSusabilidadExterna = new List<MTSeleccion>();
                this.MTEusabilidadExterna = new List<MTEvaluacion>();
            }

            if (isManIntAct)
            {
                this.mantenibilidadInterna = new List<JMetrica>();
                this.MTSmantenibilidadInterna = new List<MTSeleccion>();
                this.MTEmantenibilidadInterna = new List<MTEvaluacion>();
            }

            if (isManExtAct)
            {
                this.mantenibilidadExterna = new List<JMetrica>();
                this.MTSmantenibilidadExterna = new List<MTSeleccion>();
                this.MTEmantenibilidadExterna = new List<MTEvaluacion>();
            }
        }

        // Carga los estado de la seleccion de las caracteristicas Interna/externa

        private void cargarEstados(Evaluacion evaSeleccion)
        {
            if (evaSeleccion.EvaluacionMetricas.FuncionalidadInterna)
                isFunIntAct = true;
            else
                isFunIntAct = false;

            if (evaSeleccion.EvaluacionMetricas.FuncionalidadExterna)
                isFunExtAct = true;
            else
                isFunExtAct = false;

            if (evaSeleccion.EvaluacionMetricas.UsabilidadInterna)
                isUsaIntAct = true;
            else
                isUsaIntAct = false;

            if (evaSeleccion.EvaluacionMetricas.UsabilidadExterna)
                isUsaExtAct = true;
            else
                isUsaExtAct = false;

            if (evaSeleccion.EvaluacionMetricas.MantenibilidadInterna)
                isManIntAct = true;
            else
                isManIntAct = false;

            if (evaSeleccion.EvaluacionMetricas.MantenibilidadExterna)
                isManExtAct = true;
            else
                isManExtAct = false;
        }

        // Cambia las etiquetas de los estados de la evaluacion de metricas

        private void cargarEtiquetasEstados()
        {
            // A futuro comprobar el estado actual al hacer la re seleccion de caracteristicas y subcaracteristicas
            // para editar el estado actual y no reescribir de cero.

            if (isFunIntAct)
                miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna.cambiarEstado(0);

            cambiarEtiquetaGraficaEstado(miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna, lblEstadoFuncInterna);


            if (isFunExtAct)
                miEvaluacion.EtiquetasEvaluacion.FuncionalidadExterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasEvaluacion.FuncionalidadExterna.cambiarEstado(0);

            cambiarEtiquetaGraficaEstado(miEvaluacion.EtiquetasEvaluacion.FuncionalidadExterna, lblEstadoFuncExterna);


            if (isUsaIntAct)
                miEvaluacion.EtiquetasEvaluacion.UsabilidadInterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasEvaluacion.UsabilidadInterna.cambiarEstado(0);

            cambiarEtiquetaGraficaEstado(miEvaluacion.EtiquetasEvaluacion.UsabilidadInterna, lblEstadoUsabInterna);


            if (isUsaExtAct)
                miEvaluacion.EtiquetasEvaluacion.UsabilidadExterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasEvaluacion.UsabilidadExterna.cambiarEstado(0);

            cambiarEtiquetaGraficaEstado(miEvaluacion.EtiquetasEvaluacion.UsabilidadExterna, lblEstadoUsabExterna);


            if (isManIntAct)
                miEvaluacion.EtiquetasEvaluacion.MantenibilidadInterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasEvaluacion.MantenibilidadInterna.cambiarEstado(0);

            cambiarEtiquetaGraficaEstado(miEvaluacion.EtiquetasEvaluacion.MantenibilidadInterna, lblEstadoMantInterna);


            if (isManExtAct)
                miEvaluacion.EtiquetasEvaluacion.MantenibilidadExterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasEvaluacion.MantenibilidadExterna.cambiarEstado(0);

            cambiarEtiquetaGraficaEstado(miEvaluacion.EtiquetasEvaluacion.MantenibilidadExterna, lblEstadoMantExterna);
        }

        // Activa los botones del los Tile de evaluacion de metricas

        private void cargarTilesMetricas()
        {
            if (isFunIntAct)
                btnFuncInterna.IsEnabled = true;
            else
                btnFuncInterna.IsEnabled = false;

            if (isFunExtAct)
                btnFuncExterna.IsEnabled = true;
            else
                btnFuncExterna.IsEnabled = false;

            if (isUsaIntAct)
                btnUsabInterna.IsEnabled = true;
            else
                btnUsabInterna.IsEnabled = false;

            if (isUsaExtAct)
                btnUsabExterna.IsEnabled = true;
            else
                btnUsabExterna.IsEnabled = false;

            if (isManIntAct)
                btnMantInterna.IsEnabled = true;
            else
                btnMantInterna.IsEnabled = false;

            if (isManExtAct)
                btnMantExterna.IsEnabled = true;
            else
                btnMantExterna.IsEnabled = false;
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
            MessageBoxResult respuesta;
            Button clickedButton = (Button)e.Source;

            //Comprobar el estado de la evaluación

            if (miEvaluacion.Estado)
            {
                switch (clickedButton.Name)
                {
                    case "btnFuncInterna":

                        if (miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                            }

                        }
                      
                    break;

                    case "btnUsabInterna":

                        if (miEvaluacion.EtiquetasEvaluacion.UsabilidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.UsabilidadInterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna, MTEusabilidadInterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEusabilidadInterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna, MTEusabilidadInterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEusabilidadInterna = paginaEvaluacion.evaluacionMetrica();
                            }
                        }

                    break;

                    case "btnMantInterna":

                        if (miEvaluacion.EtiquetasEvaluacion.MantenibilidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.MantenibilidadInterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna, MTEmantenibilidadInterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEmantenibilidadInterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna, MTEmantenibilidadInterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEmantenibilidadInterna = paginaEvaluacion.evaluacionMetrica();
                            }
                        }

                    break;

                    case "btnFuncExterna":

                        if (miEvaluacion.EtiquetasEvaluacion.FuncionalidadExterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.FuncionalidadExterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Externa", funcionalidadExterna, MTSfuncionalidadExterna, MTEfuncionalidadExterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEfuncionalidadExterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Externa", funcionalidadExterna, MTSfuncionalidadExterna, MTEfuncionalidadExterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEfuncionalidadExterna = paginaEvaluacion.evaluacionMetrica();
                            }
                        }

                    break;

                    case "btnUsabExterna":

                        if (miEvaluacion.EtiquetasEvaluacion.UsabilidadExterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.UsabilidadExterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna, MTEusabilidadExterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEusabilidadExterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna, MTEusabilidadExterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEusabilidadExterna = paginaEvaluacion.evaluacionMetrica();
                            }
                        }

                    break;

                    case "btnMantExterna":

                        if (miEvaluacion.EtiquetasEvaluacion.MantenibilidadExterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.MantenibilidadExterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna, MTEmantenibilidadExterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEmantenibilidadExterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna, MTEmantenibilidadExterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEmantenibilidadExterna = paginaEvaluacion.evaluacionMetrica();
                            }
                        }

                    break;

                    default:

                        if (miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasEvaluacion.FuncionalidadInterna.Etiqueta.Equals("COMPLETAR"))
                        {
                            paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                            this.NavigationService.Navigate(paginaEvaluacion);
                            MTEfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                        }
                        else
                        {
                            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación finalizada, al continuar se perderan los calculos realizados en la sección Evaluación de Calidad, ¿desea continuar? ", "Evaluación de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (respuesta == MessageBoxResult.Yes)
                            {
                                paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                                this.NavigationService.Navigate(paginaEvaluacion);
                                MTEfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                            }
                        }

                    break;
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe crear la evaluación para usar este modulo", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
