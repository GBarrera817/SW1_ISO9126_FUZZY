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

        // Caracteristicas
        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;

        // Estado caracteristicas
        private bool isFunIntAct;
        private bool isFunExtAct;
        private bool isUsaIntAct;
        private bool isUsaExtAct;
        private bool isManIntAct;
        private bool isManExtAct;

        // Listas metricas y seleccion metrica
        private ArrayList listaMetricas;
        private ArrayList listaSeleccion;
        private int indiceListas;

        private VistaPreviaSeleccionMetricaPage origen;

        public SeleccionMetricasPage()
        {
            InitializeComponent();
            cargarEntorno();
        }

        // Metodos

        private void cargarEntorno()
        {
            inicializarBotones();
            inicializarEstadoCaracteristica();
            inicializarListas();
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
            this.listaMetricas = new ArrayList();
            this.listaSeleccion =  new ArrayList();
            this.indiceListas = 0;
        }

        private void inicializarSeleccion(ArrayList metricas)
        {
            JMetrica metricaJson;
            MTSeleccion metricaSelec;

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaSelec = new MTSeleccion();

                metricaJson = (JMetrica)metricas[i];
                metricaSelec.Id = metricaJson.Id;
                metricaSelec.Estado = true;
                metricaSelec.Proposito = -1;

                listaSeleccion.Add(metricaSelec);
            }
        }

        private void cargarJsonMetricas()
        {
            if (isFunIntAct)
                funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));

            if (isFunExtAct)
                funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));

            if (isUsaIntAct)
                usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));

            if (isUsaExtAct)
                usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));

            if (isManIntAct)
                manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));

            if (isManExtAct)
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
            {
                chckDetallesMetricas.IsChecked = true;
            }
            else
            {
                chckDetallesMetricas.IsChecked = false;
            } 
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

        // Retorna las metricas seleccionadas

        public ArrayList seleccionarMetrica()
        {
            return listaSeleccion;
        }


        // Cargar la caracteristicas (Eventos menu flotante)

        public void cargarSeleccionMetricas(VistaPreviaSeleccionMetricaPage llamada, string caractPers, ArrayList seleccion)
        {
            origen = llamada;

            cargarEntorno();

            switch (caractPers)
            {
                case "FunInt": isFunIntAct = true; break;
                case "FunExt": isFunExtAct = true; break;
                case "UsaInt": isUsaIntAct = true; break;
                case "UsaExt": isUsaExtAct = true; break;
                case "ManInt": isManIntAct = true; break;
                case "ManExt": isManExtAct = true; break;
                default:   isFunIntAct = true; break;
            }

            cargarJsonMetricas();

            switch (caractPers)
            {
                case "FunInt": cargarFuncionabilidad(funInt, listaMetricas); break;
                case "FunExt": cargarFuncionabilidad(funExt, listaMetricas); break;
                case "UsaInt": cargarUsabilidad(usaInt, listaMetricas); break;
                case "UsaExt": cargarUsabilidad(usaExt, listaMetricas); break;
                case "ManInt": cargarMantenibilidad(manInt, listaMetricas); break;
                case "ManExt": cargarMantenibilidad(manExt, listaMetricas); break;
                default: cargarFuncionabilidad(funInt, listaMetricas); break;
            }

            //Cargo lista seleccion
            listaSeleccion = (ArrayList)seleccion.Clone();

            //Si no esta, la creo
            if (listaSeleccion.Count == 0)
            {
                inicializarSeleccion(listaMetricas);
            }

            //Compruebo metrica inicial
            comprobarSeleccion(0);
        }

        // Retroceder

        private void retroceder(ref int indice, ArrayList lista)
        {
            guardarSeleccion(indice);

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
            guardarSeleccion(indice);

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
            retroceder(ref indiceListas, listaMetricas);
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            avanzar(ref indiceListas, listaMetricas);                                                               
        }

        private void btnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            guardarSeleccion(indiceListas);
            NavigationService.Navigate(origen);
        }

        private void btnTerminar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            guardarSeleccion(indiceListas);
            NavigationService.Navigate(origen);
        }
    }
}
