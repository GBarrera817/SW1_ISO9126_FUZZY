using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private Seleccion metricas;
        private EstadoModulo selecMetricas;
        private Evaluacion miEvaluacion;


        public VistaPreviaSeleccionMetricaPage(Evaluacion nueva)
		{
			InitializeComponent();

            this.paginaSeleccion = new SeleccionMetricasPage();
            this.metricas = new Seleccion();
            this.selecMetricas = new EstadoModulo();
            this.miEvaluacion = nueva;

            inicializarEstadoCaracteristica();
            inicializarListas();
            inicializarSeleccion();
            cargarJsonMetricas();

            // Tablas iniciales
            cargarTablaFuncionabilidad(funInt, DataGridEstadoMetricasInternas);
            cargarTablaFuncionabilidad(funExt, DataGridEstadoMetricasExternas);
        }

        private void inicializarEstadoCaracteristica()
        {
            this.isFunIntAct = true;
            this.isFunExtAct = true;
            this.isUsaIntAct = true;
            this.isUsaExtAct = true;
            this.isManIntAct = true;
            this.isManExtAct = true;
        }

        private void inicializarListas()
        {
            this.funcionalidadInterna = new ArrayList();
            this.funcionalidadExterna = new ArrayList();
            this.usabilidadInterna = new ArrayList();
            this.usabilidadExterna = new ArrayList();
            this.mantenibilidadInterna = new ArrayList();
            this.mantenibilidadExterna = new ArrayList();
        }

        private void inicializarSeleccion()
        {
            this.MTSfuncionalidadInterna = new ArrayList();
            this.MTSfuncionalidadExterna = new ArrayList();
            this.MTSusabilidadInterna = new ArrayList();
            this.MTSusabilidadExterna = new ArrayList();
            this.MTSmantenibilidadInterna = new ArrayList();
            this.MTSmantenibilidadExterna = new ArrayList();
        }

        private void cargarJsonMetricas()
        {
            if (isFunIntAct)
                funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));

            if (isFunExtAct)
                funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));

            if (isUsaIntAct)
                usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));

            if (isUsaExtAct)
                usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));

            if (isManIntAct)
                manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));

            if (isManExtAct)
                manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));
        }

        private void cargarTablaFuncionabilidad(JFuncionabilidad funcionalidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            tabla.ItemsSource = dtColumnas.DefaultView;

            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[0], 0, funcionalidad.Adecuacion.Length});
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[1], 0, funcionalidad.Exactitud.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[2], 0, funcionalidad.Interoperabilidad.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[3], 0, funcionalidad.SeguridadAcceso.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[4], 0, funcionalidad.CumplimientoFuncional.Length });
        }


        private void cargarTablaUsabilidad(JUsabilidad usabilidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            tabla.ItemsSource = dtColumnas.DefaultView;

            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[0], 0, usabilidad.Comprensibilidad.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[1], 0, usabilidad.Aprendizaje.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[2], 0, usabilidad.Operabilidad.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[3], 0, usabilidad.Atractividad.Length });
            dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[4], 0, usabilidad.CumplimientoUsabilidad.Length });
        }


        private void cargarTablaMantenibilidad(JMantenibilidad mantenibilidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            tabla.ItemsSource = dtColumnas.DefaultView;

            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[0], 0, mantenibilidad.Analizabilidad.Length });        
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[1], 0, mantenibilidad.Modificabilidad.Length });
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[2], 0, mantenibilidad.Estabilidad.Length });
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[3], 0, mantenibilidad.Testeabilidad.Length });
            dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[4], 0, mantenibilidad.CumplimientoMantenibilidad.Length });    
        }

        private void cambiarEstado(int estado, Label etiqueta)
        {
            var bc = new BrushConverter();
            string[] estados = new string[] { "INACTIVA", "REALIZAR", "COMPLETAR", "FINALIZADO" };
            string[] colores = new string[] { "#FF000033", "#FFCC0000", "#FFE6E600", "#FF00802B" };

            etiqueta.Background = (Brush)bc.ConvertFrom(colores[estado]);
            etiqueta.Content = estados[estado];
        }

        // Evento Flyout

        private void btnAbrirFlyout_Click(object sender, RoutedEventArgs e)
		{
            menuMetricas.IsOpen = true;
            cambiarEstado(1, lblEstadoMetricasFuncInterna);
            cambiarEstado(2, lblEstadoMetricasUsabInterna);
            cambiarEstado(3, lblEstadoMetricasMantInterna);
        }

        // Cargar tablas

        private void cargarTabla(RoutedEventArgs e)
        {
            Button clickedButton = (Button)e.Source;

            switch (clickedButton.Name)
            {
                case "btnEstadoFuncInterna": cargarTablaFuncionabilidad(funInt, DataGridEstadoMetricasInternas); break;
                case "btnEstadoUsabInterna": cargarTablaUsabilidad(usaInt, DataGridEstadoMetricasInternas); break;
                case "btnEstadoMantInterna": cargarTablaMantenibilidad(manInt, DataGridEstadoMetricasInternas); break;
                case "btnEstadoFuncExterna": cargarTablaFuncionabilidad(funExt, DataGridEstadoMetricasExternas); break;
                case "btnEstadoUsabExterna": cargarTablaUsabilidad(usaExt, DataGridEstadoMetricasExternas); break;
                case "btnEstadoMantExterna": cargarTablaMantenibilidad(manExt, DataGridEstadoMetricasExternas); break;

                default:
                    cargarTablaFuncionabilidad(funInt, DataGridEstadoMetricasInternas);
                    cargarTablaFuncionabilidad(funExt, DataGridEstadoMetricasExternas);
                break;
            }
        }

        private void controlTablas(object sender, RoutedEventArgs e)
        {
            cargarTabla(e);
        }

        // Eventos botones menu flotante (flyout)

        private void btnMenuClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Button clickedButton = (Button) e.Source;

            menuMetricas.IsOpen = false;

            switch (clickedButton.Name)
            {
                case "btnFuncInterna":
                            paginaSeleccion.cargarSeleccionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna);
                            MTSfuncionalidadInterna = paginaSeleccion.seleccionarMetrica();
                break;

                case "btnUsabInterna":
                            paginaSeleccion.cargarSeleccionMetricas(this, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna);
                            MTSusabilidadInterna = paginaSeleccion.seleccionarMetrica();
                break;

                case "btnMantInterna":
                            paginaSeleccion.cargarSeleccionMetricas(this, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna);
                            MTSmantenibilidadInterna = paginaSeleccion.seleccionarMetrica();
                break;

                case "btnFuncExterna":
                            paginaSeleccion.cargarSeleccionMetricas(this, "Funcionalidad", "Interna", funcionalidadExterna, MTSfuncionalidadExterna);
                            MTSfuncionalidadExterna = paginaSeleccion.seleccionarMetrica();
                break;

                case "btnUsabExterna":
                            paginaSeleccion.cargarSeleccionMetricas(this, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna);
                            MTSusabilidadExterna = paginaSeleccion.seleccionarMetrica();
                break;

                case "btnMantExterna":
                            paginaSeleccion.cargarSeleccionMetricas(this, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna);
                            MTSmantenibilidadExterna = paginaSeleccion.seleccionarMetrica();
                break;

                default:
                            paginaSeleccion.cargarSeleccionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna);
                            MTSfuncionalidadInterna = paginaSeleccion.seleccionarMetrica();
                break;
            }

            this.NavigationService.Navigate(paginaSeleccion);
        }
    }
}
