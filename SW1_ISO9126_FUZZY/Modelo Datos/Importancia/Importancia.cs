using SW1_ISO9126_FUZZY.Modelo_Datos.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Importancia
{
    /// <summary>
    /// Grados de importancia Caracteristicas y subcaracteristicas
    /// </summary>

    public class Importancia
    {
        private double funcionalidad;
        private ESCFuncionalidad sbcFuncionalidad;
        private double usabilidad;
        private ESCUsabilidad sbcUsabilidad;
        private double mantenibilidad;
        private ESCMantenibilidad sbcMantenibilidad;

        public Importancia()
        { 
            this.funcionalidad = 0.0;
            this.sbcFuncionalidad = new ESCFuncionalidad();
            this.usabilidad = 0.0;
            this.sbcUsabilidad = new ESCUsabilidad();
            this.mantenibilidad = 0.0;
            this.sbcMantenibilidad = new ESCMantenibilidad();
        }

        public double Funcionalidad { get => funcionalidad; set => funcionalidad = value; }
        public ESCFuncionalidad SbcFuncionalidad { get => sbcFuncionalidad; set => sbcFuncionalidad = value; }
        public double Usabilidad { get => usabilidad; set => usabilidad = value; }
        public ESCUsabilidad SbcUsabilidad { get => sbcUsabilidad; set => sbcUsabilidad = value; }
        public double Mantenibilidad { get => mantenibilidad; set => mantenibilidad = value; }
        public ESCMantenibilidad SbcMantenibilidad { get => sbcMantenibilidad; set => sbcMantenibilidad = value; }
    }
}
