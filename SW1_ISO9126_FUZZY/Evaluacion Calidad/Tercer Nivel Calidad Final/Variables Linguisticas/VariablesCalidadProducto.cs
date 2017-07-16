using SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final.Valores_Linguisticos;
using SW1_ISO9126_FUZZY.Logica_Difusa;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final.Variables_Linguisticas
{
	public class VariablesCalidadProducto
	{
		private VariableLinguistica _calidadInterna;
		private VariableLinguistica _calidadExterna;
		private VariableLinguistica _calidadFinal;

		public VariablesCalidadProducto()
		{
			ValoresCalidadProducto valoresCalidad = new ValoresCalidadProducto();

			//Calidad Interna
			_calidadInterna = new VariableLinguistica("calidad_interna", 0.0, 1.0);
			_calidadInterna.AgregarValorLinguistico(valoresCalidad.Muy_Mala);
			_calidadInterna.AgregarValorLinguistico(valoresCalidad.Mala);
			_calidadInterna.AgregarValorLinguistico(valoresCalidad.Promedio);
			_calidadInterna.AgregarValorLinguistico(valoresCalidad.Buena);
			_calidadInterna.AgregarValorLinguistico(valoresCalidad.Excelente);

			//Calidad Externa
			_calidadExterna = new VariableLinguistica("calidad_externa", 0.0, 1.0);
			_calidadExterna.AgregarValorLinguistico(valoresCalidad.No_Tiene);
			_calidadExterna.AgregarValorLinguistico(valoresCalidad.Baja);
			_calidadExterna.AgregarValorLinguistico(valoresCalidad.Regular);
			_calidadExterna.AgregarValorLinguistico(valoresCalidad.Alta);
			_calidadExterna.AgregarValorLinguistico(valoresCalidad.Muy_Alta);

			//Calidad Final
			_calidadFinal = new VariableLinguistica("calidad_final", 0.0, 1.0);
			_calidadFinal.AgregarValorLinguistico(valoresCalidad.CF_Muy_Mala);
			_calidadFinal.AgregarValorLinguistico(valoresCalidad.CF_Mala);
			_calidadFinal.AgregarValorLinguistico(valoresCalidad.CF_Promedio);
			_calidadFinal.AgregarValorLinguistico(valoresCalidad.CF_Buena);
			_calidadFinal.AgregarValorLinguistico(valoresCalidad.CF_Excelente);
		}

		public VariableLinguistica CalidadInterna { get => _calidadInterna; }
		public VariableLinguistica CalidadExterna { get => _calidadExterna; }
		public VariableLinguistica CalidadFinal { get => _calidadFinal; }
	}
}
