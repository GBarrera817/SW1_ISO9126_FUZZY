using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Resultados
{
    /// <summary>
    /// Resultado SubCaracteristica Mantenibilidad: Resultados de la evaluacion difusa subcaracteristicas Mantenibilidad
    /// </summary>

    public class RSCMantenibilidad
    {
        private string lingAnalizabilidad;
        private string lingModificabilidad;
        private string lingEstabilidad;
        private string lingTesteabilidad;
        private string lingCumplimientoMantenibilidad;

        private double numAnalizabilidad;
        private double numModificabilidad;
        private double numEstabilidad;
        private double numTesteabilidad;
        private double numCumplimientoMantenibilidad;

        public RSCMantenibilidad()
        {
            this.LingAnalizabilidad = "";
            this.LingModificabilidad = ""; 
            this.LingEstabilidad = ""; 
            this.LingTesteabilidad = ""; 
            this.LingCumplimientoMantenibilidad = ""; 

            this.NumAnalizabilidad = 0;
            this.NumModificabilidad = 0;
            this.NumEstabilidad = 0;
            this.NumTesteabilidad = 0;
            this.NumCumplimientoMantenibilidad = 0;
        }

        public string LingAnalizabilidad { get => lingAnalizabilidad; set => lingAnalizabilidad = value; }
        public string LingModificabilidad { get => lingModificabilidad; set => lingModificabilidad = value; }
        public string LingEstabilidad { get => lingEstabilidad; set => lingEstabilidad = value; }
        public string LingTesteabilidad { get => lingTesteabilidad; set => lingTesteabilidad = value; }
        public string LingCumplimientoMantenibilidad { get => lingCumplimientoMantenibilidad; set => lingCumplimientoMantenibilidad = value; }

        public double NumAnalizabilidad { get => numAnalizabilidad; set => numAnalizabilidad = value; }
        public double NumModificabilidad { get => numModificabilidad; set => numModificabilidad = value; }
        public double NumEstabilidad { get => numEstabilidad; set => numEstabilidad = value; }
        public double NumTesteabilidad { get => numTesteabilidad; set => numTesteabilidad = value; }
        public double NumCumplimientoMantenibilidad { get => numCumplimientoMantenibilidad; set => numCumplimientoMantenibilidad = value; } 
    }
}
