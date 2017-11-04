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
    public partial class SeleccionMetricasPage : Page
    {
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
            inicializarListas();
        }

        private void inicializarBotones()
        {
            btnAnterior.IsEnabled = false;
            btnSiguiente.IsEnabled = true;
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
                metricaSelec.Proposito = 0;

                listaSeleccion.Add(metricaSelec);
            }
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

            dataGridDetalleMetrica.SelectedIndex = metrica.Proposito;

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

            metrica.Estado = (bool) chckDetallesMetricas.IsChecked;

            if (metrica.Estado)
            {
                metrica.Proposito = dataGridDetalleMetrica.SelectedIndex;
            }
            else
            {
                metrica.Proposito = 0;
            }

            listaSeleccion[indice] = metrica;
        }

        // Retorna las metricas seleccionadas

        public ArrayList seleccionarMetrica()
        {
            return listaSeleccion;
        }

        // Cargar la caracteristicas (Eventos menu flotante)

        public void cargarSeleccionMetricas(VistaPreviaSeleccionMetricaPage llamada, string caracteristica, string perspectiva, ArrayList metricas, ArrayList seleccion)
        {
            origen = llamada;
            cargarEntorno();

            // Etiquetas pricipales 
            lblCaracteristica.Content = caracteristica;
            lblPerspectiva.Content = perspectiva;

            //Cargar listas metricas y seleccion
            listaMetricas = (ArrayList)metricas.Clone();
            listaSeleccion = (ArrayList)seleccion.Clone();

            //Si no hay seleccion previa, se crea
            if (listaSeleccion.Count == 0)
            {
                inicializarSeleccion(listaMetricas);
            }

            //Cargo y compruebo metrica inicial
            cargarMetrica((JMetrica)listaMetricas[0]);
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
            dataGridDetalleMetrica.SelectedIndex = 0;

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
