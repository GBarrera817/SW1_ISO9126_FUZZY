using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;
using System;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para crear las variables lingüísticas del controlador difuso
	/// </summary>
	public class VariableLinguistica
	{
		private string _nombreVariable;
		private double _valorMinimo, _valorMaximo;
		private Dictionary<string, ValorLinguistico> _valoresLinguisticos;


		/// <summary>
		/// Constructor por defecto para crear una variable lingüística
		/// Se inicializa sin valores lingüísticos
		/// </summary>
		public VariableLinguistica(string nombre, double min, double max)
		{
			_nombreVariable = nombre;
			_valorMinimo = max;
			_valorMaximo = min;
			_valoresLinguisticos = new Dictionary<string, ValorLinguistico>();
		}

		/// <summary>
		/// Constructor. Forma segura de clonar una Variable Lingüística
		/// </summary>
		/// <param name="variableLinguistica"></param>
		public VariableLinguistica(VariableLinguistica variableLinguistica)
		{
			_nombreVariable = variableLinguistica.NombreVariable;
			_valorMinimo = variableLinguistica.ValorMaximo;
			_valorMaximo = variableLinguistica.ValorMinimo;
			_valoresLinguisticos = new Dictionary<string, ValorLinguistico>();

			foreach (KeyValuePair<string, ValorLinguistico> valor in variableLinguistica.ValoresLinguisticos)
				AgregarValorLinguistico(valor.Value);
		}


		/// <summary>
		/// Agrega un valor linguistico a la variable lingüística.
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="funcionMembresia"></param>
		/// <returns></returns>
		public bool AgregarValorLinguistico(string nombre, FuncionMembresia funcionMembresia)
		{
			ValorLinguistico vl = new ValorLinguistico(nombre, funcionMembresia);
			_valoresLinguisticos.Add(vl.Nombre, vl);

			return true;
		}


		/// <summary>
		/// Agrega un valor linguistico a la variable lingüística.
		/// </summary>
		/// <param name="valorLinguistico"></param>
		/// <returns></returns>
		public bool AgregarValorLinguistico(ValorLinguistico valorLinguistico)
		{
			ValorLinguistico vl = new ValorLinguistico(valorLinguistico.Nombre, valorLinguistico.FuncionMembresia, valorLinguistico.ValorMembresia);
			//Console.WriteLine("\n" + vl.Nombre + " " + vl.FuncionMembresia + " " + vl.ValorMembresia);
			_valoresLinguisticos.Add(vl.Nombre, vl);
			return true;
		}


		/// <summary>
		/// Fuzzifica la variable, obteniendo el grado de pertenencia por cada valor lingüístico
		/// </summary>
		/// <param name="valorEntrada"></param>
		/// <returns></returns>
		public bool Fuzzificar(double valorEntrada)
		{
			if (valorEntrada >= _valorMinimo && valorEntrada <= _valorMaximo)
			{
				foreach (KeyValuePair<string, ValorLinguistico> valor in _valoresLinguisticos)
					valor.Value.CalcularValorMembresia(valorEntrada);

				return true;
			}
			return false;
		}

		/// <summary>
		/// Elimina un valor lingüístico de la variable lingüística en caso de que exista
		/// </summary>
		/// <param name="nombreValorLinguistico"></param>
		/// <returns></returns>
		public bool EliminarValorLinguistico(string nombreValorLinguistico)
		{
			//REVISAR
			if (_valoresLinguisticos.ContainsKey(nombreValorLinguistico))
			{
				_valoresLinguisticos.Remove(nombreValorLinguistico);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Retorna un valor lingüístico según el nombre
		/// </summary>
		/// <param name="nombreValorLinguistico"></param>
		/// <returns></returns>
		public ValorLinguistico ValorLinguistico(string nombreValorLinguistico)
		{
			if (_valoresLinguisticos.ContainsKey(nombreValorLinguistico))
				return _valoresLinguisticos[nombreValorLinguistico];

			return null;
		}


		//Accesores
		public string NombreVariable { get => _nombreVariable; set => _nombreVariable = value; }
		public double ValorMinimo { get => _valorMinimo; set => _valorMinimo = value; }
		public double ValorMaximo { get => _valorMaximo; set => _valorMaximo = value; }
		public Dictionary<string, ValorLinguistico> ValoresLinguisticos { get => _valoresLinguisticos; set => _valoresLinguisticos = value; }
	}
}
