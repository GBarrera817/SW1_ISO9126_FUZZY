using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Estados
{
    /// <summary>
    ///  Estados Modulo:  Guarda el estado (booleano) de los modulos por caracteristicas Internas/Externas
    /// </summary>

    public class EstadoModulo
    {
        private bool funcionalidadInterna;
        private bool usabilidadInterna;
        private bool mantenibilidadInterna;
        private bool funcionalidadExterna;
        private bool usabilidadExterna;
        private bool mantenibilidadExterna;

        public EstadoModulo()
        {
            this.FuncionalidadInterna = false;
            this.UsabilidadInterna = false;
            this.MantenibilidadInterna = false;
            this.FuncionalidadExterna = false;
            this.UsabilidadExterna = false;
            this.MantenibilidadExterna = false;
        }

        public bool FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public bool UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public bool MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }
        public bool FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public bool UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public bool MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
