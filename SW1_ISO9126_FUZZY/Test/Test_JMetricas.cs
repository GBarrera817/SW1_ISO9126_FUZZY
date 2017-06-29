using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SW1_ISO9126_FUZZY.JSON;

namespace SW1_ISO9126_FUZZY.Test
{
    public class Test_JMetricas
    {
        public static void leerJMetricas(JMetrica[] subcaracteristica)
        {
            for (int i = 0; i < subcaracteristica.Length; i++)
            {
                Console.WriteLine("");

                Console.WriteLine("ID: " + subcaracteristica[i].Id);
                Console.WriteLine("Nombre: " + subcaracteristica[i].Nombre);

                for (int j = 0; j < subcaracteristica[i].Proposito.Length; j++)
                {
                    Console.WriteLine(j + ") Proposito: " + subcaracteristica[i].Proposito[j]);
                }

                for (int k = 0; k < subcaracteristica[i].Metodo.Length; k++)
                {
                    Console.WriteLine(k + ") Metodo: " + subcaracteristica[i].Metodo[k]);
                }

                for (int l = 0; l < subcaracteristica[i].Formula.Length; l++)
                {
                    Console.WriteLine(l + ") Formula: " + subcaracteristica[i].Formula[l]);
                }

                Console.WriteLine("Peor valor: " + subcaracteristica[i].Peor_valor);
                Console.WriteLine("Mejor valor: " + subcaracteristica[i].Mejor_valor);

                for (int m = 0; m < subcaracteristica[i].Parametros.Length; m++)
                {
                    Console.WriteLine(m + ") Parametro: " + subcaracteristica[i].Parametros[m]);
                }

                for (int n = 0; n < subcaracteristica[i].Desc_param.Length; n++)
                {
                    Console.WriteLine(n + ") Descripcion: " + subcaracteristica[i].Desc_param[n]);
                }
            }
        }


        public static void testFuncionabilidad (JFuncionabilidad funcionabilidad)
        {
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Funcionabilidad");
            Console.WriteLine("Perspectiva: " + funcionabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Adecuacion");
            leerJMetricas(funcionabilidad.Adecuacion);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Funcionabilidad");
            Console.WriteLine("Perspectiva: " + funcionabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Exactitud");
            leerJMetricas(funcionabilidad.Exactitud);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Funcionabilidad");
            Console.WriteLine("Perspectiva: " + funcionabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Interoperabilidad");
            leerJMetricas(funcionabilidad.Interoperabilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Funcionabilidad");
            Console.WriteLine("Perspectiva: " + funcionabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Seguridad Acceso");
            leerJMetricas(funcionabilidad.SeguridadAcceso);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Funcionabilidad");
            Console.WriteLine("Perspectiva: " + funcionabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Cumplimiento Funcional");
            leerJMetricas(funcionabilidad.CumplimientoFuncional);
        }


        public static void testMantenibilidad(JMantenibilidad mantenibilidad)
        {
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Mantenibilidad");
            Console.WriteLine("Perspectiva: " + mantenibilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Analizabilidad");
            leerJMetricas(mantenibilidad.Analizabilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Mantenibilidad");
            Console.WriteLine("Perspectiva: " + mantenibilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Modificabilidad");
            leerJMetricas(mantenibilidad.Modificabilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Mantenibilidad");
            Console.WriteLine("Perspectiva: " + mantenibilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Estabilidad");
            leerJMetricas(mantenibilidad.Estabilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Mantenibilidad");
            Console.WriteLine("Perspectiva: " + mantenibilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Testeabilidad");
            leerJMetricas(mantenibilidad.Testeabilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Mantenibilidad");
            Console.WriteLine("Perspectiva: " + mantenibilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Cumplimiento Mantenibilidad");
            leerJMetricas(mantenibilidad.CumplimientoMantenibilidad);
        }


        public static void testUsabilidad(JUsabilidad usabilidad)
        {
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Usabilidad");
            Console.WriteLine("Perspectiva: " + usabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Comprensibilidad");
            leerJMetricas(usabilidad.Comprensibilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Usabilidad");
            Console.WriteLine("Perspectiva: " + usabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Aprendizaje");
            leerJMetricas(usabilidad.Aprendizaje);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Usabilidad");
            Console.WriteLine("Perspectiva: " + usabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Operabilidad");
            leerJMetricas(usabilidad.Operabilidad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Usabilidad");
            Console.WriteLine("Perspectiva: " + usabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Atractividad");
            leerJMetricas(usabilidad.Atractividad);

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Caracteristica: Usabilidad");
            Console.WriteLine("Perspectiva: " + usabilidad.Perspectiva);
            Console.WriteLine("Subcaracteristica: Cumplimiento Usabilidad");
            leerJMetricas(usabilidad.CumplimientoUsabilidad);
        }


        public static void Main(string[] args)
        {
            // Lee el archivo en una cadena y deserializa JSON en un tipo
            // Object objeto = JsonConvert.DeserializeObject<Object>(File.ReadAllText(@"archivo.json"));

            JFuncionabilidad Finterna = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
            testFuncionabilidad(Finterna);
            Console.ReadKey();

            JFuncionabilidad Fexterna = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
            testFuncionabilidad(Fexterna);
            Console.ReadKey();

            JMantenibilidad Minterna = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
            testMantenibilidad(Minterna);
            Console.ReadKey();

            JMantenibilidad Mexterna = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));
            testMantenibilidad(Mexterna);
            Console.ReadKey();

            JUsabilidad Uinterna = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
            testUsabilidad(Uinterna);
            Console.ReadKey();

            JUsabilidad UExterna = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
            testUsabilidad(UExterna);
            Console.ReadKey();

        }
    }
}
