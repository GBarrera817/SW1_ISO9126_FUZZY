using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void inicializarEvaluacion(ArrayList metricas) //idproposito
        {
            JMetrica metricaJson;
            MTEvaluacion metricaEval;

            for (int i = 0; i < metricas.Count; i++)
            {
                metricaEval = new MTEvaluacion();

                metricaJson = (JMetrica)metricas[i];
                metricaEval.Id = metricaJson.Id;
               // metricaEval.Formula = metricaJson.Formula;
                metricaEval.Parametros = metricaJson.Parametros; 
                // Array Float valores
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

        private void cargarMetrica(JMetrica metrica) //idproposito
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            lblID.Content = metrica.Id;
            lblSubcaracteristica.Content = metrica.Subcaracteristica;
            lblNombre.Content = metrica.Nombre;
            labelProposito.Text = metrica.Proposito[0]; //idproposito
            labelMetodo.Text = metrica.Metodo;
            label1_formula.Content = metrica.Formula[0]; //idproposito
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

        private void comprobarEvaluacion(int indice)
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

        // Guardar estado de la evaluacion de la metrica

        private void guardarEvaluacion(int indice)
        {
            MTSeleccion metrica;

            metrica = (MTSeleccion)listaSeleccion[indice];

            metrica.Estado = (bool)chckDetallesMetricas.IsChecked;

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

        // Retorna las metricas evaluadas

        public ArrayList evaluacionMetrica()
        {
            return listaEvaluacion;
        }

        // Cargar la caracteristicas (Eventos botones tile)

        public void cargarSeleccionMetricas(FormularioEvaluacionPage llamada, string caracteristica, string perspectiva, ArrayList metricas, ArrayList seleccion, ArrayList evaluacion)
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
                inicializarEvaluacion(listaMetricas);
            }

            //Cargo y compruebo metrica inicial
            cargarMetrica((JMetrica)listaMetricas[0]);
            comprobarEvaluacion(0);
        }


        // Retroceder

        private void retroceder(ref int indice, ArrayList lista)
        {
            guardarEvaluacion(indice);

            if ((indice - 1) > -1)
            {
                indice--;

                if (indice == 0)
                {
                    btnAnterior.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice]);
                comprobarEvaluacion(indice);

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
            guardarEvaluacion(indice);

            if ((indice + 1) < lista.Count)
            {
                indice++;

                if (indice == (lista.Count - 1))
                {
                    btnSiguiente.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice]);
                comprobarEvaluacion(indice);

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
            retroceder(ref indiceListas, listaMetricas);
        }

        private void btnSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            avanzar(ref indiceListas, listaMetricas);
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
