using System;
using System.Collections.Generic;
using System.Linq;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase de agregacion de reglas
	/// </summary>
	class AgregacionReglas
	{
		/// <summary>
		/// /// Realiza la agregacion de las reglas, recibe los consecuentes agrupados por 
		/// los diferentes valores lingüísticos.
		/// </summary>
		/// <param name="consecuentes"></param>
		/// <returns></returns>
		public static List<ValorLinguistico> EjecutarAgregacion(Dictionary<string, List<ValorLinguistico>> consecuentes)
		{
			List<ValorLinguistico> resultado = new List<ValorLinguistico>();

			foreach (KeyValuePair<string, List<ValorLinguistico>> consecuente in consecuentes)
			{
				List<double> valoresMembresia = new List<double>();
				ValorLinguistico valorLinguistico = null;

				Console.WriteLine("Consecuente: " + consecuente.Key);

				foreach (ValorLinguistico valor in consecuente.Value)
				{
					// Se obtiene el valor lingüístico en la primera iteración.
					if (valorLinguistico == null)
						valorLinguistico = new ValorLinguistico(valor.Nombre, valor.FuncionMembresia);
					Console.WriteLine("Grado pertenencia : " + valor.ValorMembresia);
					valoresMembresia.Add(valor.ValorMembresia);
				}
				// Se obtiene el máximo y agrega el valor lingüístico al conjunto difuso resultante.
				if (valorLinguistico != null)
				{
					valorLinguistico.ValorMembresia = valoresMembresia.Max();
					valorLinguistico.FuncionMembresia.ValorCorte = valorLinguistico.ValorMembresia;
					Console.WriteLine("Max : " + valorLinguistico.ValorMembresia);
					resultado.Add(valorLinguistico);
				}
			}
			return resultado;
		}
	}
}
