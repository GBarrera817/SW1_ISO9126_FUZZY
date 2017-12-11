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
using SW1_ISO9126_FUZZY.Archivos;
using System.IO;
using SW1_ISO9126_FUZZY.Evaluacion_Calidad.Calculos;
using SW1_ISO9126_FUZZY.JSON;

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

        // Lista de resultados con agrupamiento por subcaracteristicas
        private List<List<MTCalculo>> MTCAGfuncionalidadInterna;
        private List<List<MTCalculo>> MTCAGusabilidadInterna;
        private List<List<MTCalculo>> MTCAGmantenibilidadInterna;
        private List<List<MTCalculo>> MTCAGfuncionalidadExterna;
        private List<List<MTCalculo>> MTCAGusabilidadExterna;
        private List<List<MTCalculo>> MTCAGmantenibilidadExterna;

        // Lista final de suncaracteristicas

        //private List<List<double>> 

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
            {
                MTCfuncionalidadInterna = new List<MTCalculo>();
                MTCAGfuncionalidadInterna = new List<List<MTCalculo>>();
            }
              
            if (datos.DatosMetricas.UsabilidadInterna)
            {
                MTCusabilidadInterna = new List<MTCalculo>();
                MTCAGusabilidadInterna = new List<List<MTCalculo>>();
            }               

            if (datos.DatosMetricas.MantenibilidadInterna)
            {
                MTCmantenibilidadInterna = new List<MTCalculo>();
                MTCAGmantenibilidadInterna = new List<List<MTCalculo>>();
            }          
                
            if (datos.DatosMetricas.FuncionalidadExterna)
            {
                MTCfuncionalidadExterna = new List<MTCalculo>();
                MTCAGfuncionalidadExterna = new List<List<MTCalculo>>();
            }
                
            if (datos.DatosMetricas.UsabilidadExterna)
            {
                MTCusabilidadExterna = new List<MTCalculo>();
                MTCAGusabilidadExterna = new List<List<MTCalculo>>();
            }
                
            if (datos.DatosMetricas.MantenibilidadExterna)
            {
                MTCmantenibilidadExterna = new List<MTCalculo>();
                MTCAGmantenibilidadExterna = new List<List<MTCalculo>>();
            }            
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

            limpiarColumnasTabla(tbSubCarInterna);
            limpiarColumnasTabla(tbSubCarExterna);
            temporal = cargarDatosSubcaracteristicas(datos);
            cargarTablaSubcaracteristicas(tbSubCarInterna, (Tuple<string, string>[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);
            cargarTablaSubcaracteristicas(tbSubCarExterna, (Tuple<string, string>[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);

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

        // Calcula las formulas de las metricas

        private List<MTCalculo> calcularResultadoFormulas(List<MTEvaluacion> listaEvaluacion)
        {
            List<MTCalculo> listaCalculo = new List<MTCalculo>();
            MTEvaluacion datos;
            MTCalculo valor;

            for (int i = 0; i < listaEvaluacion.Count; i++)
            {
                datos = listaEvaluacion[i];
                valor = new MTCalculo();

                valor.Id = datos.Id;

                if (datos.Parametros.Length == 2)
                    valor.Resultado = Formula.GetResultadoFormula(datos.Formula, datos.Valores[0], datos.Valores[1]);
                else
                    valor.Resultado = Formula.GetResultadoFormula(datos.Formula, datos.Valores[0], datos.Valores[1], datos.Valores[2]);

                listaCalculo.Add(valor);

                Console.WriteLine(datos.ToString());
                Console.WriteLine(valor.ToString());
            }

            return listaCalculo;
        }

        // Agrupa la lista de metricas por subcaracteristicas

        private List<List<MTCalculo>> agruparSubcaracteristicas(List<MTCalculo> original, List<JMetrica> metricas)
        {
            List<List<MTCalculo>> lista = new List<List<MTCalculo>>();
            List<MTCalculo> sublista = new List<MTCalculo>();
            List<JMetrica> local = new List<JMetrica>(obtenerListaReal(original, metricas));
            string subcarateristica = local[0].Subcaracteristica;

            for (int i = 0; i < original.Count; i++)
            {
                if (string.Equals(subcarateristica, local[i].Subcaracteristica))
                {
                    sublista.Add(original[i]);
                }
                else
                {
                    lista.Add(sublista);

                    if (sublista.Count != 0)
                        sublista.Clear();
                }
            }

            return lista;
        }

        // Obtener metricas activadas del total de metricas

        private List<JMetrica> obtenerListaReal(List<MTCalculo> original, List<JMetrica> metricas)
        {
            List<JMetrica> local = new List<JMetrica>();
            int j = 0;

            for (int i = 0; i < original.Count; i++)
            {
                while (original[i].Id != metricas[j].Id)
                    j++;

                local.Add(metricas[j]);
                j++;
            }

            return local;
        }

        // ¿como guardar subcaracteristicas?
        // calcular double promedio
        // normalizar
        // aplicar importancia

        /*private double finalizarSubcaracteristicas(List<ListCalculo> subcaracteristica, double importancia)
        {

        }*/

        // Prepara la lista de calculos para realizar la evaluacion difusa

        private void prepararEvaluacionFuzzy(Evaluacion datos, string perspectiva)
        {
            if (perspectiva.Equals("Interna"))
            {
                if (datos.DatosMetricas.FuncionalidadInterna)
                {
                    MTCfuncionalidadInterna =  new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.FuncionalidadInterna));
                    MTCAGfuncionalidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCfuncionalidadInterna, datos.CargaMetricas.FuncionalidadInterna));
                }

                if (datos.DatosMetricas.UsabilidadInterna)
                {
                    MTCusabilidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.UsabilidadInterna));
                    MTCAGusabilidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCusabilidadInterna, datos.CargaMetricas.UsabilidadInterna));
                }

                if (datos.DatosMetricas.MantenibilidadInterna)
                {
                    MTCmantenibilidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.MantenibilidadInterna));
                    MTCAGmantenibilidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCmantenibilidadInterna, datos.CargaMetricas.MantenibilidadInterna));
                }
            }
            else
            {
                if (datos.DatosMetricas.FuncionalidadExterna)
                {
                    MTCfuncionalidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.FuncionalidadExterna));
                    MTCAGfuncionalidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCfuncionalidadExterna, datos.CargaMetricas.FuncionalidadExterna));
                }

                if (datos.DatosMetricas.UsabilidadExterna)
                {
                    MTCusabilidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.UsabilidadExterna));
                    MTCAGusabilidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCusabilidadExterna, datos.CargaMetricas.UsabilidadExterna));
                }

                if (datos.DatosMetricas.MantenibilidadExterna)
                {
                    MTCmantenibilidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.MantenibilidadExterna));
                    MTCAGmantenibilidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCmantenibilidadExterna, datos.CargaMetricas.MantenibilidadExterna));
                }
            }
        }

        // Cargas datos desde modulo evaluacion

        public void cargarModuloEvaluacion(Evaluacion datos, string perspectiva)
        {
            Console.WriteLine("Pagina calidad cargarModuloEvaluacion");

            if (perspectiva.Equals("Interna"))
            {
                prepararEvaluacionFuzzy(datos, perspectiva);
                // promediar y aplicar importancia
                // mandar a controlador 
                btnCalcSubInterna.IsEnabled = true;
            }
            else
            {
                // calcular formulas
                // agrupar por subcaracteristicas
                // promediar y aplicar importancia
                // mandar a controlador 
                btnCalcSubExterna.IsEnabled = true;
            }
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

        // Carga datos inicial para subcaracteristicas

        private ArrayList cargarDatosSubcaracteristicas(Evaluacion datos)
        {
            ArrayList lista = new ArrayList();
            ArrayList info = new ArrayList();
            ArrayList grados = new ArrayList();
            int activadas = 0;

            if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstAdecuacion)
            {
                info.Add(new Tuple<string, string>("Funcionalidad", "Adecuación"));
                grados.Add(datos.Grados.SbcFuncionalidad.Adecuacion);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstExactitud)
            {
                info.Add(new Tuple<string, string>("Funcionalidad", "Exactitud"));
                grados.Add(datos.Grados.SbcFuncionalidad.Exactitud);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstInteroperabilidad)
            {
                info.Add(new Tuple<string, string>("Funcionalidad", "Interoperabilidad"));
                grados.Add(datos.Grados.SbcFuncionalidad.Interoperabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstSeguridadAcceso)
            {
                info.Add(new Tuple<string, string>("Funcionalidad", "Seguridad Acceso"));
                grados.Add(datos.Grados.SbcFuncionalidad.SeguridadAcceso);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstCumplimientoFuncional)
            {
                info.Add(new Tuple<string, string>("Funcionalidad", "Cumplimiento Funcional"));
                grados.Add(datos.Grados.SbcFuncionalidad.CumplimientoFuncional);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarusabilidad.EstComprensibilidad)
            {
                info.Add(new Tuple<string, string>("Usabilidad", "Comprensibilidad"));
                grados.Add(datos.Grados.SbcUsabilidad.Comprensibilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarusabilidad.EstAprendizaje)
            {
                info.Add(new Tuple<string, string>("Usabilidad", "Aprendizaje"));
                grados.Add(datos.Grados.SbcUsabilidad.Aprendizaje);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarusabilidad.EstOperabilidad)
            {
                info.Add(new Tuple<string, string>("Usabilidad", "Operabilidad"));
                grados.Add(datos.Grados.SbcUsabilidad.Operabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarusabilidad.EstAtractividad)
            {
                info.Add(new Tuple<string, string>("Usabilidad", "Atractividad"));
                grados.Add(datos.Grados.SbcUsabilidad.Atractividad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarusabilidad.EstCumplimientoUsabilidad)
            {
                info.Add(new Tuple<string, string>("Usabilidad", "Cumplimiento Usabilidad"));
                grados.Add(datos.Grados.SbcUsabilidad.CumplimientoUsabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstAnalizabilidad)
            {
                info.Add(new Tuple<string, string>("Mantenibilidad", "Facilidad Análisis"));
                grados.Add(datos.Grados.SbcMantenibilidad.Analizabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstModificabilidad)
            {
                info.Add(new Tuple<string, string>("Mantenibilidad", "Modificabilidad"));
                grados.Add(datos.Grados.SbcMantenibilidad.Modificabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstEstabilidad)
            {
                info.Add(new Tuple<string, string>("Mantenibilidad", "Estabilidad"));
                grados.Add(datos.Grados.SbcMantenibilidad.Estabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstTesteabilidad)
            {
                info.Add(new Tuple<string, string>("Mantenibilidad", "Testeabilidad"));
                grados.Add(datos.Grados.SbcMantenibilidad.Testeabilidad);
                activadas++;
            }

            if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstCumplimientoMantenibilidad)
            {
                info.Add(new Tuple<string, string>("Mantenibilidad", "Cumplimiento Mantenibilidad"));
                grados.Add(datos.Grados.SbcMantenibilidad.CumplimientoMantenibilidad);
                activadas++;
            }

            Tuple<string, string>[] subcaracteristicas = (Tuple<string, string>[])info.ToArray(typeof(Tuple<string, string>));
            double[] importancia = (double[])grados.ToArray(typeof(double));
            double[] numResultados = new double[activadas];
            string[] lingResultados = new string[activadas];

            for (int i = 0; i < activadas; i++)
            {
                numResultados[i] = 0;
                lingResultados[i] = "NINGUNA";
            }

            lista.Add(subcaracteristicas);
            lista.Add(importancia);
            lista.Add(numResultados);
            lista.Add(lingResultados);

            return lista;
        }

        // Cargar tablas subcaracteristicas 

        private void cargarTablaSubcaracteristicas(DataGrid visual, Tuple<string, string>[] subcaracteristicas, double[] importancia, double[] numResultados, string[] lingResultados)
        {
            DataTable dtColumnas = new DataTable();

            dtColumnas.Columns.Add("subcaracterística", typeof(string));
            dtColumnas.Columns.Add("característica", typeof(string));
            dtColumnas.Columns.Add("importancia", typeof(string));
            dtColumnas.Columns.Add("valor", typeof(string));
            dtColumnas.Columns.Add("etiqueta", typeof(string));

            for (int i = 0; i < subcaracteristicas.Length; i++)
                dtColumnas.Rows.Add(new object[] { subcaracteristicas[i].Item2, subcaracteristicas[i].Item1, importancia[i], numResultados[i], lingResultados[i] });

            visual.ItemsSource = dtColumnas.DefaultView;
        }

        // Eventos botones

        private void btnCalcSubInterna_Click(object sender, RoutedEventArgs e)
        {
            /*if (calcularFormulasmetricas())
            {
                if (calcularFuzzySubcaracteristicas())
                {
                    btnCalcCaractInterna.IsEnabled = true;
                }
                else
                {
                    btnCalcCaractInterna.IsEnabled = false;
                }
            }*/
        }

        private void btnCalcSubExterna_Click(object sender, RoutedEventArgs e)
        {
           /* if (calcularFormulasmetricas())
            {
                if (calcularFuzzySubcaracteristicas())
                {
                    btnCalcCaractExterna.IsEnabled = true;
                }
                else
                {
                    btnCalcCaractExterna.IsEnabled = false;
                }
            }*/
        }

        // ------------------------------- PAGINA CALIDAD CARACTERISTICAS ----------------------------------------

        // Carga datos inicial para caracteristicas

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
            dtColumnas.Columns.Add("importancia", typeof(string));
            dtColumnas.Columns.Add("valor", typeof(string));
            dtColumnas.Columns.Add("etiqueta", typeof(string));

            for (int i = 0; i < caracteristicas.Length; i++)
                dtColumnas.Rows.Add(new object[] { caracteristicas[i], importancia[i], numResultados[i], lingResultados[i] });

            visual.ItemsSource = dtColumnas.DefaultView;
        }

        // Comprueba el estado de la evaluacion de las caracteristicas

        private bool comprobarEstadoEvaCar()
        {
            if (btnCalcCaractInterna.IsEnabled && btnCalcCaractExterna.IsEnabled)
                return true;
            return false;
        }

        // Eventos botones

        private void btnCalcCaractInterna_Click(object sender, RoutedEventArgs e)
        {
           /* if (calcularFuzzyCacteristicas())
            {
                if (comprobarEstadoEvaCar())
                {
                    btnCalcCalidadFinal.IsEnabled = true;
                }
                else
                {
                    btnCalcCalidadFinal.IsEnabled = false;
                }
            }*/
        }

        private void btnCalcCaractExterna_Click(object sender, RoutedEventArgs e)
        {
           /* if (calcularFuzzyCacteristicas())
            {
                if (comprobarEstadoEvaCar())
                {
                    btnCalcCalidadFinal.IsEnabled = true;
                }
                else
                {
                    btnCalcCalidadFinal.IsEnabled = false;
                }
            }*/
        }

        // ----------------------------------- PAGINA CALIDAD FINAL ----------------------------------------------

        // Carga datos inicial para calidad final

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
            if (txtNombreArchivo.Text == string.Empty)
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
            /*if (calcularFuzzyCalidad())
            {
                btnGenerarPDF.IsEnabled = true;
            }
            else
            {
                btnGenerarPDF.IsEnabled = false;
            }*/
        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            if (validarDatosReporte())
            {
                if (validarConfigPDF())
                {
                    /*if (validarEvaluacion())
                    {
                        

                					Stream myStream = null;
			
					SaveFileDialog saveFileDialog1 = new SaveFileDialog();
					string ruta = saveFileDialog1.FileName;
					saveFileDialog1.InitialDirectory = "c:\\Documentos";
					saveFileDialog1.FileName = txtNombreArchivo.Text;
					saveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
					saveFileDialog1.DefaultExt = "pdf";
					saveFileDialog1.AddExtension = true;
					saveFileDialog1.FilterIndex = 2;
					saveFileDialog1.RestoreDirectory = true;

					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					{
						Reportes r = new Reportes(saveFileDialog1.FileName);
				Xceed.Wpf.Toolkit.MessageBox.Show("El archivo se ha creado correctamente");
					}



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
