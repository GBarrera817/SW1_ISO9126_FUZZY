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

        private ArrayList subCarFunInt;
        private ArrayList subCarFunExt;
        private ArrayList subCarUsaInt;
        private ArrayList subCarUsaExt;
        private ArrayList subCarManint;
        private ArrayList subCarManExt;

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
            cargarEntorno();

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

        public ArrayList SubCarFunInt { get => subCarFunInt; set => subCarFunInt = value; }
        public ArrayList SubCarFunExt { get => subCarFunExt; set => subCarFunExt = value; }
        public ArrayList SubCarUsaInt { get => subCarUsaInt; set => subCarUsaInt = value; }
        public ArrayList SubCarUsaExt { get => subCarUsaExt; set => subCarUsaExt = value; }
        public ArrayList SubCarManint { get => subCarManint; set => subCarManint = value; }
        public ArrayList SubCarManExt { get => subCarManExt; set => subCarManExt = value; }



        // Metodos

        private void cargarEntorno()
        {
            inicializarBotones();
            inicializarEstadoCaracteristica();
            inicializarListas();
            inicializarIndexListas();
            cargarJsonMetricas();
        }

        private void inicializarBotones()
        {
            btnAnterior.IsEnabled = false;
            btnSiguiente.IsEnabled = true;
        }

        private void inicializarEstadoCaracteristica()
        {
            this.isFunIntAct = false;
            this.isFunExtAct = false;
            this.isUsaIntAct = false;
            this.isUsaExtAct = false;
            this.isManIntAct = false;
            this.isManExtAct = false;

        }

        private void inicializarListas()
        {
            this.funcionalidadInterna = new ArrayList();
            this.funcionalidadExterna = new ArrayList();
            this.usabilidadInterna = new ArrayList();
            this.usabilidadExterna = new ArrayList();
            this.mantenibilidadInterna = new ArrayList();
            this.mantenibilidadExterna = new ArrayList();

            this.subCarFunInt = new ArrayList();
            this.subCarFunExt = new ArrayList();
            this.subCarUsaInt = new ArrayList();
            this.subCarUsaExt = new ArrayList();
            this.subCarManint = new ArrayList();
            this.subCarManExt = new ArrayList();
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

        private void cargarMetrica (JMetrica metrica, string subcaracteristica)
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
            lblSubcaracterística.Content = subcaracteristica;
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


        // Crear listas de metricas por caracteristicas y sublista para obtener la subcarateristica

        private void cargarFuncionabilidad(JFuncionabilidad funcionalidad, string nombre, string perspectiva, ArrayList subcaracteristicas, ArrayList metricas)
        {
            // Etiquetas pricipales 
            tblckTituloCaracteristica.Text = nombre;
            lblPerpectiva.Content = perspectiva;
            lblSubcaracterística.Content = funcionalidad.Subcaracteristicas[0];

            for (int i = 0; i < funcionalidad.Adecuacion.Length; i++)
            {
                metricas.Add(funcionalidad.Adecuacion[i]);
                subcaracteristicas.Add(funcionalidad.Subcaracteristicas[0]);
            }

            for (int i = 0; i < funcionalidad.Exactitud.Length; i++)
            {
                metricas.Add(funcionalidad.Exactitud[i]);
                subcaracteristicas.Add(funcionalidad.Subcaracteristicas[1]);
            }

            for (int i = 0; i < funcionalidad.Interoperabilidad.Length; i++)
            {
                metricas.Add(funcionalidad.Interoperabilidad[i]);
                subcaracteristicas.Add(funcionalidad.Subcaracteristicas[2]);
            }

            for (int i = 0; i < funcionalidad.SeguridadAcceso.Length; i++)
            {
                metricas.Add(funcionalidad.SeguridadAcceso[i]);
                subcaracteristicas.Add(funcionalidad.Subcaracteristicas[3]);
            }

            for (int i = 0; i < funcionalidad.CumplimientoFuncional.Length; i++)
            {
                metricas.Add(funcionalidad.CumplimientoFuncional[i]);
                subcaracteristicas.Add(funcionalidad.Subcaracteristicas[4]);
            }

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(funcionalidad.Adecuacion[0],funcionalidad.Subcaracteristicas[0]);

        }


        private ArrayList cargarUsabilidad(JUsabilidad usabilidad, string nombre, string perspectiva, ArrayList subcaracteristicas, ArrayList metricas)
        {
            // Etiquetas pricipales 
            tblckTituloCaracteristica.Text = nombre;
            lblPerpectiva.Content = perspectiva;
            lblSubcaracterística.Content = usabilidad.Subcaracteristicas[0];


            for (int i = 0; i < usabilidad.Comprensibilidad.Length; i++)
            {
                metricas.Add(usabilidad.Comprensibilidad[i]);
                subcaracteristicas.Add(usabilidad.Subcaracteristicas[0]);
            }

            for (int i = 0; i < usabilidad.Aprendizaje.Length; i++)
            {
                metricas.Add(usabilidad.Aprendizaje[i]);
                subcaracteristicas.Add(usabilidad.Subcaracteristicas[1]);
            }

            for (int i = 0; i < usabilidad.Operabilidad.Length; i++)
            {
                metricas.Add(usabilidad.Operabilidad[i]);
                subcaracteristicas.Add(usabilidad.Subcaracteristicas[2]);
            }

            for (int i = 0; i < usabilidad.Atractividad.Length; i++)
            {
                metricas.Add(usabilidad.Atractividad[i]);
                subcaracteristicas.Add(usabilidad.Subcaracteristicas[3]);
            }

            for (int i = 0; i < usabilidad.CumplimientoUsabilidad.Length; i++)
            {
                metricas.Add(usabilidad.CumplimientoUsabilidad[i]);
                subcaracteristicas.Add(usabilidad.Subcaracteristicas[4]);
            }

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(usabilidad.Comprensibilidad[0],usabilidad.Subcaracteristicas[0]);

            return metricas;
        }


        private ArrayList cargarMantenibilidad(JMantenibilidad mantenibilidad, string nombre, string perspectiva, ArrayList subcaracteristicas, ArrayList metricas)
        {
            // Etiquetas pricipales 
            tblckTituloCaracteristica.Text = nombre;
            lblPerpectiva.Content = perspectiva;
            lblSubcaracterística.Content = mantenibilidad.Subcaracteristicas[0];


            for (int i = 0; i < mantenibilidad.Analizabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Analizabilidad[i]);
                subcaracteristicas.Add(mantenibilidad.Subcaracteristicas[0]);
            }

            for (int i = 0; i < mantenibilidad.Modificabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Modificabilidad[i]);
                subcaracteristicas.Add(mantenibilidad.Subcaracteristicas[1]);
            }

            for (int i = 0; i < mantenibilidad.Estabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Estabilidad[i]);
                subcaracteristicas.Add(mantenibilidad.Subcaracteristicas[2]);
            }

            for (int i = 0; i < mantenibilidad.Testeabilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.Testeabilidad[i]);
                subcaracteristicas.Add(mantenibilidad.Subcaracteristicas[3]);
            }

            for (int i = 0; i < mantenibilidad.CumplimientoMantenibilidad.Length; i++)
            {
                metricas.Add(mantenibilidad.CumplimientoMantenibilidad[i]);
                subcaracteristicas.Add(mantenibilidad.Subcaracteristicas[4]);
            }

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(mantenibilidad.Analizabilidad[0],mantenibilidad.Subcaracteristicas[0]);

            return metricas;
        }
        

        // Retroceder

        private void retroceder(ref int indice, ArrayList tipo, ArrayList lista)
        {
            if ((indice - 1) > -1)
            {
                indice--;

                if (indice == 0)
                {
                    btnAnterior.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice], (string)tipo[indice]);

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

        private void avanzar(ref int indice, ArrayList tipo, ArrayList lista)
        {
            if ((indice + 1) < lista.Count)
            {
                indice++;

                if (indice == (lista.Count - 1))
                {
                    btnSiguiente.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice], (string)tipo[indice]);

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
            cargarEntorno();
            isFunIntAct = true;
            cargarFuncionabilidad(funInt, "Funcionabilidad Interna","Interna",subCarFunInt,funcionalidadInterna);
            menuMetricas.IsOpen = false;
        }

        private void btnUsabInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cargarEntorno();
            isUsaIntAct = true;
            cargarUsabilidad(usaInt,"Usabilidad Interna","Interna",subCarUsaInt,usabilidadInterna);
            menuMetricas.IsOpen = false;
        }

        private void btnMantInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cargarEntorno();
            isManIntAct = true;
            cargarMantenibilidad(manInt,"Mantenibilidad Interna","Interna",subCarManint,mantenibilidadInterna);
            menuMetricas.IsOpen = false;
        }

        private void btnFuncExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cargarEntorno();
            isFunExtAct = true;
            cargarFuncionabilidad(funExt,"Funcionalidad Externa","Externa",subCarFunExt,funcionalidadExterna);
            menuMetricas.IsOpen = false;
        }

        private void btnUsabExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cargarEntorno();
            isUsaExtAct = true;
            cargarUsabilidad(usaExt,"Usabilidad Externa","Externa",subCarUsaExt, usabilidadExterna);
            menuMetricas.IsOpen = false;
        }

        private void btnMantExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cargarEntorno();
            isManExtAct = true;
            cargarMantenibilidad(manExt,"Mantenibilidad Externa","Externa",SubCarManExt,mantenibilidadExterna);
            menuMetricas.IsOpen = false;
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
                retroceder(ref indexFunInt, subCarFunInt, funcionalidadInterna);
            }

            if (isFunExtAct)
            {
                retroceder(ref indexFunExt, subCarFunExt, funcionalidadExterna);
            }

            if (isUsaIntAct)
            {
                retroceder(ref indexUsaInt, subCarUsaInt, usabilidadInterna);
            }

            if (isUsaExtAct)
            {
                retroceder(ref indexUsaExt, subCarUsaExt, usabilidadExterna);
            }

            if (isManIntAct)
            {
                retroceder(ref indexManint, subCarManint, mantenibilidadInterna);
            }

            if (isManExtAct)
            {
                retroceder(ref indexManExt, subCarManExt, mantenibilidadExterna);
            }
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isFunIntAct)
            {
                avanzar(ref indexFunInt,subCarFunInt,funcionalidadInterna);
            }                           
                                        
            if (isFunExtAct)            
            {                           
                avanzar(ref indexFunExt,subCarFunExt,funcionalidadExterna);
            }                           
                                        
            if (isUsaIntAct)            
            {                           
                avanzar(ref indexUsaInt,subCarUsaInt,usabilidadInterna);
            }                           
                                        
            if (isUsaExtAct)            
            {                           
                avanzar(ref indexUsaExt,subCarUsaExt,usabilidadExterna);
            }                           
                                        
            if (isManIntAct)            
            {                           
                avanzar(ref indexManint,subCarManint,mantenibilidadInterna);
            }                           
                                        
            if (isManExtAct)            
            {                           
                avanzar(ref indexManExt,subCarManExt,mantenibilidadExterna);
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
                indexFunInt = 0;
                isFunIntAct = false;
            }

            if (isFunExtAct)
            {
                indexFunExt = 0;
                isFunExtAct = false;
            }

            if (isUsaIntAct)
            {
                indexUsaInt = 0;
                isUsaIntAct = false;
            }

            if (isUsaExtAct)
            {
                indexUsaExt = 0;
                isUsaExtAct = false;
            }

            if (isManIntAct)
            {
                indexManint = 0;
                isManIntAct = false;
            }

            if (isManExtAct)
            {
                indexManExt = 0;
                isManExtAct = false;
            }

            // Mostrar menu caracteristicas
            // menuMetricas.IsOpen = true;

            this.NavigationService.Navigate(new Uri("Vistas/VistaPreviaSeleccionMetricaPage.xaml", UriKind.Relative));
        }
    }
}
