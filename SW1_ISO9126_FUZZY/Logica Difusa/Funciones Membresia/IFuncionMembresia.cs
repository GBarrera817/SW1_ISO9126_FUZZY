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
		/// Entrega el valor Y asociado al valor de pertenencia X.
		/// </summary>
		/// <param name="membershipValue"></param>
		/// <returns></returns>
		bool CorteFuncion(double membershipValue);


		/// <summary>
		/// Es el valor donde comienza la funcion de pertenencia
		/// </summary>
		/// <returns></returns>
		double LimInferior();

		/// <summary>
		/// Es el valor donde termina la funcion de pertenencia
		/// </summary>
		/// <returns></returns>
		double LimSuperior();

		double AlfaCorte { get; set; }

	}
}
