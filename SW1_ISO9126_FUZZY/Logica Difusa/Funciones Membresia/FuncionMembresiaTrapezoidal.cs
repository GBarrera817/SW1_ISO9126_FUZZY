using System;

namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	public class FuncionMembresiaTrapezoidal : FuncionMembresia
	{

		private double _a, _b, _c, _d, _valorCorte;
		private bool _corte;

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
			if (!(a <= b && b <= c && c <= d))
				throw new ArgumentException();

			_a = a;
			_b = b;
			_c = c;
			_d = d;
			_corte = false;
			_valorCorte = 0;	
		}

		
		/// <summary>
		/// Devuelve el valor fuzzificado.
		/// </summary>
		/// <param name="x">Valor eje X</param>
		/// <returns></returns>
		public override double ValorMembresia(double x)
		{
			double valorFuzzificado = 0;

			if( x == _a && x == _b)
			{
				valorFuzzificado = 1.0;
			}
			else if( x == _c && x == _d)
			{
				valorFuzzificado = 1.0;
			} 
			else if( x <= _a || x >= _d )
			{
				valorFuzzificado = 0;
			} 
			else if( (x >= _b) && (x <= _c) )
			{
				valorFuzzificado = 1.0;
			} 
			else if( (x > _a) && (x < _b))
			{
				valorFuzzificado = (x / (_b - _a)) - (_a / (_b - _a))  ;
			} 
			else
			{
				valorFuzzificado = (-x / (_d - _c)) + ( _d / (_d - _c)) ;
			}

			// Si la función fue cortada, el valor de membresía no puede sobrepasar al valor de corte.
			if (valorFuzzificado > _valorCorte && _corte)
			{
				valorFuzzificado = _valorCorte;
			}

			return valorFuzzificado;
		}

		public override bool CortarFuncion(double valorMembresia)
		{
			if(valorMembresia >= 0 && valorMembresia <= 1)
			{
				_valorCorte = valorMembresia;
				_corte = true;

				return true;
			}

			return false;
		}

		public override double LimInferior()
		{
			return _a;
		}

		public override double LimSuperior()
		{
			return _d;
		}

		public bool Corte { get => _corte; set => _corte = value; }

		public override double ValorCorte { get => _valorCorte; set => _valorCorte = value; }


		/// <summary>
		/// Valor izquierdo abajo
		/// </summary>
		public double A { get => _a; set => _a = value; }

		/// <summary>
		/// Valor izquierdo arriba
		/// </summary>
		public double B { get => _b; set => _b = value; }

		/// <summary>
		/// Valor derecho arriba
		/// </summary>
		public double C { get => _c; set => _c = value; }

		/// <summary>
		/// Valor derecho abajo
		/// </summary>
		public double D { get => _d; set => _d = value; }
	}
}
