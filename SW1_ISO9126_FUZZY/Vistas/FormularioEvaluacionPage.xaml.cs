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
                metricaEval.Formula = metricaJson.Formula[0]; // Existe una unica formula por metrica
                metricaEval.Parametros = metricaJson.Parametros;

                metricaEval.Valores = new float[metricaJson.Parametros.Length];

                for (int j = 0; j < metricaEval.Valores.Length; j++)
                {
                    metricaEval.Valores[j] = 0f;
                }
                
                metricaEval.MejorValor = metricaJson.Mejor_valor;
                metricaEval.PeorValor = metricaJson.Peor_valor;

                listaEvaluacion.Add(metricaEval);
            }
        }

        // Limpia los campos para contestar la evaluacion

        private void limpiarContenidoEvaluacion()
        {
            lblParam0.Content = "";
            lblParam0.Visibility = Visibility.Hidden;
            txtParam0.Text = "";
            txtParam0.IsEnabled = false;
            txtParam0.Visibility = Visibility.Hidden;
            sldparam0.Value = 0;
            sldparam0.IsEnabled = false;
            sldparam0.Visibility = Visibility.Hidden;

            lblParam1.Content = "";
            lblParam1.Visibility = Visibility.Hidden;
            txtParam1.Text = "";
            txtParam1.IsEnabled = false;
            txtParam1.Visibility = Visibility.Hidden;
            sldparam1.Value = 0;
            sldparam1.IsEnabled = false;
            sldparam1.Visibility = Visibility.Hidden;
            
            lblParam2.Content = "";
            lblParam2.Visibility = Visibility.Hidden;
            txtParam2.IsEnabled = false;
            txtParam2.Text = "";
            txtParam2.Visibility = Visibility.Hidden;
            sldparam2.Value = 0;
            sldparam2.IsEnabled = false;
            sldparam2.Visibility = Visibility.Hidden;
        }

        // Cargar una metrica

        private void cargarMetrica(JMetrica metrica, int idProposito, MTEvaluacion datos) 
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            lblID.Content = metrica.Id;
            lblSubcaracteristica.Content = metrica.Subcaracteristica;
            lblNombre.Content = metrica.Nombre;
            labelProposito.Text = metrica.Proposito[idProposito]; 
            labelMetodo.Text = metrica.Metodo;
            label1_formula.Content = metrica.Formula[0]; // Existe una unica formula para cada métrica
            lblMejorValor.Content = metrica.Mejor_valor;
            lblPeorValor.Content = metrica.Peor_valor;

            limpiarContenidoEvaluacion();

            if (metrica.Parametros.Length == 1 || metrica.Parametros.Length > 1)
            {
                lblParam0.Content = metrica.Parametros[0];
                lblParam0.Visibility = Visibility.Visible;
                txtParam0.IsEnabled = true;
                txtParam0.Text = datos.Valores[0].ToString();
                txtParam0.Visibility = Visibility.Visible;
                sldparam0.Value = datos.Valores[0];
                sldparam0.IsEnabled = true;
                sldparam0.Visibility = Visibility.Visible;
            }
                
            if (metrica.Parametros.Length == 2 || metrica.Parametros.Length > 2)
            {
                lblParam1.Content = metrica.Parametros[1];
                lblParam1.Visibility = Visibility.Visible;
                txtParam1.Text = datos.Valores[1].ToString();
                txtParam1.IsEnabled = true;
                txtParam1.Visibility = Visibility.Visible;
                sldparam1.Value = datos.Valores[1];
                sldparam1.IsEnabled = true;
                sldparam1.Visibility = Visibility.Visible;
            }
                
            if (metrica.Parametros.Length == 3)
            {
                lblParam2.Content = metrica.Parametros[2];
                lblParam2.Visibility = Visibility.Visible;
                txtParam2.Text = datos.Valores[2].ToString();
                txtParam2.IsEnabled = true;
                txtParam2.Visibility = Visibility.Visible;
                sldparam2.Value = datos.Valores[2];
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

            System.Console.WriteLine("\nID: "+indice);

            if (parametros == 1)
            {
                metrica.Valores[0] = float.Parse(txtParam0.Text);
                System.Console.WriteLine("P0: "+ metrica.Valores[0]);
            }            
                     
            if (parametros == 2)
            {
                metrica.Valores[0] = float.Parse(txtParam0.Text);
                metrica.Valores[1] = float.Parse(txtParam1.Text);
                System.Console.WriteLine("P1: " + metrica.Valores[0]);
                System.Console.WriteLine("P2: " + metrica.Valores[1]);
            }            
                            
            if (parametros == 3)
            {
                metrica.Valores[0] = float.Parse(txtParam0.Text);
                metrica.Valores[1] = float.Parse(txtParam1.Text);
                metrica.Valores[2] = float.Parse(txtParam2.Text);
                System.Console.WriteLine("P1: " + metrica.Valores[0]);
                System.Console.WriteLine("P2: " + metrica.Valores[1]);
                System.Console.WriteLine("P3: " + metrica.Valores[2]);
            }           
                           
            listaEvaluacion[indice] = metrica;
        }

        // Retorna las metricas evaluadas

        public List<MTEvaluacion> evaluacionMetrica()
        {
            return listaEvaluacion;
        }

        // Validar respuestas usuario

        private bool validadRespuesta(JMetrica metrica)
        {
            int numeroParametros = metrica.Parametros.Length;
            double valor = 0;
            bool salida = true;

            if (numeroParametros == 1 || numeroParametros > 1)
            {
                try
                {
                    valor = float.Parse(txtParam0.Text);

                    if (valor < 0 || valor > 100)
                        salida = false;
                }
                catch (System.FormatException)
                {
                    salida = false;
                }
            }

            if (numeroParametros == 2 || numeroParametros > 2)
            {
                try
                {
                    valor = float.Parse(txtParam1.Text);

                    if (valor < 0 || valor > 100)
                        salida = false;
                }
                catch (System.FormatException)
                { 
                    salida = false;
                }
            }

            if (numeroParametros == 3)
            {
                try
                {
                    valor = float.Parse(txtParam2.Text);

                    if (valor < 0 || valor > 100)
                        salida = false;
                }
                catch (System.FormatException)
                {
                    salida = false;
                }
            }

            return salida;
        }

        // Revisa cada metrica buscando ceros en todos sus parametros

        private int buscaCeroTodosParametros()
        {
            int encontradas = 0;
            int parametros = 0;

            foreach (MTEvaluacion item in listaEvaluacion)
            {
                parametros = 0;

                for (int i = 0; i < item.Valores.Length; i++)
                {
                    if (item.Valores[i] == 0)
                        parametros++;
                }

                if (parametros == item.Valores.Length)
                    encontradas++;
            }

            return encontradas;
        }

        // Revisa cada metrica buscando numeros distintos de cero en todos sus parametros

        private int buscaNingunCeroTodosParametros()
        {
            int encontradas = 0;
            int parametros = 0;

            foreach (MTEvaluacion item in listaEvaluacion)
            {
                parametros = 0;

                for (int i = 0; i < item.Valores.Length; i++)
                {
                    if (item.Valores[i] != 0)
                        parametros++;
                }

                if (parametros == item.Valores.Length)
                    encontradas++;
            }

            return encontradas;
        }

        // Revisa cada metrica buscando algun cero en sus parametros

        private int buscaAlgunCeroParametros()
        {
            int encontradas = 0;
            int parametros = 0;

            foreach (MTEvaluacion item in listaEvaluacion)
            {
                parametros = 0;

                for (int i = 0; i < item.Valores.Length; i++)
                {
                    if (item.Valores[i] == 0)
                        parametros++;
                }

                if (parametros != 0)
                    if (parametros != item.Valores.Length)
                        encontradas++;
            }

            return encontradas;
        }


        // Revisa cada metrica si tiene todos los campos distintos de cero o alguno difente de cero

        private int buscaHibrido()
        {
            int encontradas = 0;
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
                    encontradas++;
            }

            return encontradas;
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
            cargarMetrica(listaMetricas[0], listaSeleccion[0].Proposito, listaEvaluacion[0]);
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

        // Metodo para cambiar valor slider segun valor ingresado al textbox

        private void actualizarSliderTexbox(Slider desplazamiento, TextBox datos)
        {
            double valor = 0;

            try
            {
                valor = float.Parse(datos.Text);

                if (valor < 0 || valor > 100)
                {
                    desplazamiento.Value = 0;
                    datos.Text = "0";
                }
                else
                    desplazamiento.Value = float.Parse(datos.Text);
            }
            catch (System.FormatException)
            {
                desplazamiento.Value = 0;
                datos.Text = "0";
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
            if (validadRespuesta(listaMetricas[indiceListas]))
            {
                guardarEvaluacion(indiceListas);
                retroceder(ref indiceListas);
                cargarMetrica(listaMetricas[indiceListas], listaSeleccion[indiceListas].Proposito, listaEvaluacion[indiceListas]);
                cargarEvaluacion(indiceListas);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar valores  numéricos válidos, mínimo 0 y máximo 100", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validadRespuesta(listaMetricas[indiceListas]))
            {
                guardarEvaluacion(indiceListas);
                avanzar(ref indiceListas);
                cargarMetrica(listaMetricas[indiceListas], listaSeleccion[indiceListas].Proposito, listaEvaluacion[indiceListas]);
                cargarEvaluacion(indiceListas);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar valores  numéricos válidos, mínimo 0 y máximo 100", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

		private void btnGuardar_Click(object sender, RoutedEventArgs e)
		{
            int salida = 0;
            int respondidas = 0;

            if (validadRespuesta(listaMetricas[indiceListas]))
            {
                guardarEvaluacion(indiceListas);

                salida = buscaCeroTodosParametros();

                if (salida != listaEvaluacion.Count)
                {
                    respondidas = buscaHibrido();
                }
                else
                {
                    respondidas = 0;
                }

                Xceed.Wpf.Toolkit.MessageBox.Show("Métricas evaluadas almacenadas satisfactoriamente", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(origen);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar valores  numéricos válidos, mínimo 0 y máximo 100", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            if (validadRespuesta(listaMetricas[indiceListas]))
            {
                guardarEvaluacion(indiceListas);

                if (metricasRespondidas() == MTEvaluacion.)
                {
                    NavigationService.Navigate(origen);
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe responder todas las métricas para realizar la evaluación", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar valores numéricos válidos, mínimo 0 y máximo 100", "Evaluación de métricas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Eventos TextBox

        private void txtParam0_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualizarSliderTexbox(sldparam0, txtParam0);
        }

        private void txtParam1_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualizarSliderTexbox(sldparam1, txtParam1);
        }

        private void txtParam2_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualizarSliderTexbox(sldparam2, txtParam2);
        }
    }
}
