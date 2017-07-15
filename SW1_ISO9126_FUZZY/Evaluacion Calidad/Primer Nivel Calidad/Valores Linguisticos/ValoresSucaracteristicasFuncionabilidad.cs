using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Valores_Linguisticos
{
	public class ValoresFuncionabilidad
	{
		private ValorLinguistico A_muy_mala, A_mala, A_promedio, A_buena, A_excelente; //Adecuacion
		private ValorLinguistico E_nunca, E_pocas_veces, E_algunas_veces, E_casi_siempre, E_siempre; //Exactitud
		private ValorLinguistico I_muy_mala, I_mala, I_promedio, I_buena, I_excelente; //Interoperabilidad
		private ValorLinguistico S_muy_mala, S_mala, S_promedio, S_buena, S_excelente; //Seguridad
		private ValorLinguistico CF_no, CF_poco, CF_medianamente, CF_casi_todo, CF_completamente; //Cumplimiento Funcionabilidad

		private ValorLinguistico F_muy_mala, F_mala, F_promedio, F_buena, F_excelente; //Funcionabilidad

		// Constructor		
		public ValoresFuncionabilidad()
		{
			//Adecuación
			A_muy_mala = new ValorLinguistico("muy_mala", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			A_mala = new ValorLinguistico("mala", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			A_promedio = new ValorLinguistico("promedio", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			A_buena = new ValorLinguistico("buena", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			A_excelente = new ValorLinguistico("excelente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Exactitud
			E_nunca = new ValorLinguistico("nunca", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			E_pocas_veces = new ValorLinguistico("pocas_veces", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			E_algunas_veces = new ValorLinguistico("algunas_veces", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			E_casi_siempre = new ValorLinguistico("casi_siempre", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			E_siempre = new ValorLinguistico("siempre", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Interoperabilidad
			I_muy_mala = new ValorLinguistico("muy_mala", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			I_mala = new ValorLinguistico("mala", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			I_promedio = new ValorLinguistico("promedio", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			I_buena = new ValorLinguistico("buena", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			I_excelente = new ValorLinguistico("excelente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Seguridad de Acceso
			S_muy_mala = new ValorLinguistico("muy_mala", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			S_mala = new ValorLinguistico("mala", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			S_promedio = new ValorLinguistico("promedio", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			S_buena = new ValorLinguistico("buena", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			S_excelente = new ValorLinguistico("excelente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Cumplimiento de Funcionabilidad
			CF_no = new ValorLinguistico("no", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			CF_poco = new ValorLinguistico("poco", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			CF_medianamente = new ValorLinguistico("medianamente", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			CF_casi_todo = new ValorLinguistico("casi_todo", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			CF_completamente = new ValorLinguistico("completamente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Funcionabilidad
			F_muy_mala = new ValorLinguistico("muy_mala", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			F_mala = new ValorLinguistico("mala", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			F_promedio = new ValorLinguistico("promedio", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			F_buena = new ValorLinguistico("buena", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			F_excelente = new ValorLinguistico("excelente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));
		}


		//ADECUACION
		public ValorLinguistico A_Muy_Mala { get { return A_muy_mala; } }
		public ValorLinguistico A_Mala { get { return A_mala; } }
		public ValorLinguistico A_Promedio { get { return A_promedio; } }
		public ValorLinguistico A_Buena { get { return A_buena; } }
		public ValorLinguistico A_Excelente { get { return A_excelente; } }

		//EXACTITUD
		public ValorLinguistico E_Nunca { get { return E_nunca; } }
		public ValorLinguistico E_Pocas_Veces { get { return E_pocas_veces; } }
		public ValorLinguistico E_Algunas_Veces { get { return E_algunas_veces; } }
		public ValorLinguistico E_Casi_Siempre { get { return E_casi_siempre; } }
		public ValorLinguistico E_Siempre { get { return E_siempre; } }

		//INTEROPERABILIDAD
		public ValorLinguistico I_Muy_Mala { get { return I_muy_mala; } }
		public ValorLinguistico I_Mala { get { return I_mala; } }
		public ValorLinguistico I_Promedio { get { return I_promedio; } }	
		public ValorLinguistico I_Buena { get { return I_buena; } }
		public ValorLinguistico I_Excelente { get { return I_excelente; } }

		//SERGURIDAD DE ACCESO
		public ValorLinguistico S_Muy_Mala { get { return S_muy_mala; } }
		public ValorLinguistico S_Mala { get { return S_mala; } }
		public ValorLinguistico S_Promedio { get { return S_promedio; } }
		public ValorLinguistico S_Buena { get { return S_buena; } }
		public ValorLinguistico S_Excelente { get { return S_excelente; } }

		//CUMPLIMIENTO DE FUNCIONALIDAD
		public ValorLinguistico CF_No { get { return CF_no; } }
		public ValorLinguistico CF_Poco { get { return CF_poco; } }
		public ValorLinguistico CF_Medianamente { get { return CF_medianamente; } }
		public ValorLinguistico CF_Casi_Todo { get { return CF_casi_todo; } }
		public ValorLinguistico CF_Completamente { get { return CF_completamente; } }

		//FUNCIONABILIDAD
		public ValorLinguistico F_Muy_Mala { get { return F_muy_mala; } }
		public ValorLinguistico F_Mala { get { return F_mala; } }
		public ValorLinguistico F_Promedio { get { return F_promedio; } }
		public ValorLinguistico F_Buena { get { return F_buena; } }
		public ValorLinguistico F_Excelente { get { return F_excelente; } }
	}
}
