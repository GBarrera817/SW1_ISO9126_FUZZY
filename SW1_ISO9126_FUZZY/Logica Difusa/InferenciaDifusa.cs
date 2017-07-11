namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para la Inferencia de la lógica difusa.
	/// </summary>
	class InferenciaDifusa
	{
		/// <summary>
		/// Realiza la inferencia, recibe el valor resultante de aplicar el operador
		/// a la regla evaluada.
		/// </summary>
		/// <param name="resultadoOperadorDifuso"></param>
		/// <param name="valorLinguistico"></param>
		/// <returns></returns>
		public static ValorLinguistico EjecutarInferencia( double resultadoOperadorDifuso,  ValorLinguistico valorLinguistico)
		{
			ValorLinguistico resultado = new ValorLinguistico(valorLinguistico.Nombre, valorLinguistico.FuncionMembresia);

			// Obtenemos el grado de pertenencia y cortamos la funcion de pertenencia en ese grado.
			valorLinguistico.FuncionMembresia.CorteFuncion(resultadoOperadorDifuso);
			resultado.ValorMembresia = resultado.FuncionMembresia.AlfaCorte;

			return resultado;
		}

	}
}
