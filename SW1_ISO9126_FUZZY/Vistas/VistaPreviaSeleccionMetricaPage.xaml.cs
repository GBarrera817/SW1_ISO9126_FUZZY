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


        public VistaPreviaSeleccionMetricaPage()
		{
			InitializeComponent();
            inicializarListas();
            cargarJsonMetricas();
            cargarFuncionabilidad(funInt);
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


        private void cargarFuncionabilidad(JFuncionabilidad funcionalidad)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));

            //DataGrid tabla = new DataGrid();

            DataGridEstadoMetricasInternas.ItemsSource = dtColumnas.DefaultView;
            /*DataGridEstadoMetricasInternas.Columns[0].Header = "Subcaracterística";
            DataGridEstadoMetricasInternas.Columns[1].Header = "Seleccionadas";
            DataGridEstadoMetricasInternas.Columns[2].Header = "Total";*/

            dtColumnas.Rows.Add(new object[] {funcionalidad.Subcaracteristicas[0], 0 , funcionalidad.Adecuacion.Length});
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[1], 0, funcionalidad.Exactitud.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[2], 0, funcionalidad.Interoperabilidad.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[3], 0, funcionalidad.SeguridadAcceso.Length });
            dtColumnas.Rows.Add(new object[] { funcionalidad.Subcaracteristicas[4], 0, funcionalidad.CumplimientoFuncional.Length });
            
        }


        private void cargarUsabilidad(JUsabilidad usabilidad)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));


            for (int i = 0; i < usabilidad.Comprensibilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[0], 0, usabilidad.Comprensibilidad.Length });
            }

            for (int i = 0; i < usabilidad.Aprendizaje.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[1], 0, usabilidad.Aprendizaje.Length });
            }

            for (int i = 0; i < usabilidad.Operabilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[2], 0, usabilidad.Operabilidad.Length });
            }

            for (int i = 0; i < usabilidad.Atractividad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[3], 0, usabilidad.Atractividad.Length });
            }

            for (int i = 0; i < usabilidad.CumplimientoUsabilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { usabilidad.Subcaracteristicas[4], 0, usabilidad.CumplimientoUsabilidad.Length });
            }
        }


        private void cargarMantenibilidad(JMantenibilidad mantenibilidad)
        {
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
            dtColumnas.Columns.Add("seleccionadas", typeof(string));
            dtColumnas.Columns.Add("total", typeof(string));


            for (int i = 0; i < mantenibilidad.Analizabilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[0], 0, mantenibilidad.Analizabilidad.Length });
            }

            for (int i = 0; i < mantenibilidad.Modificabilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[1], 0, mantenibilidad.Modificabilidad.Length });
            }

            for (int i = 0; i < mantenibilidad.Estabilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[2], 0, mantenibilidad.Estabilidad.Length });
            }

            for (int i = 0; i < mantenibilidad.Testeabilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[3], 0, mantenibilidad.Testeabilidad.Length });
            }

            for (int i = 0; i < mantenibilidad.CumplimientoMantenibilidad.Length; i++)
            {
                dtColumnas.Rows.Add(new object[] { mantenibilidad.Subcaracteristicas[4], 0, mantenibilidad.CumplimientoMantenibilidad.Length });
            }
        }



        private void btnAbrirFlyout_Click(object sender, RoutedEventArgs e)
		{
			//flyoutSeleccionMetricas.IsOpen = true;
			this.NavigationService.Navigate(new Uri("Vistas/SeleccionMetricasPage.xaml", UriKind.Relative));
		}

		private void btnEstadoFuncInterna_Click(object sender, RoutedEventArgs e)
		{
            cargarFuncionabilidad(funInt);
        }

		private void btnEstadoUsabInterna_Click(object sender, RoutedEventArgs e)
		{
            cargarUsabilidad(usaInt);
        }

		private void btnEstadoMantInterna_Click(object sender, RoutedEventArgs e)
		{
            cargarMantenibilidad(manInt);
        }

		private void btnEstadoFuncExterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoUsabExterna_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnEstadoMantExterna_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
