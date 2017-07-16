using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    public class Calculo
    {
        // Diccionario <ID, [IMPORTANCIA, RESULTADO]>
        private Dictionary<int, double[]> funcionalidadInterna;
        private Dictionary<int, double[]> usabilidadInterna;
        private Dictionary<int, double[]> mantenibilidadInterna;
                                      
        private Dictionary<int, double[]> funcionalidadExterna;
        private Dictionary<int, double[]> usabilidadExterna;
        private Dictionary<int, double[]> mantenibilidadExterna;

        public Calculo()
        {
            this.funcionalidadInterna = new Dictionary<int, double[]>();
            this.usabilidadInterna = new Dictionary<int, double[]>;
            this.mantenibilidadInterna = new Dictionary<int, double[]>;
            this.funcionalidadExterna = new Dictionary<int, double[]>;
            this.usabilidadExterna = new Dictionary<int, double[]>;
            this.mantenibilidadExterna = new Dictionary<int, double[]>;
        }

        public Dictionary<int, double[]> FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public Dictionary<int, double[]> UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public Dictionary<int, double[]> MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }
        public Dictionary<int, double[]> FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public Dictionary<int, double[]> UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public Dictionary<int, double[]> MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
