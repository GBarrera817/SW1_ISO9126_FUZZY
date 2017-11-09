using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    ///  Estado evaluacion de calidad
    /// </summary>

    public class EstadoFinal
    {
        private bool calidadCaracteristicasInterna;
        private bool calidadCaracteristicasExterna;
        private bool calidadFinal;

        public EstadoFinal()
        {
            this.CalidadCaracteristicasInterna = false;
            this.CalidadCaracteristicasExterna = false;
            this.CalidadFinal = false;
        }

        public bool CalidadCaracteristicasInterna { get => calidadCaracteristicasInterna; set => calidadCaracteristicasInterna = value; }
        public bool CalidadCaracteristicasExterna { get => calidadCaracteristicasExterna; set => calidadCaracteristicasExterna = value; }
        public bool CalidadFinal { get => calidadFinal; set => calidadFinal = value; }
    }
}
