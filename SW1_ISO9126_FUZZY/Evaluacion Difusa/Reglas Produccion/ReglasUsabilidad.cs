using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Reglas_Produccion
{
	public class ReglasUsabilidad
	{

		private Dictionary<string, string> _aprendizaje;
		private Dictionary<string, string> _comprensibilidad;
		private Dictionary<string, string> _operabilidad;
		private Dictionary<string, string> _atractividad;
		private Dictionary<string, string> _cumplimientoUsabilidad;
		private Dictionary<string, string> _usabilidad;



		public Dictionary<string, string> ReglasUsabilidad()
		{
			Dictionary<string, string> reglasUsabilidad = new Dictionary<string, string>();

			//Completar con las reglas

			return reglasUsabilidad;
		}

		public Dictionary<string, string> Aprendizaje { get => _aprendizaje; }
		public Dictionary<string, string> Comprensibilidad { get => _comprensibilidad; }
		public Dictionary<string, string> Operabilidad { get => _operabilidad; }
		public Dictionary<string, string> Atractividad { get => _atractividad; }
		public Dictionary<string, string> CumplimientoUsabilidad { get => _cumplimientoUsabilidad; }
		public Dictionary<string, string> Usabilidad { get => _usabilidad; }
	}
}
