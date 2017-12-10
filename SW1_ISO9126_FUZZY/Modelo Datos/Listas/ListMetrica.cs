using SW1_ISO9126_FUZZY.JSON;
using System.Collections.Generic;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    /// Lista Metrica: Listas para guardar la carga (datos) asociado a cada metrica por caracteristicas Internas/Externas
    /// </summary>

    public class ListMetrica
    {
        private List<JMetrica> funcionalidadInterna;
        private List<JMetrica> funcionalidadExterna;
        private List<JMetrica> usabilidadInterna;

        private List<JMetrica> usabilidadExterna;
        private List<JMetrica> mantenibilidadInterna;
        private List<JMetrica> mantenibilidadExterna;

        public ListMetrica()
        {
            this.funcionalidadInterna = new List<JMetrica>();
            this.funcionalidadExterna = new List<JMetrica>();
            this.usabilidadInterna = new List<JMetrica>();
            this.usabilidadExterna = new List<JMetrica>();
            this.mantenibilidadInterna = new List<JMetrica>();
            this.mantenibilidadExterna = new List<JMetrica>();
        }

        public List<JMetrica> FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public List<JMetrica> FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public List<JMetrica> UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public List<JMetrica> UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public List<JMetrica> MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }
        public List<JMetrica> MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
