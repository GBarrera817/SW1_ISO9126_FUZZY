using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Metricas
{
    class ValorMetrica
    {
        //Datos metrica
        private int id { get; set; }
        private string caracteristica { get; set; }
        private string subcaracteristica { get; set; }
        private string perspectiva { get; set; }

        //Valores metrica
        private int peorValor { get; set; }
        private int mejorValor { get; set; }
        private int respuesta { get; set; }

        public ValorMetrica()
        {
            this.id = 0;
            this.caracteristica = "CARACTERISTICA";
            this.subcaracteristica = "SUBCARACTERISTICA";
            this.perspectiva = "GENERAL";
            this.peorValor = 0;
            this.mejorValor = 0;
            this.respuesta = 0;
        }
    }
}
