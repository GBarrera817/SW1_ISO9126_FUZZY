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
using SW1_ISO9126_FUZZY.Modelo_Datos.Importancias;

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
        private List<double> FMantenibilidadIntena;
        private List<double> FFuncionalidadExterna;
        private List<double> FUsabilidadExterna;
        private List<double> FMantenibilidadExterna;

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
                FMantenibilidadIntena = new List<double>();
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
                    Console.WriteLine("P0: "+datos.Valores[0]+" P1: "+datos.Valores[1]);
                }
                else
                {
                    valor.Resultado = Formula.GetResultadoFormula(datos.Formula, datos.Valores[0], datos.Valores[1], datos.Valores[2]);
                    Console.WriteLine("P0: " + datos.Valores[0] + " P1: " + datos.Valores[1] + " P2: "+datos.Valores[2]);
                }   

                Console.WriteLine("Resultado: "+valor.Resultado);
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
                }
                else
                {
                    lista.Add(sublista); 

                    Console.WriteLine("Imprimir sublista iteracion: "+i);

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
                Console.WriteLine("ID: "+original[i].Id);

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
                Console.WriteLine("\nSublista: "+i);

                temporal = new List<MTCalculo>(subcaracteristica[i]);
                valor = 0;
                resultado = 0;

                for (int j = 0; j < temporal.Count; j++)
                { 
                    Console.WriteLine("valor: "+ temporal[j].Resultado);
                    valor = valor + temporal[j].Resultado;
                }
   
                resultado = valor / temporal.Count;

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
                Console.WriteLine("Valor: "+subcaracteristicas[i]);
            }

            for (int i = 0; i < subcaracteristicas.Count; i++)
                valor = valor + subcaracteristicas[i];

            Console.WriteLine("Sumatoria: "+valor);

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

            if(subcaracteristicas.Count == grados.Count)
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
                Console.WriteLine("Importancia "+i+": "+funcionalidad[i]);

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

        private void prepararEvaluacionFuzzy(Evaluacion datos, string perspectiva)
        {
            Console.WriteLine("Entrando a prepararEvaluacionFuzzy: " + perspectiva);

            List<double> importanciaSubcarFuncionalidad = new List<double>(obtenerImportanciaSubcarFuncionalidad(datos.Grados.SbcFuncionalidad));
            List<double> importanciaSubcarUsabilidad = new List<double>(obtenerImportanciaSubcarUsabilidad(datos.Grados.SbcUsabilidad));
            List<double> importanciaSubcarMantenibilidad = new List<double>(obtenerImportanciaSubcarMantenibilidad(datos.Grados.SbcMantenibilidad));

            if (perspectiva.Equals("Interna"))
            {
                if (datos.DatosMetricas.FuncionalidadInterna)
                {
                    MTCfuncionalidadInterna =  new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.FuncionalidadInterna));
                    MTCAGfuncionalidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCfuncionalidadInterna, datos.CargaMetricas.FuncionalidadInterna));
                    FFuncionalidadInterna = new List<double>(promedioSubcaracteristicas(MTCAGfuncionalidadInterna));
                    FFuncionalidadInterna = new List<double>(normalizarSubcaracteristicas(FFuncionalidadInterna));
                    FFuncionalidadInterna = new List<double>(aplicarImportanciaSubcaracteristicas(FFuncionalidadInterna, importanciaSubcarFuncionalidad));
                }

                if (datos.DatosMetricas.UsabilidadInterna)
                {
                    MTCusabilidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.UsabilidadInterna));
                    MTCAGusabilidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCusabilidadInterna, datos.CargaMetricas.UsabilidadInterna));
                    FUsabilidadInterna = new List<double>(promedioSubcaracteristicas(MTCAGusabilidadInterna));
                    FUsabilidadInterna = new List<double>(normalizarSubcaracteristicas(FUsabilidadInterna));
                    FUsabilidadInterna = new List<double>(aplicarImportanciaSubcaracteristicas(FUsabilidadInterna, importanciaSubcarUsabilidad));
                }

                if (datos.DatosMetricas.MantenibilidadInterna)
                {
                    MTCmantenibilidadInterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.MantenibilidadInterna));
                    MTCAGmantenibilidadInterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCmantenibilidadInterna, datos.CargaMetricas.MantenibilidadInterna));
                    FMantenibilidadIntena = new List<double>(promedioSubcaracteristicas(MTCAGmantenibilidadInterna));
                    FMantenibilidadIntena = new List<double>(normalizarSubcaracteristicas(FMantenibilidadIntena));
                    FMantenibilidadIntena = new List<double>(aplicarImportanciaSubcaracteristicas(FMantenibilidadIntena, importanciaSubcarMantenibilidad));
                }
            }
            else
            {
                if (datos.DatosMetricas.FuncionalidadExterna)
                {
                    MTCfuncionalidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.FuncionalidadExterna));
                    MTCAGfuncionalidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCfuncionalidadExterna, datos.CargaMetricas.FuncionalidadExterna));
                    FFuncionalidadExterna = new List<double>(promedioSubcaracteristicas(MTCAGfuncionalidadExterna));
                    FFuncionalidadExterna = new List<double>(normalizarSubcaracteristicas(FFuncionalidadExterna));
                    FFuncionalidadExterna = new List<double>(aplicarImportanciaSubcaracteristicas(FFuncionalidadExterna, importanciaSubcarFuncionalidad));
                }

                if (datos.DatosMetricas.UsabilidadExterna)
                {
                    MTCusabilidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.UsabilidadExterna));
                    MTCAGusabilidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCusabilidadExterna, datos.CargaMetricas.UsabilidadExterna));
                    FUsabilidadExterna = new List<double>(promedioSubcaracteristicas(MTCAGusabilidadExterna));
                    FUsabilidadExterna = new List<double>(normalizarSubcaracteristicas(FUsabilidadExterna));
                    FUsabilidadExterna = new List<double>(aplicarImportanciaSubcaracteristicas(FUsabilidadExterna, importanciaSubcarUsabilidad));
                }

                if (datos.DatosMetricas.MantenibilidadExterna)
                {
                    MTCmantenibilidadExterna = new List<MTCalculo>(calcularResultadoFormulas(datos.Fomulario.MantenibilidadExterna));
                    MTCAGmantenibilidadExterna = new List<List<MTCalculo>>(agruparSubcaracteristicas(MTCmantenibilidadExterna, datos.CargaMetricas.MantenibilidadExterna));
                    FMantenibilidadExterna = new List<double>(promedioSubcaracteristicas(MTCAGmantenibilidadExterna));
                    FMantenibilidadExterna = new List<double>(normalizarSubcaracteristicas(FMantenibilidadExterna));
                    FMantenibilidadExterna = new List<double>(aplicarImportanciaSubcaracteristicas(FMantenibilidadExterna, importanciaSubcarMantenibilidad));
                }
            }
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

        // Eventos botones

        private void btnCalcSubInterna_Click(object sender, RoutedEventArgs e)
        {
            prepararEvaluacionFuzzy(miEvaluacion, "Interna");
            
            /*if (calcularFuzzySubcaracteristicas())
                btnCalcCaractInterna.IsEnabled = true;
            else
                btnCalcCaractInterna.IsEnabled = false;*/
        }

        private void btnCalcSubExterna_Click(object sender, RoutedEventArgs e)
        {
            prepararEvaluacionFuzzy(miEvaluacion, "Externa");

            /*if (calcularFuzzySubcaracteristicas())
                btnCalcCaractInterna.IsEnabled = true;
            else
                btnCalcCaractInterna.IsEnabled = false;*/
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
