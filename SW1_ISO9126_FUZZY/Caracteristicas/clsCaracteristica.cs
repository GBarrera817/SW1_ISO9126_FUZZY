using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Caracteristicas {

    class clsCaracteristica {
        private Subcaracteristicas.clsFuncionalidad funcionalidad;
        private Subcaracteristicas.clsMantenibilidad mantenibilidad;
        private Subcaracteristicas.clsUsabilidad usabilidad;

        public clsCaracteristica(Subcaracteristicas.clsFuncionalidad funcionalidad,
                                 Subcaracteristicas.clsMantenibilidad mantenibilidad,
                                 Subcaracteristicas.clsUsabilidad usabilidad) {
            this.funcionalidad = funcionalidad;
            this.mantenibilidad = mantenibilidad;
            this.usabilidad = usabilidad;
        }
    }
}
