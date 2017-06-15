using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SW1_ISO9126_FUZZY.Archivos;


namespace SW1_ISO9126_FUZZY.Views {
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        public MainPage() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            InformesEvaluacionCalidad informe = new InformesEvaluacionCalidad();
        }
    }
}
