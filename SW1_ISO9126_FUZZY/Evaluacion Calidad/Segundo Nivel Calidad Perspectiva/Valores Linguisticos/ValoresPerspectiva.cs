using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Segundo_Nivel_Calidad_Perspectiva.Valores_Linguisticos
{
	public class ValoresPerspectiva
	{
		private ValorLinguistico muy_mala, mala, promedio, buena, excelente;			//Funcionabilidad
		private ValorLinguistico muy_dificil, dificil, normal, facil, muy_facil;		//Usabilidad
		private ValorLinguistico muy_baja, baja, mediana, casi_todo, completamente;		//Mantenibilidad

		private ValorLinguistico P_muy_mala, P_mala, P_promedio, P_buena, P_excelente;  //Perspectiva

		public ValoresPerspectiva()
		{
			//Funcionabilidad
			muy_mala = new ValorLinguistico("muy_mala", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			mala =  new ValorLinguistico("mala", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			promedio = new ValorLinguistico("promedio", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			buena = new ValorLinguistico("buena", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			excelente = new ValorLinguistico("excelente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Usabilidad
			muy_dificil = new ValorLinguistico("muy_dificil", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			dificil = new ValorLinguistico("dificil", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			normal = new ValorLinguistico("normal", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			facil = new ValorLinguistico("facil", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			muy_facil = new ValorLinguistico("muy_facil", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Mantenibilidad
			muy_baja = new ValorLinguistico("muy_baja", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			baja = new ValorLinguistico("baja", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			mediana = new ValorLinguistico("mediana", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			casi_todo = new ValorLinguistico("casi_todo", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			completamente = new ValorLinguistico("completamente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Perspectiva
			P_muy_mala = new ValorLinguistico("muy_mala", new FuncionMembresiaTrapezoidal(0.0, 0.0, 0.1, 0.3));
			P_mala = new ValorLinguistico("mala", new FuncionMembresiaTriangular(0.1, 0.3, 0.5));
			P_promedio = new ValorLinguistico("promedio", new FuncionMembresiaTriangular(0.3, 0.5, 0.7));
			P_buena = new ValorLinguistico("buena", new FuncionMembresiaTriangular(0.5, 0.7, 0.9));
			P_excelente = new ValorLinguistico("excelente", new FuncionMembresiaTrapezoidal(0.7, 0.9, 1.0, 1.0));
		}

		//Funcionabilidad
		public ValorLinguistico Muy_Mala { get => muy_mala; }
		public ValorLinguistico Mala { get => mala; }
		public ValorLinguistico Promedio { get => promedio; }
		public ValorLinguistico Buena { get => buena; }
		public ValorLinguistico Excelente { get => excelente; }

		//Usabilidad
		public ValorLinguistico Muy_Dificil { get => muy_dificil; }
		public ValorLinguistico Dificil { get => dificil; }
		public ValorLinguistico Normal { get => normal; }
		public ValorLinguistico Facil { get => facil; }
		public ValorLinguistico Muy_Facil { get => muy_facil; }

		//Mantenibilidad
		public ValorLinguistico Muy_Baja { get => muy_baja; }
		public ValorLinguistico Baja { get => baja; }
		public ValorLinguistico Mediana { get => mediana; }
		public ValorLinguistico Casi_Todo { get => casi_todo; }
		public ValorLinguistico Completamente { get => completamente; }

		//Perspectiva
		public ValorLinguistico P_Muy_Mala { get => P_muy_mala; }
		public ValorLinguistico P_Mala { get => P_mala; }
		public ValorLinguistico P_Promedio { get => P_promedio; }
		public ValorLinguistico P_Buena { get => P_buena; }
		public ValorLinguistico P_Excelente { get => P_excelente; }
	}
}
