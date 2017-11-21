using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace SW1_ISO9126_FUZZY.Vistas {
    /// <summary>
    /// Lógica de interacción para ConfiguracionMetricasPage.xaml
    /// </summary>
    public partial class SeleccionMetricasPage : Page
    {
        // Listas metricas y seleccion metrica
        private List<JMetrica> listaMetricas;
        private List<MTSeleccion> listaSeleccion;
        private int indiceListas;
        private string caracteristica;
        private string perspectiva;

        private VistaPreviaSeleccionMetricaPage origen;

        public SeleccionMetricasPage()
        {
            InitializeComponent();
            cargarEntorno();
            inicializarVariables();
        }

        // Metodos

        private void cargarEntorno()
        {
            inicializarBotones();
            inicializarListas();
        }

        // Asigna estado inicial botones de movimiento

        private void inicializarBotones()
        {
            btnAnterior.IsEnabled = false;
            btnSiguiente.IsEnabled = true;
        }

        // Inicializar variables

        private void inicializarVariables()
        {
            this.caracteristica = "";
            this.perspectiva = "";
        }

        // Crear las listas para las metricas

        private void inicializarListas()
        {
            this.listaMetricas = new List<JMetrica>();
            this.listaSeleccion = new List<MTSeleccion>();
            this.indiceListas = 0;
        }

        // Crear lista para guardar la seleccion

        private void inicializarSeleccion(List<JMetrica> metricas)
        {
            JMetrica metricaJson;
            MTSeleccion metricaSelec;

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaSelec = new MTSeleccion();

                metricaJson = metricas[i];
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

        private void cargarSeleccion(int indice)
        {
            MTSeleccion metrica;

            metrica = listaSeleccion[indice];

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

            metrica = listaSeleccion[indice];

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

        public List<MTSeleccion> seleccionarMetrica()
        {
            return listaSeleccion;
        }

        // Cargar la caracteristicas (Eventos menu flotante)

        public void cargarSeleccionMetricas(VistaPreviaSeleccionMetricaPage llamada, string caracteristica, string perspectiva, List<JMetrica> metricas, List<MTSeleccion> seleccion)
        {
            // Ventana emisora
            origen = llamada;

            // Datos etiqueta estado por colores
            this.caracteristica = caracteristica;
            this.perspectiva = perspectiva;

            // Condiciones iniciales
            cargarEntorno();

            // Etiquetas pricipales 
            lblCaracteristica.Content = caracteristica;
            lblPerspectiva.Content = perspectiva;

            // Cargar listas metricas y seleccion
            listaMetricas = new List<JMetrica>(metricas); 
            listaSeleccion = new List<MTSeleccion>(seleccion);

            // Lista de metrica con un elemento
            if (listaMetricas.Count == 1)
            {
                btnSiguiente.IsEnabled = false;
            }

            // Si no hay seleccion previa, se crea
            if (listaSeleccion.Count == 0)
            {
                inicializarSeleccion(listaMetricas);
            }

            // Cargo y compruebo metrica inicial
            cargarMetrica(listaMetricas[0]);
            cargarSeleccion(0);
        }

        // Retroceder

        private void retroceder(ref int indice, List<JMetrica> lista)
        {
            guardarSeleccion(indice);

            if ((indice - 1) > -1)
            {
                indice--;

                if (indice == 0)
                {
                    btnAnterior.IsEnabled = false;
                }

                cargarMetrica(lista[indice]);
                cargarSeleccion(indice);

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

        private void avanzar(ref int indice, List<JMetrica> lista)
        {
            guardarSeleccion(indice);

            if ((indice + 1) < lista.Count)
            {
                indice++;

                if (indice == (lista.Count - 1))
                {
                    btnSiguiente.IsEnabled = false;
                }

                cargarMetrica(lista[indice]);
                cargarSeleccion(indice);

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
            origen.guardarSeleccionSMbtn(caracteristica, perspectiva);
            guardarSeleccion(indiceListas);
            Xceed.Wpf.Toolkit.MessageBox.Show("Métricas seleccionadas almacenadas satisfactoriamente", "Selección de métricas", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(origen);
        }

        private void btnTerminar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult respuesta;

            respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("Al finalizar la selección no podra agregar más metricas, ¿desea finalizar la selección? ", "Selección de métricas", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (respuesta == MessageBoxResult.Yes)
            {
                origen.finalizarSeleccionSMbtn(caracteristica, perspectiva);
                guardarSeleccion(indiceListas);
                Xceed.Wpf.Toolkit.MessageBox.Show("Selección de métricas finalizada, métricas seleccionadas almacenadas satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(origen);
            }
        }
    }
}
