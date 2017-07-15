using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	class FuncionMembresiaTrapezoidal : FuncionMembresia
	{

		double _a, _b, _c, _d, _alfaCorte;
		private bool corte;

		public FuncionMembresiaTrapezoidal() { }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="a">Valor izqAbajo</param>
		/// <param name="b">Valor izqArriba</param>
		/// <param name="c">Valor derArriba</param>
		/// <param name="d">Valor derAbajo</param>
		public FuncionMembresiaTrapezoidal(double a, double b, double c, double d) {

			_a = a;
			_b = b;
			_c = c;
			_d = d;
			corte = false;
			_alfaCorte = 0;	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public override double ValorMembresia(double x)
		{
			double valor_fuzzificado = 0;

			if( x== _a && x == _b) { valor_fuzzificado = 1.0; }
			else if( x == _c && x == _d) { valor_fuzzificado = 1.0; }
			else if( (x <= _a) || (x >= _d) ) { valor_fuzzificado = 0; }
			else if( (x >= _b) && (x <= _c) ) { valor_fuzzificado = 1.0; }
			else if( (x > _a) && (x < _b)) { valor_fuzzificado = (x / (_b - _a)) - (_a / (_b - _a))  ; }
			else { valor_fuzzificado = (-valor_fuzzificado / (_d - _c )) + ( _d / (_d - _c)) ; }

			return valor_fuzzificado;
		}
	}
}
