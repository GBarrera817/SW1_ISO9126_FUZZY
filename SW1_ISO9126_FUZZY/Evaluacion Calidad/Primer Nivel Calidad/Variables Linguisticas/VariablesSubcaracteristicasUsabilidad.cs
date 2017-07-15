using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Evaluacion_Difusa.Valores_Linguisticos;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Variables_Linguisticas
{
	/// <summary>
	/// Contiene las variables lingüísticas asociadas a Usabilidad para realizar la inferencia.
	/// </summary>
	public class VariablesUsabilidad
	{
		private VariableLinguistica _aprendizaje;
		private VariableLinguistica _comprensibilidad;
		private VariableLinguistica _operabilidad;
		private VariableLinguistica _atractividad;
		private VariableLinguistica _cumplimientoUsabilidad;
		private VariableLinguistica _usabilidad;

		public VariablesUsabilidad()
		{
			ValoresUsabilidad valoresUsabilidad = new ValoresUsabilidad();

			_aprendizaje = new VariableLinguistica("APR", 0.0, 1.0);
			_aprendizaje.AgregarValorLinguistico(valoresUsabilidad.AP_Muy_Dificil);
			_aprendizaje.AgregarValorLinguistico(valoresUsabilidad.AP_Dificil);
			_aprendizaje.AgregarValorLinguistico(valoresUsabilidad.AP_Normal);
			_aprendizaje.AgregarValorLinguistico(valoresUsabilidad.AP_Facil);
			_aprendizaje.AgregarValorLinguistico(valoresUsabilidad.AP_Muy_Facil);

			_comprensibilidad = new VariableLinguistica("COM", 0.0, 1.0);
			_comprensibilidad.AgregarValorLinguistico(valoresUsabilidad.COM_Muy_Dificil);
			_comprensibilidad.AgregarValorLinguistico(valoresUsabilidad.COM_Dificil);
			_comprensibilidad.AgregarValorLinguistico(valoresUsabilidad.COM_Normal);
			_comprensibilidad.AgregarValorLinguistico(valoresUsabilidad.COM_Facil);
			_comprensibilidad.AgregarValorLinguistico(valoresUsabilidad.COM_Muy_Facil);

			_operabilidad = new VariableLinguistica("OPE", 0.0, 1.0);
			_operabilidad.AgregarValorLinguistico(valoresUsabilidad.OP_Muy_Dificil);
			_operabilidad.AgregarValorLinguistico(valoresUsabilidad.OP_Dificil);
			_operabilidad.AgregarValorLinguistico(valoresUsabilidad.OP_Normal);
			_operabilidad.AgregarValorLinguistico(valoresUsabilidad.OP_Facil);
			_operabilidad.AgregarValorLinguistico(valoresUsabilidad.OP_Muy_Facil);

			_atractividad = new VariableLinguistica("ATR", 0.0, 1.0);
			_atractividad.AgregarValorLinguistico(valoresUsabilidad.AT_No);
			_atractividad.AgregarValorLinguistico(valoresUsabilidad.AT_Poco);
			_atractividad.AgregarValorLinguistico(valoresUsabilidad.AT_Medianamente);
			_atractividad.AgregarValorLinguistico(valoresUsabilidad.AT_Casi_Todo);
			_atractividad.AgregarValorLinguistico(valoresUsabilidad.AT_Completamente);

			_cumplimientoUsabilidad = new VariableLinguistica("CUU", 0.0, 1.0);
			_cumplimientoUsabilidad.AgregarValorLinguistico(valoresUsabilidad.CU_No);
			_cumplimientoUsabilidad.AgregarValorLinguistico(valoresUsabilidad.CU_Poco);
			_cumplimientoUsabilidad.AgregarValorLinguistico(valoresUsabilidad.CU_Medianamente);
			_cumplimientoUsabilidad.AgregarValorLinguistico(valoresUsabilidad.CU_Casi_Todo);
			_cumplimientoUsabilidad.AgregarValorLinguistico(valoresUsabilidad.CU_Completamente);

			_usabilidad = new VariableLinguistica("USA", 0.0, 1.0);
			_usabilidad.AgregarValorLinguistico(valoresUsabilidad.U_Muy_Dificil);
			_usabilidad.AgregarValorLinguistico(valoresUsabilidad.U_Dificil);
			_usabilidad.AgregarValorLinguistico(valoresUsabilidad.U_Normal);
			_usabilidad.AgregarValorLinguistico(valoresUsabilidad.U_Facil);
			_usabilidad.AgregarValorLinguistico(valoresUsabilidad.U_Muy_Facil);
		}

		//Accesores
		public VariableLinguistica Aprendizaje { get => _aprendizaje; }
		public VariableLinguistica Comprensibilidad { get => _comprensibilidad; }
		public VariableLinguistica Operabilidad { get => _operabilidad; }
		public VariableLinguistica Atractividad { get => _atractividad; }
		public VariableLinguistica CumplimientoUsabilidad { get => _cumplimientoUsabilidad; }
		public VariableLinguistica Usabilidad { get => _usabilidad; }
	}
}
