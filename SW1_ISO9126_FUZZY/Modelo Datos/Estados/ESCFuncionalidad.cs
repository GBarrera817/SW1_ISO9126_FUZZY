using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    /// Estado Subcaracteristica Funcionalidad: Guarda el estado (booleano) de las subcaracteristicas de Funcionalidad
    /// </summary>

    public class ESCFuncionalidad
    {
        private bool estAdecuacion;
        private bool estExactitud;
        private bool estInteroperabilidad;
        private bool estSeguridadAcceso;
        private bool estCumplimientoFuncional;

        public ESCFuncionalidad()
        {
            this.estAdecuacion = false;
            this.estExactitud = false;
            this.estInteroperabilidad = false;
            this.estSeguridadAcceso = false;
            this.estCumplimientoFuncional = false;
        }

        public bool EstAdecuacion { get => estAdecuacion; set => estAdecuacion = value; }
        public bool EstExactitud { get => estExactitud; set => estExactitud = value; }
        public bool EstInteroperabilidad { get => estInteroperabilidad; set => estInteroperabilidad = value; }
        public bool EstSeguridadAcceso { get => estSeguridadAcceso; set => estSeguridadAcceso = value; }
        public bool EstCumplimientoFuncional { get => estCumplimientoFuncional; set => estCumplimientoFuncional = value; }
    }
}
