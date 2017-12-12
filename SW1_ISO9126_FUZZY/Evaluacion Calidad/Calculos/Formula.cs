using System;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Calculos
{
	public static class Formula
	{
		public static double GetResultadoFormula(string formula, double param1, double param2)
		{
			double resultado = 0.0;

			if (formula.Equals("A/B"))
			{
                Console.WriteLine("Formula -> A/B");

				if(param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("A/T"))
			{
                Console.WriteLine("Formula -> A/T");

                if (param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("A/UOT"))
			{
                Console.WriteLine("Formula -> A/UOT");

                if (param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("T/N"))
			{
                Console.WriteLine("Formula -> T/N");

                if (param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1/param2;
				return Math.Round(resultado, 2);
			}

			if(formula.Equals("1 - A/B"))
			{
                Console.WriteLine("Formula -> 1 - A/B");

                if (param2 == 0)
				{
					return 0;
				}
				resultado = 1 - (param1 / param2);
				return Math.Round(resultado, 2);
			}

			if(formula.Equals("1 - A/N"))
			{
                Console.WriteLine("Formula -> 1 - A/N");

                if (param2 == 0)
				{
					return 0;
				}
				resultado = 1 - (param1 / param2);
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("Tc-Ts"))
			{
                Console.WriteLine("Formula -> Tc-Ts");

                resultado = param1 - param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("Sum(T)/N"))
			{
                Console.WriteLine("Formula -> Sum(T) / N");

                if (param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			return resultado;
		}


		public static double GetResultadoFormula(string formula, double param1, double param2, double param3) 
		{
			double resultado = 0.0;

			if(formula.Equals("(Sum(Trc)-Sum(Tsn))/N") || formula.Equals("(Sum(Tout)-Sum(Tin))/N"))
			{
                Console.WriteLine("Formula -> (Sum(Trc)-Sum(Tsn))/N  || -> (Sum(Tout)-Sum(Tin))/N");

                if (param3 == 0)
				{
					return 0;
				}
				resultado = (param1 - param2) / param3;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("(Sum(A)/Sum(B))/N"))
			{
				if(param2 == 0 || param3 == 0)
				{
					return 0;
				}
				resultado = (param1 / param2) / param3;
			}
			return resultado;
		}
	}
}
