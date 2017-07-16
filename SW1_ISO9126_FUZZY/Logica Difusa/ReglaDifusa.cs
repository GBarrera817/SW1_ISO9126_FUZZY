using System;
using System.Collections.Generic;
using System.Linq;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para generar las reglas difusas
	/// </summary>
	public class ReglaDifusa
	{
		private string _id;
		private string _operadorDifuso;
		private Dictionary<string, ValorLinguistico> _antecedente;
		private Tuple<string, ValorLinguistico> _consecuente;
		private string _texto;

		/// <summary>
		/// Inicializa una regla vacía
		/// </summary>
		public ReglaDifusa()
		{
			_id = "";
			_antecedente = new Dictionary<string, ValorLinguistico>();
			_texto = "";
			_operadorDifuso = "";
		}

		/// <summary>
		/// Inicializa una regla con su ID;
		/// </summary>
		/// <param name="id"></param>
		public ReglaDifusa(string id)
		{
			this._id = id;
			_antecedente = new Dictionary<string, ValorLinguistico>();
			_texto = "";
			_operadorDifuso = "";
		}


		/// <summary>
		/// Constructor, recibe el antecedente, el consecuente y el operador de la regla
		/// </summary>
		/// <param name="antecedente"></param>
		/// <param name="consecuente"></param>
		/// <param name="operadorDifuso"></param>
		public ReglaDifusa(Dictionary<string, ValorLinguistico> antecedente, Tuple<string, ValorLinguistico> consecuente, string operadorDifuso)
		{
			Antecedente = new Dictionary<string, ValorLinguistico>();

			foreach (KeyValuePair<string, ValorLinguistico> actual in antecedente)
				AgregarAntecedente(actual.Key, actual.Value);
			

			if( consecuente != null)		
				AgregarConsecuente(consecuente.Item1, consecuente.Item2);
		
			OperadorDifuso = operadorDifuso;
		}

		/// <summary>
		/// Constructor, recibe el id, el antecedente, el consecuente y el operador de la regla.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="antecedente"></param>
		/// <param name="consecuente"></param>
		/// <param name="operadorDifuso"></param>
		public ReglaDifusa(string id, Dictionary<string, ValorLinguistico> antecedente, Tuple<string, ValorLinguistico> consecuente, string operadorDifuso)
		{

			//REVISAR PARSEO DEL STRING
			this._id = id;
			Antecedente = new Dictionary<string, ValorLinguistico>();

			int contador = 0;
			this._texto = "IF";

			foreach (KeyValuePair<string, ValorLinguistico> actual in antecedente)
			{
				if (contador > 0)
					this._texto += " " + operadorDifuso;

				this._texto += " " + actual.Key + " IS " + actual.Value.Nombre;
				AgregarAntecedente(actual.Key, actual.Value);
				contador += 1;
			}

			this._texto += " THEN ";
			if(consecuente != null)
			{
				this._texto += consecuente.Item1 + " IS " + consecuente.Item2.Nombre;
				AgregarConsecuente(consecuente.Item1, consecuente.Item2);
			}

			OperadorDifuso = operadorDifuso;
		}


		/// <summary>
		/// Agrega una variable lingüística y valor linguistico correspondiente 
		/// al antecedente de la regla.
		/// </summary>
		/// <param name="nombreVariable"></param>
		/// <param name="valorLinguistico"></param>
		public void AgregarAntecedente(string nombreVariable, ValorLinguistico valorLinguistico)
		{ 
			//ValorLinguistico val = new ValorLinguistico(valorLinguistico.Nombre, valorLinguistico.FuncionMembresia);
			Antecedente.Add(nombreVariable, valorLinguistico);
		}

		/// <summary>
		/// Agrega o reemplaza (si existe) el consecuente de la regla.
		/// </summary>
		/// <param name="nombreVariable"></param>
		/// <param name="valorLinguistico"></param>
		public void AgregarConsecuente(string nombreVariable, ValorLinguistico valorLinguistico)
		{
			ValorLinguistico val = new ValorLinguistico(valorLinguistico.Nombre, valorLinguistico.FuncionMembresia);
			Consecuente = new Tuple<string, ValorLinguistico>(nombreVariable, val);
		}

		/// <summary>
		/// Evalúa la regla según el operador.
		/// </summary>
		/// <returns></returns>
		public double EvaluarRegla()
		{
			List<double> valoresLinguisticos = new List<double>();
			double resultado = 0;

			foreach (KeyValuePair<string, ValorLinguistico> actual in Antecedente)
				valoresLinguisticos.Add(actual.Value.ValorMembresia);

			if (_operadorDifuso == "AND")
				resultado = valoresLinguisticos.Min();
			else if (_operadorDifuso == "OR")
				resultado = valoresLinguisticos.Max();

			return resultado;
		}

		//Accesores
		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public string OperadorDifuso
		{
			get { return _operadorDifuso; }
			set { _operadorDifuso = value; }
		}

		public Dictionary<string, ValorLinguistico> Antecedente
		{
			get { return _antecedente; }
			set { _antecedente = value; }
		}

		public Tuple<string, ValorLinguistico> Consecuente
		{
			get { return _consecuente; }
			set { _consecuente = value; }
		}

		public string Texto
		{
			get { return _texto; }
		}

		public override string ToString()
		{
			return this._texto;
		}

	}
}
