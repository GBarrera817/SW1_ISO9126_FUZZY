using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para FormEvaluacionPage.xaml
	/// </summary>
	public partial class FormEvaluacionPage : Page
	{
        // Listas metricas y seleccion metrica
        private ArrayList listaMetricas;
        private ArrayList listaSeleccion;
        private ArrayList listaEvaluacion;
        private int indiceListas;

        private FormularioEvaluacionPage origen;

        public FormEvaluacionPage()
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
            this.listaSeleccion = new ArrayList();
            this.listaEvaluacion = new ArrayList();
            this.indiceListas = 0;
        }

        private void inicializarEvaluacion(ArrayList metricas, int idProposito)
        {
            JMetrica metricaJson;
            MTEvaluacion metricaEval;

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaEval = new MTEvaluacion();

                metricaJson = (JMetrica)metricas[i];
                metricaEval.Id = metricaJson.Id;
                metricaEval.Formula = metricaJson.Formula[idProposito];
                metricaEval.Parametros = metricaJson.Parametros;

                for (int j = 0; j < metricaJson.Parametros.Length; j++)
                {
                    metricaEval.Valores[j] = 0f;
                }
                
                metricaEval.MejorValor = metricaJson.Mejor_valor;
                metricaEval.PeorValor = metricaJson.Peor_valor;

                listaSeleccion.Add(metricaEval);
            }
        }

        private void limpiarSlider()
        {
            lblParam0.Content = "";
            lblParam0.Visibility = Visibility.Hidden;
            txtParam0.IsEnabled = false;
            txtParam0.Visibility = Visibility.Hidden;
            sldparam0.IsEnabled = false;
            sldparam0.Visibility = Visibility.Hidden;

            lblParam1.Content = "";
            lblParam1.Visibility = Visibility.Hidden;
            txtParam1.IsEnabled = false;
            txtParam1.Visibility = Visibility.Hidden;
            sldparam1.IsEnabled = false;
            sldparam1.Visibility = Visibility.Hidden;
            
            lblParam2.Content = "";
            lblParam2.Visibility = Visibility.Hidden;
            txtParam2.IsEnabled = false;
            txtParam2.Visibility = Visibility.Hidden;
            sldparam2.IsEnabled = false;
            sldparam2.Visibility = Visibility.Hidden;
        }

        // Cargar una metrica

        private void cargarMetrica(JMetrica metrica, int idProposito) 
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            lblID.Content = metrica.Id;
            lblSubcaracteristica.Content = metrica.Subcaracteristica;
            lblNombre.Content = metrica.Nombre;
            labelProposito.Text = metrica.Proposito[idProposito]; 
            labelMetodo.Text = metrica.Metodo;
            label1_formula.Content = metrica.Formula[idProposito]; 
            lblMejorValor.Content = metrica.Mejor_valor;
            lblPeorValor.Content = metrica.Peor_valor;

            limpiarSlider();

            if (metrica.Parametros.Length == 1 || metrica.Parametros.Length > 1)
            {
                lblParam0.Content = metrica.Parametros[0];
                lblParam0.Visibility = Visibility.Visible;
                txtParam0.IsEnabled = true;
                txtParam0.Visibility = Visibility.Visible;
                sldparam0.IsEnabled = true;
                sldparam0.Visibility = Visibility.Visible;
            }
                
            if (metrica.Parametros.Length == 2 || metrica.Parametros.Length > 2)
            {
                lblParam1.Content = metrica.Parametros[1];
                lblParam1.Visibility = Visibility.Visible;
                txtParam1.IsEnabled = true;
                txtParam1.Visibility = Visibility.Visible;
                sldparam1.IsEnabled = true;
                sldparam1.Visibility = Visibility.Visible;
            }
                
            if (metrica.Parametros.Length == 3)
            {
                lblParam2.Content = metrica.Parametros[2];
                lblParam2.Visibility = Visibility.Visible;
                txtParam2.IsEnabled = true;
                txtParam2.Visibility = Visibility.Visible;
                sldparam2.IsEnabled = true;
                sldparam2.Visibility = Visibility.Visible;
            }
                
            for (int i = 0; i < metrica.Desc_param.Length; i++)
            {
                if (i != (metrica.Desc_param.Length - 1))
                    sb.AppendLine(metrica.Desc_param[i] + "\n");
                else
                    sb.AppendLine(metrica.Desc_param[i]);
            }

            txbkParam.Text = sb.ToString();
        }

        // Comprobar el estado de la evaluacion de la metrica

        private void cargarEvaluacion(int indice)
        {
            MTEvaluacion metrica;
            int parametros = 0;

            metrica = (MTEvaluacion)listaEvaluacion[indice];
            parametros = metrica.Parametros.Length;

            if (parametros == 1)
                txtParam0.Text = metrica.Valores[0].ToString();
            
            if (parametros == 2)          
                txtParam1.Text = metrica.Valores[1].ToString();

            if (parametros == 3)
                txtParam2.Text = metrica.Valores[2].ToString();
        }

        // Guardar estado de la evaluacion de la metrica

        private void guardarEvaluacion(int indice)
        {
            MTEvaluacion metrica;
            int parametros = 0;

            metrica = (MTEvaluacion)listaEvaluacion[indice];
            parametros = metrica.Parametros.Length;

            if (parametros == 1)            
                metrica.Valores[0] = float.Parse(txtParam0.Text);           

            if (parametros == 2)            
                metrica.Valores[1] = float.Parse(txtParam1.Text);
            
            if (parametros == 3)           
                metrica.Valores[2] = float.Parse(txtParam2.Text);
            
            listaEvaluacion[indice] = metrica;
        }

        // Retorna las metricas evaluadas

        public ArrayList evaluacionMetrica()
        {
            return listaEvaluacion;
        }

        // Cargar la caracteristicas (Eventos botones tile)

        public void cargarEvaluacionMetricas(FormularioEvaluacionPage llamada, string caracteristica, string perspectiva, ArrayList metricas, ArrayList seleccion, ArrayList evaluacion)
        {
            MTSeleccion metricaSeleccionada;

            origen = llamada;
            cargarEntorno();

            // Etiquetas pricipales 
            lblCaracteristica.Content = caracteristica;
            lblPerspectiva.Content = perspectiva;

            //Cargar listas metricas y seleccion
            listaMetricas = (ArrayList)metricas.Clone();
            listaSeleccion = (ArrayList)seleccion.Clone();
            listaEvaluacion = (ArrayList)evaluacion.Clone();

            metricaSeleccionada = (MTSeleccion)listaSeleccion[0];

            //Si no hay seleccion previa, se crea
            if (listaSeleccion.Count == 0)
            {
                inicializarEvaluacion(listaMetricas, metricaSeleccionada.Proposito);
            }

            //Cargo y compruebo metrica inicial
            cargarMetrica((JMetrica)listaMetricas[0], metricaSeleccionada.Proposito);
            cargarEvaluacion(0);
        }

        // Retroceder

        private void retroceder(ref int indice, ArrayList metricas, ArrayList seleccionadas)
        {
            MTSeleccion metricaSeleccionada;

            guardarEvaluacion(indice);

            if ((indice - 1) > -1)
            {
                indice--;

                if (indice == 0)
                {
                    btnAnterior.IsEnabled = false;
                }

                metricaSeleccionada = (MTSeleccion)seleccionadas[indice];

                cargarMetrica((JMetrica)metricas[indice], metricaSeleccionada.Proposito);
                cargarEvaluacion(indice);

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

        private void avanzar(ref int indice, ArrayList metricas, ArrayList seleccionadas)
        {
            MTSeleccion metricaSeleccionada;

            guardarEvaluacion(indice);

            if ((indice + 1) < metricas.Count)
            {
                indice++;

                if (indice == (metricas.Count - 1))
                {
                    btnSiguiente.IsEnabled = false;
                }

                metricaSeleccionada = (MTSeleccion)seleccionadas[indice];

                cargarMetrica((JMetrica)metricas[indice], metricaSeleccionada.Proposito);
                cargarEvaluacion(indice);

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

        // Eventos Sliders

        private void sldparam0_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtParam0.Text = sldparam0.Value.ToString();
        }

        private void sldparam1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtParam1.Text = sldparam1.Value.ToString();
        }

        private void sldparam2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtParam2.Text = sldparam2.Value.ToString();
        }

        // Eventos botones

        private void btnAnterior_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            retroceder(ref indiceListas, listaMetricas, listaSeleccion);
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            avanzar(ref indiceListas, listaMetricas, listaSeleccion);
        }

		private void btnGuardar_Click(object sender, RoutedEventArgs e)
		{
            guardarEvaluacion(indiceListas);
            NavigationService.Navigate(origen);
        }

        private void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            guardarEvaluacion(indiceListas);
            NavigationService.Navigate(origen);
        }
    }
}
