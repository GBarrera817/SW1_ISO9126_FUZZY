using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    public class Seleccion
    {
       // Diccionario <ID, PREGUNTA>
       private Dictionary<int, int> funcionalidadInterna;
       private Dictionary<int, int> usabilidadInterna;
       private Dictionary<int, int> mantenibilidadInterna;

       private Dictionary<int, int> funcionalidadExterna;
       private Dictionary<int, int> usabilidadExterna;
       private Dictionary<int, int> mantenibilidadExterna;

        public Seleccion()
        {
            this.funcionalidadInterna = new Dictionary<int, int>();
            this.usabilidadInterna = new Dictionary<int, int>();
            this.mantenibilidadInterna = new Dictionary<int, int>();
            this.funcionalidadExterna = new Dictionary<int, int>();
            this.usabilidadExterna = new Dictionary<int, int>();
            this.mantenibilidadExterna = new Dictionary<int, int>();
        }

       public Dictionary<int, int> FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
       public Dictionary<int, int> UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
       public Dictionary<int, int> MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }

       public Dictionary<int, int> FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
       public Dictionary<int, int> UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
       public Dictionary<int, int> MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
