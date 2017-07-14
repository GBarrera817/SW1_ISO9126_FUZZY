using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;

namespace SW1_ISO9126_FUZZY.Evaluacion_Difusa.Valores_Linguisticos
{
	public class ValoresUsabilidad
	{
		private ValorLinguistico AP_muy_dificil, AP_dificil, AP_normal, AP_facil, AP_muy_facil; //Aprendizaje
		private ValorLinguistico COM_muy_dificil, COM_dificil, COM_normal, COM_facil, COM_muy_facil; //Comprensibilidad
		private ValorLinguistico OP_muy_dificil, OP_dificil, OP_normal, OP_facil, OP_muy_facil; //Operabilidad
		private ValorLinguistico AT_no, AT_poco, AT_medianamente, AT_casi_todo, AT_completamente; //Atractividad
		private ValorLinguistico CU_no, CU_poco, CU_medianamente, CU_casi_todo, CU_completamente; //Cumplimiento de Usabilidad

		private ValorLinguistico U_muy_dificil, U_dificil, U_normal, U_facil, U_muy_facil; //Usabilidad

		//Constructor
		public ValoresUsabilidad()
		{
			//Aprendizaje
			AP_muy_dificil = new ValorLinguistico("muy_dificil", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			AP_dificil = new ValorLinguistico("dificil", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			AP_normal = new ValorLinguistico("normal", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			AP_facil = new ValorLinguistico("faci", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			AP_muy_facil = new ValorLinguistico("muy_facil", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Comprensibilidad
			COM_muy_dificil = new ValorLinguistico("muy_dificil", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			COM_dificil = new ValorLinguistico("dificil", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			COM_normal = new ValorLinguistico("normal", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			COM_facil = new ValorLinguistico("facil", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			COM_muy_facil = new ValorLinguistico("muy_facil", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Operabilidad
			OP_muy_dificil = new ValorLinguistico("muy_dificil", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			OP_dificil = new ValorLinguistico("dificil", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			OP_normal = new ValorLinguistico("normal", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			OP_facil = new ValorLinguistico("faci", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			OP_muy_facil = new ValorLinguistico("muy_facil", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Atractividad
			AT_no = new ValorLinguistico("no", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			AT_poco = new ValorLinguistico("poco", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			AT_medianamente = new ValorLinguistico("medianamente", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			AT_casi_todo = new ValorLinguistico("casi_todo", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			AT_completamente = new ValorLinguistico("completamente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Cumplimiento de Usabilidad
			CU_no = new ValorLinguistico("no", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			CU_poco = new ValorLinguistico("poco", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			CU_medianamente = new ValorLinguistico("medianamente", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			CU_casi_todo = new ValorLinguistico("casi_todo", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			CU_completamente = new ValorLinguistico("completamente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Usabilidad
			U_muy_dificil = new ValorLinguistico("muy_dificil", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			U_dificil = new ValorLinguistico("dificil", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			U_normal = new ValorLinguistico("normal", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			U_facil = new ValorLinguistico("facil", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			U_muy_facil = new ValorLinguistico("muy_facil", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));
		}

		//Aprendizaje
		public ValorLinguistico AP_Muy_Dificil { get { return AP_muy_dificil; } }
		public ValorLinguistico AP_Dificil { get { return AP_dificil; } }
		public ValorLinguistico AP_Normal { get { return AP_normal; } }
		public ValorLinguistico AP_Facil { get { return AP_facil; } }
		public ValorLinguistico AP_Muy_Facil { get { return AP_muy_facil; } }

		//Comprensibilidad
		public ValorLinguistico COM_Muy_Dificil { get { return COM_muy_dificil; } }
		public ValorLinguistico COM_Dificil { get { return COM_dificil; } }
		public ValorLinguistico COM_Normal { get { return COM_normal; } }
		public ValorLinguistico COM_Facil { get { return COM_facil; } }
		public ValorLinguistico COM_Muy_Facil { get { return COM_muy_facil; } }

		//Operabilidad
		public ValorLinguistico OP_Muy_Dificil { get { return OP_muy_dificil; } }
		public ValorLinguistico OP_Dificil { get { return OP_dificil; } }
		public ValorLinguistico OP_Normal { get { return OP_normal; } }
		public ValorLinguistico OP_Facil { get { return OP_facil; } }
		public ValorLinguistico OP_Muy_Facil { get { return OP_muy_facil; } }

		//Atractividad
		public ValorLinguistico AT_No { get { return AT_no; } }
		public ValorLinguistico AT_Poco { get { return AT_poco; } }		
		public ValorLinguistico AT_Medianamente { get { return AT_medianamente; } }
		public ValorLinguistico AT_Casi_Todo { get { return AT_casi_todo; } }
		public ValorLinguistico AT_Completamente { get { return AT_completamente; } }

		//Cumplimiento de Usabilidad
		public ValorLinguistico CU_No { get { return CU_no; } }
		public ValorLinguistico CU_Poco { get { return CU_poco; } }
		public ValorLinguistico CU_Medianamente { get { return CU_medianamente; } }
		public ValorLinguistico CU_Casi_Todo { get { return CU_casi_todo; } }
		public ValorLinguistico CU_Completamente { get { return CU_completamente; } }

		//Usabilidad
		public ValorLinguistico U_Muy_Dificil { get { return U_muy_dificil; } }
		public ValorLinguistico U_Dificil { get { return U_dificil; } }
		public ValorLinguistico U_Normal { get { return U_normal; } }
		public ValorLinguistico U_Facil { get { return U_facil; } }
		public ValorLinguistico U_Muy_Facil { get { return U_muy_facil; } }
