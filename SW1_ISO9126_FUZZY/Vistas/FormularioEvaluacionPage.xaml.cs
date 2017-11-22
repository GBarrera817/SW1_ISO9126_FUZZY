using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using System.Collections.Generic;
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
        // Listas metricas, seleccion metrica y evaluacion metricas
        private List<JMetrica> listaMetricas;
        private List<MTSeleccion> listaSeleccion;
        private List<MTEvaluacion> listaEvaluacion;
        private int indiceListas;
        private string caracteristica;
        private string perspectiva;

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
            this.listaEvaluacion = new List<MTEvaluacion>();
            this.indiceListas = 0;
        }

        // Crear lista para guardar la evaluación

        private void inicializarEvaluacion(List<JMetrica> metricas, List<MTSeleccion> selecciones)
        {
            JMetrica metricaJson;
            MTSeleccion metricaSel;
            MTEvaluacion metricaEval;

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaEval = new MTEvaluacion();

                metricaJson = metricas[i];
                metricaSel = selecciones[i];

                metricaEval.Id = metricaJson.Id;
                metricaEval.Formula = metricaJson.Formula[metricaSel.Proposito];
                metricaEval.Parametros = metricaJson.Parametros;

                for (int j = 0; j < metricaJson.Parametros.Length; j++)
                {
                    metricaEval.Valores[j] = 0f;
                }
                
                metricaEval.MejorValor = metricaJson.Mejor_valor;
                metricaEval.PeorValor = metricaJson.Peor_valor;

                listaEvaluacion.Add(metricaEval);
            }
        }

        // Limpia los sliders no activados

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

            metrica = listaEvaluacion[indice];
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

            metrica = listaEvaluacion[indice];
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

        public List<MTEvaluacion> evaluacionMetrica()
        {
            return listaEvaluacion;
        }

        // Verificar condiciones de finalizacion

        private bool verificarEvaluacion()
        {
            int respondidas = 0;
            int parametros = 0;

            foreach (MTEvaluacion item in listaEvaluacion)
            {
                parametros = 0;

                for (int i = 0; i < item.Valores.Length; i++)
                {
                    if (item.Valores[i] != 0)
                        parametros++;
                }

                if (parametros != 0)
                    respondidas++;
            }

            if (respondidas != 0) return true; else return false;
        }

        // Metodo principal para evaluar las metricas

        public void cargarEvaluacionMetricas(FormularioEvaluacionPage llamada, string caracteristica, string perspectiva, List<JMetrica> metricas, List<MTSeleccion> seleccion, List<MTEvaluacion> evaluacion)
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

            //Cargar listas metricas, seleccion y evaluacion
            listaMetricas = new List<JMetrica>(metricas); 
            listaSeleccion = new List<MTSeleccion>(seleccion);
            listaEvaluacion = new List<MTEvaluacion>(evaluacion);

            // Lista de metrica con un elemento
            if (listaMetricas.Count == 1)
            {
                btnSiguiente.IsEnabled = false;
            }

            //Si no hay evaluacion previa, se crea
            if (listaEvaluacion.Count == 0)
            {
                inicializarEvaluacion(listaMetricas, listaSeleccion);
            }

            //Cargo y compruebo metrica inicial
            cargarMetrica(listaMetricas[0], listaSeleccion[0].Proposito);
            cargarEvaluacion(0);
        }

        // Retroceder

        private void retroceder(ref int indice)
        {
            if ((indice - 1) > -1)
            {
                indice--;

                if (indice == 0)               
                    btnAnterior.IsEnabled = false;
               
                if (btnSiguiente.IsEnabled == false)           
                    btnSiguiente.IsEnabled = true;               
            }
            else
            {
                MessageBox.Show("No hay más metricas", "Aviso", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                btnAnterior.IsEnabled = false;
            }
        }

        // Avanzar

        private void avanzar(ref int indice)
        {
            int max = listaMetricas.Count;

            if ((indice + 1) < max)
            {
                indice++;

                if (indice == (max - 1))               
                    btnSiguiente.IsEnabled = false;
                
                if (btnAnterior.IsEnabled == false)               
                    btnAnterior.IsEnabled = true;                
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
            guardarEvaluacion(indiceListas);
            retroceder(ref indiceListas);
            cargarMetrica(listaMetricas[indiceListas], listaSeleccion[indiceListas].Proposito);
            cargarEvaluacion(indiceListas);
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            guardarEvaluacion(indiceListas);
            avanzar(ref indiceListas);
            cargarMetrica(listaMetricas[indiceListas], listaSeleccion[indiceListas].Proposito);
            cargarEvaluacion(indiceListas);
        }

		private void btnGuardar_Click(object sender, RoutedEventArgs e)
		{
            guardarEvaluacion(indiceListas);
            Xceed.Wpf.Toolkit.MessageBox.Show("Métricas evaluadas almacenadas satisfactoriamente", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(origen);
        }

        private void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            guardarEvaluacion(indiceListas);

            if (verificarEvaluacion())
            {
                NavigationService.Navigate(origen);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe responder todas las métricas para realizar la evaluación", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
