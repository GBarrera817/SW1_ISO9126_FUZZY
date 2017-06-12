using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Archivos {

    class Program {
        static void main(string[] args) {
            EvaluacionSoftwareJSON pba = new EvaluacionSoftwareJSON {
                EvaluacionSoftware = new EvaluacionSoftware {
                    Datos_sw = new Datos_Sw {
                        Nombre_sw = "Norton Antivirus",
                        Desarrolladores = new string[] { "Symantec" },
                        Descripcion_sw = "Es un producto desarrollado por la división \"Norton\" de la empresa Symantec",
                        Manual_usuario = true
                    },
                    Metricas_internas = new Metricas_Internas { },
                    Metricas_externas = new Metricas_Externas { },
                    Cantidad_respuestas = new int[] { 3, 5 },
                    Estado_modulos = new Estado_Modulos {
                        Funcionabilidad_interna = new int[] { 8, 30 },
                        Funcionabilidad_externa = new int[] { 5, 10 },
                        Usabilidad_interna = new int[] { 2, 8 },
                        Usabilidad_externa = new int[] { 6, 9 },
                        Mantenibilidad_interna = new int[] {4, 6},
                        Mantenibilidad_externa = new int[] { 7, 10 }
                    }
                }
            };

            
            string salida = JsonConvert.SerializeObject(pba, Formatting.Indented);

            Console.ReadLine();
        }
    }
}
