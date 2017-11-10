using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    ///  Lista Calculo: Listas para guarda los calculos asociado a la formula que contiene cada metrica por caracteristicas Internas/Externas
    /// </summary>

    public class ListCalculo
    {
        private List<MTCalculo> funcionalidadInterna;
        private List<MTCalculo> usabilidadInterna;
        private List<MTCalculo> mantenibilidadInterna;
                                      
        private List<MTCalculo> funcionalidadExterna;
        private List<MTCalculo> usabilidadExterna;
        private List<MTCalculo> mantenibilidadExterna;

        public ListCalculo()
        {
            this.funcionalidadInterna = new List<MTCalculo>();
            this.usabilidadInterna = new List<MTCalculo>();
            this.mantenibilidadInterna = new List<MTCalculo>();
            this.funcionalidadExterna = new List<MTCalculo>();
            this.usabilidadExterna = new List<MTCalculo>();
            this.mantenibilidadExterna = new List<MTCalculo>();
        }

        public List<MTCalculo> FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public List<MTCalculo> UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public List<MTCalculo> MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }
        public List<MTCalculo> FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public List<MTCalculo> UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public List<MTCalculo> MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
