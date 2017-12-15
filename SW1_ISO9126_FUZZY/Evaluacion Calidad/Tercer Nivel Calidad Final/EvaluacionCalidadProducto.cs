using AI.Fuzzy.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Evaluacion_Calidad.Tercer_Nivel_Calidad_Final
{
	public class EvaluacionCalidadProducto
	{

		private MamdaniFuzzySystem _fsCalidadProducto = null;

		private MamdaniFuzzySystem SistemaCalidadProducto()
		{
			MamdaniFuzzySystem fsCalidadProducto = new MamdaniFuzzySystem();

			FuzzyVariable fvCalidadInterna = new FuzzyVariable("calidad_interna", 0.0, 1.0);
			fvCalidadInterna.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadProducto.Input.Add(fvCalidadInterna);

			FuzzyVariable fvCalidadExterna = new FuzzyVariable("calidad_externa", 0.0, 1.0);
			fvCalidadInterna.Terms.Add(new FuzzyTerm("no_tiene", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("baja", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("alta", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("muy_alta", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadProducto.Input.Add(fvCalidadInterna);

			FuzzyVariable fvCalidadProducto = new FuzzyVariable("calidad_final", 0.0, 1.0);
			fvCalidadInterna.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
			fvCalidadInterna.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
			fsCalidadProducto.Output.Add(fvCalidadInterna);

			try
			{
				MamdaniFuzzyRule r0 = fsCalidadProducto.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is no_tiene) then calidad_final is muy_mala");
				MamdaniFuzzyRule r1 = fsCalidadProducto.ParseRule("if (calidad_interna is mala) and (calidad_externa is no_tiene) then calidad_final is muy_mala");
				MamdaniFuzzyRule r2 = fsCalidadProducto.ParseRule("if (calidad_interna is regular) and (calidad_externa is no_tiene) then calidad_final is mala");
				MamdaniFuzzyRule r3 = fsCalidadProducto.ParseRule("if (calidad_interna is buena) and (calidad_externa is no_tiene) then calidad_final is mala");
				MamdaniFuzzyRule r4 = fsCalidadProducto.ParseRule("if (calidad_interna is excelente) and (calidad_externa is no_tiene) then calidad_final is regular");
				MamdaniFuzzyRule r5 = fsCalidadProducto.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is baja) then calidad_final is muy_mala");
				MamdaniFuzzyRule r6 = fsCalidadProducto.ParseRule("if (calidad_interna is mala) and (calidad_externa is baja) then calidad_final is mala");
				MamdaniFuzzyRule r7 = fsCalidadProducto.ParseRule("if (calidad_interna is regular) and (calidad_externa is baja) then calidad_final is mala");
				MamdaniFuzzyRule r8 = fsCalidadProducto.ParseRule("if (calidad_interna is buena) and (calidad_externa is baja) then calidad_final is regular");
				MamdaniFuzzyRule r9 = fsCalidadProducto.ParseRule("if (calidad_interna is excelente) and (calidad_externa is baja) then calidad_final is regular");
				MamdaniFuzzyRule r10 = fsCalidadProducto.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is regular) then calidad_final is mala");
				MamdaniFuzzyRule r11 = fsCalidadProducto.ParseRule("if (calidad_interna is mala) and (calidad_externa is regular) then calidad_final is mala");
				MamdaniFuzzyRule r12 = fsCalidadProducto.ParseRule("if (calidad_interna is regular) and (calidad_externa is regular) then calidad_final is regular");
				MamdaniFuzzyRule r13 = fsCalidadProducto.ParseRule("if (calidad_interna is buena) and (calidad_externa is regular) then calidad_final is regular");
				MamdaniFuzzyRule r14 = fsCalidadProducto.ParseRule("if (calidad_interna is excelente) and (calidad_externa is regular) then calidad_final is buena");
				MamdaniFuzzyRule r15 = fsCalidadProducto.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is alta) then calidad_final is mala");
				MamdaniFuzzyRule r16 = fsCalidadProducto.ParseRule("if (calidad_interna is mala) and (calidad_externa is alta) then calidad_final is regular");
				MamdaniFuzzyRule r17 = fsCalidadProducto.ParseRule("if (calidad_interna is regular) and (calidad_externa is alta) then calidad_final is regular");
				MamdaniFuzzyRule r18 = fsCalidadProducto.ParseRule("if (calidad_interna is buena) and (calidad_externa is alta) then calidad_final is buena");
				MamdaniFuzzyRule r19 = fsCalidadProducto.ParseRule("if (calidad_interna is excelente) and (calidad_externa is alta) then calidad_final is buena");
				MamdaniFuzzyRule r20 = fsCalidadProducto.ParseRule("if (calidad_interna is muy_mala) and (calidad_externa is muy_alta) then calidad_final is regular");
				MamdaniFuzzyRule r21 = fsCalidadProducto.ParseRule("if (calidad_interna is mala) and (calidad_externa is muy_alta) then calidad_final is regular");
				MamdaniFuzzyRule r22 = fsCalidadProducto.ParseRule("if (calidad_interna is regular) and (calidad_externa is muy_alta) then calidad_final is buena");
				MamdaniFuzzyRule r23 = fsCalidadProducto.ParseRule("if (calidad_interna is buena) and (calidad_externa is muy_alta) then calidad_final is buena");
				MamdaniFuzzyRule r24 = fsCalidadProducto.ParseRule("if (calidad_interna is excelente) and (calidad_externa is muy_alta) then calidad_final is excelente");

				fsCalidadProducto.Rules.Add(r0);
				fsCalidadProducto.Rules.Add(r1);
				fsCalidadProducto.Rules.Add(r2);
				fsCalidadProducto.Rules.Add(r3);
				fsCalidadProducto.Rules.Add(r4);
				fsCalidadProducto.Rules.Add(r5);
				fsCalidadProducto.Rules.Add(r6);
				fsCalidadProducto.Rules.Add(r7);
				fsCalidadProducto.Rules.Add(r8);
				fsCalidadProducto.Rules.Add(r9);
				fsCalidadProducto.Rules.Add(r10);
				fsCalidadProducto.Rules.Add(r11);
				fsCalidadProducto.Rules.Add(r12);
				fsCalidadProducto.Rules.Add(r13);
				fsCalidadProducto.Rules.Add(r14);
				fsCalidadProducto.Rules.Add(r15);
				fsCalidadProducto.Rules.Add(r16);
				fsCalidadProducto.Rules.Add(r17);
				fsCalidadProducto.Rules.Add(r18);
				fsCalidadProducto.Rules.Add(r19);
				fsCalidadProducto.Rules.Add(r20);
				fsCalidadProducto.Rules.Add(r21);
				fsCalidadProducto.Rules.Add(r22);
				fsCalidadProducto.Rules.Add(r23);
				fsCalidadProducto.Rules.Add(r24);
			} catch (Exception ex)
			{
				Console.WriteLine(string.Format("Parsing exception: {0}", ex.Message));

				return null;
			}

			return fsCalidadProducto;
		}

		public double obtenerCalidadProducto(List<double> valores)
		{
			if (_fsCalidadProducto == null)
			{
				_fsCalidadProducto = SistemaCalidadProducto();
				if (_fsCalidadProducto == null)
				{
					return -1;
				}
			}

			//Antecedentes
			FuzzyVariable fvCalidadInterna = _fsCalidadProducto.InputByName("calidad_interna");
			FuzzyVariable fvCalidadExterna = _fsCalidadProducto.InputByName("calidad_externa");

			//Consecuente
			FuzzyVariable fvCalidadProducto = _fsCalidadProducto.InputByName("calidad_final");

			Dictionary<FuzzyVariable, double> inputValues = new Dictionary<FuzzyVariable, double>();
			inputValues.Add(fvCalidadInterna, valores[0]);
			inputValues.Add(fvCalidadExterna, valores[1]);

			Dictionary<FuzzyVariable, double> resultado = _fsCalidadProducto.Calculate(inputValues);

			if (resultado[fvCalidadProducto].ToString("f1").Equals("NeuN"))
			{
				Console.WriteLine("Valor de calidad final es incorrecto");
				return -1;
			} else
			{
				foreach (KeyValuePair<FuzzyVariable, double> result in resultado)
				{
					Console.WriteLine("Resultado: " + result.Key + ": " + result.Value);
				}
				return resultado[fvCalidadProducto];
			}
		}

	}
}
