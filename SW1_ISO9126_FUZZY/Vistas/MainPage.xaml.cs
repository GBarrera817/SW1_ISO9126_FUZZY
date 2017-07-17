﻿using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
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

        public MainPage(Evaluacion nueva)
        {
            InitializeComponent();
            this.miEvaluacion = nueva;
            this.estadoEvaluacion = false;
        }

        public Evaluacion MiEvaluacion { get => miEvaluacion; set => miEvaluacion = value; }

        private void btnComenzarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{

            if (!estadoEvaluacion)
            {
                miEvaluacion = new Evaluacion();
                estadoEvaluacion = true;

                Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);

                Navigation.Navigation.Navigate(new Uri("Vistas/RegistroSWPage.xaml", UriKind.Relative));
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }

           
            //this.NavigationService.Navigate(new Uri("Vistas/RegistroSWPage.xaml", UriKind.Relative));
        }

		private void btnCargarEvaluacion_Click(object sender, System.Windows.RoutedEventArgs e)
		{

            if (!estadoEvaluacion)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //// Set filter options and filter index.
                openFileDialog1.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = true;

                // Process input if the user clicked OK.
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Cargar evaluacion desde JSON, json object to .net object

                    estadoEvaluacion = true;

                    Xceed.Wpf.Toolkit.MessageBox.Show("Evaluación creada satisfactoriamente", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);

                    Navigation.Navigation.Navigate(new Uri("Vistas/RegistroSWPage.xaml", UriKind.Relative));
                }

            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("La evaluación ya fue creada", "Inicio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
	}
}
