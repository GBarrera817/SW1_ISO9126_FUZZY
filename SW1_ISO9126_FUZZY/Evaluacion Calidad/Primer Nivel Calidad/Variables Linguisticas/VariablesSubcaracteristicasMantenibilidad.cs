﻿using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Evaluacion_Difusa.Valores_Linguisticos;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Variables_Linguisticas
{
	/// <summary>
	/// Contiene las variables lingüísticas asociadas a Mantenibilidad para realizar la inferencia.
	/// </summary>
	public class VariablesMantenibilidad
	{
		private VariableLinguistica _analizabilidad; 
		private VariableLinguistica _modificabilidad;
		private VariableLinguistica _estabilidad;
		private VariableLinguistica _testeabilidad;
		private VariableLinguistica _cumplimientoMantenibilidad;
		private VariableLinguistica _mantenibilidad;

		public VariablesMantenibilidad()
		{
			ValoresMantenibilidad valoresMantenibilidad = new ValoresMantenibilidad();

			_analizabilidad = new VariableLinguistica("analizabilidad", 0.0, 1.0);
			_analizabilidad.AgregarValorLinguistico(valoresMantenibilidad.AN_Muy_Dificil);
			_analizabilidad.AgregarValorLinguistico(valoresMantenibilidad.AN_Dificil);
			_analizabilidad.AgregarValorLinguistico(valoresMantenibilidad.AN_Normal);
			_analizabilidad.AgregarValorLinguistico(valoresMantenibilidad.AN_Facil);
			_analizabilidad.AgregarValorLinguistico(valoresMantenibilidad.AN_Muy_Facil);

			_modificabilidad = new VariableLinguistica("modificabilidad", 0.0, 1.0);
			_modificabilidad.AgregarValorLinguistico(valoresMantenibilidad.MO_Muy_Dificil);
			_modificabilidad.AgregarValorLinguistico(valoresMantenibilidad.MO_Dificil);
			_modificabilidad.AgregarValorLinguistico(valoresMantenibilidad.MO_Normal);
			_modificabilidad.AgregarValorLinguistico(valoresMantenibilidad.MO_Facil);
			_modificabilidad.AgregarValorLinguistico(valoresMantenibilidad.MO_Muy_Facil);

			_estabilidad = new VariableLinguistica("estabilidad", 0.0, 1.0);
			_estabilidad.AgregarValorLinguistico(valoresMantenibilidad.ESC_No);
			_estabilidad.AgregarValorLinguistico(valoresMantenibilidad.ESC_Poca);
			_estabilidad.AgregarValorLinguistico(valoresMantenibilidad.ESC_Medianamente);
			_estabilidad.AgregarValorLinguistico(valoresMantenibilidad.ESC_Casi_Todo);
			_estabilidad.AgregarValorLinguistico(valoresMantenibilidad.ESC_Completamente);

			_testeabilidad = new VariableLinguistica("testeabilidad", 0.0, 1.0);
			_testeabilidad.AgregarValorLinguistico(valoresMantenibilidad.TE_Muy_Dificil);
			_testeabilidad.AgregarValorLinguistico(valoresMantenibilidad.TE_Dificil);
			_testeabilidad.AgregarValorLinguistico(valoresMantenibilidad.TE_Normal);
			_testeabilidad.AgregarValorLinguistico(valoresMantenibilidad.TE_Facil);
			_testeabilidad.AgregarValorLinguistico(valoresMantenibilidad.TE_Muy_Facil);

			_cumplimientoMantenibilidad = new VariableLinguistica("cumplimiento_mantenibilidad", 0.0, 1.0);
			_cumplimientoMantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.CM_No);
			_cumplimientoMantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.CM_Poco);
			_cumplimientoMantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.CM_Medianamente);
			_cumplimientoMantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.CM_Casi_Todo);
			_cumplimientoMantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.CM_Completamente);

			_mantenibilidad = new VariableLinguistica("mantenibilidad", 0.0, 1.0);
			_mantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.M_Muy_Baja);
			_mantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.M_Baja);
			_mantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.M_Mediana);
			_mantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.M_Casi_Todo);
			_mantenibilidad.AgregarValorLinguistico(valoresMantenibilidad.M_Completamente);
		}

		//Accesores
		public VariableLinguistica Analizabilidad { get => _analizabilidad; }
		public VariableLinguistica Modificabilidad { get => _modificabilidad; }
		public VariableLinguistica Estabilidad { get => _estabilidad; }
		public VariableLinguistica Testeabilidad { get => _testeabilidad; }
		public VariableLinguistica CumplimientoMantenibilidad { get => _cumplimientoMantenibilidad; }
		public VariableLinguistica Mantenibilidad { get => _mantenibilidad; }
	}
}
