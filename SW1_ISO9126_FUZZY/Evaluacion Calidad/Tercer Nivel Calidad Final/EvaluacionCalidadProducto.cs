using AI.Fuzzy.Library;
using System;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final
{
	public class EvaluacionCalidadProducto
	{

		private MamdaniFuzzySystem _fsCalidadFinal = null;

		private MamdaniFuzzySystem SistemaCalidadFinal()
		{
			MamdaniFuzzySystem fsCalidadFinal = new MamdaniFuzzySystem();

			FuzzyVariable fvCalidadInterna = new FuzzyVariable("calidad_interna", 0.0, 1.0);
			fvCalidadInterna.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadFinal.Input.Add(fvCalidadInterna);

			FuzzyVariable fvCalidadExterna = new FuzzyVariable("calidad_externa", 0.0, 1.0);
			fvCalidadExterna.Terms.Add(new FuzzyTerm("no_tiene", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvCalidadExterna.Terms.Add(new FuzzyTerm("baja", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvCalidadExterna.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvCalidadExterna.Terms.Add(new FuzzyTerm("alta", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvCalidadExterna.Terms.Add(new FuzzyTerm("muy_alta", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadFinal.Input.Add(fvCalidadExterna);

			FuzzyVariable fvCalidadFinal = new FuzzyVariable("calidad_final", 0.0, 1.0);
			fvCalidadFinal.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvCalidadFinal.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvCalidadFinal.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvCalidadFinal.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvCalidadFinal.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadFinal.Output.Add(fvCalidadFinal);

			try
			{
				MamdaniFuzzyRule r0 = fsCalidadFinal.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is no_tiene) then calidad_final is muy_mala");
				MamdaniFuzzyRule r1 = fsCalidadFinal.ParseRule("if (calidad_interna is mala) and (calidad_externa is no_tiene) then calidad_final is muy_mala");
				MamdaniFuzzyRule r2 = fsCalidadFinal.ParseRule("if (calidad_interna is regular) and (calidad_externa is no_tiene) then calidad_final is mala");
				MamdaniFuzzyRule r3 = fsCalidadFinal.ParseRule("if (calidad_interna is buena) and (calidad_externa is no_tiene) then calidad_final is mala");
				MamdaniFuzzyRule r4 = fsCalidadFinal.ParseRule("if (calidad_interna is excelente) and (calidad_externa is no_tiene) then calidad_final is regular");
				MamdaniFuzzyRule r5 = fsCalidadFinal.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is baja) then calidad_final is muy_mala");
				MamdaniFuzzyRule r6 = fsCalidadFinal.ParseRule("if (calidad_interna is mala) and (calidad_externa is baja) then calidad_final is mala");
				MamdaniFuzzyRule r7 = fsCalidadFinal.ParseRule("if (calidad_interna is regular) and (calidad_externa is baja) then calidad_final is mala");
				MamdaniFuzzyRule r8 = fsCalidadFinal.ParseRule("if (calidad_interna is buena) and (calidad_externa is baja) then calidad_final is regular");
				MamdaniFuzzyRule r9 = fsCalidadFinal.ParseRule("if (calidad_interna is excelente) and (calidad_externa is baja) then calidad_final is regular");
				MamdaniFuzzyRule r10 = fsCalidadFinal.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is regular) then calidad_final is mala");
				MamdaniFuzzyRule r11 = fsCalidadFinal.ParseRule("if (calidad_interna is mala) and (calidad_externa is regular) then calidad_final is mala");
				MamdaniFuzzyRule r12 = fsCalidadFinal.ParseRule("if (calidad_interna is regular) and (calidad_externa is regular) then calidad_final is regular");
				MamdaniFuzzyRule r13 = fsCalidadFinal.ParseRule("if (calidad_interna is buena) and (calidad_externa is regular) then calidad_final is regular");
				MamdaniFuzzyRule r14 = fsCalidadFinal.ParseRule("if (calidad_interna is excelente) and (calidad_externa is regular) then calidad_final is buena");
				MamdaniFuzzyRule r15 = fsCalidadFinal.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is alta) then calidad_final is mala");
				MamdaniFuzzyRule r16 = fsCalidadFinal.ParseRule("if (calidad_interna is mala) and (calidad_externa is alta) then calidad_final is regular");
				MamdaniFuzzyRule r17 = fsCalidadFinal.ParseRule("if (calidad_interna is regular) and (calidad_externa is alta) then calidad_final is regular");
				MamdaniFuzzyRule r18 = fsCalidadFinal.ParseRule("if (calidad_interna is buena) and (calidad_externa is alta) then calidad_final is buena");
				MamdaniFuzzyRule r19 = fsCalidadFinal.ParseRule("if (calidad_interna is excelente) and (calidad_externa is alta) then calidad_final is buena");
				MamdaniFuzzyRule r20 = fsCalidadFinal.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is muy_alta) then calidad_final is regular");
				MamdaniFuzzyRule r21 = fsCalidadFinal.ParseRule("if (calidad_interna is mala) and (calidad_externa is muy_alta) then calidad_final is regular");
				MamdaniFuzzyRule r22 = fsCalidadFinal.ParseRule("if (calidad_interna is regular) and (calidad_externa is muy_alta) then calidad_final is buena");
				MamdaniFuzzyRule r23 = fsCalidadFinal.ParseRule("if (calidad_interna is buena) and (calidad_externa is muy_alta) then calidad_final is buena");
				MamdaniFuzzyRule r24 = fsCalidadFinal.ParseRule("if (calidad_interna is excelente) and (calidad_externa is muy_alta) then calidad_final is excelente");

				fsCalidadFinal.Rules.Add(r0);
				fsCalidadFinal.Rules.Add(r1);
				fsCalidadFinal.Rules.Add(r2);
				fsCalidadFinal.Rules.Add(r3);
				fsCalidadFinal.Rules.Add(r4);
				fsCalidadFinal.Rules.Add(r5);
				fsCalidadFinal.Rules.Add(r6);
				fsCalidadFinal.Rules.Add(r7);
				fsCalidadFinal.Rules.Add(r8);
				fsCalidadFinal.Rules.Add(r9);
				fsCalidadFinal.Rules.Add(r10);
				fsCalidadFinal.Rules.Add(r11);
				fsCalidadFinal.Rules.Add(r12);
				fsCalidadFinal.Rules.Add(r13);
				fsCalidadFinal.Rules.Add(r14);
				fsCalidadFinal.Rules.Add(r15);
				fsCalidadFinal.Rules.Add(r16);
				fsCalidadFinal.Rules.Add(r17);
				fsCalidadFinal.Rules.Add(r18);
				fsCalidadFinal.Rules.Add(r19);
				fsCalidadFinal.Rules.Add(r20);
				fsCalidadFinal.Rules.Add(r21);
				fsCalidadFinal.Rules.Add(r22);
				fsCalidadFinal.Rules.Add(r23);
				fsCalidadFinal.Rules.Add(r24);
			} catch (Exception ex)
			{
				Console.WriteLine(string.Format("Parsing exception: {0}", ex.Message));

				return null;
			}

			return fsCalidadFinal;
		}

		public double obtenerCalidadProducto(List<double> valores)
		{
			if (_fsCalidadFinal == null)
			{
				_fsCalidadFinal = SistemaCalidadFinal();
				if (_fsCalidadFinal == null)
				{
					return -1;
				}
			}

			//Antecedentes
			FuzzyVariable fvCalidadInterna = _fsCalidadFinal.InputByName("calidad_interna");
			FuzzyVariable fvCalidadExterna = _fsCalidadFinal.InputByName("calidad_externa");

			//Consecuente
			FuzzyVariable fvCalidadFinal = _fsCalidadFinal.OutputByName("calidad_final");

			Dictionary<FuzzyVariable, double> inputValues = new Dictionary<FuzzyVariable, double>();
			inputValues.Add(fvCalidadInterna, valores[0]);
			inputValues.Add(fvCalidadExterna, valores[1]);

			Dictionary<FuzzyVariable, double> resultado = _fsCalidadFinal.Calculate(inputValues);

			if (resultado[fvCalidadFinal].ToString("f1").Equals("NeuN"))
			{
				Console.WriteLine("Valor de calidad final es incorrecto");
				return -1;
			} else
			{
				foreach (KeyValuePair<FuzzyVariable, double> result in resultado)
				{
					Console.WriteLine("Resultado: " + result.Key + ": " + result.Value);
				}
				return resultado[fvCalidadFinal];
			}
		}

	}
}
