namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	public interface IFuncionMembresia
	{
		/// <summary>
		/// Se calcula el grado de pertenencia.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		double ValorMembresia(double x);

		/// <summary>
		/// Escala la funcion de pertenencia al grado de pertenencia pasado.
		/// </summary>
		/// <param name="valorMembresia"></param>
		/// <returns></returns>
		bool CortarFuncion(double valorMembresia);


		/// <summary>
		/// Es el valor donde comienza la función de pertenencia
		/// </summary>
		/// <returns></returns>
		double LimInferior();

		/// <summary>
		/// Es el valor donde termina la función de pertenencia
		/// </summary>
		/// <returns></returns>
		double LimSuperior();

		double ValorCorte { get; set; }

	}
}
