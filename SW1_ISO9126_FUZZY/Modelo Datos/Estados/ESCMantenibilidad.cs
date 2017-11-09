using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    /// Estado Subcaracteristica Mantenibilidad
    /// </summary>

    public class ESCMantenibilidad
    {
        private bool estAnalizabilidad;
        private bool estModificabilidad;
        private bool estEstabilidad;
        private bool estTesteabilidad;
        private bool estCumplimientoMantenibilidad;

        public ESCMantenibilidad()
        {
            this.estAnalizabilidad = false;
            this.estModificabilidad = false;
            this.estEstabilidad = false;
            this.estTesteabilidad = false;
            this.estCumplimientoMantenibilidad = false;
        }

        public bool EstAnalizabilidad { get => estAnalizabilidad; set => estAnalizabilidad = value; }
        public bool EstModificabilidad { get => estModificabilidad; set => estModificabilidad = value; }
        public bool EstEstabilidad { get => estEstabilidad; set => estEstabilidad = value; }
        public bool EstTesteabilidad { get => estTesteabilidad; set => estTesteabilidad = value; }
        public bool EstCumplimientoMantenibilidad { get => estCumplimientoMantenibilidad; set => estCumplimientoMantenibilidad = value; }
    }
}
