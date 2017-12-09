using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Estados;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using SW1_ISO9126_FUZZY.Modelo_Datos.Resultados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para EvaluacionCalidadPage.xaml
	/// </summary>
    
	public partial class EvaluacionCalidadPage : Page
	{
        // Listas resultados caracteristicas
        private List<MTCalculo> MTCfuncionalidadInterna;
        private List<MTCalculo> MTCusabilidadInterna;
        private List<MTCalculo> MTCmantenibilidadInterna;
        private List<MTCalculo> MTCfuncionalidadExterna;
        private List<MTCalculo> MTCusabilidadExterna;
        private List<MTCalculo> MTCmantenibilidadExterna;

        private EstadoModulo calidadMetricas;
        private EstadoFinal estadoFinalEvaluacion;
        private Resultado resultadoFinalEvaluacion;
        private Evaluacion miEvaluacion;

        public EvaluacionCalidadPage(Evaluacion nueva)
		{
			InitializeComponent();

            this.miEvaluacion = nueva;
            this.calidadMetricas = new EstadoModulo();
            this.estadoFinalEvaluacion = new EstadoFinal();
            this.resultadoFinalEvaluacion = new Resultado();
        }

        // Crear listas calculos metricas 

        private void inicializarListasCalculos(Evaluacion datos)
        {
            if (datos.DatosMetricas.FuncionalidadInterna)
                MTCfuncionalidadInterna = new List<MTCalculo>();

            if (datos.DatosMetricas.UsabilidadInterna)
                MTCusabilidadInterna = new List<MTCalculo>();

            if (datos.DatosMetricas.MantenibilidadInterna)          
                MTCmantenibilidadInterna = new List<MTCalculo>();        

            if (datos.DatosMetricas.FuncionalidadExterna)
                MTCfuncionalidadExterna = new List<MTCalculo>();

            if (datos.DatosMetricas.UsabilidadExterna)
                MTCusabilidadExterna = new List<MTCalculo>();

            if (datos.DatosMetricas.MantenibilidadExterna)
                MTCmantenibilidadExterna = new List<MTCalculo>();
        }

        // Limpia las columnas de la tabla

        private void limpiarColumnasTabla(DataGrid visual)
        {
            int elementos = visual.Columns.Count;

            for (int i = 0; i < elementos; i++)
                visual.Columns.RemoveAt(0);
        }

        // Carga el modulo completo segun los datos obtenidos desde pagina de registro

        public void cargarDatosModulo(Evaluacion datos)
        {
            ArrayList temporal = new ArrayList();

            inicializarListasCalculos(datos);
            //cargarDatosSubcaracteristicas(datos);

            temporal.Clear();

            limpiarColumnasTabla(tbcarInterna);
            limpiarColumnasTabla(tbcarExterna);
            temporal = cargarDatosCaracteristicas(datos);
            cargarTablaCaracteristicas(tbcarInterna, (string[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);
            cargarTablaCaracteristicas(tbcarExterna, (string[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);

            temporal.Clear();

            limpiarColumnasTabla(tbCalidadFinal);
            temporal = cargarDatosCalidad();
            cargarTablaCalidad(tbCalidadFinal, (string[])temporal[0], (double[])temporal[1], (string[])temporal[2]);
        }
        
        // Eventos de movimiento

		private void retrocederTabControl(object sender, RoutedEventArgs e)
		{
			tabControlEvaluacionCalidad.SelectedIndex = tabControlEvaluacionCalidad.SelectedIndex - 1;
		}

        private void avanzarTabControl(object sender, RoutedEventArgs e)
        {
            tabControlEvaluacionCalidad.SelectedIndex = tabControlEvaluacionCalidad.SelectedIndex + 1;
        }

        // ----------------------------- PAGINA CALIDAD SUBCARACTERISTICAS ---------------------------------------

        // Carga de prueba para subcaracteristicas

        private ArrayList llenarTablaSC(int tamano)
        {
            ArrayList chuna = new ArrayList();

            Tuple<string, string>[] subcaracteristicas = new Tuple<string, string>[tamano];
            double[] importancia = new double[tamano];
            double[] numResultados = new double[tamano];
            string[] lingResultados = new string[tamano];

            for (int i = 0; i < tamano; i++)
            {
                subcaracteristicas[i] = new Tuple<string, string>("FUNCIONALIDAD", "EXACTITUD");
                importancia[i] = 0.5;
                numResultados[i] = 2.5;
                lingResultados[i] = "NINGUNA";
            }

            chuna.Add(subcaracteristicas);
            chuna.Add(importancia);
            chuna.Add(numResultados);
            chuna.Add(lingResultados);

            return chuna;
        }

        // Cargar tablas subcaracteristicas 

        private void cargarTablaSubcaracteristicas(DataGrid visual, Tuple<string, string>[] subcaracteristicas, double[] importancia, double[] numResultados, string[] lingResultados)
        {
            DataTable dtColumnas = new DataTable();

            dtColumnas.Columns.Add("subcaracterística", typeof(string));
            dtColumnas.Columns.Add("característica", typeof(string));
            dtColumnas.Columns.Add("grado importancia", typeof(string));
            dtColumnas.Columns.Add("valor", typeof(string));
            dtColumnas.Columns.Add("etiqueta", typeof(string));

            for (int i = 0; i < subcaracteristicas.Length; i++)
                dtColumnas.Rows.Add(new object[] { subcaracteristicas[i].Item1, subcaracteristicas[i].Item2, importancia[i], numResultados[i], lingResultados[i] });

            visual.ItemsSource = dtColumnas.DefaultView;
        }

        // Eventos botones

        private void btnCalcSubInterna_Click(object sender, RoutedEventArgs e)
        {
            limpiarColumnasTabla(tbSubCarInterna);
            ArrayList entrada = llenarTablaSC(10);
            cargarTablaSubcaracteristicas(tbSubCarInterna, (Tuple<string, string>[]) entrada[0], (double[]) entrada[1], (double[]) entrada[2], (string[]) entrada[3]);
        }

        private void btnCalcSubExterna_Click(object sender, RoutedEventArgs e)
        {

        }

        // ------------------------------- PAGINA CALIDAD CARACTERISTICAS ----------------------------------------

        private ArrayList cargarDatosCaracteristicas(Evaluacion datos)
        {
            ArrayList lista = new ArrayList();
            ArrayList info = new ArrayList();
            ArrayList grados = new ArrayList();
            int activadas = 0;

            if(datos.DatosMetricas.FuncionalidadInterna || datos.DatosMetricas.FuncionalidadExterna)
            {
                info.Add("Funcionalidad");
                grados.Add(datos.Grados.Funcionalidad);
                activadas++;
            }

            if (datos.DatosMetricas.UsabilidadInterna || datos.DatosMetricas.UsabilidadExterna)
            {
                info.Add("Usabilidad");
                grados.Add(datos.Grados.Usabilidad);
                activadas++;
            }

            if (datos.DatosMetricas.MantenibilidadInterna || datos.DatosMetricas.MantenibilidadExterna)
            {
                info.Add("Mantenibilidad");
                grados.Add(datos.Grados.Mantenibilidad);
                activadas++;
            }

            string[] caracteristicas = (string[]) info.ToArray(typeof(string));
            double[] importancia = (double[]) grados.ToArray(typeof(double));
            double[] numResultados = new double[activadas];
            string[] lingResultados = new string[activadas];

            for (int i = 0; i < activadas; i++)
            {
                numResultados[i] = 0;
                lingResultados[i] = "NINGUNA";
            }

            lista.Add(caracteristicas);
            lista.Add(importancia);
            lista.Add(numResultados);
            lista.Add(lingResultados);

            return lista;
        }

        // Cargar tablas subcaracteristicas 

        private void cargarTablaCaracteristicas(DataGrid visual, string[] caracteristicas, double[] importancia, double[] numResultados, string[] lingResultados)
        {
            DataTable dtColumnas = new DataTable();

            dtColumnas.Columns.Add("característica", typeof(string));
            dtColumnas.Columns.Add("grado importancia", typeof(string));
            dtColumnas.Columns.Add("valor", typeof(string));
            dtColumnas.Columns.Add("etiqueta", typeof(string));

            for (int i = 0; i < caracteristicas.Length; i++)
                dtColumnas.Rows.Add(new object[] { caracteristicas[i], importancia[i], numResultados[i], lingResultados[i] });

            visual.ItemsSource = dtColumnas.DefaultView;
        }

        // Eventos botones

        private void btnCalcCaractInterna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalcCaractExterna_Click(object sender, RoutedEventArgs e)
        {

        }

        // ----------------------------------- PAGINA CALIDAD FINAL ----------------------------------------------

        private ArrayList cargarDatosCalidad()
        {
            int contenido = 3;
            ArrayList lista = new ArrayList();

            string[] atributos = new string[contenido];
            double[] numResultados = new double[contenido];
            string[] lingResultados = new string[contenido];

            atributos[0] = "Calidad Interna";
            atributos[1] = "Calidad Externa";
            atributos[2] = "Calidad Final";

            for (int i = 0; i < contenido; i++)
            {
                numResultados[i] = 0;
                lingResultados[i] = "NINGUNA";
            }

            lista.Add(atributos);
            lista.Add(numResultados);
            lista.Add(lingResultados);

            return lista;
        }

        // Cargar tablas subcaracteristicas 

        private void cargarTablaCalidad(DataGrid visual, string[] atributos, double[] numResultados, string[] lingResultados)
        {
            DataTable dtColumnas = new DataTable();

            dtColumnas.Columns.Add("atributo", typeof(string));
            dtColumnas.Columns.Add("valor", typeof(string));
            dtColumnas.Columns.Add("etiqueta", typeof(string));

            for (int i = 0; i < atributos.Length; i++)
                dtColumnas.Rows.Add(new object[] { atributos[i], numResultados[i], lingResultados[i] });

            visual.ItemsSource = dtColumnas.DefaultView;
        }

        // Validar datos para configurar PDF

        private bool validarConfigPDF()
        {
            if (txtNombreArchivor.Text == string.Empty)
                return false;
            return true;
        }

        // Vakudar datos del reporte

        private bool validarDatosReporte()
        {
            if (txtObjetivos.Text == string.Empty)
                return false;
            return true;
        }

        // Eventos botones

        private void btnCalcCalidadFinal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            if (validarDatosReporte())
            {
                if (validarConfigPDF())
                {
                    /*if (validarEvaluacion())
                    {
                        btnGenerarPDF();
                    }
                    */
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el nombre del archivo para generar el reporte", "Configuración reporte calidad", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el objetivo de la evaluación para generar el reporte", "Reporte calidad final software", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
