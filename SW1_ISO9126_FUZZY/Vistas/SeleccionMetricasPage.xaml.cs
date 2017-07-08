using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace SW1_ISO9126_FUZZY.Vistas {
    /// <summary>
    /// Lógica de interacción para ConfiguracionMetricasPage.xaml
    /// </summary>
    public partial class SeleccionMetricasPage : Page {

        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;

        public SeleccionMetricasPage()
        {
            InitializeComponent();
            cargarJsonMetricas();
        }

        // Accesores

        public JFuncionabilidad FunInt { get => funInt; set => funInt = value; }
        public JFuncionabilidad FunExt { get => funExt; set => funExt = value; }
        public JUsabilidad UsaInt { get => usaInt; set => usaInt = value; }
        public JUsabilidad UsaExt { get => usaExt; set => usaExt = value; }
        public JMantenibilidad ManInt { get => manInt; set => manInt = value; }
        public JMantenibilidad ManExt { get => manExt; set => manExt = value; }


        // Metodos

        private void cargarJsonMetricas()
        {
            funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
            funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
            usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
            usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
            manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
            manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));

        }


        private void cargarMetrica (JMetrica metrica)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.Add("proposito", typeof(string));
            dtColumnas.Columns.Add("formula", typeof(string));
            dataGridDetalleMetrica.ItemsSource = dtColumnas.DefaultView;
            dataGridDetalleMetrica.Columns[0].Header = "Propósito de la métrica";
            dataGridDetalleMetrica.Columns[1].Header = "Formula";

            int preguntas = 0;
            int formulas = 0;

            lblIDMetrica.Content = metrica.Id;
            lblNombreMetrica.Content = metrica.Nombre;
            txbkMetodo.Text = metrica.Metodo;

            preguntas = metrica.Proposito.Length;
            formulas = metrica.Formula.Length;
            
            /*
            MessageBox.Show("preguntas: " + preguntas);
            MessageBox.Show("formulas: " + formulas);
            MessageBox.Show(metrica.ToString());
            */

            if (preguntas == formulas)
            {
                if (preguntas == 1 && preguntas == 1)
                {
                    dtColumnas.Rows.Add(new object[] { metrica.Proposito[0], metrica.Formula[0]});
                }
                else // Cada pregunta su formula
                {
                    for (int i = 0; i < preguntas; i++)
                    {
                        dtColumnas.Rows.Add(new object[] { metrica.Proposito[i], metrica.Formula[i]});
                    }
                }
            }
            else // N preguntas, unica formulas
            {
                for (int i = 0; i < preguntas; i++)
                {
                    dtColumnas.Rows.Add(new object[] { metrica.Proposito[i], metrica.Formula[0]});
                }
            }


            for (int i = 0; i< metrica.Desc_param.Length; i++)
            {
                sb.AppendLine(metrica.Desc_param[i]);
            }

            txbkParam.Text = sb.ToString();
        }


        private void cargarFuncionabilidadInterna()
        {

            tblckTituloCaracteristica.Text = "Funcionabilidad Interna";
            lblPerpectiva.Content = "Interna";
            lblSubcaracterística.Content = UsaInt.Subcaracteristicas[0];

            ArrayList metricas = new ArrayList();

            
            metricas.Add(funInt.Adecuacion[0]);
           

            cargarMetrica(funInt.Adecuacion[0]);

            //return metricas;
        }


        // Eventos menu flotante

        private void btnFuncInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Funcionabilidad Interna";
            lblPerpectiva.Content = "Interna";
            cargarFuncionabilidadInterna();


        }

        private void btnUsabInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Usabilidad Interna";
            lblPerpectiva.Content = "Interna";



        }

        private void btnMantInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Mantenibilidad Interna";
            lblPerpectiva.Content = "Interna";



        }

        private void btnFuncExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Funcionalidad Externa";
            lblPerpectiva.Content = "Externa";


        }


        private void btnUsabExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Usabilidad Externa";
            lblPerpectiva.Content = "Externa";


        }


        private void btnMantExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Mantenibilidad Externa";
            lblPerpectiva.Content = "Externa";


        }


        // Evento checkbox

        private void chckDetallesMetricas_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            expDetMet.IsExpanded = true;
        }

        private void chckDetallesMetricas_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            expDetMet.IsExpanded = false;
        }

        // Eventos botones

        private void btnAnterior_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //cargarusabilidadInterna();
        }

        private void btnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btnTerminar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuMetricas.IsOpen = true;
        }

        // Revisar metricas

        private string infoMetrica(string nombre, string perspectiva, JMetrica[] subcaracateristica)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("SubCaracteristica: " + nombre);
            sb.AppendLine("Perspectiva: " + perspectiva);
            sb.AppendLine("número metricas: " + subcaracateristica.Length);
            sb.AppendLine("\n");

            for (int i = 0; i < subcaracateristica.Length; i++)
            {
                sb.AppendLine("ID: " + subcaracateristica[i].Id);
                sb.AppendLine("Nombre: " + subcaracateristica[i].Nombre);
                sb.AppendLine("Metodo: " + subcaracateristica[i].Metodo.Length);
                sb.AppendLine("Formula: " + subcaracateristica[i].Formula.Length);

                if (subcaracateristica[i].Proposito.Length > 1 || subcaracateristica[i].Formula.Length > 1)
                {
                    sb.AppendLine("<========================== METRICA ESPECIAL ==========================>");
                }

                sb.AppendLine("\n");
            }

            sb.AppendLine("\n");

            return sb.ToString();
        }


        private void crearArchivoEstadoMetrica()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("\n---------------------------- Funcionalidad Interna ----------------------------\n");
            sb.AppendLine(infoMetrica("Adecuacion", "Interna", funInt.Adecuacion));
            sb.AppendLine(infoMetrica("Exactitud", "Interna", funInt.Exactitud));
            sb.AppendLine(infoMetrica("Interoperabilidad", "Interna", funInt.Interoperabilidad));
            sb.AppendLine(infoMetrica("SeguridadAcceso", "Interna", funInt.SeguridadAcceso));
            sb.AppendLine(infoMetrica("CumplimientoFuncional", "Interna", funInt.CumplimientoFuncional));
            sb.AppendLine("\n---------------------------- Usabilidad Interna ----------------------------\n");
            sb.AppendLine(infoMetrica("Comprensibilidad", "Interna", usaInt.Comprensibilidad));
            sb.AppendLine(infoMetrica("Aprendizaje", "Interna", usaInt.Aprendizaje));
            sb.AppendLine(infoMetrica("Operabilidad", "Interna", usaInt.Operabilidad));
            sb.AppendLine(infoMetrica("Atractividad", "Interna", usaInt.Atractividad));
            sb.AppendLine(infoMetrica("CumplimientoUsabilidad", "Interna", usaInt.CumplimientoUsabilidad));
            sb.AppendLine("\n---------------------------- Mantenibilidad Interna ----------------------------\n");
            sb.AppendLine(infoMetrica("Analizabilidad", "Interna", manInt.Analizabilidad));
            sb.AppendLine(infoMetrica("Modificabilidad", "Interna", manInt.Modificabilidad));
            sb.AppendLine(infoMetrica("Estabilidad", "Interna", manInt.Estabilidad));
            sb.AppendLine(infoMetrica("Testeabilidad", "Interna", manInt.Testeabilidad));
            sb.AppendLine(infoMetrica("CumplimientoMantenibilidad", "Interna", manInt.CumplimientoMantenibilidad));
            sb.AppendLine("\n---------------------------- Funcionalidad Externa ----------------------------\n");
            sb.AppendLine(infoMetrica("Adecuacion", "Externa", funExt.Adecuacion));
            sb.AppendLine(infoMetrica("Exactitud", "Externa", funExt.Exactitud));
            sb.AppendLine(infoMetrica("Interoperabilidad", "Externa", funExt.Interoperabilidad));
            sb.AppendLine(infoMetrica("SeguridadAcceso", "Externa", funExt.SeguridadAcceso));
            sb.AppendLine(infoMetrica("CumplimientoFuncional", "Externa", funExt.CumplimientoFuncional));
            sb.AppendLine("\n---------------------------- Usabilidad Externa ----------------------------\n");
            sb.AppendLine(infoMetrica("Comprensibilidad", "Externa", usaExt.Comprensibilidad));
            sb.AppendLine(infoMetrica("Aprendizaje", "Externa", usaExt.Aprendizaje));
            sb.AppendLine(infoMetrica("Operabilidad", "Externa", usaExt.Operabilidad));
            sb.AppendLine(infoMetrica("Atractividad", "Externa", usaExt.Atractividad));
            sb.AppendLine(infoMetrica("CumplimientoUsabilidad", "Externa", usaExt.CumplimientoUsabilidad));
            sb.AppendLine("\n---------------------------- Mantenibilidad Externa ----------------------------\n");
            sb.AppendLine(infoMetrica("Analizabilidad", "Externa", manExt.Analizabilidad));
            sb.AppendLine(infoMetrica("Modificabilidad", "Externa", manExt.Modificabilidad));
            sb.AppendLine(infoMetrica("Estabilidad", "Externa", manExt.Estabilidad));
            sb.AppendLine(infoMetrica("Testeabilidad", "Externa", manExt.Testeabilidad));
            sb.AppendLine(infoMetrica("CumplimientoMantenibilidad", "Externa", manExt.CumplimientoMantenibilidad));


            // crear el path
            var archivo = "C:\\Users\\Gonzalo Santander\\Documents\\Visual Studio 2017\\Projects\\SW1_ISO9126_FUZZY\\SW1_ISO9126_FUZZY\\bin\\Debug\\Estado.txt";

            // eliminar el fichero si ya existe
            if (File.Exists(archivo))
                File.Delete(archivo);

            // crear el fichero
            using (var fileStream = File.Create(archivo))
            {
                var texto = new UTF8Encoding(true).GetBytes(sb.ToString());
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();
            }

        }
    }
}
