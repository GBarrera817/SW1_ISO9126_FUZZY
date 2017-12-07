using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Estados;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using SW1_ISO9126_FUZZY.Modelo_Datos.Resultados;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace SW1_ISO9126_FUZZY.Vistas
{
	/// <summary>
	/// Lógica de interacción para EvaluacionCalidadPage.xaml
	/// </summary>
    
	public partial class EvaluacionCalidadPage : Page
	{
        // Listas resultados caracteristicas
        private List<MTCalculo> MTCfuncionalidadInterna;
        private List<MTCalculo> MTCusabilidadInterna;
        private List<MTCalculo> MTCmantenibilidadInterna;
        private List<MTCalculo> MTCfuncionalidadExterna;
        private List<MTCalculo> MTCusabilidadExterna;
        private List<MTCalculo> MTCmantenibilidadExterna;

        private EstadoModulo calidadMetricas;
        private EstadoFinal estadoFinalEvaluacion;
        private Resultado resultadoFinalEvaluacion;
        private Evaluacion miEvaluacion;

        public EvaluacionCalidadPage(Evaluacion nueva)
		{
			InitializeComponent();

            this.miEvaluacion = nueva;
            this.calidadMetricas = new EstadoModulo();
            this.estadoFinalEvaluacion = new EstadoFinal();
            this.resultadoFinalEvaluacion = new Resultado();
        }

        // Crear listas calculos metricas 

        private void inicializarListasCalculos(Evaluacion datos)
        {
            if (datos.DatosMetricas.FuncionalidadInterna)
                MTCfuncionalidadInterna = new List<MTCalculo>();

            if (datos.DatosMetricas.UsabilidadInterna)
                MTCusabilidadInterna = new List<MTCalculo>();

            if (datos.DatosMetricas.MantenibilidadInterna)          
                MTCmantenibilidadInterna = new List<MTCalculo>();        

            if (datos.DatosMetricas.FuncionalidadExterna)
                MTCfuncionalidadExterna = new List<MTCalculo>();

            if (datos.DatosMetricas.UsabilidadExterna)
                MTCusabilidadExterna = new List<MTCalculo>();

            if (datos.DatosMetricas.MantenibilidadExterna)
                MTCmantenibilidadExterna = new List<MTCalculo>();
        }

        // Cargar tablas subcaracteristicas internas

        // Cargar tablas subcaracteristicas externas

        // Carga el modulo completo segun los datos obtenidos desde pagina de registro

        public void cargarDatosModulo(Evaluacion datos)
        {
            inicializarListasCalculos(datos);
        }
        



        // Eventos de movimiento

		private void retrocederTabControl(object sender, RoutedEventArgs e)
		{
			tabControlEvaluacionCalidad.SelectedIndex = tabControlEvaluacionCalidad.SelectedIndex - 1;
		}

        private void avanzarTabControl(object sender, RoutedEventArgs e)
        {
            tabControlEvaluacionCalidad.SelectedIndex = tabControlEvaluacionCalidad.SelectedIndex + 1;
        }

        // ----------------------------- PAGINA CALIDAD SUBCARACTERISTICAS ---------------------------------------

        private void btnCalcSubInterna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalcSubExterna_Click(object sender, RoutedEventArgs e)
        {

        }

        // ------------------------------- PAGINA CALIDAD CARACTERISTICAS ----------------------------------------

        private void btnCalcCaractInterna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalcCaractExterna_Click(object sender, RoutedEventArgs e)
        {

        }

        // ----------------------------------- PAGINA CALIDAD FINAL ----------------------------------------------

        // Validar datos para configurar PDF
        
        private bool validarConfigPDF()
        {
            if (txtNombreArchivor.Text == string.Empty)
                return false;
            return true;
        }

        private bool validarDatosReporte()
        {
            if (txtObjetivos.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        // Eventos botones

        private void btnCalcCalidadFinal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            if (validarDatosReporte())
            {
                if (validarConfigPDF())
                {
                    /*if (validarEvaluacion())
                    {
                        btnGenerarPDF();
                    }
                    */
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el nombre del archivo para generar el reporte", "Configuración reporte calidad", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe ingresar el objetivo de la evaluación para generar el reporte", "Reporte calidad final software", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
