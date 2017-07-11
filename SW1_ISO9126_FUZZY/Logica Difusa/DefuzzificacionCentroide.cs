using Integracion;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para calcular el método de defuzzificación del Centroide.
	/// </summary>
	class DefuzzificacionCentroide
	{
		public static double EjecutarCentroide(List<ValorLinguistico> agregacion)
		{
			double resultado = 0;
			double numerador = 0;
			double denominador = 0;

			/*Las integrales de la formula del centroide se realizan para cada valor linguistico
			   que conforman el resultado de la agregación. */

			foreach (ValorLinguistico valor in agregacion)
			{
				//Console.WriteLine("Valor linguistico: " + valor.Nombre + " Valor corte: " + valor.Fp.ValorCorte);
				double a = valor.FuncionMembresia.LimInferior();
				double b = valor.FuncionMembresia.LimSuperior();
				double epsilon = 1e-8; // tolerancia al error.

				numerador += SimpsonIntegrator.Integrate(x => valor.FuncionMembresia.ValorMembresia(x) * x, a,
					b, epsilon);

				denominador += SimpsonIntegrator.Integrate(x => valor.FuncionMembresia.ValorMembresia(x), a,
					b, epsilon);
				//Console.WriteLine("Numerador: " + numerador + " Denominador: " + denominador);
			}
			// Se divide el resultado de las integrales para obtener el centroide.
			resultado = numerador / denominador;
			//Console.WriteLine("Defuzzificacion: " + resultado);

			return resultado;
		}
	}
}
