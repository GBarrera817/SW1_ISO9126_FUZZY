using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Resultados
{
    /// <summary>
    /// Resultado SubCaracteristica Funcionalidad: Resultados de la evaluacion difusa subcaracteristicas Funcionalidad
    /// </summary>

    public class RSCFuncionalidad
    {
        private string lingAdecuacion;
        private string lingExactitud;
        private string lingInteroperabilidad;
        private string lingSeguridadAcceso;
        private string lingCumplimientoFuncional;

        private double numAdecuacion;
        private double numExactitud;
        private double numInteroperabilidad;
        private double numSeguridadAcceso;
        private double numCumplimientoFuncional;

        public RSCFuncionalidad()
        {
            this.LingAdecuacion = "";
            this.LingExactitud = "";
            this.LingInteroperabilidad = "";
            this.LingSeguridadAcceso = "";
            this.LingCumplimientoFuncional = "";

            this.NumAdecuacion = 0;
            this.NumExactitud = 0;
            this.NumInteroperabilidad = 0;
            this.NumSeguridadAcceso = 0;
            this.NumCumplimientoFuncional = 0;
        }

        public string LingAdecuacion { get => lingAdecuacion; set => lingAdecuacion = value; }
        public string LingExactitud { get => lingExactitud; set => lingExactitud = value; }
        public string LingInteroperabilidad { get => lingInteroperabilidad; set => lingInteroperabilidad = value; }
        public string LingSeguridadAcceso { get => lingSeguridadAcceso; set => lingSeguridadAcceso = value; }
        public string LingCumplimientoFuncional { get => lingCumplimientoFuncional; set => lingCumplimientoFuncional = value; }

        public double NumAdecuacion { get => numAdecuacion; set => numAdecuacion = value; }
        public double NumExactitud { get => numExactitud; set => numExactitud = value; }
        public double NumInteroperabilidad { get => numInteroperabilidad; set => numInteroperabilidad = value; }
        public double NumSeguridadAcceso { get => numSeguridadAcceso; set => numSeguridadAcceso = value; }
        public double NumCumplimientoFuncional { get => numCumplimientoFuncional; set => numCumplimientoFuncional = value; }
    }
}
