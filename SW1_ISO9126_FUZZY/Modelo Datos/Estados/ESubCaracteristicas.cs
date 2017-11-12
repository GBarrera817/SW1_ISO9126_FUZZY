using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    /// Estado SubCaracteristicas:  Guarda el estado (booleano) de las subcaracteristicas
    /// </summary>

    public class ESubCaracteristicas
    {
        private ESCFuncionalidad subCarfuncionalidad;
        private ESCUsabilidad subCarusabilidad;
        private ESCMantenibilidad subCarmantenibilidad;

        public ESubCaracteristicas()
        {
            this.subCarfuncionalidad = new ESCFuncionalidad();
            this.subCarusabilidad = new ESCUsabilidad();
            this.subCarmantenibilidad = new ESCMantenibilidad();
        }

        public ESCFuncionalidad SubCarfuncionalidad { get => subCarfuncionalidad; set => subCarfuncionalidad = value; }
        public ESCUsabilidad SubCarusabilidad { get => subCarusabilidad; set => subCarusabilidad = value; }
        public ESCMantenibilidad SubCarmantenibilidad { get => subCarmantenibilidad; set => subCarmantenibilidad = value; }
    }
}
