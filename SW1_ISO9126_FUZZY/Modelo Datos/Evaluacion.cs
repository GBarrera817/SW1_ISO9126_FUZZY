using SW1_ISO9126_FUZZY.Modelo_Datos.Estados;
using SW1_ISO9126_FUZZY.Modelo_Datos.Importancias;
using SW1_ISO9126_FUZZY.Modelo_Datos.Listas;
using SW1_ISO9126_FUZZY.Modelo_Datos.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    /// <summary>
    /// Evaluacion: Almacena todos los datos de la evaluacion
    /// </summary>

    public class Evaluacion
    {
        private bool estado;
        private Software informacion;
        private EstadoModulo datosMetricas;
        private ESubCaracteristicas estSubcaracteristicas;
        private Importancia grados;
        private EstadoModulo seleccionMetricas;
        private ListSeleccion seleccion;
        private EstadoModulo evaluacionMetricas;
        private ListEvaluacion fomulario;
        private ListCalculo calculos;
        private EstadoModulo calidadMetricas;
        private EstadoFinal estadoCalidadSoftware;
        private Resultado valorCalidadSoftware;


        public Evaluacion()
        {
            this.estado = false;
            this.informacion = new Software();
            this.datosMetricas = new EstadoModulo();
            this.estSubcaracteristicas = new ESubCaracteristicas();
            this.grados = new Importancia();
            this.seleccionMetricas = new EstadoModulo();
            this.seleccion = new ListSeleccion();
            this.evaluacionMetricas = new EstadoModulo();
            this.fomulario = new ListEvaluacion();
            this.calculos = new ListCalculo();
            this.calidadMetricas = new EstadoModulo();
            this.estadoCalidadSoftware = new EstadoFinal();
            this.valorCalidadSoftware = new Resultado();
        }

        public Evaluacion(bool estado, Software informacion, EstadoModulo datosMetricas, ESubCaracteristicas estSubcaracteristicas, Importancia grados, EstadoModulo seleccionMetricas, ListSeleccion seleccion, EstadoModulo evaluacionMetricas, ListEvaluacion fomulario, ListCalculo calculos, EstadoModulo calidadMetricas, EstadoFinal estadoCalidadSoftware, Resultado valorCalidadSoftware)
        {
            this.estado = estado;
            this.informacion = informacion;
            this.datosMetricas = datosMetricas;
            this.estSubcaracteristicas = estSubcaracteristicas;
            this.grados = grados;
            this.seleccionMetricas = seleccionMetricas;
            this.seleccion = seleccion;
            this.evaluacionMetricas = evaluacionMetricas;
            this.fomulario = fomulario;
            this.calculos = calculos;
            this.calidadMetricas = calidadMetricas;
            this.estadoCalidadSoftware = estadoCalidadSoftware;
            this.valorCalidadSoftware = valorCalidadSoftware;
        }

        public bool Estado { get => estado; set => estado = value; }
        public Software Informacion { get => informacion; set => informacion = value; }
        public EstadoModulo DatosMetricas { get => datosMetricas; set => datosMetricas = value; }
        public ESubCaracteristicas EstSubcaracteristicas { get => estSubcaracteristicas; set => estSubcaracteristicas = value; }
        public Importancia Grados { get => grados; set => grados = value; }
        public EstadoModulo SeleccionMetricas { get => seleccionMetricas; set => seleccionMetricas = value; }
        public ListSeleccion Seleccion { get => seleccion; set => seleccion = value; }
        public EstadoModulo EvaluacionMetricas { get => evaluacionMetricas; set => evaluacionMetricas = value; }
        public ListEvaluacion Fomulario { get => fomulario; set => fomulario = value; }
        public ListCalculo Calculos { get => calculos; set => calculos = value; }
        public EstadoModulo CalidadMetricas { get => calidadMetricas; set => calidadMetricas = value; }
        public EstadoFinal EstadoCalidadSoftware { get => estadoCalidadSoftware; set => estadoCalidadSoftware = value; }
        public Resultado ValorCalidadSoftware { get => valorCalidadSoftware; set => valorCalidadSoftware = value; }
    }
}
