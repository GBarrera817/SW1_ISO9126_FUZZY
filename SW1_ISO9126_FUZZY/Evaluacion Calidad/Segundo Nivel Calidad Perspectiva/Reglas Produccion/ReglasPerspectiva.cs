using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Segundo_Nivel_Calidad_Perspectiva.Reglas_Produccion
{
	public class ReglasPerspectiva
	{
		private Dictionary<string, string> _perspectiva;

		public ReglasPerspectiva()
		{
			_perspectiva = ReglasPers();
		}

		public Dictionary<string, string> ReglasPers()
		{
			Dictionary<string, string> reglasPerspectiva = new Dictionary<string, string>();

			reglasPerspectiva.Add("1", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS muy_mala");
			reglasPerspectiva.Add("2", "IF funcionabilidad IS mala AND usabilidad IS muy_dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS muy_mala");
			reglasPerspectiva.Add("3", "IF funcionabilidad IS promedio AND usabilidad IS muy_dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("4", "IF funcionabilidad IS buena AND usabilidad IS muy_dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("5", "IF funcionabilidad IS excelente AND usabilidad IS muy_dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("6", "IF funcionabilidad IS muy_mala AND usabilidad IS dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS muy_mala");
			reglasPerspectiva.Add("7", "IF funcionabilidad IS mala AND usabilidad IS dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("8", "IF funcionabilidad IS promedio AND usabilidad IS dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("9", "IF funcionabilidad IS buena AND usabilidad IS dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("10", "IF funcionabilidad IS excelente AND usabilidad IS dificil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("11", "IF funcionabilidad IS muy_mala AND usabilidad IS normal AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("12", "IF funcionabilidad IS mala AND usabilidad IS normal AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("13", "IF funcionabilidad IS promedio AND usabilidad IS normal AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("14", "IF funcionabilidad IS buena AND usabilidad IS normal AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("15", "IF funcionabilidad IS excelente AND usabilidad IS normal AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("16", "IF funcionabilidad IS muy_mala AND usabilidad IS facil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("17", "IF funcionabilidad IS mala AND usabilidad IS facil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("18", "IF funcionabilidad IS promedio AND usabilidad IS facil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("19", "IF funcionabilidad IS buena AND usabilidad IS facil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("20", "IF funcionabilidad IS excelente AND usabilidad IS facil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("21", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_facil AND mantenibilidad IS muy_baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("22", "IF funcionabilidad IS mala AND usabilidad IS muy_facil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("23", "IF funcionabilidad IS promedio AND usabilidad IS muy_facil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("24", "IF funcionabilidad IS buena AND usabilidad IS muy_facil AND mantenibilidad IS muy_baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("25", "IF funcionabilidad IS excelente AND usabilidad IS muy_facil AND mantenibilidad IS muy_baja THEN calidad_producto IS buena");
			reglasPerspectiva.Add("26", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_dificil AND mantenibilidad IS baja THEN calidad_producto IS muy_mala");
			reglasPerspectiva.Add("27", "IF funcionabilidad IS mala AND usabilidad IS muy_dificil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("28", "IF funcionabilidad IS promedio AND usabilidad IS muy_dificil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("29", "IF funcionabilidad IS buena AND usabilidad IS muy_dificil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("30", "IF funcionabilidad IS excelente AND usabilidad IS muy_dificil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("31", "IF funcionabilidad IS muy_mala AND usabilidad IS dificil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("32", "IF funcionabilidad IS mala AND usabilidad IS dificil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("33", "IF funcionabilidad IS promedio AND usabilidad IS dificil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("34", "IF funcionabilidad IS buena AND usabilidad IS dificil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("35", "IF funcionabilidad IS excelente AND usabilidad IS dificil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("36", "IF funcionabilidad IS muy_mala AND usabilidad IS normal AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("37", "IF funcionabilidad IS mala AND usabilidad IS normal AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("38", "IF funcionabilidad IS promedio AND usabilidad IS normal AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("39", "IF funcionabilidad IS buena AND usabilidad IS normal AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("40", "IF funcionabilidad IS excelente AND usabilidad IS normal AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("41", "IF funcionabilidad IS muy_mala AND usabilidad IS facil AND mantenibilidad IS baja THEN calidad_producto IS mala");
			reglasPerspectiva.Add("42", "IF funcionabilidad IS mala AND usabilidad IS facil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("43", "IF funcionabilidad IS promedio AND usabilidad IS facil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("44", "IF funcionabilidad IS buena AND usabilidad IS facil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("45", "IF funcionabilidad IS excelente AND usabilidad IS facil AND mantenibilidad IS baja THEN calidad_producto IS buena");
			reglasPerspectiva.Add("46", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_facil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("47", "IF funcionabilidad IS mala AND usabilidad IS muy_facil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("48", "IF funcionabilidad IS promedio AND usabilidad IS muy_facil AND mantenibilidad IS baja THEN calidad_producto IS regular");
			reglasPerspectiva.Add("49", "IF funcionabilidad IS buena AND usabilidad IS muy_facil AND mantenibilidad IS baja THEN calidad_producto IS buena");
			reglasPerspectiva.Add("50", "IF funcionabilidad IS excelente AND usabilidad IS muy_facil AND mantenibilidad IS baja THEN calidad_producto IS buena");
			reglasPerspectiva.Add("51", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_dificil AND mantenibilidad IS mediana THEN calidad_producto IS mala");
			reglasPerspectiva.Add("52", "IF funcionabilidad IS mala AND usabilidad IS muy_dificil AND mantenibilidad IS mediana THEN calidad_producto IS mala");
			reglasPerspectiva.Add("53", "IF funcionabilidad IS promedio AND usabilidad IS muy_dificil AND mantenibilidad IS mediana THEN calidad_producto IS mala");
			reglasPerspectiva.Add("54", "IF funcionabilidad IS buena AND usabilidad IS muy_dificil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("55", "IF funcionabilidad IS excelente AND usabilidad IS muy_dificil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("56", "IF funcionabilidad IS muy_mala AND usabilidad IS dificil AND mantenibilidad IS mediana THEN calidad_producto IS mala");
			reglasPerspectiva.Add("57", "IF funcionabilidad IS mala AND usabilidad IS dificil AND mantenibilidad IS mediana THEN calidad_producto IS mala");
			reglasPerspectiva.Add("58", "IF funcionabilidad IS promedio AND usabilidad IS dificil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("59", "IF funcionabilidad IS buena AND usabilidad IS dificil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("60", "IF funcionabilidad IS excelente AND usabilidad IS dificil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("61", "IF funcionabilidad IS muy_mala AND usabilidad IS normal AND mantenibilidad IS mediana THEN calidad_producto IS mala");
			reglasPerspectiva.Add("62", "IF funcionabilidad IS mala AND usabilidad IS normal AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("63", "IF funcionabilidad IS promedio AND usabilidad IS normal AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("64", "IF funcionabilidad IS buena AND usabilidad IS normal AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("65", "IF funcionabilidad IS excelente AND usabilidad IS normal AND mantenibilidad IS mediana THEN calidad_producto IS buena");
			reglasPerspectiva.Add("66", "IF funcionabilidad IS muy_mala AND usabilidad IS facil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("67", "IF funcionabilidad IS mala AND usabilidad IS facil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("68", "IF funcionabilidad IS promedio AND usabilidad IS facil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("69", "IF funcionabilidad IS buena AND usabilidad IS facil AND mantenibilidad IS mediana THEN calidad_producto IS buena");
			reglasPerspectiva.Add("70", "IF funcionabilidad IS excelente AND usabilidad IS facil AND mantenibilidad IS mediana THEN calidad_producto IS buena");
			reglasPerspectiva.Add("71", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_facil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("72", "IF funcionabilidad IS mala AND usabilidad IS muy_facil AND mantenibilidad IS mediana THEN calidad_producto IS regular");
			reglasPerspectiva.Add("73", "IF funcionabilidad IS promedio AND usabilidad IS muy_facil AND mantenibilidad IS mediana THEN calidad_producto IS buena");
			reglasPerspectiva.Add("74", "IF funcionabilidad IS buena AND usabilidad IS muy_facil AND mantenibilidad IS mediana THEN calidad_producto IS buena");
			reglasPerspectiva.Add("75", "IF funcionabilidad IS excelente AND usabilidad IS muy_facil AND mantenibilidad IS mediana THEN calidad_producto IS buena");
			reglasPerspectiva.Add("76", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS mala");
			reglasPerspectiva.Add("77", "IF funcionabilidad IS mala AND usabilidad IS muy_dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS mala");
			reglasPerspectiva.Add("78", "IF funcionabilidad IS promedio AND usabilidad IS muy_dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("79", "IF funcionabilidad IS buena AND usabilidad IS muy_dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("80", "IF funcionabilidad IS excelente AND usabilidad IS muy_dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("81", "IF funcionabilidad IS muy_mala AND usabilidad IS dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS mala");
			reglasPerspectiva.Add("82", "IF funcionabilidad IS mala AND usabilidad IS dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("83", "IF funcionabilidad IS promedio AND usabilidad IS dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("84", "IF funcionabilidad IS buena AND usabilidad IS dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("85", "IF funcionabilidad IS excelente AND usabilidad IS dificil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("86", "IF funcionabilidad IS muy_mala AND usabilidad IS normal AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("87", "IF funcionabilidad IS mala AND usabilidad IS normal AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("88", "IF funcionabilidad IS promedio AND usabilidad IS normal AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("89", "IF funcionabilidad IS buena AND usabilidad IS normal AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("90", "IF funcionabilidad IS excelente AND usabilidad IS normal AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("91", "IF funcionabilidad IS muy_mala AND usabilidad IS facil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("92", "IF funcionabilidad IS mala AND usabilidad IS facil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("93", "IF funcionabilidad IS promedio AND usabilidad IS facil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("94", "IF funcionabilidad IS buena AND usabilidad IS facil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("95", "IF funcionabilidad IS excelente AND usabilidad IS facil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("96", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_facil AND mantenibilidad IS casi_todo THEN calidad_producto IS regular");
			reglasPerspectiva.Add("97", "IF funcionabilidad IS mala AND usabilidad IS muy_facil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("98", "IF funcionabilidad IS promedio AND usabilidad IS muy_facil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("99", "IF funcionabilidad IS buena AND usabilidad IS muy_facil AND mantenibilidad IS casi_todo THEN calidad_producto IS buena");
			reglasPerspectiva.Add("100", "IF funcionabilidad IS excelente AND usabilidad IS muy_facil AND mantenibilidad IS casi_todo THEN calidad_producto IS excelente");
			reglasPerspectiva.Add("101", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_dificil AND mantenibilidad IS completamente THEN calidad_producto IS mala");
			reglasPerspectiva.Add("102", "IF funcionabilidad IS mala AND usabilidad IS muy_dificil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("103", "IF funcionabilidad IS promedio AND usabilidad IS muy_dificil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("104", "IF funcionabilidad IS buena AND usabilidad IS muy_dificil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("105", "IF funcionabilidad IS excelente AND usabilidad IS muy_dificil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("106", "IF funcionabilidad IS muy_mala AND usabilidad IS dificil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("107", "IF funcionabilidad IS mala AND usabilidad IS dificil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("108", "IF funcionabilidad IS promedio AND usabilidad IS dificil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("109", "IF funcionabilidad IS buena AND usabilidad IS dificil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("110", "IF funcionabilidad IS excelente AND usabilidad IS dificil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("111", "IF funcionabilidad IS muy_mala AND usabilidad IS normal AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("112", "IF funcionabilidad IS mala AND usabilidad IS normal AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("113", "IF funcionabilidad IS promedio AND usabilidad IS normal AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("114", "IF funcionabilidad IS buena AND usabilidad IS normal AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("115", "IF funcionabilidad IS excelente AND usabilidad IS normal AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("116", "IF funcionabilidad IS muy_mala AND usabilidad IS facil AND mantenibilidad IS completamente THEN calidad_producto IS regular");
			reglasPerspectiva.Add("117", "IF funcionabilidad IS mala AND usabilidad IS facil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("118", "IF funcionabilidad IS promedio AND usabilidad IS facil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("119", "IF funcionabilidad IS buena AND usabilidad IS facil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("120", "IF funcionabilidad IS excelente AND usabilidad IS facil AND mantenibilidad IS completamente THEN calidad_producto IS excelente");
			reglasPerspectiva.Add("121", "IF funcionabilidad IS muy_mala AND usabilidad IS muy_facil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("122", "IF funcionabilidad IS mala AND usabilidad IS muy_facil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("123", "IF funcionabilidad IS promedio AND usabilidad IS muy_facil AND mantenibilidad IS completamente THEN calidad_producto IS buena");
			reglasPerspectiva.Add("124", "IF funcionabilidad IS buena AND usabilidad IS muy_facil AND mantenibilidad IS completamente THEN calidad_producto IS excelente");
			reglasPerspectiva.Add("125", "IF funcionabilidad IS excelente AND usabilidad IS muy_facil AND mantenibilidad IS completamente THEN calidad_producto IS excelente");




			return reglasPerspectiva;
		}
	}
}
