using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Archivos_configuracion
{
    public class JRevisar
    {
        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;


        public JRevisar()
        {
            cargarJsonMetricas();
        }


        private void cargarJsonMetricas()
        {
            funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
            funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
            usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
            usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
            manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
            manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));

        }


        // Revisar metricas

        private string infoMetrica(string nombre, string perspectiva, JMetrica[] subcaracateristica)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int contadorEspecial = 0;

            sb.AppendLine("\n+++++++++++++++++++++++++ "+nombre+" +++++++++++++++++++++++++\n");

            sb.AppendLine("Perspectiva: " + perspectiva);
            sb.AppendLine("número metricas: " + subcaracateristica.Length);
            sb.AppendLine("\n");

            for (int i = 0; i < subcaracateristica.Length; i++)
            {
                contadorEspecial = 0;

                if (subcaracateristica[i].Proposito.Length == 0 || subcaracateristica[i].Proposito.Length > 3)
                    contadorEspecial++;

                if(subcaracateristica[i].Formula.Length == 0 || subcaracateristica[i].Formula.Length > 1)
                    contadorEspecial++;

                if (subcaracateristica[i].Parametros.Length == 0 || subcaracateristica[i].Parametros.Length > 2)
                    contadorEspecial++;

                sb.AppendLine("\n");

                if (contadorEspecial != 0)
                {
                    sb.AppendLine("<<<<<<<<<<<<<<<<<<<<<<<<< METRICA ESPECIAL =========================");       
                }

                sb.AppendLine("ID: " + subcaracateristica[i].Id);
                sb.AppendLine("Nombre: " + subcaracateristica[i].Nombre);
                sb.AppendLine("Proposito: " + subcaracateristica[i].Proposito.Length);
                sb.AppendLine("Formula: " + subcaracateristica[i].Formula.Length);
                sb.AppendLine("Parametros: " + subcaracateristica[i].Parametros.Length);

                if (contadorEspecial != 0)
                {
                    sb.AppendLine("========================= METRICA ESPECIAL >>>>>>>>>>>>>>>>>>>>>>>>>");
                }

                sb.AppendLine("\n");
            }

            sb.AppendLine("\n");

            return sb.ToString();
        }


        private string crearEstadoMetrica()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("\n************************* Funcionalidad Interna *************************\n");
            sb.AppendLine(infoMetrica("Adecuacion", "Interna", funInt.Adecuacion));
            sb.AppendLine(infoMetrica("Exactitud", "Interna", funInt.Exactitud));
            sb.AppendLine(infoMetrica("Interoperabilidad", "Interna", funInt.Interoperabilidad));
            sb.AppendLine(infoMetrica("SeguridadAcceso", "Interna", funInt.SeguridadAcceso));
            sb.AppendLine(infoMetrica("CumplimientoFuncional", "Interna", funInt.CumplimientoFuncional));
            sb.AppendLine("\n************************* Usabilidad Interna *************************\n");
            sb.AppendLine(infoMetrica("Comprensibilidad", "Interna", usaInt.Comprensibilidad));
            sb.AppendLine(infoMetrica("Aprendizaje", "Interna", usaInt.Aprendizaje));
            sb.AppendLine(infoMetrica("Operabilidad", "Interna", usaInt.Operabilidad));
            sb.AppendLine(infoMetrica("Atractividad", "Interna", usaInt.Atractividad));
            sb.AppendLine(infoMetrica("CumplimientoUsabilidad", "Interna", usaInt.CumplimientoUsabilidad));
            sb.AppendLine("\n************************* Mantenibilidad Interna *************************\n");
            sb.AppendLine(infoMetrica("Analizabilidad", "Interna", manInt.Analizabilidad));
            sb.AppendLine(infoMetrica("Modificabilidad", "Interna", manInt.Modificabilidad));
            sb.AppendLine(infoMetrica("Estabilidad", "Interna", manInt.Estabilidad));
            sb.AppendLine(infoMetrica("Testeabilidad", "Interna", manInt.Testeabilidad));
            sb.AppendLine(infoMetrica("CumplimientoMantenibilidad", "Interna", manInt.CumplimientoMantenibilidad));
            sb.AppendLine("\n************************* Funcionalidad Externa *************************\n");
            sb.AppendLine(infoMetrica("Adecuacion", "Externa", funExt.Adecuacion));
            sb.AppendLine(infoMetrica("Exactitud", "Externa", funExt.Exactitud));
            sb.AppendLine(infoMetrica("Interoperabilidad", "Externa", funExt.Interoperabilidad));
            sb.AppendLine(infoMetrica("SeguridadAcceso", "Externa", funExt.SeguridadAcceso));
            sb.AppendLine(infoMetrica("CumplimientoFuncional", "Externa", funExt.CumplimientoFuncional));
            sb.AppendLine("\n************************* Usabilidad Externa *************************\n");
            sb.AppendLine(infoMetrica("Comprensibilidad", "Externa", usaExt.Comprensibilidad));
            sb.AppendLine(infoMetrica("Aprendizaje", "Externa", usaExt.Aprendizaje));
            sb.AppendLine(infoMetrica("Operabilidad", "Externa", usaExt.Operabilidad));
            sb.AppendLine(infoMetrica("Atractividad", "Externa", usaExt.Atractividad));
            sb.AppendLine(infoMetrica("CumplimientoUsabilidad", "Externa", usaExt.CumplimientoUsabilidad));
            sb.AppendLine("\n************************* Mantenibilidad Externa *************************\n");
            sb.AppendLine(infoMetrica("Analizabilidad", "Externa", manExt.Analizabilidad));
            sb.AppendLine(infoMetrica("Modificabilidad", "Externa", manExt.Modificabilidad));
            sb.AppendLine(infoMetrica("Estabilidad", "Externa", manExt.Estabilidad));
            sb.AppendLine(infoMetrica("Testeabilidad", "Externa", manExt.Testeabilidad));
            sb.AppendLine(infoMetrica("CumplimientoMantenibilidad", "Externa", manExt.CumplimientoMantenibilidad));

            return sb.ToString();
        }


        public void crearArchivo(string nombre)
        {
            // crear el path
            var archivo = nombre;

            // eliminar el fichero si ya existe
            if (File.Exists(archivo))
                File.Delete(archivo);

            // crear el fichero
            using (var fileStream = File.Create(archivo))
            {
                var texto = new UTF8Encoding(true).GetBytes(crearEstadoMetrica());
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();
            }
        }


        public static void Main()
        {
            JRevisar revision = new JRevisar();

            revision.crearArchivo("EstadoMetricas.txt");
        }



        /*
         
         DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
        if(dialogResult == DialogResult.Yes)
        {
            //do something
        }
        else if (dialogResult == DialogResult.No)
        {
            //do something else
        }
         
         
         */
    }
}
