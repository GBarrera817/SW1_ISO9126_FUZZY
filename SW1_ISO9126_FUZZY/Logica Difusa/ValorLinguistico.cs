using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para crear los valores linguisticos del controlador difuso
	/// </summary>
	class ValorLinguistico
	{
		private string _nombre;
		private FuncionMembresia _funcionMembresia;
		private double _valorMembresia;
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="funcionMembresia"></param>
		public ValorLinguistico(string nombre, FuncionMembresia funcionMembresia)
		{
			Nombre = nombre;
			FuncionMembresia = funcionMembresia;
			ValorMembresia = -1;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="funcionMembresia"></param>
		/// <param name="valorPertenencia"></param>
		public ValorLinguistico(string nombre, FuncionMembresia funcionMembresia, double valorMembresia)
		{
			Nombre = nombre;
			FuncionMembresia = funcionMembresia;
			ValorMembresia = valorMembresia; //valor de membresia por defecto
		}
		
		/// <summary>
		/// Calcula el valor de membresia del valor lingüístico
		/// </summary>
		/// <param name="valor"></param>
		public void ObtenerValorMembresia(double valor)
		{
			ValorMembresia = FuncionMembresia.ValorMembresia(valor);
		}

		//Accesores
		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		public FuncionMembresia FuncionMembresia
		{
			get { return _funcionMembresia; }
			set { _funcionMembresia = value; }
		}

		public double ValorMembresia
		{
			get { return _valorMembresia; }
			set { _valorMembresia = value; }
		}

	}
}
