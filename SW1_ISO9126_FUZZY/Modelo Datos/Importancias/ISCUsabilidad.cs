using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Importancias
{
    /// <summary>
    /// Grados de importancia subcaracteristicas Usabilidad
    /// </summary>

    public class ISCUsabilidad
    {
        private double comprensibilidad;
        private double aprendizaje;
        private double operabilidad;
        private double atractividad;
        private double cumplimientoUsabilidad;

        public ISCUsabilidad()
        {
            this.comprensibilidad = 0.0;
            this.aprendizaje = 0.0;
            this.operabilidad = 0.0;
            this.atractividad = 0.0;
            this.cumplimientoUsabilidad = 0.0;
        }

        public double Comprensibilidad { get => comprensibilidad; set => comprensibilidad = value; }
        public double Aprendizaje { get => aprendizaje; set => aprendizaje = value; }
        public double Operabilidad { get => operabilidad; set => operabilidad = value; }
        public double Atractividad { get => atractividad; set => atractividad = value; }
        public double CumplimientoUsabilidad { get => cumplimientoUsabilidad; set => cumplimientoUsabilidad = value; }
    }
}
