using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		/// Constructor por defecto para crear una Variable Lingüística
		/// </summary>
		public VariableLinguistica(string nombre, double min, double max)
		{
			NombreVariable = nombre;
			ValorMaximo = max;
			ValorMinimo = min;
			ValoresLinguisticos = new Dictionary<string, ValorLinguistico>();
		}

		/// <summary>
		/// Constructor. Forma segura de clonar una Variable Lingüística
		/// </summary>
		/// <param name="variableLinguistica"></param>
		public VariableLinguistica(VariableLinguistica variableLinguistica)
		{
			NombreVariable = variableLinguistica.NombreVariable;
			ValorMaximo = variableLinguistica.ValorMaximo;
			ValorMinimo = variableLinguistica.ValorMinimo;
			ValoresLinguisticos = new Dictionary<string, ValorLinguistico>();

			foreach (KeyValuePair<string, ValorLinguistico> valor in variableLinguistica.ValoresLinguisticos)
			{
				AgregarValorLinguistico(valor.Value);
			}
		}

		/// <summary>
		/// Agrega un valor linguistico a la variable lingüística.
		/// </summary>
		/// <param name="valorLinguistico"></param>
		/// <returns></returns>
		public bool AgregarValorLinguistico(ValorLinguistico valorLinguistico)
		{
			ValorLinguistico vl = new ValorLinguistico(valorLinguistico.Nombre, valorLinguistico.FuncionMembresia, valorLinguistico.ValorMembresia);
			_valoresLinguisticos.Add(vl.Nombre, vl);

			return true;
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
		/// Fuzzifica la variable, obteniendo el grado de pertenencia por cada valor
		/// lingüístico
		/// </summary>
		/// <param name="valorEntrada"></param>
		/// <returns></returns>
		public bool Fuzzificar(double valorEntrada)
		{
			if(valorEntrada >= ValorMinimo && valorEntrada <= ValorMaximo)
			{
				foreach (KeyValuePair<string, ValorLinguistico> valor  in ValoresLinguisticos)
				{
					valor.Value.ObtenerValorMembresia(valorEntrada);
				}
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
			if (ValoresLinguisticos.Equals(nombreValorLinguistico))
			{
				ValoresLinguisticos.Remove(nombreValorLinguistico);
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
			if (ValoresLinguisticos.ContainsKey(nombreValorLinguistico))
				return ValoresLinguisticos[nombreValorLinguistico];

			return null;
		}


		//Accesores
		public string NombreVariable
		{
			get { return _nombreVariable; }
			set { _nombreVariable = value; }
		}

		public Dictionary<string, ValorLinguistico> ValoresLinguisticos
		{
			get { return _valoresLinguisticos; }
			set { _valoresLinguisticos = value; }
		}

		public double ValorMaximo
		{
			get { return _valorMaximo; }
			set { _valorMaximo = value; }
		}

		public double ValorMinimo
		{
			get { return _valorMinimo; }
			set { _valorMinimo = value; }
		}

	}
}
