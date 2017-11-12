using SW1_ISO9126_FUZZY.Modelo_Datos;
using SW1_ISO9126_FUZZY.Modelo_Datos.Estados;
using SW1_ISO9126_FUZZY.Modelo_Datos.Importancias;
using System;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    
    public partial class RegistroSWPage : Page {

        private Evaluacion miEvaluacion;

        private Software aplicacion;
        private Importancia grados;
        private EstadoModulo estadoCaracteristicas;
        private ESubCaracteristicas estadoSubCaractetisticas;

        public RegistroSWPage(Evaluacion nueva) {

            InitializeComponent();

            this.miEvaluacion = nueva;
            this.aplicacion = new Software();
            this.grados = new Importancia();
            this.estadoCaracteristicas = new EstadoModulo();
            this.estadoSubCaractetisticas = new ESubCaracteristicas();
        }

        // guardar datos de la evaluacion

        private void guardarDatosSw()
        {
            string developers = txtDesarrolladores.Text;
            string combo = cmboxTipoEvaluador.SelectedItem.ToString();

            aplicacion.Evaluador = txtNombreEvaluador.Text;

            aplicacion.Tipo = combo.Split(':')[1];

            aplicacion.Nombre = txtnombreSW.Text;
            aplicacion.Desarrollador = developers.Split(',');

            if (rdbManual1.IsChecked == true)
                aplicacion.Manual = "Si";

            if (rdbManual2.IsChecked == true)
                aplicacion.Manual = "No";

            aplicacion.Descripcion = txtDescripcion.Text;
        }

        // guardar grados de importancia ingresados

        private void guardarGradosFuncionalidad()
        {
            if(lblFuncionalidad.IsChecked == true)
            {
                estadoCaracteristicas.FuncionalidadInterna = true;
                estadoCaracteristicas.FuncionalidadExterna = true;
                grados.Funcionalidad = Convert.ToDouble(dudFuncionalidad.Text);
            }

            if (lblAdecuacion.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarfuncionalidad.EstAdecuacion = true;
                grados.SbcFuncionalidad.Adecuacion = Convert.ToDouble(dudAdecuacion.Text);
            }


            if (lblExactitud.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarfuncionalidad.EstExactitud = true;
                grados.SbcFuncionalidad.Exactitud = Convert.ToDouble(dudExactitud.Text);
            }
              

            if (lblInteroperabilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarfuncionalidad.EstInteroperabilidad = true;
                grados.SbcFuncionalidad.Interoperabilidad = Convert.ToDouble(dudInteroperabilidad.Text);
            }
               

            if (lblSeguridad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarfuncionalidad.EstSeguridadAcceso = true;
                grados.SbcFuncionalidad.SeguridadAcceso = Convert.ToDouble(dudSeguridad.Text);
            }
                

            if (lblCumpFuncionalidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarfuncionalidad.EstCumplimientoFuncional = true;
                grados.SbcFuncionalidad.CumplimientoFuncional = Convert.ToDouble(dudCumpFuncionalidad.Text);
            }
                
        }

        private void guardarGradosUsabilidad()
        {
            if (lblUsabilidad.IsChecked == true)
            {
                estadoCaracteristicas.UsabilidadInterna = true;
                estadoCaracteristicas.UsabilidadExterna = true;
                grados.Usabilidad = Convert.ToDouble(dudUsabilidad.Text);
            }

            if (lblComprensibilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarusabilidad.EstComprensibilidad = true;
                grados.SbcUsabilidad.Comprensibilidad= Convert.ToDouble(dudComprensibilidad.Text);
            }


            if (lblAprendizaje.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarusabilidad.EstAprendizaje= true;
                grados.SbcUsabilidad.Aprendizaje = Convert.ToDouble(dudAprendizaje.Text);
            }


            if (lblOperabilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarusabilidad.EstOperabilidad = true;
                grados.SbcUsabilidad.Operabilidad = Convert.ToDouble(dudOperabilidad.Text);
            }


            if (lblAtractividad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarusabilidad.EstAtractividad = true;
                grados.SbcUsabilidad.Atractividad = Convert.ToDouble(dudAtractividad.Text);
            }


            if (lblCumpUsabilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarusabilidad.EstCumplimientoUsabilidad = true;
                grados.SbcUsabilidad.CumplimientoUsabilidad = Convert.ToDouble(dudCumpUsabilidad.Text);
            }
        }

        private void guardarGradosMantenbilidad()
        {
            if (lblMantenibilidad.IsChecked == true)
            {
                estadoCaracteristicas.MantenibilidadInterna = true;
                estadoCaracteristicas.MantenibilidadExterna = true;
                grados.Mantenibilidad = Convert.ToDouble(dudMantenibilidad.Text);
            }

            if (lblFacAnalisis.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarmantenibilidad.EstAnalizabilidad = true;
                grados.SbcMantenibilidad.Analizabilidad = Convert.ToDouble(dudFacAnalisis.Text);
            }


            if (lblModificabilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarmantenibilidad.EstModificabilidad = true;
                grados.SbcMantenibilidad.Modificabilidad = Convert.ToDouble(dudModificabilidad.Text);
            }


            if (lblEstabilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarmantenibilidad.EstEstabilidad = true;
                grados.SbcMantenibilidad.Estabilidad = Convert.ToDouble(dudEstabilidad.Text);
            }


            if (lblTesteabilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarmantenibilidad.EstTesteabilidad = true;
                grados.SbcMantenibilidad.Testeabilidad = Convert.ToDouble(dudTesteabilidad.Text);
            }


            if (lblCumpMantenibilidad.IsChecked == true)
            {
                estadoSubCaractetisticas.SubCarmantenibilidad.EstCumplimientoMantenibilidad = true;
                grados.SbcMantenibilidad.CumplimientoMantenibilidad = Convert.ToDouble(dudCumpMantenibilidad.Text);
            }
        }

        private void resgistrarDatos()
        {
            // Obtener desde la interfaz grafica
            guardarDatosSw();
            guardarGradosFuncionalidad();
            guardarGradosUsabilidad();
            guardarGradosMantenbilidad();

            // Asignar a la evaluacion
            miEvaluacion.Informacion = aplicacion;
            miEvaluacion.DatosMetricas = estadoCaracteristicas;
            miEvaluacion.EstSubcaracteristicas = estadoSubCaractetisticas;
            miEvaluacion.Grados = grados;
        }

        // validar datos del software

        private bool validar_datos_sw()
        {
            if(txtNombreEvaluador.Text == string.Empty)
                return false;

            if(txtnombreSW.Text == string.Empty)
                return false;

            if (txtDesarrolladores.Text == string.Empty)
                return false;

            if (rdbManual1.IsChecked == false && rdbManual2.IsChecked == false)
                return false;

            if(txtDescripcion.Text == string.Empty)
                return false;

            return true;
        }

        // Validar seleccion caracteristicas

        private bool validar_seleccion_caracteristicas()
        {
            if((lblFuncionalidad.IsChecked == false ) && (lblUsabilidad.IsChecked == false ) && (lblMantenibilidad.IsChecked == false))
                return false;
            
            return true;
        }

        // Validar valor caracteristicas

        private bool validar_valor_caracteristica_funcionalidad()
        {
            if (lblFuncionalidad.IsChecked == true)
            {
                if ((dudFuncionalidad.Value == 0) || (dudFuncionalidad.Value < 0) || (dudFuncionalidad.Value > 1))
                    return false;
            }

            return true;
        }

        private bool validar_valor_caracteristica_usabilidad()
        {
            if (lblUsabilidad.IsChecked == true)
            {
                if ((dudUsabilidad.Value == 0) || (dudUsabilidad.Value < 0) || (dudUsabilidad.Value > 1))
                    return false;
            }

            return true;
        }

        private bool validar_valor_caracteristica_mantenibilidad()
        {
            if (lblMantenibilidad.IsChecked == true)
            {
                if ((dudMantenibilidad.Value == 0) || (dudMantenibilidad.Value < 0) || (dudMantenibilidad.Value > 1))
                    return false;
            }

            return true;
        }

        // validar seleccion de subcaracteristicas

        private bool validar_seleccion_subcaracteristicas_funcionabilidad()
        {
            int contador = 0;

            if (lblAdecuacion.IsChecked == true)
                contador++;

            if (lblExactitud.IsChecked == true)
                contador++;

            if (lblInteroperabilidad.IsChecked == true)
                contador++;

            if (lblSeguridad.IsChecked == true)
                contador++;

            if (lblCumpFuncionalidad.IsChecked == true)
                contador++;

            if (contador != 0)
                return true;
            else
                return false;
        }

        private bool validar_seleccion_subcaracteristicas_usabilidad()
        {
            int contador = 0;

            if (lblAprendizaje.IsChecked == true)
                contador++;

            if (lblComprensibilidad.IsChecked == true)
                contador++;

            if (lblOperabilidad.IsChecked == true)
                contador++;

            if (lblAtractividad.IsChecked == true)
                contador++;

            if (lblCumpUsabilidad.IsChecked == true)
                contador++;

            if (contador != 0)
                return true;
            else
                return false;
        }

        private bool validar_seleccion_subcaracteristicas_mantenibilidad()
        {
            int contador = 0;

            if (lblFacAnalisis.IsChecked == true)
                contador++;

            if (lblModificabilidad.IsChecked == true)
                contador++;

            if (lblEstabilidad.IsChecked == true)
                contador++;

            if (lblTesteabilidad.IsChecked == true)
                contador++;

            if (lblCumpMantenibilidad.IsChecked == true)
                contador++;

            if (contador != 0)
                return true;
            else
                return false;
        }

        // validar valores 

        private bool validar_valores_subcaracteristicas_funcionabilidad()
        {
            if (lblAdecuacion.IsChecked == true)
            {
                if ((dudAdecuacion.Value == 0) || (dudAdecuacion.Value < 0) || (dudAdecuacion.Value > 1))
                    return false;
            }

            if (lblExactitud.IsChecked == true)
            {
                if ((dudExactitud.Value == 0) || (dudExactitud.Value < 0) || (dudExactitud.Value > 1))
                    return false;
            }

            if (lblInteroperabilidad.IsChecked == true)
            {
                if ((dudInteroperabilidad.Value == 0) || (dudInteroperabilidad.Value < 0) || (dudInteroperabilidad.Value > 1))
                    return false;
            }

            if (lblSeguridad.IsChecked == true)
            {
                if ((dudSeguridad.Value == 0) || (dudSeguridad.Value < 0) || (dudSeguridad.Value > 1))
                    return false;
            }

            if (lblCumpFuncionalidad.IsChecked == true)
            {
                if ((dudCumpFuncionalidad.Value == 0) || (dudCumpFuncionalidad.Value < 0) || (dudCumpFuncionalidad.Value > 1))
                    return false;
            }

            return true;

        }

        private bool validar_valores_subcaracteristicas_usabilidad()
        {
            if (lblAprendizaje.IsChecked == true)
            {
                if ((dudAprendizaje.Value == 0) || (dudAprendizaje.Value < 0) || (dudAprendizaje.Value > 1))
                    return false;
            }

            if (lblComprensibilidad.IsChecked == true)
            {
                if ((dudComprensibilidad.Value == 0) || (dudComprensibilidad.Value < 0) || (dudComprensibilidad.Value > 1))
                    return false;
            }

            if (lblOperabilidad.IsChecked == true)
            {
                if ((dudOperabilidad.Value == 0) || (dudOperabilidad.Value < 0) || (dudOperabilidad.Value > 1))
                    return false;
            }

            if (lblAtractividad.IsChecked == true)
            {
                if ((dudAtractividad.Value == 0) || (dudAtractividad.Value < 0) || (dudAtractividad.Value > 1))
                    return false;
            }

            if (lblCumpUsabilidad.IsChecked == true)
            {
                if ((dudCumpUsabilidad.Value == 0) || (dudCumpUsabilidad.Value < 0) || (dudCumpUsabilidad.Value > 1))
                    return false;
            }

            return true;

        }

        private bool validar_valores_subcaracteristicas_mantenibilidad()
        {
            if (lblFacAnalisis.IsChecked == true)
            {
                if ((dudFacAnalisis.Value == 0) || (dudFacAnalisis.Value < 0) || (dudFacAnalisis.Value > 1))
                    return false;
            }

            if (lblModificabilidad.IsChecked == true)
            {
                if ((dudModificabilidad.Value == 0) || (dudModificabilidad.Value < 0) || (dudModificabilidad.Value > 1))
                    return false;
            }

            if (lblEstabilidad.IsChecked == true)
            {
                if ((dudEstabilidad.Value == 0) || (dudEstabilidad.Value < 0) || (dudEstabilidad.Value > 1))
                    return false;
            }

            if (lblTesteabilidad.IsChecked == true)
            {
                if ((dudTesteabilidad.Value == 0) || (dudTesteabilidad.Value < 0) || (dudTesteabilidad.Value > 1))
                    return false;
            }

            if (lblCumpMantenibilidad.IsChecked == true)
            {
                if ((dudCumpMantenibilidad.Value == 0) || (dudCumpMantenibilidad.Value < 0) || (dudCumpMantenibilidad.Value > 1))
                    return false;
            }

            return true;

        }

        // Eventos botones

        private void btnSigSW_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tabInfoSoftware.SelectedIndex = tabInfoSoftware.SelectedIndex + 1;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            bool datosSW = false;
            bool funcionalidad = false;
            bool usabilidad = false;
            bool mantenibilidad = false;

            if (validar_datos_sw())
            {
                datosSW = true;
                //Xceed.Wpf.Toolkit.MessageBox.Show(datos.ToString(), "Datos del software", MessageBoxButton.OK, MessageBoxImage.Information);

                if (validar_seleccion_caracteristicas())
                {
                    if (lblFuncionalidad.IsChecked == true)
                    {
                        if (validar_valor_caracteristica_funcionalidad())
                        {
                            if (validar_seleccion_subcaracteristicas_funcionabilidad())
                            {
                                if (validar_valores_subcaracteristicas_funcionabilidad())
                                {
                                    funcionalidad = true;
                                }
                                else
                                {
                                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar un valor válido para la subcaracterística de funcionabilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar al menos una subcaracterística para funcionabilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar un valor válido para la característica funcionabilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }


                    if (lblUsabilidad.IsChecked == true)
                    {
                        if (validar_valor_caracteristica_usabilidad())
                        {
                            if (validar_seleccion_subcaracteristicas_usabilidad())
                            {
                                if (validar_valores_subcaracteristicas_usabilidad())
                                {
                                    usabilidad = true;
                                }
                                else
                                {
                                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar un valor válido para la subcaracterística de usabilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar al menos una subcaracterística para usabilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar un valor válido para la característica usabilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }


                    if (lblMantenibilidad.IsChecked == true)
                    {
                        if (validar_valor_caracteristica_mantenibilidad())
                        {
                            if (validar_seleccion_subcaracteristicas_mantenibilidad())
                            {
                                if (validar_valores_subcaracteristicas_mantenibilidad())
                                {
                                    mantenibilidad = true;
                                }
                                else
                                {
                                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar un valor válido para la subcaracterística de mantenibilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar al menos una subcaracterística para mantenibilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar un valor válido para la característica mantenibilidad", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Debe seleccionar al menos una característica para la evaluación del software", "Grados de importancia", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Debe completar los datos del evaluador y del software para realizar la evaluación", "Datos del software", MessageBoxButton.OK, MessageBoxImage.Information);
                tabInfoSoftware.SelectedIndex = tabInfoSoftware.SelectedIndex -1;
            }


            if ( (datosSW == true) && ( (lblFuncionalidad.IsChecked == true && funcionalidad == true) || (lblUsabilidad.IsChecked == true && usabilidad == true) || (lblMantenibilidad.IsChecked == true && mantenibilidad == true)) )
            {
                resgistrarDatos();
                Xceed.Wpf.Toolkit.MessageBox.Show("Datos de evaluador, software y grados de importancia almacenados correctamente", "Registro datos evaluación", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new VistaPreviaSeleccionMetricaPage(miEvaluacion));
            }
        }

        // Eventos checkbox grandes funcionalidad

        private void lblFuncionalidad_Checked(object sender, RoutedEventArgs e)
        {
            dudFuncionalidad.IsEnabled = true;

            lblAdecuacion.IsEnabled = true;
            lblExactitud.IsEnabled = true;
            lblInteroperabilidad.IsEnabled = true;
            lblSeguridad.IsEnabled = true;
            lblCumpFuncionalidad.IsEnabled = true;
        }

        private void lblFuncionalidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudFuncionalidad.IsEnabled = false;
            dudFuncionalidad.Value = 0;

            lblAdecuacion.IsEnabled = false;
            lblAdecuacion.IsChecked = false;
            dudAdecuacion.IsEnabled = false;
            dudAdecuacion.Value = 0;
            lblExactitud.IsEnabled = false;
            lblExactitud.IsChecked = false;
            dudExactitud.IsEnabled = false;
            dudExactitud.Value = 0;
            lblInteroperabilidad.IsEnabled = false;
            lblInteroperabilidad.IsChecked = false;
            dudInteroperabilidad.IsEnabled = false;
            dudInteroperabilidad.Value = 0;
            lblSeguridad.IsEnabled = false;
            lblSeguridad.IsChecked = false;
            dudSeguridad.IsEnabled = false;
            dudSeguridad.Value = 0;
            lblCumpFuncionalidad.IsEnabled = false;
            lblCumpFuncionalidad.IsChecked = false;
            dudCumpFuncionalidad.IsEnabled = false;
            dudCumpFuncionalidad.Value = 0;
        }

        // Eventos checkbox grandes usabilidad

        private void lblUsabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudUsabilidad.IsEnabled = true;

            lblAprendizaje.IsEnabled = true;           
            lblComprensibilidad.IsEnabled = true;        
            lblOperabilidad.IsEnabled = true;
            lblAtractividad.IsEnabled = true;            
            lblCumpUsabilidad.IsEnabled = true;            
        }

        private void lblUsabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudUsabilidad.IsEnabled = false;
            dudUsabilidad.Value = 0;

            lblAprendizaje.IsEnabled = false;
            lblAprendizaje.IsChecked = false;
            dudAprendizaje.IsEnabled = false;
            dudAprendizaje.Value = 0;
            lblComprensibilidad.IsEnabled = false;
            lblComprensibilidad.IsChecked = false;
            dudComprensibilidad.IsEnabled = false;
            dudComprensibilidad.Value = 0;
            lblOperabilidad.IsEnabled = false;
            lblOperabilidad.IsChecked = false;
            dudOperabilidad.IsEnabled = false;
            dudOperabilidad.Value = 0;
            lblAtractividad.IsEnabled = false;
            lblAtractividad.IsChecked = false;
            dudAtractividad.IsEnabled = false;
            dudAtractividad.Value = 0;
            lblCumpUsabilidad.IsEnabled = false;
            lblCumpUsabilidad.IsChecked = false;
            dudCumpUsabilidad.IsEnabled = false;
            dudCumpUsabilidad.Value = 0;
        }

        // Eventos checkbox grandes mantenibilidad

        private void lblMantenibilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudMantenibilidad.IsEnabled = true;

            lblFacAnalisis.IsEnabled = true;
            lblModificabilidad.IsEnabled = true;
            lblEstabilidad.IsEnabled = true;
            lblTesteabilidad.IsEnabled = true;
            lblCumpMantenibilidad.IsEnabled = true;
        }

        private void lblMantenibilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudMantenibilidad.IsEnabled = false;
            dudMantenibilidad.Value = 0;

            lblFacAnalisis.IsEnabled = false;
            lblFacAnalisis.IsChecked = false;
            dudFacAnalisis.IsEnabled = false;
            dudFacAnalisis.Value = 0;
            lblModificabilidad.IsEnabled = false;
            lblModificabilidad.IsChecked = false;
            dudModificabilidad.IsEnabled = false;
            dudModificabilidad.Value = 0;
            lblEstabilidad.IsEnabled = false;
            lblEstabilidad.IsChecked = false;
            dudEstabilidad.IsEnabled = false;
            dudEstabilidad.Value = 0;
            lblTesteabilidad.IsEnabled = false;
            lblTesteabilidad.IsChecked = false;
            dudTesteabilidad.IsEnabled = false;
            dudTesteabilidad.Value = 0;
            lblCumpMantenibilidad.IsEnabled = false;
            lblCumpMantenibilidad.IsChecked = false;
            dudCumpMantenibilidad.IsEnabled = false;
            dudCumpMantenibilidad.Value = 0;
        }

        // Eventos checkbox chicos funcionalidad

        private void lblAdecuacion_Checked(object sender, RoutedEventArgs e)
        {
            dudAdecuacion.IsEnabled = true;
        }

        private void lblAdecuacion_UnChecked(object sender, RoutedEventArgs e)
        {
            dudAdecuacion.IsEnabled = false;
            dudAdecuacion.Value = 0;
        }

        private void lblExactitud_Checked(object sender, RoutedEventArgs e)
        {
            dudExactitud.IsEnabled = true;
        }

        private void lblExactitud_UnChecked(object sender, RoutedEventArgs e)
        {
            dudExactitud.IsEnabled = false;
            dudExactitud.Value = 0;
        }

        private void lblInteroperabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudInteroperabilidad.IsEnabled = true;
        }

        private void lblInteroperabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudInteroperabilidad.IsEnabled = false;
            dudInteroperabilidad.Value = 0;
        }

        private void lblSeguridad_Checked(object sender, RoutedEventArgs e)
        {
            dudSeguridad.IsEnabled = true;
        }

        private void lblSeguridad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudSeguridad.IsEnabled = false;
            dudSeguridad.Value = 0;
        }

        private void lblCumpFuncionalidad_Checked(object sender, RoutedEventArgs e)
        {
            dudCumpFuncionalidad.IsEnabled = true;
        }

        private void lblCumpFuncionalidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudCumpFuncionalidad.IsEnabled = false;
            dudCumpFuncionalidad.Value = 0;
        }

        // Eventos checkbox chicos usabilidad

        private void lblAprendizaje_Checked(object sender, RoutedEventArgs e)
        {
            dudAprendizaje.IsEnabled = true;
        }

        private void lblAprendizaje_UnChecked(object sender, RoutedEventArgs e)
        {
            dudAprendizaje.IsEnabled = false;
            dudAprendizaje.Value = 0;
        }

        private void lblComprensibilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudComprensibilidad.IsEnabled = true;
        }

        private void lblComprensibilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudComprensibilidad.IsEnabled = false;
            dudComprensibilidad.Value = 0;
        }

        private void lblOperabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudOperabilidad.IsEnabled = true;
        }

        private void lblOperabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudOperabilidad.IsEnabled = false;
            dudOperabilidad.Value = 0;
        }

        private void lblAtractividad_Checked(object sender, RoutedEventArgs e)
        {
            dudAtractividad.IsEnabled = true;
        }

        private void lblAtractividad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudAtractividad.IsEnabled = false;
            dudAtractividad.Value = 0;
        }

        private void lblCumpUsabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudCumpUsabilidad.IsEnabled = true;
        }

        private void lblCumpUsabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudCumpUsabilidad.IsEnabled = false;
            dudCumpUsabilidad.Value = 0;
        }

        // Eventos checkbox chicos mantenibilidad

        private void lblFacAnalisis_Checked(object sender, RoutedEventArgs e)
        {
            dudFacAnalisis.IsEnabled = true;
        }

        private void lblFacAnalisis_UnChecked(object sender, RoutedEventArgs e)
        {
            dudFacAnalisis.IsEnabled = false;
            dudFacAnalisis.Value = 0;
        }

        private void lblModificabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudModificabilidad.IsEnabled = true;
        }

        private void lblModificabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudModificabilidad.IsEnabled = false;
            dudModificabilidad.Value = 0;
        }

        private void lblEstabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudEstabilidad.IsEnabled = true;        
        }

        private void lblEstabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudEstabilidad.IsEnabled = false;
            dudEstabilidad.Value = 0;
        }

        private void lblTesteabilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudTesteabilidad.IsEnabled = true; 
        }

        private void lblTesteabilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudTesteabilidad.IsEnabled = false;
            dudTesteabilidad.Value = 0;
        }

        private void lblCumpMantenibilidad_Checked(object sender, RoutedEventArgs e)
        {
            dudCumpMantenibilidad.IsEnabled = true;
        }

        private void lblCumpMantenibilidad_UnChecked(object sender, RoutedEventArgs e)
        {
            dudCumpMantenibilidad.IsEnabled = false;
            dudCumpMantenibilidad.Value = 0;
        }
    }
}
