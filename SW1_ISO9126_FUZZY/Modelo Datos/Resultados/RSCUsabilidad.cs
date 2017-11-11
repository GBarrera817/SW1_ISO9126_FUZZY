using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Resultados
{
    /// <summary>
    /// Resultado SubCaracteristica Usabilidad: Resultados de la evaluacion difusa subcaracteristicas Usabilidad
    /// </summary>

    public class RSCUsabilidad
    {
        private string lingComprensibilidad;
        private string lingAprendizaje;
        private string lingOperabilidad;
        private string lingAtractividad;
        private string lingCumplimientoUsabilidad;

        private double numComprensibilidad;
        private double numAprendizaje;
        private double numOperabilidad;
        private double numAtractividad;
        private double numCumplimientoUsabilidad;

        public RSCUsabilidad()
        {
            this.lingComprensibilidad = "";
            this.lingAprendizaje = ""; 
            this.lingOperabilidad = ""; 
            this.lingAtractividad = "";
            this.lingCumplimientoUsabilidad = "";

            this.numComprensibilidad = 0;
            this.numAprendizaje = 0;
            this.numOperabilidad = 0;
            this.numAtractividad = 0;
            this.numCumplimientoUsabilidad = 0;
        }

        public string LingComprensibilidad { get => lingComprensibilidad; set => lingComprensibilidad = value; }
        public string LingAprendizaje { get => lingAprendizaje; set => lingAprendizaje = value; }
        public string LingOperabilidad { get => lingOperabilidad; set => lingOperabilidad = value; }
        public string LingAtractividad { get => lingAtractividad; set => lingAtractividad = value; }
        public string LingCumplimientoUsabilidad { get => lingCumplimientoUsabilidad; set => lingCumplimientoUsabilidad = value; }

        public double NumComprensibilidad { get => numComprensibilidad; set => numComprensibilidad = value; }
        public double NumAprendizaje { get => numAprendizaje; set => numAprendizaje = value; }
        public double NumOperabilidad { get => numOperabilidad; set => numOperabilidad = value; }
        public double NumAtractividad { get => numAtractividad; set => numAtractividad = value; }
        public double NumCumplimientoUsabilidad { get => numCumplimientoUsabilidad; set => numCumplimientoUsabilidad = value; }
    }
}
