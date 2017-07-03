using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using System.Data;
using System.IO;
using System.Windows.Controls;

namespace SW1_ISO9126_FUZZY.Vistas {
    /// <summary>
    /// Lógica de interacción para ConfiguracionMetricasPage.xaml
    /// </summary>
    public partial class SeleccionMetricasPage : Page {

        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;


        public SeleccionMetricasPage()
        {
            InitializeComponent();
            cargarJsonMetricas();
        }


        // Accesores

        public JFuncionabilidad FunInt { get => funInt; set => funInt = value; }
        public JFuncionabilidad FunExt { get => funExt; set => funExt = value; }
        public JUsabilidad UsaInt { get => usaInt; set => usaInt = value; }
        public JUsabilidad UsaExt { get => usaExt; set => usaExt = value; }
        public JMantenibilidad ManInt { get => manInt; set => manInt = value; }
        public JMantenibilidad ManExt { get => manExt; set => manExt = value; }


        // Metodos

        private void cargarJsonMetricas()
        {
            funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
            funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
            usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
            usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
            manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
            manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));
        }



        // Eventos

        private void btnFuncInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            tblckTituloCaracteristica.Text = "Funcionalidad Interna";
            lblPerpectiva.Content = "Interna"; 
            lblSubcaracterística.Content = "Cambiando contenido";
            //lblPerpectiva
        }

        private void btnUsabInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Usabilidad Interna";
            lblPerpectiva.Content = "Interna";
        }

        private void btnMantInterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Mantenibilidad Interna";
            lblPerpectiva.Content = "Interna";
        }

        private void btnUsabExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Usabilidad Externa";
            lblPerpectiva.Content = "Externa";
        }

        private void btnFuncExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Funcionalidad Externa";
            lblPerpectiva.Content = "Externa";
        }

        private void btnMantExterna_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tblckTituloCaracteristica.Text = "Mantenibilidad Externa";
            lblPerpectiva.Content = "Externa";
        }



    }
}
