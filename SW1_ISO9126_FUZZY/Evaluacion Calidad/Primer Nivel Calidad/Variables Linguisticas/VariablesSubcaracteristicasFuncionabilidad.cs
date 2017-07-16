using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Evaluacion_Difusa.Valores_Linguisticos;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Variables_Linguisticas
{
	/// <summary>
	/// Contiene las variables lingüísticas asociadas a Funcionabilidad para realizar la inferencia.
	/// </summary>
	public class VariablesFuncionabilidad
	{
		private VariableLinguistica _adecuacion;
		private VariableLinguistica _exactitud;
		private VariableLinguistica _interoperabilidad;
		private VariableLinguistica _seguridadAcceso;
		private VariableLinguistica _cumplimientoFuncionabilidad;
		private VariableLinguistica _funcionabilidad;

		public VariablesFuncionabilidad()
		{
			ValoresFuncionabilidad valoresFuncionabilidad = new ValoresFuncionabilidad();

			_adecuacion = new VariableLinguistica("adecuacion", 0.0, 1.0);
			_adecuacion.AgregarValorLinguistico(valoresFuncionabilidad.A_Muy_Mala);
			_adecuacion.AgregarValorLinguistico(valoresFuncionabilidad.A_Mala);
			_adecuacion.AgregarValorLinguistico(valoresFuncionabilidad.A_Promedio);
			_adecuacion.AgregarValorLinguistico(valoresFuncionabilidad.A_Buena);
			_adecuacion.AgregarValorLinguistico(valoresFuncionabilidad.A_Excelente);

			_exactitud = new VariableLinguistica("exactitud", 0.0, 1.0);
			_exactitud.AgregarValorLinguistico(valoresFuncionabilidad.E_Nunca);
			_exactitud.AgregarValorLinguistico(valoresFuncionabilidad.E_Pocas_Veces);
			_exactitud.AgregarValorLinguistico(valoresFuncionabilidad.E_Algunas_Veces);
			_exactitud.AgregarValorLinguistico(valoresFuncionabilidad.E_Casi_Siempre);
			_exactitud.AgregarValorLinguistico(valoresFuncionabilidad.E_Siempre);

			_interoperabilidad = new VariableLinguistica("interoperabilidad", 0.0, 1.0);
			_interoperabilidad.AgregarValorLinguistico(valoresFuncionabilidad.I_Muy_Mala);
			_interoperabilidad.AgregarValorLinguistico(valoresFuncionabilidad.I_Mala);
			_interoperabilidad.AgregarValorLinguistico(valoresFuncionabilidad.I_Promedio);
			_interoperabilidad.AgregarValorLinguistico(valoresFuncionabilidad.I_Buena);
			_interoperabilidad.AgregarValorLinguistico(valoresFuncionabilidad.I_Excelente);

			_seguridadAcceso = new VariableLinguistica("seguridad", 0.0, 1.0);
			_seguridadAcceso.AgregarValorLinguistico(valoresFuncionabilidad.S_Mala);
			_seguridadAcceso.AgregarValorLinguistico(valoresFuncionabilidad.S_Mala);
			_seguridadAcceso.AgregarValorLinguistico(valoresFuncionabilidad.S_Promedio);
			_seguridadAcceso.AgregarValorLinguistico(valoresFuncionabilidad.S_Buena);
			_seguridadAcceso.AgregarValorLinguistico(valoresFuncionabilidad.S_Excelente);

			_cumplimientoFuncionabilidad = new VariableLinguistica("cumplimiento_funcional", 0.0, 1.0);
			_cumplimientoFuncionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.CF_No);
			_cumplimientoFuncionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.CF_Poco);
			_cumplimientoFuncionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.CF_Medianamente);
			_cumplimientoFuncionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.CF_Casi_Todo);
			_cumplimientoFuncionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.CF_Completamente);

			_funcionabilidad = new VariableLinguistica("funcionabilidad", 0.0, 1.0);
			_funcionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.F_Muy_Mala);
			_funcionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.F_Mala);
			_funcionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.F_Promedio);
			_funcionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.F_Buena);
			_funcionabilidad.AgregarValorLinguistico(valoresFuncionabilidad.F_Excelente);
		}


		public VariableLinguistica Adecuacion { get => _adecuacion; }
		public VariableLinguistica Exactitud { get => _exactitud; }
		public VariableLinguistica Interoperabilidad { get => _interoperabilidad; }
		public VariableLinguistica SeguridadAcceso { get => _seguridadAcceso; }
		public VariableLinguistica CumplimientoFuncionabilidad { get => _cumplimientoFuncionabilidad; }
		public VariableLinguistica Funcionabilidad { get => _funcionabilidad; }
	}
}
