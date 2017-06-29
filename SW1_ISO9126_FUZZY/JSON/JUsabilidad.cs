using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW1_ISO9126_FUZZY.JSON
{
    public class JUsabilidad
    {
        private string perspectiva;
        private JMetrica[] comprensibilidad;
        private JMetrica[] aprendizaje;
        private JMetrica[] operabilidad;
        private JMetrica[] atractividad;
        private JMetrica[] cumplimientoUsabilidad;

        public JUsabilidad() { }

        public string Perspectiva { get => perspectiva; set => perspectiva = value; }
        public JMetrica[] Comprensibilidad { get => comprensibilidad; set => comprensibilidad = value; }
        public JMetrica[] Aprendizaje { get => aprendizaje; set => aprendizaje = value; }
        public JMetrica[] Operabilidad { get => operabilidad; set => operabilidad = value; }
        public JMetrica[] Atractividad { get => atractividad; set => atractividad = value; }
        public JMetrica[] CumplimientoUsabilidad { get => cumplimientoUsabilidad; set => cumplimientoUsabilidad = value; }
    }
}
