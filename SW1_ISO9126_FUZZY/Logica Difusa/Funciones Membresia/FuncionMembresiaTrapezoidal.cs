using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	public class FuncionMembresiaTrapezoidal : FuncionMembresia
	{

		double _a, _b, _c, _d, _valorCorte;
		private bool corte;

		/// <summary>
		/// Constructor vacío
		/// </summary>
		public FuncionMembresiaTrapezoidal()
		{ }

		/// <summary>
		/// Constructor, recibe los cuatro valores "límites" de la función.
		/// </summary>
		/// <param name="a">Valor izqAbajo</param>
		/// <param name="b">Valor izqArriba</param>
		/// <param name="c">Valor derArriba</param>
		/// <param name="d">Valor derAbajo</param>
		public FuncionMembresiaTrapezoidal(double a, double b, double c, double d)
		{
			if (!(A <= B && B <= C && C <= D))
				throw new ArgumentException();

			_a = a;
			_b = b;
			_c = c;
			_d = d;
			Corte = false;
			ValorCorte = 0;	
		}

		
		/// <summary>
		/// Devuelve el valor fuzzificado.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public override double ValorMembresia(double x)
		{
			double valor_fuzzificado = 0;

			if( x== _a && x == _b)
			{
				valor_fuzzificado = 1.0;
			}
			else if( x == _c && x == _c)
			{
				valor_fuzzificado = 1.0;
			} 
			else if( (x <= _a) || (x >= _d) )
			{
				valor_fuzzificado = 0;
			} 
			else if( (x >= _b) && (x <= _c) )
			{
				valor_fuzzificado = 1.0;
			} 
			else if( (x > _a) && (x < _b))
			{
				valor_fuzzificado = (x / (_b - _a)) - (_a / (_b - _a))  ;
			} 
			else
			{
				valor_fuzzificado = (-x / (_d - _c)) + ( _d / (_d - _c)) ;
			}

			// Si la función fue cortada, el valor de membresía no puede sobrepasar al valor de corte.
			if (valor_fuzzificado > ValorCorte && Corte)
			{
				valor_fuzzificado = ValorCorte;
			}

			return valor_fuzzificado;
		}

		public override bool CortarFuncion(double valorMembresia)
		{
			if(valorMembresia >= 0 && valorMembresia <= 1)
			{
				ValorCorte = valorMembresia;
				Corte = true;

				return true;
			}

			return false;
		}

		public override double LimInferior()
		{
			return A;
		}

		public override double LimSuperior()
		{
			return D;
		}

		public bool Corte { get => corte; set => corte = value; }

		public override double ValorCorte { get => _valorCorte; set => _valorCorte = value; }

		public double A { get => _a; set => _a = value; }

		public double B { get => _b; set => _b = value; }

		public double C { get => _c; set => _c = value; }

		public double D { get => _d; set => _d = value; }
	}
}
