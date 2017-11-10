using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Resultados
{
    /// <summary>
    /// Resultados de la evaluacion difusa final, resultado linguistico y numerico
    /// </summary>
    
    public class Resultado
    {
        private string lingCalidadFinal;
        private string lingCalidadInterna;
        private string lingCalidadExterna;

        private double numCalidadFinal;
        private double numCalidadInternaNum;
        private double munCalidadExternaNum;

        private RCaracteristicas carInternas;
        private RCaracteristicas carExternas;

        private RSCFuncionalidad subcarFunInterna;
        private RSCFuncionalidad subcarFunExterna;

        private RSCUsabilidad subcarUsabInterna;
        private RSCUsabilidad subcarUsabExterna;

        private RSCMantenibilidad subcarManInterna;
        private RSCMantenibilidad subcarManExterna;

        public Resultado()
        {
            this.LingCalidadFinal = "";
            this.LingCalidadInterna = "";
            this.LingCalidadExterna = "";

            this.NumCalidadFinal = 0;
            this.NumCalidadInternaNum = 0;
            this.MunCalidadExternaNum = 0;

            this.carInternas = new RCaracteristicas();
            this.carExternas = new RCaracteristicas();

            this.subcarFunInterna = new RSCFuncionalidad();
            this.subcarFunExterna = new RSCFuncionalidad();

            this.subcarUsabInterna = new RSCUsabilidad();
            this.subcarUsabExterna = new RSCUsabilidad();

            this.subcarManInterna = new RSCMantenibilidad();
            this.subcarManExterna = new RSCMantenibilidad();
        }

        public string LingCalidadFinal { get => lingCalidadFinal; set => lingCalidadFinal = value; }
        public string LingCalidadInterna { get => lingCalidadInterna; set => lingCalidadInterna = value; }
        public string LingCalidadExterna { get => lingCalidadExterna; set => lingCalidadExterna = value; }

        public double NumCalidadFinal { get => numCalidadFinal; set => numCalidadFinal = value; }
        public double NumCalidadInternaNum { get => numCalidadInternaNum; set => numCalidadInternaNum = value; }
        public double MunCalidadExternaNum { get => munCalidadExternaNum; set => munCalidadExternaNum = value; }

        public RCaracteristicas CarInternas { get => carInternas; set => carInternas = value; }
        public RCaracteristicas CarExternas { get => carExternas; set => carExternas = value; }

        public RSCFuncionalidad SubcarFunInterna { get => subcarFunInterna; set => subcarFunInterna = value; }
        public RSCFuncionalidad SubcarFunExterna { get => subcarFunExterna; set => subcarFunExterna = value; }

        public RSCUsabilidad SubcarUsabInterna { get => subcarUsabInterna; set => subcarUsabInterna = value; }
        public RSCUsabilidad SubcarUsabExterna { get => subcarUsabExterna; set => subcarUsabExterna = value; }

        public RSCMantenibilidad SubcarManInterna { get => subcarManInterna; set => subcarManInterna = value; }
        public RSCMantenibilidad SubcarManExterna { get => subcarManExterna; set => subcarManExterna = value; }
    }
}
