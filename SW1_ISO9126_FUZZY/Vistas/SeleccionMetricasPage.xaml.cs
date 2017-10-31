using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Controls;

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

        private ArrayList listaSeleccion;

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

        private VistaPreviaSeleccionMetricaPage origen;

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

            this.listaSeleccion =  new ArrayList();
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

        private void inicializarSeleccion(ArrayList metricas)
        {
            JMetrica metricaJson = new JMetrica();
            MTSeleccion metricaSelec = new MTSeleccion();

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaJson = (JMetrica)metricas[i];
                metricaSelec.Id = metricaJson.Id;

                listaSeleccion.Add(metricaSelec);
            }

            System.Console.WriteLine("tamaño lista seleccion:"+listaSeleccion.Count);
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

            int preguntas = 0;
            int formulas = 0;

            lblIDMetrica.Content = metrica.Id;
            lblSubcaracterística.Content = metrica.Subcaracteristica;
            lblNombreMetrica.Content = metrica.Nombre;
            txbkMetodo.Text = metrica.Metodo;

            preguntas = metrica.Proposito.Length;
            formulas = metrica.Formula.Length;
            
            /*
            MessageBox.Show("preguntas: " + preguntas);
            MessageBox.Show("formulas: " + formulas);
            MessageBox.Show(metrica.ToString());
            */

            // Igual número de preguntas y formulas

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

            // Listar parametros formulas

            for (int i = 0; i< metrica.Desc_param.Length; i++)
            {
                sb.AppendLine(metrica.Desc_param[i]);
            }

            txbkParam.Text = sb.ToString();
        }

        // Comprobar el estado de la seleccion de la metrica

        private void comprobarSeleccion(int indice)
        {
            MTSeleccion metrica;

            metrica = (MTSeleccion)listaSeleccion[indice];

            if (metrica.Estado)
                chckDetallesMetricas.IsChecked = true;
            else
                chckDetallesMetricas.IsChecked = false;
        }

        // Guardar estado de la seleccion de la metrica

        private void guardarSeleccion(int indice)
        {
            MTSeleccion metrica;

            metrica = (MTSeleccion)listaSeleccion[indice];
            metrica.Proposito = 0; // fila seleccionada
            metrica.Estado = (bool) chckDetallesMetricas.IsChecked;

            listaSeleccion[indice] = metrica;
        }

        // Crear listas de metricas por caracteristicas y sublista para obtener la subcarateristica

        private void cargarFuncionabilidad(JFuncionabilidad funcionalidad, ArrayList metricas)
        {
            // Etiquetas pricipales 
            lblCaracterística.Content = funcionalidad.Caracteristica;
            lblPerpectiva.Content = funcionalidad.Perspectiva;

            for (int i = 0; i < funcionalidad.Adecuacion.Length; i++)
                metricas.Add(funcionalidad.Adecuacion[i]);           

            for (int i = 0; i < funcionalidad.Exactitud.Length; i++)           
                metricas.Add(funcionalidad.Exactitud[i]);
            
            for (int i = 0; i < funcionalidad.Interoperabilidad.Length; i++)           
                metricas.Add(funcionalidad.Interoperabilidad[i]);
            
            for (int i = 0; i < funcionalidad.SeguridadAcceso.Length; i++)           
                metricas.Add(funcionalidad.SeguridadAcceso[i]);
            
            for (int i = 0; i < funcionalidad.CumplimientoFuncional.Length; i++)           
                metricas.Add(funcionalidad.CumplimientoFuncional[i]);
            
            // Cargar metrica de primera subcaracteristica
            cargarMetrica(funcionalidad.Adecuacion[0]);
        }


        private void cargarUsabilidad(JUsabilidad usabilidad, ArrayList metricas)
        {
            // Etiquetas pricipales 
            lblCaracterística.Content = usabilidad.Caracteristica;
            lblPerpectiva.Content = usabilidad.Perspectiva;

            for (int i = 0; i < usabilidad.Comprensibilidad.Length; i++)
                metricas.Add(usabilidad.Comprensibilidad[i]);

            for (int i = 0; i < usabilidad.Aprendizaje.Length; i++)
                metricas.Add(usabilidad.Aprendizaje[i]);

            for (int i = 0; i < usabilidad.Operabilidad.Length; i++)
                metricas.Add(usabilidad.Operabilidad[i]);

            for (int i = 0; i < usabilidad.Atractividad.Length; i++)
                metricas.Add(usabilidad.Atractividad[i]);

            for (int i = 0; i < usabilidad.CumplimientoUsabilidad.Length; i++)
                metricas.Add(usabilidad.CumplimientoUsabilidad[i]);

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(usabilidad.Comprensibilidad[0]);
        }


        private void cargarMantenibilidad(JMantenibilidad mantenibilidad, ArrayList metricas)
        {
            // Etiquetas pricipales 
            lblCaracterística.Content = mantenibilidad.Caracteristica;
            lblPerpectiva.Content = mantenibilidad.Perspectiva;

            for (int i = 0; i < mantenibilidad.Analizabilidad.Length; i++)
                metricas.Add(mantenibilidad.Analizabilidad[i]);

            for (int i = 0; i < mantenibilidad.Modificabilidad.Length; i++)
                metricas.Add(mantenibilidad.Modificabilidad[i]);

            for (int i = 0; i < mantenibilidad.Estabilidad.Length; i++)
                metricas.Add(mantenibilidad.Estabilidad[i]);

            for (int i = 0; i < mantenibilidad.Testeabilidad.Length; i++)
                metricas.Add(mantenibilidad.Testeabilidad[i]);

            for (int i = 0; i < mantenibilidad.CumplimientoMantenibilidad.Length; i++)
                metricas.Add(mantenibilidad.CumplimientoMantenibilidad[i]);

            // Cargar metrica de primera subcaracteristica
            cargarMetrica(mantenibilidad.Analizabilidad[0]);
        }


        private ArrayList seleccionarMetrica()
        {
            return listaSeleccion;
        }


        // Retroceder

        private void retroceder(ref int indice, ArrayList lista)
        {
            if ((indice - 1) > -1)
            {
                indice--;

                if (indice == 0)
                {
                    btnAnterior.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice]);
                comprobarSeleccion(indice);

                if (btnSiguiente.IsEnabled == false)
                {
                    btnSiguiente.IsEnabled = true;
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("No hay más metricas", "Aviso", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                btnAnterior.IsEnabled = false;
            }
        }

        // Avanzar

        private void avanzar(ref int indice, ArrayList lista)
        {
            if ((indice + 1) < lista.Count)
            {
                indice++;

                if (indice == (lista.Count - 1))
                {
                    btnSiguiente.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice]);
                comprobarSeleccion(indice);

                if (btnAnterior.IsEnabled == false)
                {
                    btnAnterior.IsEnabled = true;
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("No hay más metricas", "Aviso", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                btnSiguiente.IsEnabled = false;
            }
        }

        // Eventos menu flotante

        public void FuncInterna_Activar(VistaPreviaSeleccionMetricaPage llamada, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();
            isFunIntAct = true;

            listaSeleccion.Clear();
            listaSeleccion = (ArrayList)seleccion.Clone();

            if (listaSeleccion.Count == 0)
            {
                inicializarSeleccion(funcionalidadInterna);
            }
            
            cargarFuncionabilidad(funInt,funcionalidadInterna);
            comprobarSeleccion(1);
            
        }

        // Cargar la caracteristicas

        public void UsabInterna_Activar(VistaPreviaSeleccionMetricaPage llamada, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();
            isUsaIntAct = true;
            cargarUsabilidad(usaInt,usabilidadInterna);
            
        }

        public void MantInterna_Activar(VistaPreviaSeleccionMetricaPage llamada, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();
            isManIntAct = true;
            cargarMantenibilidad(manInt,mantenibilidadInterna);
           
        }

        public void FuncExterna_Activar(VistaPreviaSeleccionMetricaPage llamada, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();
            isFunExtAct = true;
            cargarFuncionabilidad(funExt,funcionalidadExterna);
            
        }

        public void UsabExterna_Activar(VistaPreviaSeleccionMetricaPage llamada, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();
            isUsaExtAct = true;
            cargarUsabilidad(usaExt,usabilidadExterna);
            
        }

        public void MantExterna_Activar(VistaPreviaSeleccionMetricaPage llamada, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();
            isManExtAct = true;
            cargarMantenibilidad(manExt,mantenibilidadExterna);
            
        }

        // Evento checkbox

        private void chckDetallesMetricas_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            img_no_metric.Visibility = System.Windows.Visibility.Hidden;
            txt_metric_disable.Visibility = System.Windows.Visibility.Hidden;
            expDetMet.IsExpanded = true;
        }

        private void chckDetallesMetricas_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            img_no_metric.Visibility = System.Windows.Visibility.Visible;
            txt_metric_disable.Visibility = System.Windows.Visibility.Visible;
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
                avanzar(ref indexFunInt,funcionalidadInterna);
            }                           
                                        
            if (isFunExtAct)            
            {                           
                avanzar(ref indexFunExt,funcionalidadExterna);
            }                           
                                        
            if (isUsaIntAct)            
            {                           
                avanzar(ref indexUsaInt,usabilidadInterna);
            }                           
                                        
            if (isUsaExtAct)            
            {                           
                avanzar(ref indexUsaExt,usabilidadExterna);
            }                           
                                        
            if (isManIntAct)            
            {                           
                avanzar(ref indexManint,mantenibilidadInterna);
            }                           
                                        
            if (isManExtAct)            
            {                           
                avanzar(ref indexManExt,mantenibilidadExterna);
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

            NavigationService.Navigate(origen);
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

            NavigationService.Navigate(origen);
        }
    }
}
