using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Etiquetas
{
    public class Etiqueta
    {      
        private ColorEstado funcionalidadInterna;
        private ColorEstado usabilidadInterna;
        private ColorEstado mantenibilidadInterna;
        private ColorEstado funcionalidadExterna;
        private ColorEstado usabilidadExterna;
        private ColorEstado mantenibilidadExterna;

        public Etiqueta()
        {
            this.funcionalidadInterna =  new ColorEstado();
            this.usabilidadInterna =     new ColorEstado();
            this.mantenibilidadInterna = new ColorEstado();
            this.funcionalidadExterna =  new ColorEstado();
            this.usabilidadExterna =    new ColorEstado();
            this.mantenibilidadExterna = new ColorEstado();
        }

        public ColorEstado FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public ColorEstado UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public ColorEstado MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }
        public ColorEstado FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public ColorEstado UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public ColorEstado MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
