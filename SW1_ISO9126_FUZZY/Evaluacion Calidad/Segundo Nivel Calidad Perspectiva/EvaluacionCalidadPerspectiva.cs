using AI.Fuzzy.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final
{
	public class EvaluacionCalidadPerspectiva
	{

		private MamdaniFuzzySystem _fsCalidadPerspectiva = null;

		private MamdaniFuzzySystem SistemaCalidadPerspectiva()
		{
			MamdaniFuzzySystem fsCalidadPerspectiva = new MamdaniFuzzySystem();

			FuzzyVariable fvFuncionalidad = new FuzzyVariable("funcionalidad", 0.0, 1.0);
			fvFuncionalidad.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvFuncionalidad.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvFuncionalidad.Terms.Add(new FuzzyTerm("promedio", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvFuncionalidad.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvFuncionalidad.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadPerspectiva.Input.Add(fvFuncionalidad);


			FuzzyVariable fvUsabilidad = new FuzzyVariable("usabilidad", 0.0, 1.0);
			fvUsabilidad.Terms.Add(new FuzzyTerm("muy_dificil", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvUsabilidad.Terms.Add(new FuzzyTerm("dificil", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvUsabilidad.Terms.Add(new FuzzyTerm("normal", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvUsabilidad.Terms.Add(new FuzzyTerm("facil", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvUsabilidad.Terms.Add(new FuzzyTerm("muy_facil", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadPerspectiva.Input.Add(fvUsabilidad);



			FuzzyVariable fvMantenibilidad = new FuzzyVariable("mantenibilidad", 0.0, 1.0);
			fvMantenibilidad.Terms.Add(new FuzzyTerm("muy_baja", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvMantenibilidad.Terms.Add(new FuzzyTerm("baja", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvMantenibilidad.Terms.Add(new FuzzyTerm("mediana", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvMantenibilidad.Terms.Add(new FuzzyTerm("casi_todo", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvMantenibilidad.Terms.Add(new FuzzyTerm("completamente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadPerspectiva.Input.Add(fvMantenibilidad);


			FuzzyVariable fvPerspectiva = new FuzzyVariable("calidad_producto", 0.0, 1.0);
			fvPerspectiva.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvPerspectiva.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvPerspectiva.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvPerspectiva.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvPerspectiva.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadPerspectiva.Output.Add(fvPerspectiva);

			try
			{
				MamdaniFuzzyRule r0 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_dificil) and (mantenibilidad is muy_baja) then calidad_producto is muy_mala");
				MamdaniFuzzyRule r1 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_dificil) and (mantenibilidad is muy_baja) then calidad_producto is muy_mala");
				MamdaniFuzzyRule r2 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_dificil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r3 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_dificil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r4 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_dificil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r5 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is dificil) and (mantenibilidad is muy_baja) then calidad_producto is muy_mala");
				MamdaniFuzzyRule r6 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is dificil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r7 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is dificil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r8 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is dificil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r9 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is dificil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r10 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is normal) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r11 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is normal) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r12 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is normal) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r13 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is normal) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r14 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is normal) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r15 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad isfacil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r16 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad isfacil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r17 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad isfacil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r18 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad isfacil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r19 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad isfacil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r20 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_facil) and (mantenibilidad is muy_baja) then calidad_producto is mala");
				MamdaniFuzzyRule r21 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_facil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r22 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_facil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r23 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_facil) and (mantenibilidad is muy_baja) then calidad_producto is regular");
				MamdaniFuzzyRule r24 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_facil) and (mantenibilidad is muy_baja) then calidad_producto is buena");
				MamdaniFuzzyRule r25 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_dificil) and (mantenibilidad is baja) then calidad_producto is muy_mala");
				MamdaniFuzzyRule r26 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_dificil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r27 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_dificil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r28 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_dificil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r29 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_dificil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r30 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is dificil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r31 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is dificil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r32 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is dificil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r33 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is dificil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r34 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is dificil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r35 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is normal) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r36 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is normal) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r37 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is normal) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r38 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is normal) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r39 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is normal) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r40 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad isfacil) and (mantenibilidad is baja) then calidad_producto is mala");
				MamdaniFuzzyRule r41 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad isfacil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r42 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad isfacil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r43 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad isfacil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r44 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad isfacil) and (mantenibilidad is baja) then calidad_producto is buena");
				MamdaniFuzzyRule r45 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_facil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r46 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_facil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r47 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_facil) and (mantenibilidad is baja) then calidad_producto is regular");
				MamdaniFuzzyRule r48 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_facil) and (mantenibilidad is baja) then calidad_producto is buena");
				MamdaniFuzzyRule r49 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_facil) and (mantenibilidad is baja) then calidad_producto is buena");
				MamdaniFuzzyRule r50 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_dificil) and (mantenibilidad is mediana) then calidad_producto is mala");
				MamdaniFuzzyRule r51 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_dificil) and (mantenibilidad is mediana) then calidad_producto is mala");
				MamdaniFuzzyRule r52 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_dificil) and (mantenibilidad is mediana) then calidad_producto is mala");
				MamdaniFuzzyRule r53 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_dificil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r54 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_dificil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r55 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is dificil) and (mantenibilidad is mediana) then calidad_producto is mala");
				MamdaniFuzzyRule r56 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is dificil) and (mantenibilidad is mediana) then calidad_producto is mala");
				MamdaniFuzzyRule r57 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is dificil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r58 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is dificil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r59 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is dificil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r60 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is normal) and (mantenibilidad is mediana) then calidad_producto is mala");
				MamdaniFuzzyRule r61 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is normal) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r62 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is normal) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r63 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is normal) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r64 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is normal) and (mantenibilidad is mediana) then calidad_producto is buena");
				MamdaniFuzzyRule r65 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad isfacil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r66 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad isfacil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r67 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad isfacil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r68 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad isfacil) and (mantenibilidad is mediana) then calidad_producto is buena");
				MamdaniFuzzyRule r69 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad isfacil) and (mantenibilidad is mediana) then calidad_producto is buena");
				MamdaniFuzzyRule r70 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_facil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r71 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_facil) and (mantenibilidad is mediana) then calidad_producto is regular");
				MamdaniFuzzyRule r72 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_facil) and (mantenibilidad is mediana) then calidad_producto is buena");
				MamdaniFuzzyRule r73 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_facil) and (mantenibilidad is mediana) then calidad_producto is buena");
				MamdaniFuzzyRule r74 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_facil) and (mantenibilidad is mediana) then calidad_producto is buena");
				MamdaniFuzzyRule r75 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_dificil) and (mantenibilidad is casi_todo) then calidad_producto is mala");
				MamdaniFuzzyRule r76 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_dificil) and (mantenibilidad is casi_todo) then calidad_producto is mala");
				MamdaniFuzzyRule r77 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_dificil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r78 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_dificil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r79 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_dificil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r80 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is dificil) and (mantenibilidad is casi_todo) then calidad_producto is mala");
				MamdaniFuzzyRule r81 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is dificil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r82 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is dificil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r83 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is dificil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r84 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is dificil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r85 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is normal) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r86 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is normal) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r87 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is normal) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r88 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is normal) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r89 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is normal) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r90 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad isfacil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r91 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad isfacil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r92 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad isfacil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r93 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad isfacil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r94 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad isfacil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r95 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_facil) and (mantenibilidad is casi_todo) then calidad_producto is regular");
				MamdaniFuzzyRule r96 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_facil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r97 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_facil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r98 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_facil) and (mantenibilidad is casi_todo) then calidad_producto is buena");
				MamdaniFuzzyRule r99 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_facil) and (mantenibilidad is casi_todo) then calidad_producto is excelente");
				MamdaniFuzzyRule r100 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_dificil) and (mantenibilidad is completamente) then calidad_producto is mala");
				MamdaniFuzzyRule r101 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_dificil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r102 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_dificil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r103 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_dificil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r104 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_dificil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r105 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is dificil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r106 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is dificil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r107 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is dificil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r108 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is dificil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r109 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is dificil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r110 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is normal) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r111 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is normal) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r112 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is normal) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r113 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is normal) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r114 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is normal) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r115 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad isfacil) and (mantenibilidad is completamente) then calidad_producto is regular");
				MamdaniFuzzyRule r116 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad isfacil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r117 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad isfacil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r118 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad isfacil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r119 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad isfacil) and (mantenibilidad is completamente) then calidad_producto is excelente");
				MamdaniFuzzyRule r120 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is muy_mala) and (usabilidad is muy_facil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r121 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is mala) and (usabilidad is muy_facil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r122 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is promedio) and (usabilidad is muy_facil) and (mantenibilidad is completamente) then calidad_producto is buena");
				MamdaniFuzzyRule r123 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is buena) and (usabilidad is muy_facil) and (mantenibilidad is completamente) then calidad_producto is excelente");
				MamdaniFuzzyRule r124 = fsCalidadPerspectiva.ParseRule("if (funcionalidad is excelente) and (usabilidad is muy_facil) and (mantenibilidad is completamente) then calidad_producto is excelente");


				fsCalidadPerspectiva.Rules.Add(r0);
				fsCalidadPerspectiva.Rules.Add(r1);
				fsCalidadPerspectiva.Rules.Add(r2);
				fsCalidadPerspectiva.Rules.Add(r3);
				fsCalidadPerspectiva.Rules.Add(r4);
				fsCalidadPerspectiva.Rules.Add(r5);
				fsCalidadPerspectiva.Rules.Add(r6);
				fsCalidadPerspectiva.Rules.Add(r7);
				fsCalidadPerspectiva.Rules.Add(r8);
				fsCalidadPerspectiva.Rules.Add(r9);
				fsCalidadPerspectiva.Rules.Add(r10);
				fsCalidadPerspectiva.Rules.Add(r11);
				fsCalidadPerspectiva.Rules.Add(r12);
				fsCalidadPerspectiva.Rules.Add(r13);
				fsCalidadPerspectiva.Rules.Add(r14);
				fsCalidadPerspectiva.Rules.Add(r15);
				fsCalidadPerspectiva.Rules.Add(r16);
				fsCalidadPerspectiva.Rules.Add(r17);
				fsCalidadPerspectiva.Rules.Add(r18);
				fsCalidadPerspectiva.Rules.Add(r19);
				fsCalidadPerspectiva.Rules.Add(r20);
				fsCalidadPerspectiva.Rules.Add(r21);
				fsCalidadPerspectiva.Rules.Add(r22);
				fsCalidadPerspectiva.Rules.Add(r23);
				fsCalidadPerspectiva.Rules.Add(r24);
				fsCalidadPerspectiva.Rules.Add(r25);
				fsCalidadPerspectiva.Rules.Add(r26);
				fsCalidadPerspectiva.Rules.Add(r27);
				fsCalidadPerspectiva.Rules.Add(r28);
				fsCalidadPerspectiva.Rules.Add(r29);
				fsCalidadPerspectiva.Rules.Add(r30);
				fsCalidadPerspectiva.Rules.Add(r31);
				fsCalidadPerspectiva.Rules.Add(r32);
				fsCalidadPerspectiva.Rules.Add(r33);
				fsCalidadPerspectiva.Rules.Add(r34);
				fsCalidadPerspectiva.Rules.Add(r35);
				fsCalidadPerspectiva.Rules.Add(r36);
				fsCalidadPerspectiva.Rules.Add(r37);
				fsCalidadPerspectiva.Rules.Add(r38);
				fsCalidadPerspectiva.Rules.Add(r39);
				fsCalidadPerspectiva.Rules.Add(r40);
				fsCalidadPerspectiva.Rules.Add(r41);
				fsCalidadPerspectiva.Rules.Add(r42);
				fsCalidadPerspectiva.Rules.Add(r43);
				fsCalidadPerspectiva.Rules.Add(r44);
				fsCalidadPerspectiva.Rules.Add(r45);
				fsCalidadPerspectiva.Rules.Add(r46);
				fsCalidadPerspectiva.Rules.Add(r47);
				fsCalidadPerspectiva.Rules.Add(r48);
				fsCalidadPerspectiva.Rules.Add(r49);
				fsCalidadPerspectiva.Rules.Add(r50);
				fsCalidadPerspectiva.Rules.Add(r51);
				fsCalidadPerspectiva.Rules.Add(r52);
				fsCalidadPerspectiva.Rules.Add(r53);
				fsCalidadPerspectiva.Rules.Add(r54);
				fsCalidadPerspectiva.Rules.Add(r55);
				fsCalidadPerspectiva.Rules.Add(r56);
				fsCalidadPerspectiva.Rules.Add(r57);
				fsCalidadPerspectiva.Rules.Add(r58);
				fsCalidadPerspectiva.Rules.Add(r59);
				fsCalidadPerspectiva.Rules.Add(r60);
				fsCalidadPerspectiva.Rules.Add(r61);
				fsCalidadPerspectiva.Rules.Add(r62);
				fsCalidadPerspectiva.Rules.Add(r63);
				fsCalidadPerspectiva.Rules.Add(r64);
				fsCalidadPerspectiva.Rules.Add(r65);
				fsCalidadPerspectiva.Rules.Add(r66);
				fsCalidadPerspectiva.Rules.Add(r67);
				fsCalidadPerspectiva.Rules.Add(r68);
				fsCalidadPerspectiva.Rules.Add(r69);
				fsCalidadPerspectiva.Rules.Add(r70);
				fsCalidadPerspectiva.Rules.Add(r71);
				fsCalidadPerspectiva.Rules.Add(r72);
				fsCalidadPerspectiva.Rules.Add(r73);
				fsCalidadPerspectiva.Rules.Add(r74);
				fsCalidadPerspectiva.Rules.Add(r75);
				fsCalidadPerspectiva.Rules.Add(r76);
				fsCalidadPerspectiva.Rules.Add(r77);
				fsCalidadPerspectiva.Rules.Add(r78);
				fsCalidadPerspectiva.Rules.Add(r79);
				fsCalidadPerspectiva.Rules.Add(r80);
				fsCalidadPerspectiva.Rules.Add(r81);
				fsCalidadPerspectiva.Rules.Add(r82);
				fsCalidadPerspectiva.Rules.Add(r83);
				fsCalidadPerspectiva.Rules.Add(r84);
				fsCalidadPerspectiva.Rules.Add(r85);
				fsCalidadPerspectiva.Rules.Add(r86);
				fsCalidadPerspectiva.Rules.Add(r87);
				fsCalidadPerspectiva.Rules.Add(r88);
				fsCalidadPerspectiva.Rules.Add(r89);
				fsCalidadPerspectiva.Rules.Add(r90);
				fsCalidadPerspectiva.Rules.Add(r91);
				fsCalidadPerspectiva.Rules.Add(r92);
				fsCalidadPerspectiva.Rules.Add(r93);
				fsCalidadPerspectiva.Rules.Add(r94);
				fsCalidadPerspectiva.Rules.Add(r95);
				fsCalidadPerspectiva.Rules.Add(r96);
				fsCalidadPerspectiva.Rules.Add(r97);
				fsCalidadPerspectiva.Rules.Add(r98);
				fsCalidadPerspectiva.Rules.Add(r99);
				fsCalidadPerspectiva.Rules.Add(r100);
				fsCalidadPerspectiva.Rules.Add(r101);
				fsCalidadPerspectiva.Rules.Add(r102);
				fsCalidadPerspectiva.Rules.Add(r103);
				fsCalidadPerspectiva.Rules.Add(r104);
				fsCalidadPerspectiva.Rules.Add(r105);
				fsCalidadPerspectiva.Rules.Add(r106);
				fsCalidadPerspectiva.Rules.Add(r107);
				fsCalidadPerspectiva.Rules.Add(r108);
				fsCalidadPerspectiva.Rules.Add(r109);
				fsCalidadPerspectiva.Rules.Add(r110);
				fsCalidadPerspectiva.Rules.Add(r111);
				fsCalidadPerspectiva.Rules.Add(r112);
				fsCalidadPerspectiva.Rules.Add(r113);
				fsCalidadPerspectiva.Rules.Add(r114);
				fsCalidadPerspectiva.Rules.Add(r115);
				fsCalidadPerspectiva.Rules.Add(r116);
				fsCalidadPerspectiva.Rules.Add(r117);
				fsCalidadPerspectiva.Rules.Add(r118);
				fsCalidadPerspectiva.Rules.Add(r119);
				fsCalidadPerspectiva.Rules.Add(r120);
				fsCalidadPerspectiva.Rules.Add(r121);
				fsCalidadPerspectiva.Rules.Add(r122);
				fsCalidadPerspectiva.Rules.Add(r123);
				fsCalidadPerspectiva.Rules.Add(r124);


			} catch (Exception ex)
			{
				Console.WriteLine(string.Format("Parsing exception: {0}", ex.Message));

				return null;
			}

			return fsCalidadPerspectiva;
		}


		public double obtenerCalidadPerspectiva(List<double> valores)
		{
			if (_fsCalidadPerspectiva == null)
			{
				_fsCalidadPerspectiva = SistemaCalidadPerspectiva();
				if (_fsCalidadPerspectiva == null)
				{
					return -1;
				}
			}

			//Antecedentes
			FuzzyVariable fvFuncionabilidad = _fsCalidadPerspectiva.InputByName("funcionalidad");
			FuzzyVariable fvUsabilidad = _fsCalidadPerspectiva.InputByName("usabilidad");
			FuzzyVariable fvMantenibilidad = _fsCalidadPerspectiva.InputByName("mantenibilidad");

			//Consecuente
			FuzzyVariable fvCalidadPerspectiva = _fsCalidadPerspectiva.InputByName("calidad_producto");

			Dictionary<FuzzyVariable, double> inputValues = new Dictionary<FuzzyVariable, double>();
			inputValues.Add(fvFuncionabilidad, valores[0]);
			inputValues.Add(fvUsabilidad, valores[1]);
			inputValues.Add(fvMantenibilidad, valores[2]);

			Dictionary<FuzzyVariable, double> resultado = _fsCalidadPerspectiva.Calculate(inputValues);

			if (resultado[fvCalidadPerspectiva].ToString("f1").Equals("NeuN"))
			{
				Console.WriteLine("Valor de calidad perspectiva es incorrecto");
				return -1;
			} else
			{
				foreach (KeyValuePair<FuzzyVariable, double> result in resultado)
				{
					Console.WriteLine("Resultado: " + result.Key + ": " + result.Value);
				}
				return resultado[fvCalidadPerspectiva];
			}

		}

	

	}
}
