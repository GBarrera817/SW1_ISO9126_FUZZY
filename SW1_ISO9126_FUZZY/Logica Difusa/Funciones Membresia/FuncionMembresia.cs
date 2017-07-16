namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	public class FuncionMembresia : IFuncionMembresia
	{
		public virtual bool CortarFuncion(double valorMembresia)
		{
			return false;
		}

		public virtual double ValorMembresia(double x)
		{
			return 0;
		}

		public virtual double LimInferior()
		{
			return 0;
		}

		public virtual double LimSuperior()
		{
			return 0;
		}

		public virtual double ValorCorte
		{ 
			get { return -1; }
			set { }
		}
	}
}
