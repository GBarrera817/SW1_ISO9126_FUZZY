using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Reglas_Produccion
{
	public class ReglasMantenibilidad
	{
		
		private Dictionary<string, string> _mantenibilidad;

		public Dictionary<string, string> ReglasMant()
		{
			Dictionary<string, string> reglasMantenibilidad = new Dictionary<string, string>();

			return reglasMantenibilidad;
		}


		//Accesores
		public Dictionary<string, string> Mantenibilidad { get => _mantenibilidad; }
	}
}
