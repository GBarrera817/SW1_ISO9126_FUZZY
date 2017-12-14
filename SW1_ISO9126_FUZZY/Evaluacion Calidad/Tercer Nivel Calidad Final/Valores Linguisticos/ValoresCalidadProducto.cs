using SW1_ISO9126_FUZZY.Logica_Difusa;
using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final.Valores_Linguisticos
{
	public class ValoresCalidadProducto
	{
		private ValorLinguistico muy_mala, mala, promedio, buena, excelente; //Calidad Interna
		private ValorLinguistico no_tiene, baja, regular, alta, muy_alta;    //Calidad Externa
		private ValorLinguistico CF_muy_mala, CF_mala, CF_promedio, CF_buena, CF_excelente; //Calidad Final

		public ValoresCalidadProducto()
		{
			//Calidad Interna
			muy_mala = new ValorLinguistico("muy_mala", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			mala = new ValorLinguistico("mala", new FuncionTriangular(0.1, 0.3, 0.5));
			promedio = new ValorLinguistico("promedio", new FuncionTriangular(0.3, 0.5, 0.7));
			buena = new ValorLinguistico("buena", new FuncionTriangular(0.5, 0.7, 0.9));
			excelente = new ValorLinguistico("excelente", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Calidad Externa
			no_tiene = new ValorLinguistico("no_tiene", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			baja = new ValorLinguistico("baja", new FuncionTriangular(0.1, 0.3, 0.5));
			regular = new ValorLinguistico("regular", new FuncionTriangular(0.3, 0.5, 0.7));
			alta = new ValorLinguistico("alta", new FuncionTriangular(0.5, 0.7, 0.9));
			muy_alta = new ValorLinguistico("muy_alta", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));

			//Calidad Final
			CF_muy_mala = new ValorLinguistico("CF_muy_mala", new FuncionTrapezoidal(0.0, 0.0, 0.1, 0.3));
			CF_mala = new ValorLinguistico("CF_mala", new FuncionTriangular(0.1, 0.3, 0.5));
			CF_promedio = new ValorLinguistico("CF_promedio", new FuncionTriangular(0.3, 0.5, 0.7));
			CF_buena = new ValorLinguistico("CF_buena", new FuncionTriangular(0.5, 0.7, 0.9));
			CF_excelente = new ValorLinguistico("CF_excelente", new FuncionTrapezoidal(0.7, 0.9, 1.0, 1.0));
		}

		//Calidad Interna
		public ValorLinguistico Muy_Mala { get => muy_mala; }
		public ValorLinguistico Mala { get => mala; }
		public ValorLinguistico Promedio { get => promedio; }
		public ValorLinguistico Buena { get => buena; }
		public ValorLinguistico Excelente { get => excelente; }

		//Calidad Externa
		public ValorLinguistico No_Tiene { get => no_tiene; }
		public ValorLinguistico Baja { get => baja; }
		public ValorLinguistico Regular { get => regular; }
		public ValorLinguistico Alta { get => alta; }
		public ValorLinguistico Muy_Alta { get => muy_alta; }


		//Calidad Final
		public ValorLinguistico CF_Muy_Mala { get => CF_muy_mala; }
		public ValorLinguistico CF_Mala { get => CF_mala; }
		public ValorLinguistico CF_Promedio { get => CF_promedio; }
		public ValorLinguistico CF_Buena { get => CF_buena; }
		public ValorLinguistico CF_Excelente { get => CF_excelente; }

	}
}
