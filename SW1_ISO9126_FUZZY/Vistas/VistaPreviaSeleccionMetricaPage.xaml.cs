﻿using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Etiquetas;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para VistaPreviaSeleccionMetricaPage.xaml
	/// </summary>
    
	public partial class VistaPreviaSeleccionMetricaPage : Page
	{
        // Caracteristicas
        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;

        // Estado caracteristicas
        private bool isFunIntAct;
        private bool isFunExtAct;
        private bool isUsaIntAct;
        private bool isUsaExtAct;
        private bool isManIntAct;
        private bool isManExtAct;

        // Listas de caracteristicas
        private ArrayList funcionalidadInterna;
        private ArrayList funcionalidadExterna;
        private ArrayList usabilidadInterna;
        private ArrayList usabilidadExterna;
        private ArrayList mantenibilidadInterna;
        private ArrayList mantenibilidadExterna;

        // Listas de caracteristicas seleccionadas
        private ArrayList MTSfuncionalidadInterna;
        private ArrayList MTSfuncionalidadExterna;
        private ArrayList MTSusabilidadInterna;
        private ArrayList MTSusabilidadExterna;
        private ArrayList MTSmantenibilidadInterna;
        private ArrayList MTSmantenibilidadExterna;

        private SeleccionMetricasPage paginaSeleccion;
        /*private Seleccion metricas;
        private EstadoModulo selecMetricas;*/
        private Evaluacion miEvaluacion;


        public VistaPreviaSeleccionMetricaPage(Evaluacion nueva)
		{
			InitializeComponent();

            this.paginaSeleccion = new SeleccionMetricasPage();
            /*this.metricas = new Seleccion();
            this.selecMetricas = new EstadoModulo();*/
            this.miEvaluacion = nueva;

            inicializarEstadoCaracteristica();
            cargarJsonMetricas();

            // Tablas iniciales
            cargarTablaFuncionabilidad(funInt, DataGridEstadoMetricasInternas);
            cargarTablaFuncionabilidad(funExt, DataGridEstadoMetricasExternas);
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

        // Cargar las metricas desde archivos JSON

        private void cargarJsonMetricas()
        {
            funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
            funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
            usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
            usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
            manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
            manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));
        }

        // Crea las listas para mostrar y guardar las metricas

        private void inicializarListas()
        {
            if (isFunIntAct)
            {
                this.funcionalidadInterna = new ArrayList();
                this.MTSfuncionalidadInterna = new ArrayList();
            }

            if (isFunExtAct)
            {
                this.funcionalidadExterna = new ArrayList();
                this.MTSfuncionalidadExterna = new ArrayList();
            }

            if (isUsaIntAct)
            {
                this.usabilidadInterna = new ArrayList();
                this.MTSusabilidadInterna = new ArrayList();
            }

            if (isUsaExtAct)
            {
                this.usabilidadExterna = new ArrayList();
                this.MTSusabilidadExterna = new ArrayList();
            }

            if (isManIntAct)
            {
                this.mantenibilidadInterna = new ArrayList();
                this.MTSmantenibilidadInterna = new ArrayList();
            }

            if (isManExtAct)
            {
                this.mantenibilidadExterna = new ArrayList();
                this.MTSmantenibilidadExterna = new ArrayList();
            }
        }

        // Carga los estado de la seleccion de las caracteristicas Interna/externa

        private void cargarEstados(Evaluacion evaSeleccion)
        {
            if (evaSeleccion.DatosMetricas.FuncionalidadInterna)
                isFunIntAct = true;
            else
                isFunIntAct = false;

            if (evaSeleccion.DatosMetricas.FuncionalidadExterna)
                isFunExtAct = true;
            else
                isFunExtAct = false;

            if (evaSeleccion.DatosMetricas.UsabilidadInterna)
                isUsaIntAct = true;
            else
                isUsaIntAct = false;

            if (evaSeleccion.DatosMetricas.UsabilidadExterna)
                isUsaExtAct = true;
            else
                isUsaExtAct = false;

            if (evaSeleccion.DatosMetricas.MantenibilidadInterna)
                isManIntAct = true;
            else
                isManIntAct = false;

            if (evaSeleccion.DatosMetricas.MantenibilidadExterna)
                isManExtAct = true;
            else
                isManExtAct = false;
        }

        // Crea las listas de metricas por caracteristicas Internas/Externas

        private void cargarListasMetricas()
        {
            if (isFunIntAct)
                cargarListaFuncionabilidad(miEvaluacion, funInt, funcionalidadInterna);

            if (isFunExtAct)
                cargarListaFuncionabilidad(miEvaluacion, funExt, funcionalidadExterna);

            if (isUsaIntAct)
                cargarListaUsabilidad(miEvaluacion, usaInt, usabilidadInterna);

            if (isUsaExtAct)
                cargarListaUsabilidad(miEvaluacion, usaExt, usabilidadExterna);

            if (isManIntAct)
                cargarListaMantenibilidad(miEvaluacion, manInt, mantenibilidadInterna);

            if (isManExtAct)
                cargarListaMantenibilidad(miEvaluacion, manExt, mantenibilidadExterna);
        }

        // Cambia las etiquetas de los estados de la seleccion de metricas

        private void cargarEtiquetasEstados()
        {
            // A futuro comprobar el estado actual al hacer la re seleccion de caracteristicas y subcaracteristicas
            // para editar el estado actual y no reescribir de cero.

            if (isFunIntAct)          
                miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna.cambiarEstado(1);                       
            else          
                miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna.cambiarEstado(0);

            cambiarEstado(miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna, lblEstadoMetricasFuncInterna);
            
                
            if (isFunExtAct)
                miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna.cambiarEstado(0);

            cambiarEstado(miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna, lblEstadoMetricasFuncExterna);
             
            
            if (isUsaIntAct)           
                miEvaluacion.EtiquetasSeleccion.UsabilidadInterna.cambiarEstado(1);           
            else           
                miEvaluacion.EtiquetasSeleccion.UsabilidadInterna.cambiarEstado(0);

            cambiarEstado(miEvaluacion.EtiquetasSeleccion.UsabilidadInterna, lblEstadoMetricasUsabInterna);
              

            if (isUsaExtAct)
                miEvaluacion.EtiquetasSeleccion.UsabilidadExterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasSeleccion.UsabilidadExterna.cambiarEstado(0);

            cambiarEstado(miEvaluacion.EtiquetasSeleccion.UsabilidadExterna, lblEstadoMetricasUsabExterna);
              
            
            if (isManIntAct)
                miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna.cambiarEstado(0);

            cambiarEstado(miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna, lblEstadoMetricasMantInterna);
                

            if (isManExtAct)
                miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna.cambiarEstado(1);
            else
                miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna.cambiarEstado(0);

            cambiarEstado(miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna, lblEstadoMetricasMantExterna);
        }

        // Activa los botones del menu de seleccion de metricas

        private void cargarMenuMetricas()
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

        // Crear listas de metricas por caracteristicas
     
        private void cargarListaFuncionabilidad(Evaluacion datosEvaluacion, JFuncionabilidad funcionalidad, ArrayList metricas)
        {
            if (datosEvaluacion.EstSubcaracteristicas.SubCarfuncionalidad.EstAdecuacion)
                for (int i = 0; i < funcionalidad.Adecuacion.Length; i++)
                    metricas.Add(funcionalidad.Adecuacion[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarfuncionalidad.EstExactitud)
                for (int i = 0; i < funcionalidad.Exactitud.Length; i++)
                    metricas.Add(funcionalidad.Exactitud[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarfuncionalidad.EstInteroperabilidad)
                for (int i = 0; i < funcionalidad.Interoperabilidad.Length; i++)
                    metricas.Add(funcionalidad.Interoperabilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarfuncionalidad.EstSeguridadAcceso)
                for (int i = 0; i < funcionalidad.SeguridadAcceso.Length; i++)
                    metricas.Add(funcionalidad.SeguridadAcceso[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarfuncionalidad.EstCumplimientoFuncional)
                for (int i = 0; i < funcionalidad.CumplimientoFuncional.Length; i++)
                    metricas.Add(funcionalidad.CumplimientoFuncional[i]);
        }

        private void cargarListaUsabilidad(Evaluacion datosEvaluacion, JUsabilidad usabilidad, ArrayList metricas)
        {
            if (datosEvaluacion.EstSubcaracteristicas.SubCarusabilidad.EstComprensibilidad)
                for (int i = 0; i < usabilidad.Comprensibilidad.Length; i++)
                    metricas.Add(usabilidad.Comprensibilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarusabilidad.EstAprendizaje)
                for (int i = 0; i < usabilidad.Aprendizaje.Length; i++)
                    metricas.Add(usabilidad.Aprendizaje[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarusabilidad.EstOperabilidad)
                for (int i = 0; i < usabilidad.Operabilidad.Length; i++)
                    metricas.Add(usabilidad.Operabilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarusabilidad.EstAtractividad)
                for (int i = 0; i < usabilidad.Atractividad.Length; i++)
                    metricas.Add(usabilidad.Atractividad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarusabilidad.EstCumplimientoUsabilidad)
                for (int i = 0; i < usabilidad.CumplimientoUsabilidad.Length; i++)
                    metricas.Add(usabilidad.CumplimientoUsabilidad[i]);
        }

        private void cargarListaMantenibilidad(Evaluacion datosEvaluacion, JMantenibilidad mantenibilidad, ArrayList metricas)
        {
            if (datosEvaluacion.EstSubcaracteristicas.SubCarmantenibilidad.EstAnalizabilidad)
                for (int i = 0; i < mantenibilidad.Analizabilidad.Length; i++)
                    metricas.Add(mantenibilidad.Analizabilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarmantenibilidad.EstModificabilidad)
                for (int i = 0; i < mantenibilidad.Modificabilidad.Length; i++)
                    metricas.Add(mantenibilidad.Modificabilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarmantenibilidad.EstEstabilidad)
                for (int i = 0; i < mantenibilidad.Estabilidad.Length; i++)
                    metricas.Add(mantenibilidad.Estabilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarmantenibilidad.EstTesteabilidad)
                for (int i = 0; i < mantenibilidad.Testeabilidad.Length; i++)
                    metricas.Add(mantenibilidad.Testeabilidad[i]);

            if (datosEvaluacion.EstSubcaracteristicas.SubCarmantenibilidad.EstCumplimientoMantenibilidad)
                for (int i = 0; i < mantenibilidad.CumplimientoMantenibilidad.Length; i++)
                    metricas.Add(mantenibilidad.CumplimientoMantenibilidad[i]);
        }

        // Carga el modulo completo segun los datos obtenidos desde pagina de registro

        public void cargarDatosModulo(Evaluacion evaSeleccion)
        {
            miEvaluacion = evaSeleccion;

            if (miEvaluacion.Estado)
            {
                cargarEstados(miEvaluacion);
                inicializarListas();
                cargarListasMetricas();
                cargarEtiquetasEstados();
                cargarMenuMetricas();
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe crear la evaluación para usar este modulo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Centrar columnas de las tablas

        private void centrarColumnas(DataGrid tabla)
        {
            Style estilo = new Style(typeof(DataGrid));

            estilo.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center));

            tabla.Columns[1].CellStyle = estilo;
        }

        // Cargar tablas de subcaracteristicas por caracteristicas Interna/Externa

        private void cargarTablaFuncionabilidad(JFuncionabilidad funcionalidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));                

            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[0], 0, funcionalidad.Adecuacion.Length});
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[1], 0, funcionalidad.Exactitud.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[2], 0, funcionalidad.Interoperabilidad.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[3], 0, funcionalidad.SeguridadAcceso.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[4], 0, funcionalidad.CumplimientoFuncional.Length });

            tabla.ItemsSource = dtColumnas.DefaultView;
        }

        private void cargarTablaUsabilidad(JUsabilidad usabilidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[0], 0, usabilidad.Comprensibilidad.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[1], 0, usabilidad.Aprendizaje.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[2], 0, usabilidad.Operabilidad.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[3], 0, usabilidad.Atractividad.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[4], 0, usabilidad.CumplimientoUsabilidad.Length });

            tabla.ItemsSource = dtColumnas.DefaultView;
        }

        private void cargarTablaMantenibilidad(JMantenibilidad mantenibilidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[0], 0, mantenibilidad.Analizabilidad.Length });        
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[1], 0, mantenibilidad.Modificabilidad.Length });
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[2], 0, mantenibilidad.Estabilidad.Length });
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[3], 0, mantenibilidad.Testeabilidad.Length });
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[4], 0, mantenibilidad.CumplimientoMantenibilidad.Length });

            tabla.ItemsSource = dtColumnas.DefaultView;
        }

        // Cambia las letras y los colores de las etiquetas de estado

        public void cambiarEstado(ColorEstado estado, Label etiqueta)
        {
            var bc = new BrushConverter();

            etiqueta.Background = (Brush)bc.ConvertFrom(estado.Color);
            etiqueta.Content = estado.Etiqueta;
        }

        // Cargar tablas por botones

        private void cargarTabla(RoutedEventArgs e)
        {
            Button clickedButton = (Button)e.Source;

            switch (clickedButton.Name)
            {
                case "btnEstadoFuncInterna": cargarTablaFuncionabilidad(funInt, DataGridEstadoMetricasInternas); txTablaInterna.Text = "Funcionalidad";  break;
                case "btnEstadoUsabInterna": cargarTablaUsabilidad(usaInt, DataGridEstadoMetricasInternas);      txTablaInterna.Text = "Usabilidad";     break;
                case "btnEstadoMantInterna": cargarTablaMantenibilidad(manInt, DataGridEstadoMetricasInternas);  txTablaInterna.Text = "Mantenibilidad"; break;
                case "btnEstadoFuncExterna": cargarTablaFuncionabilidad(funExt, DataGridEstadoMetricasExternas); txTablaExterna.Text = "Funcionalidad";  break;
                case "btnEstadoUsabExterna": cargarTablaUsabilidad(usaExt, DataGridEstadoMetricasExternas);      txTablaExterna.Text = "Usabilidad";     break;
                case "btnEstadoMantExterna": cargarTablaMantenibilidad(manExt, DataGridEstadoMetricasExternas);  txTablaExterna.Text = "Mantenibilidad"; break;

                default:
                    cargarTablaFuncionabilidad(funInt, DataGridEstadoMetricasInternas); txTablaInterna.Text = "Funcionalidad";
                    cargarTablaFuncionabilidad(funExt, DataGridEstadoMetricasExternas); txTablaExterna.Text = "Funcionalidad";
                break;
            }
        }

        private void controlTablas(object sender, RoutedEventArgs e)
        {
            cargarTabla(e);
        }

        // Comprimir lista seleccion de metricas a solo las activadas

        private ArrayList comprimirSeleccion(ArrayList seleccion)
        {
            MTSeleccion metricaSelec;
            ArrayList local = new ArrayList();

            for (int i = 0; i < seleccion.Count; i++)
            {
                metricaSelec = new MTSeleccion();
                metricaSelec = (MTSeleccion)seleccion[i];

                if (metricaSelec.Estado)               
                    local.Add(metricaSelec);               
            }

            return local;
        }

        // Comprimir lista de metricas a solo las seleccionadas

        private ArrayList comprimirMetricas(ArrayList metricas, ArrayList seleccion)
        {
            JMetrica metricaJson;
            MTSeleccion metricaSelec;
            ArrayList local = new ArrayList();

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaJson = new JMetrica();

                metricaJson = (JMetrica)metricas[i];
                metricaSelec = (MTSeleccion)seleccion[i];

                if (metricaSelec.Estado)
                    local.Add(metricaJson);    
            }

            return local;
        }

        // Evento Flyout

        private void btnAbrirFlyout_Click(object sender, RoutedEventArgs e)
        {
            if (miEvaluacion.Estado)

                if(isFunIntAct || isFunExtAct || isUsaIntAct || isUsaExtAct || isManIntAct || isManExtAct)
                    menuMetricas.IsOpen = true;        
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar alguna caracteristica desde la sección Selección e Importancia", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            else           
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe crear la evaluación para usar este modulo", "Información", MessageBoxButton.OK, MessageBoxImage.Information);           
        }

        // Eventos botones menu flotante (flyout)

        private void btnMenuClick(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult respuesta;
            Button clickedButton = (Button) e.Source;

            menuMetricas.IsOpen = false;

            switch (clickedButton.Name)
            {
                case "btnFuncInterna":

                    if (miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna, lblEstadoMetricasFuncInterna, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSfuncionalidadInterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna, lblEstadoMetricasFuncInterna, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSfuncionalidadInterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }

                break;
                
                case "btnUsabInterna":

                    if (miEvaluacion.EtiquetasSeleccion.UsabilidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.UsabilidadInterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.UsabilidadInterna, lblEstadoMetricasUsabInterna, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSusabilidadInterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.UsabilidadInterna, lblEstadoMetricasUsabInterna, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSusabilidadInterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }
                            
                break;

                case "btnMantInterna":

                    if (miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna, lblEstadoMetricasMantInterna, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSmantenibilidadInterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.MantenibilidadInterna, lblEstadoMetricasMantInterna, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSmantenibilidadInterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }
                            
                break;

                case "btnFuncExterna":

                    if (miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna, lblEstadoMetricasFuncExterna, "Funcionalidad", "Externa", funcionalidadExterna, MTSfuncionalidadExterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSfuncionalidadExterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.FuncionalidadExterna, lblEstadoMetricasFuncExterna, "Funcionalidad", "Externa", funcionalidadExterna, MTSfuncionalidadExterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSfuncionalidadExterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }

                break;

                case "btnUsabExterna":

                    if (miEvaluacion.EtiquetasSeleccion.UsabilidadExterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.UsabilidadExterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.UsabilidadExterna, lblEstadoMetricasUsabExterna, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSusabilidadExterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.UsabilidadExterna, lblEstadoMetricasUsabExterna, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSusabilidadExterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }
                            
                break;

                case "btnMantExterna":

                    if (miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna, lblEstadoMetricasMantExterna, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSmantenibilidadExterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.MantenibilidadExterna, lblEstadoMetricasMantExterna, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSmantenibilidadExterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }
                            
                break;

                default:

                    if (miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna.Etiqueta.Equals("REALIZAR") || miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna.Etiqueta.Equals("COMPLETAR"))
                    {
                        paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna, lblEstadoMetricasFuncInterna, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna);
                        this.NavigationService.Navigate(paginaSeleccion);
                        MTSfuncionalidadInterna = paginaSeleccion.seleccionarMetrica();
                    }
                    else
                    {
                        respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Selección finalizada, al continuar se perderan las respuestas ingresadas en el formulario de evaluacón, ¿desea continuar? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (respuesta == MessageBoxResult.Yes)
                        {
                            paginaSeleccion.cargarSeleccionMetricas(this, miEvaluacion.EtiquetasSeleccion.FuncionalidadInterna, lblEstadoMetricasFuncInterna, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna);
                            this.NavigationService.Navigate(paginaSeleccion);
                            MTSfuncionalidadInterna = paginaSeleccion.seleccionarMetrica();
                        }
                    }

                break;
            }
        } 
    }
}
