 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    ///  Lista Evaluacion: Listas para guardar la evalucion (datos) asociado a cada metrica por caracteristicas Internas/Externas
    /// </summary>

    public class ListEvaluacion
    {
        private List<MTEvaluacion> funcionalidadInterna;
        private List<MTEvaluacion> usabilidadInterna;
        private List<MTEvaluacion> mantenibilidadInterna;

        private List<MTEvaluacion> funcionalidadExterna;
        private List<MTEvaluacion> usabilidadExterna;
        private List<MTEvaluacion> mantenibilidadExterna;

        public ListEvaluacion()
        {
            this.FuncionalidadInterna =  new List<MTEvaluacion>();
            this.UsabilidadInterna = new List<MTEvaluacion>();
            this.MantenibilidadInterna = new List<MTEvaluacion>();
            this.FuncionalidadExterna = new List<MTEvaluacion>();
            this.UsabilidadExterna = new List<MTEvaluacion>();
            this.MantenibilidadExterna = new List<MTEvaluacion>();
        }

        public List<MTEvaluacion> FuncionalidadInterna { get => funcionalidadInterna; set => funcionalidadInterna = value; }
        public List<MTEvaluacion> UsabilidadInterna { get => usabilidadInterna; set => usabilidadInterna = value; }
        public List<MTEvaluacion> MantenibilidadInterna { get => mantenibilidadInterna; set => mantenibilidadInterna = value; }

        public List<MTEvaluacion> FuncionalidadExterna { get => funcionalidadExterna; set => funcionalidadExterna = value; }
        public List<MTEvaluacion> UsabilidadExterna { get => usabilidadExterna; set => usabilidadExterna = value; }
        public List<MTEvaluacion> MantenibilidadExterna { get => mantenibilidadExterna; set => mantenibilidadExterna = value; }
    }
}
