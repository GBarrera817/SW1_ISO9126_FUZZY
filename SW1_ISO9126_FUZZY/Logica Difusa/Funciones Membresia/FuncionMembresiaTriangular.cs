using System;

namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	/// <summary>
	/// Función de pertenencia Triangular 
	/// </summary>
	public class FuncionMembresiaTriangular : FuncionMembresia
	{
		double _a, _b, _c, _valorCorte;
		private bool corte;



		public FuncionMembresiaTriangular()
		{ }

		/// <summary>
		/// Contructor, recibe los 3 puntos de la funcion triangular
		/// </summary>
		/// <param name="a">Valor izquierdo</param>
		/// <param name="b">Valor medio</param>
		/// <param name="c">Valor derecho</param>
		public FuncionMembresiaTriangular(double a, double b, double c)
		{
			if (!(a <= b && b <= c))
				throw new ArgumentException();

			_a = a;
			_b = b;
			_c = c;
			Corte = false;
			ValorCorte = -1;
		}

		public override double ValorMembresia(double x)
		{
			double valor_fuzzificado = 0;

			if (x == A && x == _b)
			{
				valor_fuzzificado = 1.0;
			} else if (x == _b && x == _c)
			{
				valor_fuzzificado = 1.0;
			} else if ((x <= A) || (x >= _c))
			{
				valor_fuzzificado = 0;
			} else if (x == _b)
			{
				valor_fuzzificado = 1;
			} else if ((x > A) && (x < _b))
			{
				valor_fuzzificado = (x / (_b - A)) - (A / (_b - A));
			} else
			{
				valor_fuzzificado = (-valor_fuzzificado / (_c - _b)) + (_c / (_c - _b));
			}

			// Si la funcion fue cortada, el grado de pertenencia no puede sobrepasar al valor de corte.
			if (valor_fuzzificado > ValorCorte && Corte)
			{
				valor_fuzzificado = ValorCorte;
			}

			return valor_fuzzificado;
		}

		public override bool CortarFuncion(double valorMembresia)
		{
			if (valorMembresia >= 0 && valorMembresia <= 1)
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
			return C;
		}

		public override double ValorCorte { get => _valorCorte; set => _valorCorte = value; }

		public bool Corte { get => corte; set => corte = value; }

		/// <summary>
		/// Valor más a la izquierda
		/// </summary>
		public double A { get => _a; set => _a = value; }

		/// <summary>
		/// Valor del centro
		/// </summary>
		public double B { get => _b; set => _b = value; }

		/// <summary>
		/// Valor más a la derecha
		/// </summary>
		public double C { get => _c; set => _c = value; }
	}
}
