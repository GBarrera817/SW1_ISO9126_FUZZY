using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Inferencia_Difusa;
using System;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad
{
	public static class EvaluacionDifusa
	{
		/// <summary>
		/// Realiza una evaluación con lógica difusa. Los datos entregados deben tener una importancia
		/// </summary>
		/// <param name="datos"></param>
		/// <param name="variables"></param>
		/// <param name="reglas"></param>
		/// <returns></returns>
		public static double Evaluacion(Dictionary<string, Tuple<double, double>> datos, List<VariableLinguistica> variables, Dictionary<string, string> reglas)
		{
			Inferencia inferencia = new Inferencia();

			foreach (VariableLinguistica variable in variables)
				inferencia.AgregarVariable(variable);

			foreach (KeyValuePair<string, string> regla in reglas)
				inferencia.AgregarRegla(regla.Key, regla.Value);

			return inferencia.EjecutarInferencia(datos);
		}

		public static double Evaluacion(Dictionary<string, double> datos, List<VariableLinguistica> variables, Dictionary<string, string> reglas)
		{
			Inferencia inferencia = new Inferencia();

			foreach (VariableLinguistica variable in variables)
			{
				inferencia.AgregarVariable(variable);
			}

			foreach (KeyValuePair<string, string> regla in reglas)
			{
				inferencia.AgregarRegla(regla.Key, regla.Value);
			}

			return inferencia.EjecutarInferencia(datos);
		}
	}
}
