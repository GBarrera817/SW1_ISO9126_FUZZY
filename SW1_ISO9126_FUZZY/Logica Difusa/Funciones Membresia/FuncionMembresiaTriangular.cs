namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	/// <summary>
	/// Función de pertenencia Triangular 
	/// </summary>
	class FuncionMembresiaTriangular : FuncionMembresia
	{
		double _a, _b, _c, _alfaCorte;
		private bool corte;

		public FuncionMembresiaTriangular() { }

		/// <summary>
		/// Contructor, recibe los 3 puntos de la funcion triangular
		/// </summary>
		/// <param name="a">Valor izquierdo</param>
		/// <param name="b">Valor medio</param>
		/// <param name="c">Valor derecho</param>
		public FuncionMembresiaTriangular(double a, double b, double c)
		{
			_a = a;
			_b = b;
			_c = c;
			corte = false;
			_alfaCorte = -1;
		}

		public override double ValorMembresia(double x)
		{
			double valor_fuzzificado = 0;

			if( x == _a && x == _b) { valor_fuzzificado = 1.0; }
			else if( x == _b && x == _c) { valor_fuzzificado = 1.0; }
			else if( (x <= _a) || (x >= _c)) { valor_fuzzificado = 0; }
			else if( x == _b) { valor_fuzzificado = 1; }
			else if( (x > _a) && (x < _b) ) { valor_fuzzificado = (x / (_b - _a)) - (_a / (_b - _a)); }
			else{ valor_fuzzificado = (-valor_fuzzificado / (_c - _b)) + (_c / (_c - _b)); }
			
			return valor_fuzzificado;
		}
		
	}
}
