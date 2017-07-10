using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using System;
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
        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;

        public FormEvaluacionPage()
		{
			InitializeComponent();
            cargarJsonMetricas();
            cargarMetrica(funInt.Adecuacion[0]);
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

        private void cargarMetrica(JMetrica metrica)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            lblPerspectiva.Content = "Interna";
            lblCaracteristica.Content ="Funcionabilidad";
            lblSubcaracteristica.Content = "Adecuación";
            lblID.Content = metrica.Id;
            lblNombre.Content = metrica.Nombre;
            labelProposito.Text = metrica.Proposito[0];
            labelMetodo.Text = metrica.Metodo;
            label1_formula.Content = metrica.Formula[0];
            lblMejorValor.Content = metrica.Mejor_valor;
            lblMejorValor_Copy.Content = metrica.Peor_valor;

            for (int i = 0; i < metrica.Desc_param.Length; i++)
            {
                sb.AppendLine(metrica.Desc_param[i]);
            }

            txbkParam.Text = sb.ToString();
        }


        private void txtParam1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void txtParam0_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void sliderParam0_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

		}

		private void sliderParam1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

		}

		private void btnSiguiente_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnAnterior_Click(object sender, RoutedEventArgs e)
		{
			/*if(e.OriginalSource != sender)
			{
				e.Handled = true;
			}
			else{
				MessageBox.Show("Hola");
			}*/
		}

		private void btnFinalizarCuestionario_Click(object sender, RoutedEventArgs e)
		{
            this.NavigationService.Navigate(new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.Relative));
        }
    
		private void btnGuardar_Click(object sender, RoutedEventArgs e)
		{
            this.NavigationService.Navigate(new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.Relative));
        }
    
	}
}
