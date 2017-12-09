using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    /// Estado Final: Estado evaluacion de calidad
    /// </summary>

    public class EstadoFinal
    {
        private bool calidadSubCarateristicaIntena;
        private bool calidadSubCaracteristicaExterna;
        private bool calidadCaracteristicasInterna;
        private bool calidadCaracteristicasExterna;
        private bool calidadFinal;

        public EstadoFinal()
        {
            this.calidadSubCarateristicaIntena = false;
            this.calidadSubCaracteristicaExterna = false;
            this.calidadCaracteristicasInterna = false;
            this.CalidadCaracteristicasExterna = false;
            this.calidadFinal = false;
        }

        public bool CalidadSubCarateristicaIntena { get => calidadSubCarateristicaIntena; set => calidadSubCarateristicaIntena = value; }
        public bool CalidadSubCaracteristicaExterna { get => calidadSubCaracteristicaExterna; set => calidadSubCaracteristicaExterna = value; }
        public bool CalidadCaracteristicasInterna { get => calidadCaracteristicasInterna; set => calidadCaracteristicasInterna = value; }
        public bool CalidadCaracteristicasExterna { get => calidadCaracteristicasExterna; set => calidadCaracteristicasExterna = value; }
        public bool CalidadFinal { get => calidadFinal; set => calidadFinal = value; }
    }
}
