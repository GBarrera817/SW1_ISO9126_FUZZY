using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Archivos {

    public class MetricasFuncionalidadJSON {
        public Funcionalidad Funcionalidad { get; set; }
    }

    public class Funcionalidad {
        public Subcaracteristica[] Subcaracteristicas { get; set; }
        public string Perspectiva { get; set; }
    }

    public class Subcaracteristica {
        public Adecuación Adecuación { get; set; }
        public Exactitud Exactitud { get; set; }
        public Interoperabilidad Interoperabilidad { get; set; }
        public Seguridadacceso SeguridadAcceso { get; set; }
        public Cumplimientofuncional CumplimientoFuncional { get; set; }
    }

    public class Adecuación {
        public Metrica[] Metricas { get; set; }
    }

    public class Exactitud {
        public Metrica[] Metricas { get; set; }
    }

    public class Interoperabilidad {
        public Metrica[] Metricas { get; set; }
    }

    public class Seguridadacceso {
        public Metrica[] Metricas { get; set; }
    }

    public class Cumplimientofuncional {
        public Metrica[] Metricas { get; set; }
    }

    public class Metrica {
        public int id { get; set; }
        public string nombre { get; set; }
        public string[] proposito { get; set; }
        public string[] metodo { get; set; }
        public string[] formula { get; set; }
        public int peor_valor { get; set; }
        public int mejor_valor { get; set; }
        public string[] parametros { get; set; }
        public string[] desc_param { get; set; }
    }
}
