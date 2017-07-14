using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Reglas_Produccion
{
	public class ReglasMantenibilidad
	{
		private Dictionary<string, string> _analizabilidad;
		private Dictionary<string, string> _modificabilidad;
		private Dictionary<string, string> _coexistencia;
		private Dictionary<string, string> _reemplazabilidad;
		private Dictionary<string, string> _cumplimientoMantenibilidad;
		private Dictionary<string, string> _mantenibilidad;

		public Dictionary<string, string> ReglasMantenibilidad()
		{
			Dictionary<string, string> reglasMantenibilidad = new Dictionary<string, string>();

			return reglasMantenibilidad;
		}


		//Accesores
		public Dictionary<string, string> Analizabilidad { get => _analizabilidad; }
		public Dictionary<string, string> Modificabilidad { get => _modificabilidad; }
		public Dictionary<string, string> Coexistencia { get => _coexistencia; }
		public Dictionary<string, string> Reemplazabilidad { get => _reemplazabilidad; }
		public Dictionary<string, string> CumplimientoMantenibilidad { get => _cumplimientoMantenibilidad; }
		public Dictionary<string, string> Mantenibilidad { get => _mantenibilidad; }
	}
}
