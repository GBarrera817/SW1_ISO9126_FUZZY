using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para crear los valores linguisticos del controlador difuso
	/// </summary>
	public class ValorLinguistico
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
			_nombre = nombre;
			_funcionMembresia = funcionMembresia;
			_valorMembresia = -1;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="funcionMembresia"></param>
		/// <param name="valorPertenencia"></param>
		public ValorLinguistico(string nombre, FuncionMembresia funcionMembresia, double valorMembresia)
		{
			_nombre = nombre;
			_funcionMembresia = funcionMembresia;
			_valorMembresia = valorMembresia; //valor de membresia por defecto
		}

		/// <summary>
		/// Calcula el valor de membresia del valor lingüístico
		/// </summary>
		/// <param name="valor"></param>
		public void CalcularValorMembresia(double valor)
		{
			_valorMembresia = FuncionMembresia.ValorMembresia(valor);
		}

		//Accesores
		public string Nombre { get => _nombre; set => _nombre = value; }
		public FuncionMembresia FuncionMembresia { get => _funcionMembresia; set => _funcionMembresia = value; }
		public double ValorMembresia { get => _valorMembresia; set => _valorMembresia = value; }

	}
}
