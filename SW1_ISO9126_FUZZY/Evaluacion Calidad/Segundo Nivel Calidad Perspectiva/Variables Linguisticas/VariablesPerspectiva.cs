using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Evaluacion_Calidad.Segundo_Nivel_Calidad_Perspectiva.Valores_Linguisticos;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Segundo_Nivel_Calidad_Perspectiva.Variables_Linguisticas
{
	public class VariablesPerspectiva
	{
		private VariableLinguistica _funcionabilidad;
		private VariableLinguistica _usabilidad;
		private VariableLinguistica _mantenibilidad;

		private VariableLinguistica _perspectiva;

		public VariablesPerspectiva()
		{
			ValoresPerspectiva valoresPerspectiva = new ValoresPerspectiva();

			//Funcionabilidad
			_funcionabilidad = new VariableLinguistica("funcionabilidad", 0.0, 1.0);
			_funcionabilidad.AgregarValorLinguistico(valoresPerspectiva.Muy_Mala);
			_funcionabilidad.AgregarValorLinguistico(valoresPerspectiva.Mala);
			_funcionabilidad.AgregarValorLinguistico(valoresPerspectiva.Promedio);
			_funcionabilidad.AgregarValorLinguistico(valoresPerspectiva.Buena);
			_funcionabilidad.AgregarValorLinguistico(valoresPerspectiva.Excelente);

			//Usabilidad
			_usabilidad = new VariableLinguistica("usabilidad", 0.0, 1.0);
			_usabilidad.AgregarValorLinguistico(valoresPerspectiva.Muy_Dificil);
			_usabilidad.AgregarValorLinguistico(valoresPerspectiva.Dificil);
			_usabilidad.AgregarValorLinguistico(valoresPerspectiva.Normal);
			_usabilidad.AgregarValorLinguistico(valoresPerspectiva.Facil);
			_usabilidad.AgregarValorLinguistico(valoresPerspectiva.Muy_Facil);

			//Mantenibilidad
			_mantenibilidad = new VariableLinguistica("mantenibilidad", 0.0, 1.0);
			_mantenibilidad.AgregarValorLinguistico(valoresPerspectiva.Muy_Baja);
			_mantenibilidad.AgregarValorLinguistico(valoresPerspectiva.Baja);
			_mantenibilidad.AgregarValorLinguistico(valoresPerspectiva.Mediana);
			_mantenibilidad.AgregarValorLinguistico(valoresPerspectiva.Casi_Todo);
			_mantenibilidad.AgregarValorLinguistico(valoresPerspectiva.Completamente);

			//Perspectiva
			_perspectiva = new VariableLinguistica("perspectiva", 0.0, 1.0);
			_perspectiva.AgregarValorLinguistico(valoresPerspectiva.P_Muy_Mala);
			_perspectiva.AgregarValorLinguistico(valoresPerspectiva.P_Mala);
			_perspectiva.AgregarValorLinguistico(valoresPerspectiva.P_Promedio);
			_perspectiva.AgregarValorLinguistico(valoresPerspectiva.P_Buena);
			_perspectiva.AgregarValorLinguistico(valoresPerspectiva.P_Excelente);
		}

		public VariableLinguistica Funcionabilidad { get => _funcionabilidad; }
		public VariableLinguistica Usabilidad { get => _usabilidad; }
		public VariableLinguistica Mantenibilidad { get => _mantenibilidad; }
		public VariableLinguistica Perspectiva { get => _perspectiva; }
	}
}
