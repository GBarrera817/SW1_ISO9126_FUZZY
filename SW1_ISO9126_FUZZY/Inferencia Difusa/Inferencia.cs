﻿using System.Collections.Generic;
using System;
using System.Linq;
using SW1_ISO9126_FUZZY.Logica_Difusa;




namespace SW1_ISO9126_FUZZY.Inferencia_Difusa
{
	/// <summary>
	/// Clase para realizar la Inferencia difusa
	/// </summary>
	public class Inferencia
	{
		private Dictionary<string, string> _baseReglas;
		private Dictionary<string, VariableLinguistica> _variablesLinguisticas;

		public Inferencia()
		{
			BaseReglas = new Dictionary<string, string>();
			VariablesLinguisticas = new Dictionary<string, VariableLinguistica>();
		}

		/// <summary>
		/// Agrega una variable lingüística.
		/// </summary>
		/// <param name="variableLinguistica"></param>
		/// <returns></returns>
		public bool AgregarVariable(VariableLinguistica variableLinguistica)
		{
			if (!VariablesLinguisticas.ContainsKey(variableLinguistica.NombreVariable))
			{
				VariablesLinguisticas.Add(variableLinguistica.NombreVariable, variableLinguistica);
				return true;
			}
			return false;
		}


		/// <summary>
		/// Elimina una variable lingüística.
		/// </summary>
		/// <param name="variableLinguistica"></param>
		/// <returns></returns>
		public bool EliminarVariable(string variableLinguistica)
		{
			if (VariablesLinguisticas.ContainsKey(variableLinguistica))
			{
				VariablesLinguisticas.Remove(variableLinguistica);
				return true;
			}

			return false;
		}


