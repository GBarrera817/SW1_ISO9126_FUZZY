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

        private FormularioEvaluacionPage origen;

        public FormEvaluacionPage()
        {
            InitializeComponent();
            cargarEntorno();
		}

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

        public bool IsFunIntAct { get => isFunIntAct; set => isFunIntAct = value; }
        public bool IsFunExtAct { get => isFunExtAct; set => isFunExtAct = value; }
        public bool IsUsaIntAct { get => isUsaIntAct; set => isUsaIntAct = value; }
        public bool IsUsaExtAct { get => isUsaExtAct; set => isUsaExtAct = value; }
        public bool IsManIntAct { get => isManIntAct; set => isManIntAct = value; }
        public bool IsManExtAct { get => isManExtAct; set => isManExtAct = value; }

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

        private void cargarMetrica(JMetrica metrica)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            lblID.Content = metrica.Id;
            lblSubcaracteristica.Content = metrica.Subcaracteristica;
            lblNombre.Content = metrica.Nombre;
            labelProposito.Text = metrica.Proposito[0];
            labelMetodo.Text = metrica.Metodo;
            label1_formula.Content = metrica.Formula[0];
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


        private void cargarFuncionabilidad(JFuncionabilidad funcionalidad, string nombre, string perspectiva, ArrayList metricas)
        {
            // Etiquetas pricipales
            lblPerspectiva.Content = perspectiva;
            lblCaracteristica.Content = nombre;
            lblSubcaracteristica.Content = funcionalidad.Subcaracteristicas[0];

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


        private ArrayList cargarUsabilidad(JUsabilidad usabilidad, string nombre, string perspectiva, ArrayList metricas)
        {
            // Etiquetas pricipales
            lblPerspectiva.Content = perspectiva;
            lblCaracteristica.Content = nombre;
            lblSubcaracteristica.Content = usabilidad.Subcaracteristicas[0];

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

            return metricas;
        }


        private ArrayList cargarMantenibilidad(JMantenibilidad mantenibilidad, string nombre, string perspectiva, ArrayList metricas)
        {
            // Etiquetas pricipales
            lblPerspectiva.Content = perspectiva;
            lblCaracteristica.Content = nombre;
            lblSubcaracteristica.Content = mantenibilidad.Subcaracteristicas[0];

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

            return metricas;
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
            if ((indice + 1) < lista.Count)
            {
                indice++;

                if (indice == (lista.Count - 1))
                {
                    btnSiguiente.IsEnabled = false;
                }

                cargarMetrica((JMetrica)lista[indice]);

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
                avanzar(ref indexFunInt, funcionalidadInterna);
            }

            if (isFunExtAct)
            {
                avanzar(ref indexFunExt, funcionalidadExterna);
            }

            if (isUsaIntAct)
            {
                avanzar(ref indexUsaInt, usabilidadInterna);
            }

            if (isUsaExtAct)
            {
                avanzar(ref indexUsaExt, usabilidadExterna);
            }

            if (isManIntAct)
            {
                avanzar(ref indexManint, mantenibilidadInterna);
            }

            if (isManExtAct)
            {
                avanzar(ref indexManExt, mantenibilidadExterna);
            }
        }

        private void btnFinalizarCuestionario_Click(object sender, RoutedEventArgs e)
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

           // this.NavigationService.Navigate(new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.Relative));
           // NavigationService.Navigate(new Uri("Vistas/FormularioEvaluacionPage.xaml", UriKind.Relative));
            NavigationService.Navigate(origen);
        }
    
		private void btnGuardar_Click(object sender, RoutedEventArgs e)
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

        // Acceso a contenido

        public void FuncInterna_Activar(FormularioEvaluacionPage llamada)
        {
            origen = llamada;
            cargarEntorno();
            isFunIntAct = true;
            cargarFuncionabilidad(funInt, "Funcionabilidad", "Interna", funcionalidadInterna);
        }

        public void UsabInterna_Activar(FormularioEvaluacionPage llamada)
        {
            origen = llamada;
            cargarEntorno();
            isUsaIntAct = true;
            cargarUsabilidad(usaInt, "Usabilidad", "Interna", usabilidadInterna);
        }

        public void MantInterna_Activar(FormularioEvaluacionPage llamada)
        {
            origen = llamada;
            cargarEntorno();
            isManIntAct = true;
            cargarMantenibilidad(manInt, "Mantenibilidad", "Interna", mantenibilidadInterna);
        }

        public void FuncExterna_Activar(FormularioEvaluacionPage llamada)
        {
            origen = llamada;
            cargarEntorno();
            isFunExtAct = true;
            cargarFuncionabilidad(funExt, "Funcionalidad", "Externa", funcionalidadExterna);
        }

        public void UsabExterna_Activar(FormularioEvaluacionPage llamada)
        {
            origen = llamada;
            cargarEntorno();
            isUsaExtAct = true;
            cargarUsabilidad(usaExt, "Usabilidad", "Externa", usabilidadExterna);
        }

        public void MantExterna_Activar(FormularioEvaluacionPage llamada)
        {
            origen = llamada;
            cargarEntorno();
            isManExtAct = true;
            cargarMantenibilidad(manExt, "Mantenibilidad Externa", "Externa", mantenibilidadExterna);
        }

    }
}
