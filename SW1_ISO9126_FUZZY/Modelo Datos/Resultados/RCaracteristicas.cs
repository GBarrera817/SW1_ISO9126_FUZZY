using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Resultados
{
    /// <summary>
    ///  Resultado Caracteristicas: De la evaluacion difusa a nivel de caracteristicas, resultado linguistico y numerico
    /// </summary>

    public class RCaracteristicas
    {
        private string lingfuncionalidadInterna;
        private string lingusabilidadInterna;
        private string lingmantenibilidadInterna;
        private string lingfuncionalidadExterna;
        private string lingusabilidadExterna;
        private string lingmantenibilidadExterna;

        private double numfuncionalidadInterna;
        private double numusabilidadInterna;
        private double nummantenibilidadInterna;
        private double numfuncionalidadExterna;
        private double numusabilidadExterna;
        private double nummantenibilidadExterna;

        public RCaracteristicas()
        {
            this.lingfuncionalidadInterna = "";
            this.lingusabilidadInterna = "";
            this.lingmantenibilidadInterna = "";
            this.lingfuncionalidadExterna = "";
            this.lingusabilidadExterna = "";
            this.lingmantenibilidadExterna = "";

            this.numfuncionalidadInterna = 0;
            this.numusabilidadInterna = 0;
            this.nummantenibilidadInterna = 0;
            this.numfuncionalidadExterna = 0;
            this.numusabilidadExterna = 0;
            this.nummantenibilidadExterna = 0;
        }

        public string LingfuncionalidadInterna { get => lingfuncionalidadInterna; set => lingfuncionalidadInterna = value; }
        public string LingusabilidadInterna { get => lingusabilidadInterna; set => lingusabilidadInterna = value; }
        public string LingmantenibilidadInterna { get => lingmantenibilidadInterna; set => lingmantenibilidadInterna = value; }
        public string LingfuncionalidadExterna { get => lingfuncionalidadExterna; set => lingfuncionalidadExterna = value; }
        public string LingusabilidadExterna { get => lingusabilidadExterna; set => lingusabilidadExterna = value; }
        public string LingmantenibilidadExterna { get => lingmantenibilidadExterna; set => lingmantenibilidadExterna = value; }

        public double NumfuncionalidadInterna { get => numfuncionalidadInterna; set => numfuncionalidadInterna = value; }
        public double NumusabilidadInterna { get => numusabilidadInterna; set => numusabilidadInterna = value; }
        public double NummantenibilidadInterna { get => nummantenibilidadInterna; set => nummantenibilidadInterna = value; }
        public double NumfuncionalidadExterna { get => numfuncionalidadExterna; set => numfuncionalidadExterna = value; }
        public double NumusabilidadExterna { get => numusabilidadExterna; set => numusabilidadExterna = value; }
        public double NummantenibilidadExterna { get => nummantenibilidadExterna; set => nummantenibilidadExterna = value; }
    }
}
