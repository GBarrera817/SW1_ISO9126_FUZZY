﻿using SW1_ISO9126_FUZZY.Modelo_Datos;
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
using SW1_ISO9126_FUZZY.Modelo_Datos.Importancias;
using SW1_ISO9126_FUZZY.Evaluacion_Calidad.Primer_Nivel_Calidad;
using SW1_ISO9126_FUZZY.Evaluacion_Calidad.Segundo_Nivel_Calidad_Perspectiva;
using SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final;
using SW1_ISO9126_FUZZY.Evaluacion_Calidad;

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

		// Lista final de subcaracteristicas
		private List<double> FFuncionalidadInterna;
		private List<double> FUsabilidadInterna;
		private List<double> FMantenibilidadInterna;
		private List<double> FFuncionalidadExterna;
		private List<double> FUsabilidadExterna;
		private List<double> FMantenibilidadExterna;

		private List<double> calidadCaracteristicasInternas;
		private List<double> calidadCaracteristicasExternas;

		private double calidadInterna;
		private double calidadExterna;
		private double calidadProducto;

		private bool estadoCalidadInterna;
		private bool estadoCalidadExterna;
		private bool estadoCalidadFinal;

		private EstadoModulo calidadMetricas;
		private EstadoFinal estadoFinalEvaluacion;
		private Resultado resultadoFinalEvaluacion;
		private Evaluacion miEvaluacion;

		private EvaluacionCalidadCaracteristica controladorCaracteristica;
		private EvaluacionCalidadPerspectiva controladorPerspectiva;
		private EvaluacionCalidadProducto controladorProducto;

		public EvaluacionCalidadPage(Evaluacion nueva)
		{
			InitializeComponent();

			this.miEvaluacion = nueva;
			this.calidadMetricas = new EstadoModulo();
			this.estadoFinalEvaluacion = new EstadoFinal();
			this.resultadoFinalEvaluacion = new Resultado();

			controladorCaracteristica = new EvaluacionCalidadCaracteristica();
			controladorPerspectiva = new EvaluacionCalidadPerspectiva();
			controladorProducto = new EvaluacionCalidadProducto();
		}

		// Crear listas calculos metricas 

		private void inicializarListasCalculos(Evaluacion datos)
		{
			Console.WriteLine("inicializarListasCalculos");

			if (datos.DatosMetricas.FuncionalidadInterna)
			{
				MTCfuncionalidadInterna = new List<MTCalculo>();
				MTCAGfuncionalidadInterna = new List<List<MTCalculo>>();
				FFuncionalidadInterna = new List<double>();
			}

			if (datos.DatosMetricas.UsabilidadInterna)
			{
				MTCusabilidadInterna = new List<MTCalculo>();
				MTCAGusabilidadInterna = new List<List<MTCalculo>>();
				FUsabilidadInterna = new List<double>();
			}

			if (datos.DatosMetricas.MantenibilidadInterna)
			{
				MTCmantenibilidadInterna = new List<MTCalculo>();
				MTCAGmantenibilidadInterna = new List<List<MTCalculo>>();
				FMantenibilidadInterna = new List<double>();
			}

			if (datos.DatosMetricas.FuncionalidadExterna)
			{
				MTCfuncionalidadExterna = new List<MTCalculo>();
				MTCAGfuncionalidadExterna = new List<List<MTCalculo>>();
				FFuncionalidadExterna = new List<double>();
			}

			if (datos.DatosMetricas.UsabilidadExterna)
			{
				MTCusabilidadExterna = new List<MTCalculo>();
				MTCAGusabilidadExterna = new List<List<MTCalculo>>();
				FUsabilidadExterna = new List<double>();
			}

			if (datos.DatosMetricas.MantenibilidadExterna)
			{
				MTCmantenibilidadExterna = new List<MTCalculo>();
				MTCAGmantenibilidadExterna = new List<List<MTCalculo>>();
				FMantenibilidadExterna = new List<double>();
			}

			calidadCaracteristicasInternas = new List<double>();
			calidadCaracteristicasExternas = new List<double>();
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
			Console.WriteLine("cargarDatosModulo");

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

		// Cargas datos desde modulo evaluacion

		public void cargarModuloEvaluacion(Evaluacion datos, string perspectiva)
		{
			Console.WriteLine("Pagina calidad cargarModuloEvaluacion");

			miEvaluacion = datos;

			if (perspectiva.Equals("Interna"))
				btnCalcSubInterna.IsEnabled = true;
			else
				btnCalcSubExterna.IsEnabled = true;
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

		// Calcula las formulas de las metricas

		private List<MTCalculo> calcularResultadoFormulas(List<MTEvaluacion> listaEvaluacion)
		{
			Console.WriteLine("calcularResultadoFormulas");

			List<MTCalculo> listaCalculo = new List<MTCalculo>();
			MTEvaluacion datos;
			MTCalculo valor;

			for (int i = 0; i < listaEvaluacion.Count; i++)
			{
				datos = listaEvaluacion[i];
				valor = new MTCalculo();

				valor.Id = datos.Id;

				Console.WriteLine("\n<<===================");

				Console.WriteLine("Datos origen");
				Console.WriteLine(datos.ToString());
				Console.WriteLine("---------------------");
				Console.WriteLine("Datos evaluacion");

				if (datos.Parametros.Length == 2)
				{
					valor.Resultado = Formula.GetResultadoFormula(datos.Formula, datos.Valores[0], datos.Valores[1]);
					Console.WriteLine("P0: " + datos.Valores[0] + " P1: " + datos.Valores[1]);
				} else
				{
					valor.Resultado = Formula.GetResultadoFormula(datos.Formula, datos.Valores[0], datos.Valores[1], datos.Valores[2]);
					Console.WriteLine("P0: " + datos.Valores[0] + " P1: " + datos.Valores[1] + " P2: " + datos.Valores[2]);
				}

				Console.WriteLine("Resultado: " + valor.Resultado);
				Console.WriteLine("---------------------");
				Console.WriteLine("Datos almacenados");
				Console.WriteLine(valor.ToString());

				listaCalculo.Add(valor);

				Console.WriteLine("\n===================>>");
			}

			return listaCalculo;
		}

		// Agrupa la lista de calculo de metricas por subcaracteristicas

		private List<List<MTCalculo>> agruparSubcaracteristicas(List<MTCalculo> original, List<JMetrica> metricas)
		{
			Console.WriteLine("Modulo: agruparSubcaracteristicas");

			List<JMetrica> local = new List<JMetrica>(obtenerListaReal(original, metricas));
			List<List<MTCalculo>> lista = new List<List<MTCalculo>>();
			List<MTCalculo> sublista = new List<MTCalculo>();

			string subcarateristica = local[0].Subcaracteristica;

			for (int i = 0; i < original.Count; i++)
			{
				Console.WriteLine("comparar : " + subcarateristica + " VS " + local[i].Subcaracteristica);
				if (string.Equals(subcarateristica, local[i].Subcaracteristica))
				{
					sublista.Add(original[i]);
					Console.WriteLine("Agregado a la lista actual: " + original[i].Id);
				} else
				{
					lista.Add(sublista);

					Console.WriteLine("Imprimir sublista iteracion: " + i);

					for (int k = 0; k < sublista.Count; k++)
					{
						Console.WriteLine("ID: " + sublista[k].Id);
					}

					sublista = new List<MTCalculo>();

					sublista.Add(original[i]);
					subcarateristica = local[i].Subcaracteristica;
					Console.WriteLine("Agregado a la lista nueva: " + original[i].Id);
				}
			}

			lista.Add(sublista);

			Console.WriteLine("Imprimir sublista");

			for (int k = 0; k < sublista.Count; k++)
			{
				Console.WriteLine("ID: " + sublista[k].Id);
			}

			Console.WriteLine("Sublistas creadas");
			Console.WriteLine("-----------------");

			foreach (List<MTCalculo> sublist in lista)
			{
				Console.WriteLine("Sublista");

				foreach (MTCalculo item in sublist)
					Console.WriteLine("ID: " + item.Id);
			}

			return lista;
		}

		// Obtener metricas activadas del total de metricas

		private List<JMetrica> obtenerListaReal(List<MTCalculo> original, List<JMetrica> metricas)
		{
			Console.WriteLine("modulo: obtenerListaReal");

			List<JMetrica> local = new List<JMetrica>();
			int j = 0;

			for (int i = 0; i < original.Count; i++)
			{
				while (original[i].Id != metricas[j].Id)
					j++;

				local.Add(metricas[j]);
				j++;
			}

			Console.WriteLine("Lista original MTCalculo");

			for (int i = 0; i < original.Count; i++)
				Console.WriteLine("ID: " + original[i].Id);

			Console.WriteLine("Lista original JMetrica");

			for (int i = 0; i < local.Count; i++)
				Console.WriteLine("ID: " + local[i].Id);

			return local;
		}

		// Promedia las metricas de las subcaracteristicas de una caracteristica 

		private List<double> promedioSubcaracteristicas(List<List<MTCalculo>> subcaracteristica)
		{
			Console.WriteLine("promedioSubcaracteristicas");

			List<double> promedios = new List<double>();
			List<MTCalculo> temporal;
			double valor, resultado;

			for (int i = 0; i < subcaracteristica.Count; i++)
			{
				Console.WriteLine("\nSublista: " + i);

				temporal = new List<MTCalculo>(subcaracteristica[i]);
				valor = 0;
				resultado = 0;

				for (int j = 0; j < temporal.Count; j++)
				{
					Console.WriteLine("valor: " + temporal[j].Resultado);
					valor = valor + temporal[j].Resultado;
				}

				resultado = valor / temporal.Count;

				if(resultado == 0)
				{
					resultado = 1 ;
				}

				Console.WriteLine("Promedio: " + resultado);
				promedios.Add(resultado);
			}

			Console.WriteLine("\nLista de promedios de salida");
			Console.WriteLine("----------------------------");

			foreach (double item in promedios)
			{
				Console.WriteLine("Promedio: " + item);
			}

			return promedios;
		}

		// Normaliza las subcaracteristicas de una caracteristica 

		private List<double> normalizarSubcaracteristicas(List<double> subcaracteristicas)
		{
			Console.WriteLine("normalizarSubcaracteristicas");

			List<double> normalizacion = new List<double>();
			double valor = 0;
			double resultado = 0;

			Console.WriteLine("\nLista de entrada");
			Console.WriteLine("----------------");

			for (int i = 0; i < subcaracteristicas.Count; i++)
			{
				Console.WriteLine("Valor: " + subcaracteristicas[i]);
			}

			for (int i = 0; i < subcaracteristicas.Count; i++)
				valor = valor + subcaracteristicas[i];

			Console.WriteLine("Sumatoria: " + valor);

			for (int i = 0; i < subcaracteristicas.Count; i++)
			{
				resultado = subcaracteristicas[i] / valor;
				normalizacion.Add(Math.Round(resultado, 2));
			}

			Console.WriteLine("\nLista de salida normalizada");
			Console.WriteLine("-----------------------------");

			for (int i = 0; i < normalizacion.Count; i++)
				Console.WriteLine("Valor: " + normalizacion[i]);

			return normalizacion;
		}

		// Aplica importancia a las subcaracteristicas

		private List<double> aplicarImportanciaSubcaracteristicas(List<double> subcaracteristicas, List<double> grados)
		{
			Console.WriteLine("aplicarImportanciaSubcaracteristicas");

			List<double> importancias = new List<double>();
			double resultado = 0;
			double subcar = 0;
			double grado = 0;

			Console.WriteLine("\nListas de entrada");
			Console.WriteLine("-------------------");

			Console.WriteLine("\nListas subcacteristicas");

			for (int i = 0; i < subcaracteristicas.Count; i++)
			{
				Console.WriteLine("Valor: " + subcaracteristicas[i]);
			}

			Console.WriteLine("\nListas grados de importancia");

			for (int i = 0; i < grados.Count; i++)
			{
				Console.WriteLine("grado: " + grados[i]);
			}

			if (subcaracteristicas.Count == grados.Count)
				Console.WriteLine("\nMisma longitud");
			else
				Console.WriteLine("\nDiferente longitud CUIDADO !!!");

			for (int i = 0; i < subcaracteristicas.Count; i++)
			{
				subcar = subcaracteristicas[i];
				grado = grados[i]; // error de indice

				resultado = subcar * grado;
				importancias.Add(resultado);
			}

			Console.WriteLine("\nLista de salida graduada");
			Console.WriteLine("--------------------------");

			for (int i = 0; i < importancias.Count; i++)
				Console.WriteLine("Valor resultante: " + importancias[i]);

			return importancias;
		}

		// Metodos para recuperar los grados de importancia subcaracteristicas

		private List<double> obtenerImportanciaSubcarFuncionalidad(ISCFuncionalidad info)
		{
			Console.WriteLine("Entando a: obtenerImportanciaSubcarFuncionalidad");

			List<double> funcionalidad = new List<double>();

			if (info.Adecuacion != 0)
				funcionalidad.Add(info.Adecuacion);

			if (info.Exactitud != 0)
				funcionalidad.Add(info.Exactitud);

			if (info.Interoperabilidad != 0)
				funcionalidad.Add(info.Interoperabilidad);

			if (info.SeguridadAcceso != 0)
				funcionalidad.Add(info.SeguridadAcceso);

			if (info.CumplimientoFuncional != 0)
				funcionalidad.Add(info.CumplimientoFuncional);

			for (int i = 0; i < funcionalidad.Count; i++)
				Console.WriteLine("Importancia " + i + ": " + funcionalidad[i]);

			return funcionalidad;
		}

		private List<double> obtenerImportanciaSubcarUsabilidad(ISCUsabilidad info)
		{
			Console.WriteLine("Entando a: obtenerImportanciaSubcarUsabilidad");

			List<double> usabilidad = new List<double>();

			if (info.Comprensibilidad != 0)
				usabilidad.Add(info.Comprensibilidad);

			if (info.Aprendizaje != 0)
				usabilidad.Add(info.Aprendizaje);

			if (info.Operabilidad != 0)
				usabilidad.Add(info.Operabilidad);

			if (info.Atractividad != 0)
				usabilidad.Add(info.Atractividad);

			if (info.CumplimientoUsabilidad != 0)
				usabilidad.Add(info.CumplimientoUsabilidad);

			for (int i = 0; i < usabilidad.Count; i++)
				Console.WriteLine("Importancia " + i + ": " + usabilidad[i]);

			return usabilidad;
		}

		private List<double> obtenerImportanciaSubcarMantenibilidad(ISCMantenibilidad info)
		{
			Console.WriteLine("Entando a: obtenerImportanciaSubcarMantenibilidad");

			List<double> mantenibilidad = new List<double>();

			if (info.Analizabilidad != 0)
				mantenibilidad.Add(info.Analizabilidad);

			if (info.Modificabilidad != 0)
				mantenibilidad.Add(info.Modificabilidad);

			if (info.Estabilidad != 0)
				mantenibilidad.Add(info.Estabilidad);

			if (info.Testeabilidad != 0)
				mantenibilidad.Add(info.Testeabilidad);

			if (info.CumplimientoMantenibilidad != 0)
				mantenibilidad.Add(info.CumplimientoMantenibilidad);

			for (int i = 0; i < mantenibilidad.Count; i++)
				Console.WriteLine("Importancia " + i + ": " + mantenibilidad[i]);

			return mantenibilidad;
		}

		// Prepara la lista de calculos para realizar la evaluacion difusa

		private void prepararEvaluacionDifusaSubcaracteristicas(Evaluacion datos, string perspectiva)
		{
			Console.WriteLine("Entrando a prepararEvaluacionFuzzy: " + perspectiva);

			List<double> importanciaSubcarFuncionalidad = new List<double>(obtenerImportanciaSubcarFuncionalidad(datos.Grados.SbcFuncionalidad));
			List<double> importanciaSubcarUsabilidad = new List<double>(obtenerImportanciaSubcarUsabilidad(datos.Grados.SbcUsabilidad));
			List<double> importanciaSubcarMantenibilidad = new List<double>(obtenerImportanciaSubcarMantenibilidad(datos.Grados.SbcMantenibilidad));

			if (perspectiva.Equals("Interna"))
			{
				if (datos.DatosMetricas.FuncionalidadInterna)
				{
					MTCfuncionalidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.FuncionalidadInterna));
					MTCAGfuncionalidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCfuncionalidadInterna, datos.CargaMetricas.FuncionalidadInterna));
					FFuncionalidadInterna = new List<double>(promedioSubcaracteristicas(MTCAGfuncionalidadInterna));
					FFuncionalidadInterna = new List<double>(normalizarSubcaracteristicas(FFuncionalidadInterna));
					FFuncionalidadInterna = new List<double>(aplicarImportanciaSubcaracteristicas(FFuncionalidadInterna, importanciaSubcarFuncionalidad));
					FFuncionalidadInterna = new List<double>(asignarSCFuncionalidadControlador(datos, FFuncionalidadInterna));
				}

				if (datos.DatosMetricas.UsabilidadInterna)
				{
					MTCusabilidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.UsabilidadInterna));
					MTCAGusabilidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCusabilidadInterna, datos.CargaMetricas.UsabilidadInterna));
					FUsabilidadInterna = new List<double>(promedioSubcaracteristicas(MTCAGusabilidadInterna));
					FUsabilidadInterna = new List<double>(normalizarSubcaracteristicas(FUsabilidadInterna));
					FUsabilidadInterna = new List<double>(aplicarImportanciaSubcaracteristicas(FUsabilidadInterna, importanciaSubcarUsabilidad));
					FUsabilidadInterna = new List<double>(asignarSCUsabilidadControlador(datos, FUsabilidadInterna));
				}

				if (datos.DatosMetricas.MantenibilidadInterna)
				{
					MTCmantenibilidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.MantenibilidadInterna));
					MTCAGmantenibilidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCmantenibilidadInterna, datos.CargaMetricas.MantenibilidadInterna));
					FMantenibilidadInterna = new List<double>(promedioSubcaracteristicas(MTCAGmantenibilidadInterna));
					FMantenibilidadInterna = new List<double>(normalizarSubcaracteristicas(FMantenibilidadInterna));
					FMantenibilidadInterna = new List<double>(aplicarImportanciaSubcaracteristicas(FMantenibilidadInterna, importanciaSubcarMantenibilidad));
					FMantenibilidadInterna = new List<double>(asignarSCMantenibilidadControlador(datos, FMantenibilidadInterna));
				}
			} else
			{
				if (datos.DatosMetricas.FuncionalidadExterna)
				{
					MTCfuncionalidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.FuncionalidadExterna));
					MTCAGfuncionalidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCfuncionalidadExterna, datos.CargaMetricas.FuncionalidadExterna));
					FFuncionalidadExterna = new List<double>(promedioSubcaracteristicas(MTCAGfuncionalidadExterna));
					FFuncionalidadExterna = new List<double>(normalizarSubcaracteristicas(FFuncionalidadExterna));
					FFuncionalidadExterna = new List<double>(aplicarImportanciaSubcaracteristicas(FFuncionalidadExterna, importanciaSubcarFuncionalidad));
					FFuncionalidadExterna = new List<double>(asignarSCFuncionalidadControlador(datos, FFuncionalidadExterna));
				}

				if (datos.DatosMetricas.UsabilidadExterna)
				{
					MTCusabilidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.UsabilidadExterna));
					MTCAGusabilidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCusabilidadExterna, datos.CargaMetricas.UsabilidadExterna));
					FUsabilidadExterna = new List<double>(promedioSubcaracteristicas(MTCAGusabilidadExterna));
					FUsabilidadExterna = new List<double>(normalizarSubcaracteristicas(FUsabilidadExterna));
					FUsabilidadExterna = new List<double>(aplicarImportanciaSubcaracteristicas(FUsabilidadExterna, importanciaSubcarUsabilidad));
					FUsabilidadExterna = new List<double>(asignarSCUsabilidadControlador(datos, FUsabilidadExterna));
				}

				if (datos.DatosMetricas.MantenibilidadExterna)
				{
					MTCmantenibilidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.MantenibilidadExterna));
					MTCAGmantenibilidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCmantenibilidadExterna, datos.CargaMetricas.MantenibilidadExterna));
					FMantenibilidadExterna = new List<double>(promedioSubcaracteristicas(MTCAGmantenibilidadExterna));
					FMantenibilidadExterna = new List<double>(normalizarSubcaracteristicas(FMantenibilidadExterna));
					FMantenibilidadExterna = new List<double>(aplicarImportanciaSubcaracteristicas(FMantenibilidadExterna, importanciaSubcarMantenibilidad));
					FMantenibilidadExterna = new List<double>(asignarSCMantenibilidadControlador(datos, FMantenibilidadExterna));
				}
			}
		}

		private List<double> asignarSCFuncionalidadControlador(Evaluacion datos, List<double> subcaracteristicas)
		{
			Console.WriteLine("metodo: asignarSCFuncionalidadControlador");

			int cuadratura = 0;
			double adecuacion, exactitud, interoperabilidad, seguridadAcceso, cumplimientoFuncional;
			List<double> lista = new List<double>();

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstAdecuacion)
			{
				adecuacion = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				adecuacion = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstExactitud)
			{
				exactitud = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				exactitud = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstInteroperabilidad)
			{
				interoperabilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				interoperabilidad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstSeguridadAcceso)
			{
				seguridadAcceso = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				seguridadAcceso = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstCumplimientoFuncional)
			{
				cumplimientoFuncional = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				cumplimientoFuncional = 0;
			}

			lista.Add(adecuacion);
			lista.Add(exactitud);
			lista.Add(interoperabilidad);
			lista.Add(seguridadAcceso);
			lista.Add(cumplimientoFuncional);

			foreach (double item in lista)
				Console.WriteLine("Valor: " + item);

			if (cuadratura == subcaracteristicas.Count)
				Console.WriteLine("Cuadra");
			else
				Console.WriteLine("No cuadra");

			return lista;
		}

		private List<double> asignarSCUsabilidadControlador(Evaluacion datos, List<double> subcaracteristicas)
		{
			Console.WriteLine("metodo: asignarSCUsabilidadControlador");

			int cuadratura = 0;
			double comprensibilidad, aprendizaje, operabilidad, atractividad, cumplimientoUsabilidad;
			List<double> lista = new List<double>();

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstComprensibilidad)
			{
				comprensibilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				comprensibilidad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstAprendizaje)
			{
				aprendizaje = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				aprendizaje = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstOperabilidad)
			{
				operabilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				operabilidad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstAtractividad)
			{
				atractividad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				atractividad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstCumplimientoUsabilidad)
			{
				cumplimientoUsabilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				cumplimientoUsabilidad = 0;
			}

			lista.Add(comprensibilidad);
			lista.Add(aprendizaje);
			lista.Add(operabilidad);
			lista.Add(atractividad);
			lista.Add(cumplimientoUsabilidad);

			foreach (double item in lista)
				Console.WriteLine("Valor: " + item);

			if (cuadratura == subcaracteristicas.Count)
				Console.WriteLine("Cuadra");
			else
				Console.WriteLine("No cuadra");

			return lista;
		}

		private List<double> asignarSCMantenibilidadControlador(Evaluacion datos, List<double> subcaracteristicas)
		{
			Console.WriteLine("metodo: asignarSCMantenibilidadControlador");

			int cuadratura = 0;
			double facilidadAnalisis, modificabilidad, estabilidad, testeabilidad, cumplimientoMantenibilidad;
			List<double> lista = new List<double>();

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstAnalizabilidad)
			{
				facilidadAnalisis = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				facilidadAnalisis = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstModificabilidad)
			{
				modificabilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				modificabilidad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstEstabilidad)
			{
				estabilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				estabilidad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstTesteabilidad)
			{
				testeabilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				testeabilidad = 0;
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstCumplimientoMantenibilidad)
			{
				cumplimientoMantenibilidad = subcaracteristicas[cuadratura];
				cuadratura++;
			} else
			{
				cumplimientoMantenibilidad = 0;
			}

			lista.Add(facilidadAnalisis);
			lista.Add(modificabilidad);
			lista.Add(estabilidad);
			lista.Add(testeabilidad);
			lista.Add(cumplimientoMantenibilidad);

			foreach (double item in lista)
				Console.WriteLine("Valor: " + item);

			if (cuadratura == subcaracteristicas.Count)
				Console.WriteLine("Cuadra");
			else
				Console.WriteLine("No cuadra");

			return lista;
		}

		/* private void evaluacionDifusaSubcaracteristicas(List<double> subcaracteristicas, Dictionary<string, string> reglasSubcaracteristicas, )
         {

         }*/

		// Eventos botones

		private void btnCalcSubInterna_Click(object sender, RoutedEventArgs e)
		{
			/*
			prepararEvaluacionDifusaSubcaracteristicas(miEvaluacion, "Interna");
			ecc.obtenerCalidadFuncionalidad(FFuncionalidadInterna);
			Console.WriteLine(ecc.obtenerCalidadFuncionalidad(FFuncionalidadInterna));
			/*if (calcularFuzzySubcaracteristicas())
                btnCalcCaractInterna.IsEnabled = true;
            else
                btnCalcCaractInterna.IsEnabled = false;*/

			ArrayList temporal = new ArrayList();

			prepararEvaluacionDifusaSubcaracteristicas(miEvaluacion, "Interna");
			temporal = cargarResultadosSubcaracteristicas(miEvaluacion, "Interna");
			cargarTablaSubcaracteristicas(tbSubCarInterna, (Tuple<string, string>[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);

			btnCalcCaractInterna.IsEnabled = true;
		}

		private void btnCalcSubExterna_Click(object sender, RoutedEventArgs e)
		{
			//prepararEvaluacionDifusaSubcaracteristicas(miEvaluacion, "Externa");


			/*if (calcularFuzzySubcaracteristicas())
                btnCalcCaractInterna.IsEnabled = true;
            else
                btnCalcCaractInterna.IsEnabled = false;*/

			ArrayList temporal = new ArrayList();

			prepararEvaluacionDifusaSubcaracteristicas(miEvaluacion, "Externa");
			temporal = cargarResultadosSubcaracteristicas(miEvaluacion, "Externa");
			cargarTablaSubcaracteristicas(tbSubCarExterna, (Tuple<string, string>[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);

			btnCalcCaractInterna.IsEnabled = true;

		}

		// ------------------------------- PAGINA CALIDAD CARACTERISTICAS ----------------------------------------

		// Carga datos inicial para caracteristicas

		private ArrayList cargarDatosCaracteristicas(Evaluacion datos)
		{
			ArrayList lista = new ArrayList();
			ArrayList info = new ArrayList();
			ArrayList grados = new ArrayList();
			int activadas = 0;

			if (datos.DatosMetricas.FuncionalidadInterna || datos.DatosMetricas.FuncionalidadExterna)
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

			string[] caracteristicas = (string[])info.ToArray(typeof(string));
			double[] importancia = (double[])grados.ToArray(typeof(double));
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

		// Carga los resultado de la evluacion de caracteristicas
		private ArrayList cargarResultadosCaracteristicas(Evaluacion datos, string perspectiva, List<double> resultado)
		{
			ArrayList lista = new ArrayList();
			ArrayList info = new ArrayList();
			ArrayList grados = new ArrayList();
			ArrayList resultados = new ArrayList();
			ArrayList etiquetas = new ArrayList();


			if (datos.DatosMetricas.FuncionalidadInterna || datos.DatosMetricas.FuncionalidadExterna)
			{
				info.Add("Funcionalidad");
				grados.Add(datos.Grados.Funcionalidad);
				resultados.Add(resultado[0]);
				etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(resultado[0]));
			}

			if (datos.DatosMetricas.UsabilidadInterna || datos.DatosMetricas.UsabilidadExterna)
			{
				info.Add("Usabilidad");
				grados.Add(datos.Grados.Usabilidad);
				resultados.Add(resultado[1]);
				etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(resultado[1]));
			}

			if (datos.DatosMetricas.MantenibilidadInterna || datos.DatosMetricas.MantenibilidadExterna)
			{
				info.Add("Mantenibilidad");
				grados.Add(datos.Grados.Mantenibilidad);
				resultados.Add(resultado[2]);
				etiquetas.Add(EtiquetasDifusas5.getEtiquetaLinguistica(resultado[2]));
			}

			string[] caracteristicas = (string[])info.ToArray(typeof(string));
			double[] importancia = (double[])grados.ToArray(typeof(double));
			double[] numResultados = (double[])resultados.ToArray(typeof(double));
			string[] lingResultados = (string[])etiquetas.ToArray(typeof(string));

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
			double resultadoFInt, resultadoUInt, resultadoMInt;
			ArrayList temporal = new ArrayList();

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

			if (miEvaluacion.DatosMetricas.FuncionalidadInterna)
			{
				resultadoFInt = controladorCaracteristica.obtenerCalidadFuncionalidad(FFuncionalidadInterna);
			} else
			{
				resultadoFInt = 0;
			}

			if (miEvaluacion.DatosMetricas.UsabilidadInterna)
			{
				resultadoUInt = controladorCaracteristica.obtenerCalidadUsabilidad(FUsabilidadInterna);
			} else
			{
				resultadoUInt = 0;
			}

			if (miEvaluacion.DatosMetricas.MantenibilidadInterna)
			{
				resultadoMInt = controladorCaracteristica.obtenerCalidadMantenibilidad(FMantenibilidadInterna);
			} else
			{
				resultadoMInt = 0;
			}

			calidadCaracteristicasInternas.Add(resultadoFInt);
			calidadCaracteristicasInternas.Add(resultadoUInt);
			calidadCaracteristicasInternas.Add(resultadoMInt);

			temporal = cargarResultadosCaracteristicas(miEvaluacion, "Interna", calidadCaracteristicasInternas);
			cargarTablaCaracteristicas(tbcarInterna, (string[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);

			estadoCalidadInterna = true;

			if(estadoCalidadExterna)
				btnCalcCalidadFinal.IsEnabled = true;

		}

		private void btnCalcCaractExterna_Click(object sender, RoutedEventArgs e)
		{
			double resultadoFExt, resultadoUExt, resultadoMExt;
			ArrayList temporal = new ArrayList();

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

			if (miEvaluacion.DatosMetricas.FuncionalidadExterna)
			{
				resultadoFExt = controladorCaracteristica.obtenerCalidadFuncionalidad(FFuncionalidadExterna);
			} else
			{
				resultadoFExt = 0;
			}

			if (miEvaluacion.DatosMetricas.UsabilidadExterna)
			{
				resultadoUExt = controladorCaracteristica.obtenerCalidadUsabilidad(FUsabilidadExterna);
			} else
			{
				resultadoUExt = 0;
			}

			if (miEvaluacion.DatosMetricas.MantenibilidadExterna)
			{
				resultadoMExt = controladorCaracteristica.obtenerCalidadMantenibilidad(FMantenibilidadExterna);
			} else
			{
				resultadoMExt = 0;
			}

			calidadCaracteristicasExternas.Add(resultadoFExt);
			calidadCaracteristicasExternas.Add(resultadoUExt);
			calidadCaracteristicasExternas.Add(resultadoMExt);

			temporal = cargarResultadosCaracteristicas(miEvaluacion, "Externa", calidadCaracteristicasExternas);
			cargarTablaCaracteristicas(tbcarExterna, (string[])temporal[0], (double[])temporal[1], (double[])temporal[2], (string[])temporal[3]);

			estadoCalidadExterna = true;

			if (estadoCalidadInterna)
				btnCalcCalidadFinal.IsEnabled = true;

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

		// Cargar respuestas calidad final

		private ArrayList cargarResultadosCalidad(List<double> resultados)
		{
			int contenido = 3;
			ArrayList lista = new ArrayList();

			string[] atributos = new string[contenido];
			double[] numResultados = new double[contenido];
			string[] lingResultados = new string[contenido];

			atributos[0] = "Calidad Interna";
			atributos[1] = "Calidad Externa";
			atributos[2] = "Calidad Final";

			numResultados[0] = resultados[0];
			numResultados[1] = resultados[1];
			numResultados[2] = resultados[2];

			lingResultados[0] = EtiquetasDifusas1.getEtiquetaLinguistica(resultados[0]);
			lingResultados[1] = EtiquetasDifusas1.getEtiquetaLinguistica(resultados[1]);
			lingResultados[2] = EtiquetasDifusas1.getEtiquetaLinguistica(resultados[2]);

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

		private ArrayList cargarResultadosSubcaracteristicas(Evaluacion datos, string perspectiva)
		{
			ArrayList lista = new ArrayList();
			ArrayList info = new ArrayList();
			ArrayList grados = new ArrayList();
			ArrayList resultados = new ArrayList();
			ArrayList etiquetas = new ArrayList();


			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstAdecuacion)
			{
				info.Add(new Tuple<string, string>("Funcionalidad", "Adecuación"));
				grados.Add(datos.Grados.SbcFuncionalidad.Adecuacion);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FFuncionalidadInterna[0]);
					etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(FFuncionalidadInterna[0]));
				} else
				{
					resultados.Add(FFuncionalidadExterna[0]);
					etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(FFuncionalidadExterna[0]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstExactitud)
			{
				info.Add(new Tuple<string, string>("Funcionalidad", "Exactitud"));
				grados.Add(datos.Grados.SbcFuncionalidad.Exactitud);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FFuncionalidadInterna[1]);
					etiquetas.Add(EtiquetasDifusas2.getEtiquetaLinguistica(FFuncionalidadInterna[1]));
				} else
				{
					resultados.Add(FFuncionalidadExterna[1]);
					etiquetas.Add(EtiquetasDifusas2.getEtiquetaLinguistica(FFuncionalidadExterna[1]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstInteroperabilidad)
			{
				info.Add(new Tuple<string, string>("Funcionalidad", "Interoperabilidad"));
				grados.Add(datos.Grados.SbcFuncionalidad.Interoperabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FFuncionalidadInterna[2]);
					etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(FFuncionalidadInterna[2]));
				} else
				{
					resultados.Add(FFuncionalidadExterna[2]);
					etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(FFuncionalidadExterna[2]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstSeguridadAcceso)
			{
				info.Add(new Tuple<string, string>("Funcionalidad", "Seguridad Acceso"));
				grados.Add(datos.Grados.SbcFuncionalidad.SeguridadAcceso);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FFuncionalidadInterna[3]);
					etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(FFuncionalidadInterna[3]));
				} else
				{
					resultados.Add(FFuncionalidadExterna[3]);
					etiquetas.Add(EtiquetasDifusas1.getEtiquetaLinguistica(FFuncionalidadExterna[3]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarfuncionalidad.EstCumplimientoFuncional)
			{
				info.Add(new Tuple<string, string>("Funcionalidad", "Cumplimiento Funcional"));
				grados.Add(datos.Grados.SbcFuncionalidad.CumplimientoFuncional);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FFuncionalidadInterna[4]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FFuncionalidadInterna[4]));
				} else
				{
					resultados.Add(FFuncionalidadExterna[4]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FFuncionalidadExterna[4]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstComprensibilidad)
			{
				info.Add(new Tuple<string, string>("Usabilidad", "Comprensibilidad"));
				grados.Add(datos.Grados.SbcUsabilidad.Comprensibilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FUsabilidadInterna[0]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FUsabilidadInterna[0]));
				} else
				{
					resultados.Add(FUsabilidadExterna[0]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FUsabilidadExterna[0]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstAprendizaje)
			{
				info.Add(new Tuple<string, string>("Usabilidad", "Aprendizaje"));
				grados.Add(datos.Grados.SbcUsabilidad.Aprendizaje);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FUsabilidadInterna[1]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FUsabilidadInterna[1]));
				} else
				{
					resultados.Add(FUsabilidadExterna[1]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FUsabilidadExterna[1]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstOperabilidad)
			{
				info.Add(new Tuple<string, string>("Usabilidad", "Operabilidad"));
				grados.Add(datos.Grados.SbcUsabilidad.Operabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FUsabilidadInterna[2]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FUsabilidadInterna[2]));
				} else
				{
					resultados.Add(FUsabilidadExterna[2]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FUsabilidadExterna[2]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstAtractividad)
			{
				info.Add(new Tuple<string, string>("Usabilidad", "Atractividad"));
				grados.Add(datos.Grados.SbcUsabilidad.Atractividad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FUsabilidadInterna[3]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FUsabilidadInterna[3]));
				} else
				{
					resultados.Add(FUsabilidadExterna[3]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FUsabilidadExterna[3]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarusabilidad.EstCumplimientoUsabilidad)
			{
				info.Add(new Tuple<string, string>("Usabilidad", "Cumplimiento Usabilidad"));
				grados.Add(datos.Grados.SbcUsabilidad.CumplimientoUsabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FUsabilidadInterna[4]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FUsabilidadInterna[4]));
				} else
				{
					resultados.Add(FUsabilidadExterna[4]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FUsabilidadExterna[4]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstAnalizabilidad)
			{
				info.Add(new Tuple<string, string>("Mantenibilidad", "Facilidad Análisis"));
				grados.Add(datos.Grados.SbcMantenibilidad.Analizabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FMantenibilidadInterna[0]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FMantenibilidadInterna[0]));
				} else
				{
					resultados.Add(FMantenibilidadExterna[0]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FMantenibilidadExterna[0]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstModificabilidad)
			{
				info.Add(new Tuple<string, string>("Mantenibilidad", "Modificabilidad"));
				grados.Add(datos.Grados.SbcMantenibilidad.Modificabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FMantenibilidadInterna[1]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FMantenibilidadInterna[1]));
				} else
				{
					resultados.Add(FMantenibilidadExterna[1]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FMantenibilidadExterna[1]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstEstabilidad)
			{
				info.Add(new Tuple<string, string>("Mantenibilidad", "Estabilidad"));
				grados.Add(datos.Grados.SbcMantenibilidad.Estabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FMantenibilidadInterna[2]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FMantenibilidadInterna[2]));
				} else
				{
					resultados.Add(FMantenibilidadExterna[2]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FMantenibilidadExterna[2]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstTesteabilidad)
			{
				info.Add(new Tuple<string, string>("Mantenibilidad", "Testeabilidad"));
				grados.Add(datos.Grados.SbcMantenibilidad.Testeabilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FMantenibilidadInterna[3]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FMantenibilidadInterna[3]));
				} else
				{
					resultados.Add(FMantenibilidadExterna[3]);
					etiquetas.Add(EtiquetasDifusas4.getEtiquetaLinguistica(FMantenibilidadExterna[3]));
				}
			}

			if (datos.EstSubcaracteristicas.SubCarmantenibilidad.EstCumplimientoMantenibilidad)
			{
				info.Add(new Tuple<string, string>("Mantenibilidad", "Cumplimiento Mantenibilidad"));
				grados.Add(datos.Grados.SbcMantenibilidad.CumplimientoMantenibilidad);

				if (perspectiva.Equals("Interna"))
				{
					resultados.Add(FMantenibilidadInterna[4]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FMantenibilidadInterna[4]));
				} else
				{
					resultados.Add(FMantenibilidadExterna[4]);
					etiquetas.Add(EtiquetasDifusas3.getEtiquetaLinguistica(FMantenibilidadExterna[4]));
				}
			}

			Tuple<string, string>[] subcaracteristicas = (Tuple<string, string>[])info.ToArray(typeof(Tuple<string, string>));
			double[] importancia = (double[])grados.ToArray(typeof(double));
			double[] numResultados = (double[])resultados.ToArray(typeof(double));
			string[] lingResultados = (string[])etiquetas.ToArray(typeof(string));

			lista.Add(subcaracteristicas);
			lista.Add(importancia);
			lista.Add(numResultados);
			lista.Add(lingResultados);

			return lista;
		}

		// Eventos botones

		private void btnCalcCalidadFinal_Click(object sender, RoutedEventArgs e)
		{

			List<double> listaCalidadPerspectiva = new List<double>();
			List<double> resultadosFinales = new List<double>();
			ArrayList temporal = new ArrayList(); 

			/*if (calcularFuzzyCalidad())
            {
                btnGenerarPDF.IsEnabled = true;
            }
            else
            {
                btnGenerarPDF.IsEnabled = false;
            }*/


			calidadInterna = controladorPerspectiva.obtenerCalidadPerspectiva(calidadCaracteristicasInternas);
			calidadExterna = controladorPerspectiva.obtenerCalidadPerspectiva(calidadCaracteristicasExternas);

			listaCalidadPerspectiva.Add(calidadInterna);
			listaCalidadPerspectiva.Add(calidadExterna);

			calidadProducto = controladorProducto.obtenerCalidadProducto(listaCalidadPerspectiva);

			resultadosFinales.Add(calidadInterna);
			resultadosFinales.Add(calidadExterna);
			resultadosFinales.Add(calidadProducto);

			temporal = cargarResultadosCalidad(resultadosFinales);
			cargarTablaCalidad(tbCalidadFinal, (string[])temporal[0], (double[])temporal[1], (string[])temporal[2]);

			btnGenerarPDF.IsEnabled = true;
		}

		//Datos configuración del PDF
		private List<string> obtenerDatosInforme()
		{
			List<string> datos = new List<string>();
			string[] cadena = calendario.DisplayDate.ToString().Split(' ');
			string fecha = cadena[0];

			datos.Add(txtNombreArchivo.Text);
			datos.Add(cmboxTipoFuente.Text);
			datos.Add(dudtTamFuente.Text);
			datos.Add(txtObjetivos.Text);
			datos.Add(txtObservacion.Text);
			datos.Add(fecha);

			return datos;
		}

		private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
		{
			if (validarDatosReporte())
			{
				if (validarConfigPDF())
				{
					//if (validarEvaluacion())
                    //{
                        

                					Stream myStream = null;
			
					System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
					string ruta = saveFileDialog1.FileName;
					saveFileDialog1.InitialDirectory = "c:\\Documentos";
					saveFileDialog1.FileName = txtNombreArchivo.Text;
					saveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
					saveFileDialog1.DefaultExt = "pdf";
					saveFileDialog1.AddExtension = true;
					saveFileDialog1.FilterIndex = 2;
					saveFileDialog1.RestoreDirectory = true;

					if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						//Reportes r = new Reportes(saveFileDialog1.FileName, miEvaluacion, datosInforme());
				Xceed.Wpf.Toolkit.MessageBox.Show("El archivo se ha creado correctamente");
					}



                    //}
                    
				} else
				{
					Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el nombre del archivo para generar el reporte", "Configuración reporte calidad", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			} else
			{
				Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el objetivo de la evaluación para generar el reporte", "Reporte calidad final software", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
	}
}
