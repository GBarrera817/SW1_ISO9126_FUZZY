using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Valores_Linguisticos
{
	public class ValoresMantenibilidad
	{
		private ValorLinguistico AN_muy_dificil, AN_dificil, AN_normal, AN_facil, AN_muy_facil; //Analizabilidad
		private ValorLinguistico MO_muy_dificil, MO_dificil, MO_normal, MO_facil, MO_muy_facil; //Modificabilidad
		private ValorLinguistico ESC_no, ESC_poca, ESC_medianamente, ESC_casi_todo, ESC_completamente; //Escalabilidad	 													
		private ValorLinguistico TE_muy_dificil, TE_dificil, TE_normal, TE_facil, TE_muy_facil; //Testeabilidad
		private ValorLinguistico CM_no, CM_poco, CM_medianamente, CM_casi_todo, CM_completamente; //Cumplimiento de Mantenibilidad

		private ValorLinguistico M_muy_baja, M_baja, M_mediana, M_casi_todo, M_completamente; //Mantenibilidad

		//Constructor
		public ValoresMantenibilidad()
		{
			//Analizabilidad
			AN_muy_dificil = new ValorLinguistico("muy_mala", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			AN_dificil = new ValorLinguistico("mala", new FuncionTriangular(0.1, 0.3, 0.5));
			AN_normal = new ValorLinguistico("promedio", new FuncionTriangular(0.3, 0.5, 0.7));
			AN_facil = new ValorLinguistico("buena", new FuncionTriangular(0.5, 0.7, 0.9));
			AN_muy_facil = new ValorLinguistico("excelente", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Modificabilidad
			MO_muy_dificil = new ValorLinguistico("muy_dificil", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			MO_dificil = new ValorLinguistico("dificil", new FuncionTriangular(0.1, 0.3, 0.5));
			MO_normal = new ValorLinguistico("normal", new FuncionTriangular(0.3, 0.5, 0.7));
			MO_facil = new ValorLinguistico("facil", new FuncionTriangular(0.5, 0.7, 0.9));
			MO_muy_facil = new ValorLinguistico("muy_facil", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Escalabilidad
			ESC_no = new ValorLinguistico("no", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			ESC_poca = new ValorLinguistico("poco", new FuncionTriangular(0.1, 0.3, 0.5));
			ESC_medianamente = new ValorLinguistico("medianamente", new FuncionTriangular(0.3, 0.5, 0.7));
			ESC_casi_todo = new ValorLinguistico("casi_todo", new FuncionTriangular(0.5, 0.7, 0.9));
			ESC_completamente = new ValorLinguistico("completamente", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Testeabilidad
			TE_muy_dificil = new ValorLinguistico("muy_dificil", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			TE_dificil = new ValorLinguistico("_dificil", new FuncionTriangular(0.1, 0.3, 0.5));
			TE_normal = new ValorLinguistico("normal", new FuncionTriangular(0.3, 0.5, 0.7));
			TE_facil = new ValorLinguistico("facil", new FuncionTriangular(0.5, 0.7, 0.9));
			TE_muy_facil = new ValorLinguistico("muy_facil", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Cumplimiento de Mantenibilidad
			CM_no = new ValorLinguistico("no", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			CM_poco = new ValorLinguistico("poco", new FuncionTriangular(0.1, 0.3, 0.5));
			CM_medianamente = new ValorLinguistico("medianamente", new FuncionTriangular(0.3, 0.5, 0.7));
			CM_casi_todo = new ValorLinguistico("casi_todo", new FuncionTriangular(0.5, 0.7, 0.9));
			CM_completamente = new ValorLinguistico("completamente", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Mantenibilidad
			M_muy_baja = new ValorLinguistico("muy_baja", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			M_baja = new ValorLinguistico("baja", new FuncionTriangular(0.1, 0.3, 0.5));
			M_mediana = new ValorLinguistico("mediana", new FuncionTriangular(0.3, 0.5, 0.7));
			M_casi_todo = new ValorLinguistico("casi_todo", new FuncionTriangular(0.5, 0.7, 0.9));
			M_completamente = new ValorLinguistico("completamente", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));
		}


		//Analizabilidad
		public ValorLinguistico AN_Muy_Dificil { get { return AN_muy_dificil; } }
		public ValorLinguistico AN_Dificil { get { return AN_dificil; } }
		public ValorLinguistico AN_Normal { get { return AN_normal; } }
		public ValorLinguistico AN_Facil { get { return AN_facil; } }
		public ValorLinguistico AN_Muy_Facil { get { return AN_muy_facil; } }

		//Modificabilidad
		public ValorLinguistico MO_Muy_Dificil { get { return MO_muy_dificil; } }
		public ValorLinguistico MO_Dificil { get { return MO_dificil; } }
		public ValorLinguistico MO_Normal { get { return MO_normal; } }
		public ValorLinguistico MO_Facil { get { return MO_facil; } }
		public ValorLinguistico MO_Muy_Facil { get { return MO_muy_facil; } }

		//Escalabilidad	 
		public ValorLinguistico ESC_No { get { return ESC_no; } }
		public ValorLinguistico ESC_Poca { get { return ESC_poca; } }
		public ValorLinguistico ESC_Medianamente { get { return ESC_medianamente; } }
		public ValorLinguistico ESC_Casi_Todo { get { return ESC_casi_todo; } }
		public ValorLinguistico ESC_Completamente { get { return ESC_completamente; } }

		//Testeabilidad
		public ValorLinguistico TE_Muy_Dificil { get { return TE_muy_dificil; } }
		public ValorLinguistico TE_Dificil { get { return TE_dificil; } }
		public ValorLinguistico TE_Normal { get { return TE_normal; } }
		public ValorLinguistico TE_Facil { get { return TE_facil; } } 
		public ValorLinguistico TE_Muy_Facil { get { return TE_muy_facil; } }

		//Cumplimiento de Mantenibilidad
		public ValorLinguistico CM_No { get { return CM_no; } }
		public ValorLinguistico CM_Poco { get { return CM_poco; } }
		public ValorLinguistico CM_Medianamente { get { return CM_medianamente; } }
		public ValorLinguistico CM_Casi_Todo { get { return CM_casi_todo; } }
		public ValorLinguistico CM_Completamente { get { return CM_completamente; } }

		//Mantenibilidad
		public ValorLinguistico M_Muy_Baja { get { return M_muy_baja; } }
		public ValorLinguistico M_Baja { get { return M_baja; } }
		public ValorLinguistico M_Mediana { get { return M_mediana; } }
		public ValorLinguistico M_Casi_Todo { get { return M_casi_todo; } }
		public ValorLinguistico M_Completamente { get { return M_completamente; } }
	}
}
