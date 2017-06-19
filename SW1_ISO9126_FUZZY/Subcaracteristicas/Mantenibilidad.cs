using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Subcaracteristicas {

    class Mantenibilidad {
        private double facilidad_analisis = 0.0;
        private double modificabilidad = 0.0;
        private double estabilidad = 0.0;
        private double testeabilidad = 0.0;
        private double cumplimiento_mantenibilidad = 0.0;

        private double calidadFuncionabilidad = 0.0;

        private double id_facilidad_analisis;
        private double id_modificabilidad;
        private double id_estabilidad;
        private double id_testeabilidad;
        private double id_cumplimiento_mantenibilidad;

        // Accesores 

        public double Facilidad_analisis {
            get { return facilidad_analisis; }
            set { facilidad_analisis = value; }
        }

        public double Modificabilidad {
            get { return modificabilidad; }
            set { modificabilidad = value; }
        }

        public double Estabilidad {
            get { return estabilidad; }
            set { estabilidad = value; }
        }

        public double Testeabilidad {
            get { return testeabilidad; }
            set { testeabilidad = value; }
        }

        public double Cumplimiento_Mantenibilidad {
            get { return cumplimiento_mantenibilidad; }
            set { cumplimiento_mantenibilidad = value; }
        }
    }
}
