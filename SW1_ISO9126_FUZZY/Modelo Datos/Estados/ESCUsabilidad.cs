using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    /// Estado Subcaracteristica Usabilidad
    /// </summary>

    public class ESCUsabilidad
    {
        private bool estComprensibilidad;
        private bool estAprendizaje;
        private bool estOperabilidad;
        private bool estAtractividad;
        private bool estCumplimientoUsabilidad;

        public ESCUsabilidad()
        {
            this.estComprensibilidad = false;
            this.estAprendizaje = false;
            this.estOperabilidad = false;
            this.estAtractividad = false;
            this.estCumplimientoUsabilidad = false;
        }

        public bool EstComprensibilidad { get => estComprensibilidad; set => estComprensibilidad = value; }
        public bool EstAprendizaje { get => estAprendizaje; set => estAprendizaje = value; }
        public bool EstOperabilidad { get => estOperabilidad; set => estOperabilidad = value; }
        public bool EstAtractividad { get => estAtractividad; set => estAtractividad = value; }
        public bool EstCumplimientoUsabilidad { get => estCumplimientoUsabilidad; set => estCumplimientoUsabilidad = value; }
    }
}
