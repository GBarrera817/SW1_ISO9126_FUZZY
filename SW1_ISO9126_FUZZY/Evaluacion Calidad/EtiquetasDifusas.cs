
namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad
{

	/// <summary>
	/// Etiquetas para: Funcionalidad, Adecuacion, Interoperabilidad, Seguridad.
	/// </summary>	
	public static class EtiquetasDifusas1
	{
		private static string MM = "Muy Mala";
		private static string MA = "Mala";
		private static string PR = "Promedio";
		private static string BU = "Buena";
		private static string EX = "Excelente";

		public static string getEtiquetaLinguistica(double x)
		{
			if (x >= 0.0 && x < 0.20)
				return MM;

			if (x >= 0.20 && x < 0.40)
				return MA;

			if (x >= 0.40 && x < 0.60)
				return PR;

			if (x >= 0.60 && x < 0.80)
				return BU;

			if (x >= 0.80 && x <= 1.0)
				return EX;

			return null;
		}
	}

	/// <summary>
	/// Etiquetas para: Exactitud
	/// </summary>
	public static class EtiquetasDifusas2
	{
		//Exactitud

		private static string NC = "Nunca";
		private static string PV = "Pocas veces";
		private static string AV = "Algunas veces";
		private static string CS = "Casi siempre";
		private static string S = "Siempre";

		public static string getEtiquetaLinguistica(double x)
		{
			if (x >= 0.0 && x < 0.20)
				return NC;

			if (x >= 0.20 && x < 0.40)
				return PV;

			if (x >= 0.40 && x < 0.60)
				return AV;

			if (x >= 0.60 && x < 0.80)
				return CS;

			if (x >= 0.80 && x <= 1.0)
				return S;

			return null;
		}
	}

	/// <summary>
	/// Etiquetas para: Cumplimiento funcional, atractividad, cumplimiento usabilidad, estabilidad, cumplimiento mantenibilidad.
	/// </summary>
	public static class EtiquetasDifusas3
	{
	
		private static string NO = "No";
		private static string PO = "Poco";
		private static string ME = "Medianamente";
		private static string CT = "Casi todo";
		private static string CO = "Completamente";

		public static string getEtiquetaLinguistica(double x)
		{
			if (x >= 0.0 && x < 0.20)
				return NO;

			if (x >= 0.20 && x < 0.40)
				return PO;

			if (x >= 0.40 && x < 0.60)
				return ME;

			if (x >= 0.60 && x < 0.80)
				return CT;

			if (x >= 0.80 && x <= 1.0)
				return CO;

			return null;
		}
	}

	/// <summary>
	/// Etiquetas para: Facilidad aprendizaje, comprensibilidad, operabilidad, usabilidad, Facilidad análisis, modificabilidad, testeabilidad
	/// </summary>
	public static class EtiquetasDifusas4
	{
		private static string MD = "Muy difícil";
		private static string DI = "Difícil";
		private static string N = "Normal";
		private static string FA = "Fácil";
		private static string MF = "Muy fácil";

		public static string getEtiquetaLinguistica(double x)
		{
			if (x >= 0.0 && x < 0.20)
				return MD;

			if (x >= 0.20 && x < 0.40)
				return DI;

			if (x >= 0.40 && x < 0.60)
				return N;

			if (x >= 0.60 && x < 0.80)
				return FA;

			if (x >= 0.80 && x <= 1.0)
				return MF;

			return null;

		}
	}

	/// <summary>
	/// Etiquetas para: Mantenibilidad
	/// </summary>
	public static class EtiquetasDifusas5
	{
		private static string MB = "Muy baja";
		private static string BA = "Baja";
		private static string ME = "Mediana";
		private static string CT = "Casi todo";
		private static string CO = "Completamente";

		public static string getEtiquetaLinguistica(double x)
		{
			if (x >= 0.0 && x < 0.20)
				return MB;

			if (x >= 0.20 && x < 0.40)
				return BA;

			if (x >= 0.40 && x < 0.60)
				return ME;

			if (x >= 0.60 && x < 0.80)
				return CT;

			if (x >= 0.80 && x <= 1.0)
				return CO;

			return null;

		}
	}
}
