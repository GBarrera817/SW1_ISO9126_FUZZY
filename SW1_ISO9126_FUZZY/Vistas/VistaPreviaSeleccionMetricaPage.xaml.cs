using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
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

        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;

        private ArrayList funcionalidadInterna;
        private ArrayList funcionalidadExterna;
        private ArrayList usabilidadInterna;
        private ArrayList usabilidadExterna;
        private ArrayList mantenibilidadInterna;
        private ArrayList mantenibilidadExterna;

        SeleccionMetricasPage paginaSeleccion;

        public VistaPreviaSeleccionMetricaPage(SeleccionMetricasPage pagina)
		{
            
			InitializeComponent();

            this.paginaSeleccion = pagina;
            inicializarListas();
            cargarJsonMetricas();
            cargarFuncionabilidad(funInt, DataGridEstadoMetricasInternas);
            cargarFuncionabilidad(funExt, DataGridEstadoMetricasExternas);
        }


        private void cargarJsonMetricas()
        {
            funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
            funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
            usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
            usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
            manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
            manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));

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


        private void cargarFuncionabilidad(JFuncionabilidad funcionalidad, DataGrid tabla)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            //DataGrid tabla = new DataGrid();

            tabla.ItemsSource = dtColumnas.DefaultView;
            /*DataGridEstadoMetricasInternas.Columns[0].Header = "Subcaracterística";
            DataGridEstadoMetricasInternas.Columns[1].Header = "Seleccionadas";
            DataGridEstadoMetricasInternas.Columns[2].Header = "Total";*/

            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[0], 0, funcionalidad.Adecuacion.Length});
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[1], 0, funcionalidad.Exactitud.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[2], 0, funcionalidad.Interoperabilidad.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[3], 0, funcionalidad.SeguridadAcceso.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[4], 0, funcionalidad.CumplimientoFuncional.Length });
            
        }


        private void cargarUsabilidad(JUsabilidad usabilidad, DataGrid tabla)
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


        private void cargarMantenibilidad(JMantenibilidad mantenibilidad, DataGrid tabla)
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
        }

        // Eventos botones tabla y label estado

		private void btnEstadoFuncInterna_Click(object sender, RoutedEventArgs e)
		{ 
            cargarFuncionabilidad(funInt, DataGridEstadoMetricasInternas);
            cambiarEstado(1, lblEstadoMetricasFuncInterna);
        }

		private void btnEstadoUsabInterna_Click(object sender, RoutedEventArgs e)
		{  
            cargarUsabilidad(usaInt, DataGridEstadoMetricasInternas);
            cambiarEstado(2,lblEstadoMetricasUsabInterna);
        }

		private void btnEstadoMantInterna_Click(object sender, RoutedEventArgs e)
		{ 
            cargarMantenibilidad(manInt, DataGridEstadoMetricasInternas);
            cambiarEstado(3,lblEstadoMetricasMantInterna);
        }

		private void btnEstadoFuncExterna_Click(object sender, RoutedEventArgs e)
		{
            cargarFuncionabilidad(funExt, DataGridEstadoMetricasExternas);
        }

		private void btnEstadoUsabExterna_Click(object sender, RoutedEventArgs e)
		{
            cargarUsabilidad(usaExt, DataGridEstadoMetricasExternas);
        }

		private void btnEstadoMantExterna_Click(object sender, RoutedEventArgs e)
		{
            cargarMantenibilidad(manExt, DataGridEstadoMetricasExternas);
        }

        // Eventos botones menu flotante (flyout)

        private void btnFuncInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = false;
            paginaSeleccion.FuncInterna_Activar(this);
            this.NavigationService.Navigate(paginaSeleccion);
        }

        private void btnUsabInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = false;
            paginaSeleccion.UsabInterna_Activar(this);
            this.NavigationService.Navigate(paginaSeleccion);
        }

        private void btnMantInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = false;
            paginaSeleccion.MantInterna_Activar(this);
            this.NavigationService.Navigate(paginaSeleccion);
        }

        private void btnFuncExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = false;
            paginaSeleccion.FuncExterna_Activar(this);
            this.NavigationService.Navigate(paginaSeleccion);
        }

        private void btnUsabExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = false;
            paginaSeleccion.UsabExterna_Activar(this);
            this.NavigationService.Navigate(paginaSeleccion);
        }

        private void btnMantExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = false;
            paginaSeleccion.MantExterna_Activar(this);
            this.NavigationService.Navigate(paginaSeleccion);
        }
    }
}
