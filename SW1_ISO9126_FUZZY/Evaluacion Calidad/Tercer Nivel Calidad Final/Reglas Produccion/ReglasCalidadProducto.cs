using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final.Reglas_Produccion
{
	public class ReglasCalidadProducto
	{
		private Dictionary<string, string> _calidadFinal;

		public ReglasCalidadProducto()
		{
			_calidadFinal = ReglasCF();
		}

		public Dictionary<string, string> ReglasCF()
		{
			Dictionary<string, string> reglasCF = new Dictionary<string, string>();

			reglasCF.Add("1", "IF calidad_interna IS muy_mala AND calidad_externa IS no_tiene THEN calidad_final IS muy_mala");
			reglasCF.Add("2", "IF calidad_interna IS mala AND calidad_externa IS no_tiene THEN calidad_final IS muy_mala");
			reglasCF.Add("3", "IF calidad_interna IS regular AND calidad_externa IS no_tiene THEN calidad_final IS mala");
			reglasCF.Add("4", "IF calidad_interna IS buena AND calidad_externa IS no_tiene THEN calidad_final IS mala");
			reglasCF.Add("5", "IF calidad_interna IS excelente AND calidad_externa IS no_tiene THEN calidad_final IS regular");
			reglasCF.Add("6", "IF calidad_interna IS muy_mala AND calidad_externa IS baja THEN calidad_final IS muy_mala");
			reglasCF.Add("7", "IF calidad_interna IS mala AND calidad_externa IS baja THEN calidad_final IS mala");
			reglasCF.Add("8", "IF calidad_interna IS regular AND calidad_externa IS baja THEN calidad_final IS mala");
			reglasCF.Add("9", "IF calidad_interna IS buena AND calidad_externa IS baja THEN calidad_final IS regular");
			reglasCF.Add("10", "IF calidad_interna IS excelente AND calidad_externa IS baja THEN calidad_final IS regular");
			reglasCF.Add("11", "IF calidad_interna IS muy_mala AND calidad_externa IS regular THEN calidad_final IS mala");
			reglasCF.Add("12", "IF calidad_interna IS mala AND calidad_externa IS regular THEN calidad_final IS mala");
			reglasCF.Add("13", "IF calidad_interna IS regular AND calidad_externa IS regular THEN calidad_final IS regular");
			reglasCF.Add("14", "IF calidad_interna IS buena AND calidad_externa IS regular THEN calidad_final IS regular");
			reglasCF.Add("15", "IF calidad_interna IS excelente AND calidad_externa IS regular THEN calidad_final IS buena");
			reglasCF.Add("16", "IF calidad_interna IS muy_mala AND calidad_externa IS alta THEN calidad_final IS mala");
			reglasCF.Add("17", "IF calidad_interna IS mala AND calidad_externa IS alta THEN calidad_final IS regular");
			reglasCF.Add("18", "IF calidad_interna IS regular AND calidad_externa IS alta THEN calidad_final IS regular");
			reglasCF.Add("19", "IF calidad_interna IS buena AND calidad_externa IS alta THEN calidad_final IS buena");
			reglasCF.Add("20", "IF calidad_interna IS excelente AND calidad_externa IS alta THEN calidad_final IS buena");
			reglasCF.Add("21", "IF calidad_interna IS muy_mala AND calidad_externa IS muy_alta THEN calidad_final IS regular");
			reglasCF.Add("22", "IF calidad_interna IS mala AND calidad_externa IS muy_alta THEN calidad_final IS regular");
			reglasCF.Add("23", "IF calidad_interna IS regular AND calidad_externa IS muy_alta THEN calidad_final IS buena");
			reglasCF.Add("24", "IF calidad_interna IS buena AND calidad_externa IS muy_alta THEN calidad_final IS buena");
			reglasCF.Add("25", "IF calidad_interna IS excelente AND calidad_externa IS muy_alta THEN calidad_final IS excelente");

			return reglasCF;
		}

		public Dictionary<string, string> CalidadFinal { get => _calidadFinal; }
	}
}
