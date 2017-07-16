using Integracion;
using System;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
	/// <summary>
	/// Clase para calcular el método de defuzzificación del Centroide.
	/// </summary>
	public class DefuzzificacionCentroide
	{
		/// <summary>
		/// Realiza el método del Centroide, devolviendo el valor defuzzificado.
		/// Recibe un conjunto difuso resultante de la agregación
		/// </summary>
		/// <param name="agregacion"></param>
		/// <returns></returns>
		public static double EjecutarCentroide(List<ValorLinguistico> agregacion)
		{
			double resultado = 0;
			double numerador = 0;
			double denominador = 0;

			/*Las integrales de la fórmula del centroide se realizan para cada valor lingüístico
			   que conforman el resultado de la agregación. */

			foreach (ValorLinguistico valor in agregacion)
			{
				Console.WriteLine("Valor lingüístico: " + valor.Nombre + " Valor corte: " + valor.FuncionMembresia.ValorCorte);
				double a = valor.FuncionMembresia.LimInferior();
				double b = valor.FuncionMembresia.LimSuperior();
				double epsilon = 1e-8; // tolerancia al error.

				numerador += SimpsonIntegrator.Integrate(x => valor.FuncionMembresia.ValorMembresia(x) * x, a, b, epsilon);
				denominador += SimpsonIntegrator.Integrate(x => valor.FuncionMembresia.ValorMembresia(x), a, b, epsilon);

				Console.WriteLine("Numerador: " + numerador + " Denominador: " + denominador);
			}
			// Se divide el resultado de las integrales para obtener el centroide.
			resultado = numerador / denominador;
			Console.WriteLine("Defuzzificacion: " + resultado);

			return resultado;
		}
	}
}
