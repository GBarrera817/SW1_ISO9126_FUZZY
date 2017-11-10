using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    public class ListSeleccion
    {
       private List<MTSeleccion> funcionalidadInterna;
       private List<MTSeleccion> usabilidadInterna;
       private List<MTSeleccion> mantenibilidadInterna;

       private List<MTSeleccion> funcionalidadExterna;
       private List<MTSeleccion> usabilidadExterna;
       private List<MTSeleccion> mantenibilidadExterna;

        public ListSeleccion()
        {
            this.funcionalidadInterna = new List<MTSeleccion>();
            this.usabilidadInterna = new List<MTSeleccion>();
            this.mantenibilidadInterna = new List<MTSeleccion>();
            this.funcionalidadExterna = new List<MTSeleccion>();
            this.usabilidadExterna = new List<MTSeleccion>();
            this.mantenibilidadExterna = new List<MTSeleccion>();
        }

       public List<MTSeleccion> FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
       public List<MTSeleccion> UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
       public List<MTSeleccion> MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }

       public List<MTSeleccion> FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
       public List<MTSeleccion> UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
       public List<MTSeleccion> MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
