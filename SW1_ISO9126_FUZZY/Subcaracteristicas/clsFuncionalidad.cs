using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Subcaracteristicas {

    class clsFuncionalidad {
        private double adecuacion = 0.0;
        private double exactitud = 0.0;
        private double interoperabilidad = 0.0;
        private double seguridad_acceso = 0.0;
        private double cumplimiento_funcionalidad = 0.0;

        private double calidadFuncionabilidad = 0.0;

        private double id_adecuacion;
        private double id_correccion;
        private double id_interoperabilidad;
        private double id_seguridad_acceso;
        private double id_cumplimiento_funcionalidad;

        // Accesores 

        public double Adecuacion {
            get { return adecuacion; }
            set { adecuacion = value; }
        }

        public double Correccion {
            get { return exactitud; }
            set { exactitud = value; }
        }

        public double Interoperabilidad {
            get { return interoperabilidad; }
            set { interoperabilidad = value; }
        }

        public double Seguridad_Acceso {
            get { return seguridad_acceso; }
            set { seguridad_acceso = value; }
        }

        public double Cumplimiento_Funcionalidad {
            get { return cumplimiento_funcionalidad; }
            set { cumplimiento_funcionalidad = value; }
        }
    }
}
