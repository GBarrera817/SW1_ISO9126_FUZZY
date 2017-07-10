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

        private ArrayList funcionalidadInterna;
        private ArrayList funcionalidadExterna;
        private ArrayList usabilidadInterna;
        private ArrayList usabilidadExterna;
        private ArrayList mantenibilidadInterna;
        private ArrayList mantenibilidadExterna;

        private int indexFunInt;
        private int indexFunExt;
        private int indexUsaInt;
        private int indexUsaExt;
        private int indexManint;
        private int indexManExt;

        private bool isFunIntAct;
        private bool isFunExtAct;
        private bool isUsaIntAct;
        private bool isUsaExtAct;
        private bool isManIntAct;
        private bool isManExtAct;

        public SeleccionMetricasPage()
        {
            InitializeComponent();
            inicializarEstadoCaracteristica();
            inicializarIndexListas();
            cargarJsonMetricas();
        }

        // Accesores

        public JFuncionabilidad FunInt { get => funInt; set => funInt = value; }
        public JFuncionabilidad FunExt { get => funExt; set => funExt = value; }
        public JUsabilidad UsaInt { get => usaInt; set => usaInt = value; }
        public JUsabilidad UsaExt { get => usaExt; set => usaExt = value; }
        public JMantenibilidad ManInt { get => manInt; set => manInt = value; }
        public JMantenibilidad ManExt { get => manExt; set => manExt = value; }

        public ArrayList FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public ArrayList FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public ArrayList UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public ArrayList UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public ArrayList MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }
        public ArrayList MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }


        // Metodos

        private void inicializarEstadoCaracteristica()
        {
            this.isFunIntAct = false;
            this.isFunExtAct = false;
            this.isUsaIntAct = false;
            this.isUsaExtAct = false;
            this.isManIntAct = false;
            this.isManExtAct = false;

        }

        private void inicializarIndexListas()
        {
            this.indexFunInt = 0;
            this.indexFunExt = 0;
            this.indexUsaInt = 0;
            this.indexUsaExt = 0;
            this.indexManint = 0;
            this.indexManExt = 0;

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

        // Cargar una metrica

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


        // Crear listas de metricas por caracteristicas

        private ArrayList cargarFuncionabilidad(JFuncionabilidad funcionalidad, string nombre, string perspectiva)
        {
            // Etiquetas pricipales 
            tblckTituloCaracteristica.Text = nombre;
            lblPerpectiva.Content = perspectiva;
            lblSubcaracterística.Content = funcionalidad.Subcaracteristicas[0];

            // Crear lista de todas las metricas de las caracteristicas
            ArrayList metricas = new ArrayList();

            for (int i = 0; i < funcionalidad.Adecuacion.Length; i++)
            {
                metricas.Add(funcionalidad.Adecuacion[i]);
            }

            for (int i = 0; i < funcionalidad.Exactitud.Length; i++)
            {
                metricas.Add(funcionalidad.Exactitud[i]);
            }

            for (int i = 0; i < funcionalidad.Interoperabilidad.Length; i++)
            {
                metricas.Add(funcionalidad.Interoperabilidad[i]);
            }

            for (int i = 0; i < funcionalidad.SeguridadAcceso.Length; i++)
            {
                metricas.Add(funcionalidad.SeguridadAcceso[i]);
            }

            for (int i = 0; i < funcionalidad.CumplimientoFuncional.Length; i++)
            {
                metricas.Add(funcionalidad.CumplimientoFuncional[i]);
            }

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(funcionalidad.Adecuacion[0]);

            return metricas;
        }


        private ArrayList cargarUsabilidad(JUsabilidad usabilidad, string nombre, string perspectiva)
        {
            // Etiquetas pricipales 
            tblckTituloCaracteristica.Text = nombre;
            lblPerpectiva.Content = perspectiva;
            lblSubcaracterística.Content = usabilidad.Subcaracteristicas[0];

            // Crear lista de todas las metricas de las caracteristicas
            ArrayList metricas = new ArrayList();

            for (int i = 0; i < usabilidad.Comprensibilidad.Length; i++)
            {
                metricas.Add(usabilidad.Comprensibilidad[i]);
            }

            for (int i = 0; i < usabilidad.Aprendizaje.Length; i++)
            {
                metricas.Add(usabilidad.Aprendizaje[i]);
            }

            for (int i = 0; i < usabilidad.Operabilidad.Length; i++)
            {
                metricas.Add(usabilidad.Operabilidad[i]);
            }

            for (int i = 0; i < usabilidad.Atractividad.Length; i++)
            {
                metricas.Add(usabilidad.Atractividad[i]);
            }

            for (int i = 0; i < usabilidad.CumplimientoUsabilidad.Length; i++)
            {
                metricas.Add(usabilidad.CumplimientoUsabilidad[i]);
            }

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(usabilidad.Comprensibilidad[0]);

            return metricas;
        }


        private ArrayList cargarMantenibilidad(JMantenibilidad mantenibilidad, string nombre, string perspectiva)
        {
            // Etiquetas pricipales 
            tblckTituloCaracteristica.Text = nombre;
            lblPerpectiva.Content = perspectiva;
            lblSubcaracterística.Content = mantenibilidad.Subcaracteristicas[0];

            // Crear lista de todas las metricas de las caracteristicas
            ArrayList metricas = new ArrayList();

            for (int i = 0; i < mantenibilidad.Analizabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Analizabilidad[i]);
            }

            for (int i = 0; i < mantenibilidad.Modificabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Modificabilidad[i]);
            }

            for (int i = 0; i < mantenibilidad.Estabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Estabilidad[i]);
            }

            for (int i = 0; i < mantenibilidad.Testeabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Testeabilidad[i]);
            }

            for (int i = 0; i < mantenibilidad.CumplimientoMantenibilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.CumplimientoMantenibilidad[i]);
            }

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(mantenibilidad.Analizabilidad[0]);

            return metricas;
        }


        // Retroceder

        private void retroceder(ref int indice, ArrayList lista)
        {
            if (indice - 1 > -1)
            {
                indice--;
                cargarMetrica((JMetrica)lista[indice]);

                if (btnSiguiente.IsEnabled == false)
                {
                    btnSiguiente.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("No hay más metricas", "Aviso", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                btnAnterior.IsEnabled = false;
            }
        }

        // Avanzar

        private void avanzar(ref int indice, ArrayList lista)
        {
            if (indice + 1 < lista.Count)
            {
                indice++;
                cargarMetrica((JMetrica)lista[indice]);

                if (btnAnterior.IsEnabled == false)
                {
                    btnAnterior.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("No hay más metricas", "Aviso", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                btnSiguiente.IsEnabled = false;
            }
        }

        // Eventos menu flotante

        private void btnFuncInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isFunIntAct = true;
            funcionalidadInterna = cargarFuncionabilidad(funInt, "Funcionabilidad Interna","Interna");
        }

        private void btnUsabInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isUsaIntAct = true;
            usabilidadInterna = cargarUsabilidad(usaInt,"Usabilidad Interna", "Interna");
        }

        private void btnMantInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isManIntAct = true;
            mantenibilidadInterna = cargarMantenibilidad(manInt,"Mantenibilidad Interna","Interna");
        }

        private void btnFuncExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isFunExtAct = true;
            funcionalidadExterna = cargarFuncionabilidad(funExt,"Funcionalidad Externa","Externa");
        }

        private void btnUsabExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isUsaExtAct = true;
            usabilidadExterna = cargarUsabilidad(usaExt,"Usabilidad Externa","Externa");
        }

        private void btnMantExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isManExtAct = true;
            mantenibilidadExterna = cargarMantenibilidad(manExt,"Mantenibilidad Externa","Externa");
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
            if (isFunIntAct)
            {
                retroceder(ref indexFunInt, funcionalidadInterna);
            }

            if (isFunExtAct)
            {
                retroceder(ref indexFunExt, funcionalidadExterna);
            }

            if (isUsaIntAct)
            {
                retroceder(ref indexUsaInt, usabilidadInterna);
            }

            if (isUsaExtAct)
            {
                retroceder(ref indexUsaExt, usabilidadExterna);
            }

            if (isManIntAct)
            {
                retroceder(ref indexManint, mantenibilidadInterna);
            }

            if (isManExtAct)
            {
                retroceder(ref indexManExt, mantenibilidadExterna);
            }
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isFunIntAct)
            {
                avanzar(ref indexFunInt, funcionalidadInterna);
            }

            if (isFunExtAct)
            {
                avanzar(ref indexFunExt, funcionalidadExterna);
            }

            if (isUsaIntAct)
            {
                avanzar(ref indexUsaInt, usabilidadInterna);
            }

            if (isUsaExtAct)
            {
                avanzar(ref indexUsaExt, usabilidadExterna);
            }

            if (isManIntAct)
            {
                avanzar(ref indexManint, mantenibilidadInterna);
            }

            if (isManExtAct)
            {
                avanzar(ref indexManExt, mantenibilidadExterna);
            }
        }

        private void btnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isFunIntAct)
            {

            }

            if (isFunExtAct)
            {

            }

            if (isUsaIntAct)
            {

            }

            if (isUsaExtAct)
            {

            }

            if (isManIntAct)
            {

            }

            if (isManExtAct)
            {

            }
        }

        private void btnTerminar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isFunIntAct)
            {
                isFunIntAct = false;
            }

            if (isFunExtAct)
            {
                isFunExtAct = false;
            }

            if (isUsaIntAct)
            {
                isUsaIntAct = false;
            }

            if (isUsaExtAct)
            {
                isUsaExtAct = false;
            }

            if (isManIntAct)
            {
                isManIntAct = false;
            }

            if (isManExtAct)
            {
                isManExtAct = false;
            }

            //menuMetricas.IsOpen = true;
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
                sb.AppendLine("Proposito: " + subcaracateristica[i].Proposito.Length);
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
