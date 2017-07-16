namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para la implicación de la lógica difusa.
	/// </summary>
	public static class ImplicacionDifusa
	{
		/// <summary>
		/// Realiza la implicación, recibe el valor resultante de aplicar el operador
		/// a la regla evaluada.
		/// </summary>
		/// <param name="resultadoOperadorDifuso"></param>
		/// <param name="valorLinguistico"></param>
		/// <returns></returns>
		public static ValorLinguistico EjecutarImplicacion( double resultadoOperadorDifuso,  ValorLinguistico valorLinguistico)
		{
			ValorLinguistico resultado = new ValorLinguistico(valorLinguistico.Nombre, valorLinguistico.FuncionMembresia);

			// Obtenemos el grado de pertenencia y cortamos la función de pertenencia en ese grado.

			//VOLVER A COMENTAR ESTA LÍNEA
			resultado.FuncionMembresia.CortarFuncion(resultadoOperadorDifuso);


			valorLinguistico.FuncionMembresia.CortarFuncion(resultadoOperadorDifuso);
			resultado.ValorMembresia = resultado.FuncionMembresia.ValorCorte;

			return resultado;
		}

	}
}
