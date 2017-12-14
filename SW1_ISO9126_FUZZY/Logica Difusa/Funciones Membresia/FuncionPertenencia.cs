using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia
{
    public class FuncionPertenencia : IFuncionPertenencia
    {
        public virtual bool CortarFuncion(double gradoPertenencia)
        {
            return false;
        }

        public virtual double GradoPertenencia(double x)
        {
            return 0;
        }

        public virtual double LimiteInferior()
        {
            return 0;
        }
        public virtual double LimiteSuperior()
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
