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
		/// Realiza la agregacion de las reglas, recibe los consecuentes agrupados por 
		/// los diferentes valores linguisticos.
		/// </summary>
		public static List<ValorLinguistico> EjecutarAgregacion(Dictionary<string, List<ValorLinguistico>> consecuentes)
		{
			List<ValorLinguistico> resultado = new List<ValorLinguistico>();

			foreach (KeyValuePair<string, List<ValorLinguistico>> consecuente in consecuentes)
			{
				List<double> valoresMembresia = new List<double>();
				ValorLinguistico valorLinguistico = null;

				foreach (ValorLinguistico valor in consecuente.Value)
				{
					// Se obtiene el valor linguistico en la primera iteracion.
					if (valorLinguistico == null)
						valorLinguistico = new ValorLinguistico(valor.Nombre, valor.FuncionMembresia);
					//Console.WriteLine("Grado pertenencia : " + valor.GradoPertenencia);
					valoresMembresia.Add(valor.ValorMembresia);

					if(valorLinguistico != null)
					{
						valorLinguistico.ValorMembresia = valoresMembresia.Max();
						valorLinguistico.FuncionMembresia.ValorCorte = valorLinguistico.ValorMembresia;
						//Console.WriteLine("Max : " + valorLinguistico.GradoPertenencia);
						resultado.Add(valorLinguistico);
					}
				}
			}
			return resultado;
		}
	}
}
