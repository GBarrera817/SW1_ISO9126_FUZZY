using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Subcaracteristicas {

    class clsUsabilidad {
        private double aprendizaje = 0.0;
        private double comprensibilidad = 0.0;
        private double operabilidad = 0.0;
        private double atractividad = 0.0;
        private double cumplimiento_usabilidad = 0.0;

        private double calidadUsabilidad = 0.0;

        private double id_aprendizaje;
        private double id_comprensibilidad;
        private double id_operabilidad;
        private double id_atractividad;
        private double id_cumplimiento_usabilidad;


        public double Aprendizaje {
            get { return aprendizaje; }
            set { aprendizaje = value; }
        }

        public double Comprensibilidad {
            get { return comprensibilidad; }
            set { comprensibilidad = value; }
        }

        public double Operabilidad {
            get { return operabilidad; }
            set { operabilidad = value; }
        }

        public double Atractividad {
            get { return atractividad; }
            set { atractividad = value; }
        }

        public double Cumplimiento_Usabilidad {
            get { return cumplimiento_usabilidad; }
            set { cumplimiento_usabilidad = value; }
        }
    }
}
