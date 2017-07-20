﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    public class Evaluacion
    {
        private Software informacion;
        private Importancia grados;
        private Seleccion eleccion;
        private Respuesta fomulario;
        private Calculo resultados;
        private EstadoModulo seleccionMetricas;
        private EstadoModulo evaluacionMetricas;
        private EstadoModulo calidad;

        public Evaluacion(){}

        public Evaluacion(Software informacion, Importancia grados, Seleccion eleccion, Respuesta fomulario, Calculo resultados, EstadoModulo seleccionMetricas, EstadoModulo evaluacionMetricas, EstadoModulo calidad)
        {
            this.Informacion = informacion;
            this.Grados = grados;
            this.Eleccion = eleccion;
            this.Fomulario = fomulario;
            this.Resultados = resultados;
            this.SeleccionMetricas = seleccionMetricas;
            this.EvaluacionMetricas = evaluacionMetricas;
            this.calidad = calidad;
        }

        public Software Informacion { get => informacion; set => informacion = value; }
        public Importancia Grados { get => grados; set => grados = value; }
        public Seleccion Eleccion { get => eleccion; set => eleccion = value; }
        public Respuesta Fomulario { get => fomulario; set => fomulario = value; }
        public Calculo Resultados { get => resultados; set => resultados = value; }
        public EstadoModulo SeleccionMetricas { get => seleccionMetricas; set => seleccionMetricas = value; }
        public EstadoModulo EvaluacionMetricas { get => evaluacionMetricas; set => evaluacionMetricas = value; }
        public EstadoModulo Calidad { get => calidad; set => calidad = value; }

    }
}