		/// <summary>
		/// Agrega una regla a la base de reglas. 
		/// Si la regla no existe, se agrega y retorna true.
		/// Si la regla existe, retorna false;
		/// </summary>
		/// <param name="id"></param>
		/// <param name="regla"></param>
		/// <returns></returns>
		public bool AgregarRegla(string id, string regla)
		{
			if (!BaseReglas.ContainsKey(id))
			{
				BaseReglas.Add(id, regla);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Elimina una regla de la base de reglas de la inferencia, solo si existe y retorna true.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool EliminarRegla(string id)
		{
			if (BaseReglas.ContainsKey(id))
			{
				BaseReglas.Remove(id);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Agrega una variable lingüística. Si no existe, la crea y retorna true.
		/// Si existe, devuelve false.
		/// </summary>
		/// <param name="variableLinguistica"></param>
		/// <returns></returns>
		public bool AgregarVariableLinguistica(VariableLinguistica variableLinguistica)
		{
			if (!VariablesLinguisticas.ContainsKey(variableLinguistica.NombreVariable))
			{
				VariablesLinguisticas.Add(variableLinguistica.NombreVariable, variableLinguistica);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Elimina una variable lingüística de la inferencia, en caso de que exista.
		/// Si no existe retorna falso.
		/// </summary>
		/// <param name="variableLinguistica"></param>
		/// <returns></returns>
		public bool EliminarVariableLinguistica(VariableLinguistica variableLinguistica)
		{
			if (VariablesLinguisticas.ContainsKey(variableLinguistica.NombreVariable))
			{
				VariablesLinguisticas.Remove(variableLinguistica.NombreVariable);
				return true;
			}
			return false;
		}


		/// <summary>
		/// Obtiene el antecedente de la regla.
		/// </summary>
		/// <param name="regla"></param>
		/// <returns></returns>
		public Dictionary<string, ValorLinguistico> GetAntecedente(string regla)
		{
			//"IF adecuacion IS muy_mala THEN funcionalidad IS muy_mala";
			string[] reglaTemp = regla.Split(' ');
			Dictionary<string, ValorLinguistico> antecedente = new Dictionary<string, ValorLinguistico>();

			// Regla con una sola variable lingüística en el antecedente.
			if (reglaTemp.Length == 8)
			{
				string variable = reglaTemp[1];
				string valor = reglaTemp[3];

				if (VariablesLinguisticas.ContainsKey(variable))
				{
					//valorLinguistico = "muy_mala"
					ValorLinguistico valorLinguistico = VariablesLinguisticas[variable].ValorLinguistico(valor);
					antecedente.Add(variable, valorLinguistico);
				}
			} else if (reglaTemp.Length >= 12)
			{
				//IF adecuacion IS muy_mala AND exactitud IS nunca THEN funcionabilidad IS muy_mala -> Tamaño de Regla mínima con más de una una variable y un valor lingüístico.
				for (int i = 2; i < reglaTemp.Length && reglaTemp[i] != "THEN"; i++)
				{
					if ((reglaTemp[i] == "IS") && (i - 1 > 0) && (i + 1 < reglaTemp.Length))
					{
						string variable = reglaTemp[i - 1];
						string valor = reglaTemp[i + 1];

						if (VariablesLinguisticas.ContainsKey(variable))
						{
							ValorLinguistico valorLinguistico = VariablesLinguisticas[variable].ValorLinguistico(valor);
							antecedente.Add(valor, valorLinguistico);
						}
					}
				}
			}
			return antecedente;
		}

		/// <summary>
		/// Obtiene el consecuente de la regla.
		/// </summary>
		/// <param name="regla"></param>
		/// <returns></returns>
		public Tuple<string, ValorLinguistico> GetConsecuente(string regla)
		{
			string[] reglaTemp = regla.Split(' ');
			Tuple<string, ValorLinguistico> consecuente = null;

			//IF adecuacion IS muy_mala AND exactitud IS nunca THEN funcionabilidad IS muy_mala
			if (reglaTemp.Length >= 8) //revisar
			{
				string variable = reglaTemp[reglaTemp.Length - 3];
				string valor = reglaTemp[reglaTemp.Length - 1];

				if (VariablesLinguisticas.ContainsKey(variable))
				{
					ValorLinguistico valorLinguistico = VariablesLinguisticas[variable].ValorLinguistico(valor);
					consecuente = new Tuple<string, ValorLinguistico>(variable, valorLinguistico);
				}
			}
			return consecuente;
		}

		/// <summary>
		/// Obtiene el operador de la regla difusa. 
		/// El operador puede ser AND u OR.
		/// </summary>
		/// <param name="regla"></param>
		/// <returns></returns>
		public string GetOperador(string regla)
		{
			string operador = "";
			string[] reglaTemp = regla.Split(' ');

			//IF adecuacion IS muy_mala AND exactitud IS nunca THEN funcionabilidad IS muy_mala
			if (reglaTemp.Length >= 12)
			{
				if (reglaTemp[4] == "AND" || reglaTemp[4] == "OR")
				{
					operador = reglaTemp[4];
				} 
				else if (reglaTemp.Length == 8)
				{
					operador = "AND";
				}
			}
			return operador;
		}


		/// <summary>
		/// Obtiene la regla (objeto) a partir de una regla en string.
		/// </summary>
		/// <param name="regla"></param>
		/// <returns></returns>
		public ReglaDifusa GetRegla(string regla)
		{
			ReglaDifusa resultado = null;
			string operadorDifuso = GetOperador(regla);

			if (operadorDifuso != "")
			{
				Dictionary<string, ValorLinguistico> antecedente = new Dictionary<string, ValorLinguistico>(GetAntecedente(regla));

				if (antecedente.Count > 0)
				{
					Tuple<string, ValorLinguistico> consecuente = GetConsecuente(regla);

					if (consecuente != null)
						resultado = new ReglaDifusa(antecedente, consecuente, operadorDifuso);
				}
			}
			return resultado;
		}


		/// <summary>
		/// Evalúa una regla, devolviendo el valor lingüistico cortado del consecuente de la regla.
		/// </summary>
		/// <param name="regla"></param>
		/// <returns></returns>
		public ValorLinguistico EvaluacionRegla(ReglaDifusa regla)
		{
			List<double> valoresLinguisticos = new List<double>();
			double resultadoOperador = -1;

			foreach (KeyValuePair<string, ValorLinguistico> actual in regla.Antecedente)
			{
				//COMENTAR ESTA LINEA
				Console.Write(" Valor(" + actual.Key + "): " + actual.Value.ValorMembresia);
				valoresLinguisticos.Add(actual.Value.ValorMembresia);
			}

			if (regla.OperadorDifuso == "AND")
			{
				//COMENTAR ESTA LINEA
				Console.Write(" Min");
				resultadoOperador = valoresLinguisticos.Min();
			} else if (regla.OperadorDifuso == "OR")
			{
				//COMENTAR ESTA LINEA
				Console.Write(" Max");
				resultadoOperador = valoresLinguisticos.Max();
			}
			//COMENTAR ESTA LINEA
			Console.WriteLine(" Resultado Operador: " + resultadoOperador);
			return ImplicacionDifusa.EjecutarImplicacion(resultadoOperador, regla.Consecuente.Item2);
		}


		/// <summary>
		/// Evalúa todas las reglas de la base de reglas.
		/// Retorna los consecuentes agrupados por los diferentes valores lingüísticos.
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, List<ValorLinguistico>> EvaluacionTodasReglas()
		{
			Dictionary<string, List<ValorLinguistico>> consecuentes = new Dictionary<string, List<ValorLinguistico>>();

			foreach (KeyValuePair<string, string> r in BaseReglas)
			{
				ReglaDifusa regla = GetRegla(r.Value);

				if (regla != null)
				{
					//COMENTAR ESTA LINEA
					Console.WriteLine("Consecuente regla: " + regla.Consecuente.Item1);
					string valorLinguistico = regla.Consecuente.Item2.Nombre;

					// Se agrega el valor lingüístico del consecuente si no ha sido agregado al diccionario.
					if (consecuentes.ContainsKey(valorLinguistico))
					{
						consecuentes.Add(valorLinguistico, new List<ValorLinguistico>());
					}
					// Se evalúa la regla y agregamos el valor lingüístico resultante.
					//COMENTAR ESTA LINEA
					Console.Write("Regla: " + r.Key);
					ValorLinguistico evaluacion = EvaluacionRegla(regla);
					consecuentes[valorLinguistico].Add(evaluacion);
				}
			}
			return consecuentes;
		}
		
		

		/// <summary>
		/// Fuzzifica las variables lingüísticas
		/// </summary>
		/// <param name="datos"></param>
		public void Fuzzificacion(Dictionary<string, double> datos)
		{
			foreach (KeyValuePair<string, double> x in datos)
			{
				Console.WriteLine("Dato " + x.Key + ": " + x.Value);
				if (VariablesLinguisticas.ContainsKey(x.Key))
					VariablesLinguisticas[x.Key].Fuzzificar(x.Value);
			}
		}

		/// <summary>
		/// Fuzzifica las variables aplicando la importancia definida para cada una de ellas.
		/// </summary>
		/// <param name="datos"></param>
		public void Fuzzificacion(Dictionary<string, Tuple<double, double>> datos)
		{
			double totalImportancia = 0;

			// Obtenemos el total de las importancias.
			foreach (KeyValuePair<string, Tuple<double, double>> x in datos)
			{
				totalImportancia += x.Value.Item2;
			}
			// Fuzzifica y normaliza el valor de membresía resultante.
			foreach (KeyValuePair<string, Tuple<double, double>> x in datos)
			{
				if (VariablesLinguisticas.ContainsKey(x.Key))
				{
					double importancia = x.Value.Item2;
					VariablesLinguisticas[x.Key].Fuzzificar(x.Value.Item1);

					// Normalización
					foreach (KeyValuePair<string, ValorLinguistico> val in VariablesLinguisticas[x.Key].ValoresLinguisticos)
					{
						double normalizacion = val.Value.ValorMembresia * (importancia / totalImportancia);
						val.Value.ValorMembresia = normalizacion;
					}
				}
			}
		}

		/// <summary>
		/// Ejecuta la inferencia difusa, retornando un valor defuzzificado.
		/// </summary>
		/// <param name="datos"></param>
		/// <returns></returns>
		public double EjecutarInferencia(Dictionary<string, double> datos)
		{
			double defuzzificacion = 0;

			Fuzzificacion(datos);

			Dictionary<string, List<ValorLinguistico>> consecuentes = EvaluacionTodasReglas();
			List<ValorLinguistico> conjuntoDifuso = AgregacionReglas.EjecutarAgregacion(consecuentes);

			defuzzificacion = DefuzzificacionCentroide.EjecutarCentroide(conjuntoDifuso);

			return defuzzificacion;
		}

		/// <summary>
		/// Ejecuta la inferencia difusa, con valores de imortancia para los datos a fuzzificar.
		/// Retorna un valor defuzzificado
		/// </summary>
		/// <param name="datos"></param>
		/// <returns></returns>
		public double EjecutarInferencia(Dictionary<string, Tuple<double, double>> datos)
		{
			double defuzzificacion = 0;

			Fuzzificacion(datos);

			Dictionary<string, List<ValorLinguistico>> consecuentes = EvaluacionTodasReglas();

			List<ValorLinguistico> conjuntoDifuso = AgregacionReglas.EjecutarAgregacion(consecuentes);

			return defuzzificacion;
		}

		// Accesores 
		public Dictionary<string, VariableLinguistica> VariablesLinguisticas
		{
			get { return _variablesLinguisticas; }
			set { _variablesLinguisticas = value; }
		}

		public Dictionary<string, string> BaseReglas
		{
			get { return _baseReglas; }
			set { _baseReglas = value; }
		}
	}
}
