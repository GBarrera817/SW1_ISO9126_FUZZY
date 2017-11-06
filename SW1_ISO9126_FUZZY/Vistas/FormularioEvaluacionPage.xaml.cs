using Newtonsoft.Json;
using SW1_ISO9126_FUZZY.JSON;
using SW1_ISO9126_FUZZY.Modelo_Datos;
using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SW1_ISO9126_FUZZY.Vistas
{
    /// <summary>
    /// Lógica de interacción para FormularioEvaluacionPage.xaml
    /// </summary>
    public partial class FormularioEvaluacionPage : Page {

        // Caracteristicas
        private JFuncionabilidad funInt;
        private JFuncionabilidad funExt;
        private JUsabilidad usaInt;
        private JUsabilidad usaExt;
        private JMantenibilidad manInt;
        private JMantenibilidad manExt;

        // Estado caracteristicas
        private bool isFunIntAct;
        private bool isFunExtAct;
        private bool isUsaIntAct;
        private bool isUsaExtAct;
        private bool isManIntAct;
        private bool isManExtAct;

        // Listas de caracteristicas
        private ArrayList funcionalidadInterna;
        private ArrayList funcionalidadExterna;
        private ArrayList usabilidadInterna;
        private ArrayList usabilidadExterna;
        private ArrayList mantenibilidadInterna;
        private ArrayList mantenibilidadExterna;

        // Listas de caracteristicas seleccionadas
        private ArrayList MTSfuncionalidadInterna;
        private ArrayList MTSfuncionalidadExterna;
        private ArrayList MTSusabilidadInterna;
        private ArrayList MTSusabilidadExterna;
        private ArrayList MTSmantenibilidadInterna;
        private ArrayList MTSmantenibilidadExterna;

        // Listas de caracteristicas evaluadas
        private ArrayList MTEfuncionalidadInterna;
        private ArrayList MTEfuncionalidadExterna;
        private ArrayList MTEusabilidadInterna;
        private ArrayList MTEusabilidadExterna;
        private ArrayList MTEmantenibilidadInterna;
        private ArrayList MTEmantenibilidadExterna;

        private FormEvaluacionPage paginaEvaluacion;
        private Respuesta metricas;
        private EstadoModulo evalMetricas;
        private Evaluacion miEvaluacion;

        public FormularioEvaluacionPage(Evaluacion nueva) {

            InitializeComponent();
            this.paginaEvaluacion = new FormEvaluacionPage();
            this.metricas = new Respuesta();
            this.evalMetricas = new EstadoModulo();
            this.miEvaluacion = nueva;

            inicializarEstadoCaracteristica();
            inicializarListas();
            inicializarSeleccion();
            inicializarEvaluacion();
            cargarJsonMetricas();
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

        private void inicializarSeleccion()
        {
            this.MTSfuncionalidadInterna = new ArrayList();
            this.MTSfuncionalidadExterna = new ArrayList();
            this.MTSusabilidadInterna = new ArrayList();
            this.MTSusabilidadExterna = new ArrayList();
            this.MTSmantenibilidadInterna = new ArrayList();
            this.MTSmantenibilidadExterna = new ArrayList();
        }

        private void inicializarEvaluacion()
        {
            this.MTEfuncionalidadInterna = new ArrayList();
            this.MTEfuncionalidadExterna = new ArrayList();
            this.MTEusabilidadInterna = new ArrayList();
            this.MTEusabilidadExterna = new ArrayList();
            this.MTEmantenibilidadInterna = new ArrayList();
            this.MTEmantenibilidadExterna = new ArrayList();
        }

        // Crear listas de metricas por caracteristicas

        private void cargarListaFuncionabilidad(JFuncionabilidad funcionalidad, ArrayList metricas)
        {
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
        }

        private void cargarListaUsabilidad(JUsabilidad usabilidad, ArrayList metricas)
        {
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
        }

        private void cargarListaMantenibilidad(JMantenibilidad mantenibilidad, ArrayList metricas)
        {
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
        }

        private void cargarJsonMetricas()
        {
            if (isFunIntAct)
            {
                funInt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadInterna.json"));
                cargarListaFuncionabilidad(funInt, funcionalidadInterna);
            }

            if (isFunExtAct)
            {
                funExt = JsonConvert.DeserializeObject<JFuncionabilidad>(File.ReadAllText("../../Archivos_configuracion/FuncionalidadExterna.json"));
                cargarListaFuncionabilidad(funExt, funcionalidadExterna);
            }

            if (isUsaIntAct)
            {
                usaInt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadInterna.json"));
                cargarListaUsabilidad(usaInt, usabilidadInterna);
            }

            if (isUsaExtAct)
            {
                usaExt = JsonConvert.DeserializeObject<JUsabilidad>(File.ReadAllText("../../Archivos_configuracion/UsabilidadExterna.json"));
                cargarListaUsabilidad(usaExt, usabilidadExterna);
            }

            if (isManIntAct)
            {
                manInt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadInterna.json"));
                cargarListaMantenibilidad(manInt, mantenibilidadInterna);
            }

            if (isManExtAct)
            {
                manExt = JsonConvert.DeserializeObject<JMantenibilidad>(File.ReadAllText("../../Archivos_configuracion/MantenibilidadExterna.json"));
                cargarListaMantenibilidad(manExt, mantenibilidadExterna);
            }
        }

        private void cambiarEstado(int estado, Label etiqueta)
        {
            var bc = new BrushConverter();
            string[] estados = new string[] { "INACTIVA", "REALIZAR", "COMPLETAR", "FINALIZADO" };
            string[] colores = new string[] { "#FF000033", "#FFCC0000", "#FFE6E600", "#FF00802B" };

            etiqueta.Background = (Brush)bc.ConvertFrom(colores[estado]);
            etiqueta.Content = estados[estado];
        }

        // Eventos botones menu flotante (flyout)

        private void btnTileClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Button clickedButton = (Button)e.Source;

            //Comprobar el estado de la seleccion de metricas

            switch (clickedButton.Name)
            {
                case "btnFuncInterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                    MTSfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnUsabInterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Interna", usabilidadInterna, MTSusabilidadInterna, MTEusabilidadInterna);
                    MTSusabilidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnMantInterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Interna", mantenibilidadInterna, MTSmantenibilidadInterna, MTEmantenibilidadInterna);
                    MTSmantenibilidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnFuncExterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Externa", funcionalidadExterna, MTSfuncionalidadExterna, MTEfuncionalidadExterna);
                    MTSfuncionalidadExterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnUsabExterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Usabilidad", "Externa", usabilidadExterna, MTSusabilidadExterna, MTEusabilidadExterna);
                    MTSusabilidadExterna = paginaEvaluacion.evaluacionMetrica();
                break;

                case "btnMantExterna":
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Mantenibilidad", "Externa", mantenibilidadExterna, MTSmantenibilidadExterna, MTEmantenibilidadExterna;
                    MTSmantenibilidadExterna = paginaEvaluacion.evaluacionMetrica();
                break;

                default:
                    paginaEvaluacion.cargarEvaluacionMetricas(this, "Funcionalidad", "Interna", funcionalidadInterna, MTSfuncionalidadInterna, MTEfuncionalidadInterna);
                    MTSfuncionalidadInterna = paginaEvaluacion.evaluacionMetrica();
                break;
            }

            this.NavigationService.Navigate(paginaEvaluacion);
        }
    }
}
