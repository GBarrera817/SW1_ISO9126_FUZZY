using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Calculos
{
	public class Formula
	{
		public double GetResultadoFormula(string formula, double param1, double param2)
		{
			double resultado = 0.0;

			if (formula.Equals("A/B"))
			{
				if(param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("A/T"))
			{
				if(param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("A/UOT"))
			{
				if(param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("T/N"))
			{
				if(param1 == 0 || param2 == 0)
				{
					return 0;
				}
				resultado = param1/param2;
				return Math.Round(resultado, 2);
			}

			if(formula.Equals("1 - A/B"))
			{
				if(param2 == 0)
				{
					return 0;
				}
				resultado = 1 - (param1 / param2);
				return Math.Round(resultado, 2);
			}

			if(formula.Equals("1 - A/N"))
			{
				if(param2 == 0)
				{
					return 0;
				}
				resultado = 1 - (param1 / param2);
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("Tc-Ts"))
			{
				resultado = param1 - param2;
				return Math.Round(resultado, 2);
			}

			if (formula.Equals("Sum(T)/N"))
			{
				if(param2 == 0)
				{
					return 0;
				}
				resultado = param1 / param2;
				return Math.Round(resultado, 2);
			}

			

			return resultado;
		}


		public double GetResultadoFormula(string formula, double param1, double param2, double param3) 
		{
			double resultado = 0.0;

			if(formula.Equals("(Sum(Trc)-Sum(Tsn))/N") || formula.Equals("(Sum(Tout)-Sum(Tin))/N"))
			{
				if(param3 == 0)
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
