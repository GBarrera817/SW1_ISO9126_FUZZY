using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    
    public partial class MainPage : Page
    {
        private Evaluacion miEvaluacion;

        private bool estadoEvaluacion;

        private RegistroSWPage paginaRegistro;

        public MainPage(Evaluacion nueva, RegistroSWPage pagina)
        {
            InitializeComponent();

            this.miEvaluacion = nueva;
            this.estadoEvaluacion = false;

            this.paginaRegistro = pagina;
        }

        // Crea un archivo en disco

        public void crearArchivo(string nombre, string info)
        {
            // crear el path
            var archivo = nombre;

            // crear el fichero
            using (var fileStream = File.Create(archivo))
            {
                var texto = new UTF8Encoding(true).GetBytes(info);
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();
            }
        }

        // Guarda la evaluacion en formato JSON

        private void guardarEvaluacion()
        {
            string ruta, output;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.InitialDirectory = "c:\\Documentos";
            saveFileDialog.Filter = "Archivos JSON (.json)|*.json";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ruta = saveFileDialog.FileName;
                output = JsonConvert.SerializeObject(miEvaluacion, Formatting.Indented);
                crearArchivo(ruta, output);
              
                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación guardada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cargarJson()
        {
            //string filtro "Archivos JSON (.json)|*.json|Todos los archivos (*.*)|*.*";
            string ruta, output;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();      
            openFileDialog1.Filter = "Archivos JSON (.json)|*.json";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            var resultado = openFileDialog1.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                /* validar Json
                if (validarJson())
                {
                    // Cargar evaluacion desde JSON, json object to .net object
                }else{
                    mensaje de error
                }*/


                // Cargar evaluacion desde JSON, json object to .net object

                ruta = openFileDialog1.FileName;
                Console.WriteLine("Archivo: "+ruta);

                miEvaluacion = JsonConvert.DeserializeObject<Evaluacion>(File.ReadAllText(ruta));
                output = JsonConvert.SerializeObject(miEvaluacion, Formatting.Indented);
                Console.WriteLine(output);

                estadoEvaluacion = true;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación cargada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(paginaRegistro);
            }

            if (resultado == DialogResult.Cancel)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Carga de evaluación desde archivo cancelada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool validarJson()
        {
            // Verifica la estructura del json
            return true;
        }

        private void loadMessenger()
        {
            Navigation.Navigation.Navigate(new Uri("https://www.messenger.com/login.php"));
        }

        // Evento botones

        private void btnComenzarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!estadoEvaluacion)
            {
                estadoEvaluacion = true;
                miEvaluacion.Estado = estadoEvaluacion;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(paginaRegistro);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCargarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult respuesta;

            if (!estadoEvaluacion)
            {
                cargarJson();
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
                respuesta = Xceed.Wpf.Toolkit.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (respuesta == MessageBoxResult.Yes)
                {
                    cargarJson();
                }
            }
        }

        private void btnGuardarEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            if (estadoEvaluacion)           
                guardarEvaluacion();       
            else         
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe crear la evaluación para poder guardarla", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);     
        }

        /* Ejemplos de MessageBox
         
            MessageBoxResult result4 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result1 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            MessageBoxResult result7 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            MessageBoxResult result5 = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "Extended WPF ToolKit MessageBox", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            Windows.MessageBox

		        MessageBoxResult respuesta;

		        respuesta = System.Windows.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

		        if (respuesta == MessageBoxResult.Yes)

            Windows.Forms.MessageBox
			
			    DialogResult  respuesta;

                respuesta = System.Windows.Forms.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
			
            Xceed.Wpf.ToolKit.MessageBox
			
				MessageBoxResult respuesta;

				respuesta = System.Windows.MessageBox.Show("¿Desea sobre escribir la evaluación ya cargada?, se perderan todos los datos actuales", "Cargar evaluación desde archivo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

				if (respuesta == MessageBoxResult.Yes)
        */
    }
}
