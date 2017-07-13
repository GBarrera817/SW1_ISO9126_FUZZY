namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
	public class FuncionMembresia : IFuncionMembresia
	{
		public double AlfaCorte { get { return -1; } set { } }

		public virtual bool CorteFuncion(double membershipValue)
		{
			return false;
		}

		public virtual double LimInferior()
		{
			return 0;
		}

		public virtual double LimSuperior()
		{
			return 0;
		}

		public virtual double ValorMembresia(double x)
		{
			return 0;
		}
	}
}
