using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW1_ISO9126_FUZZY.JSON
{
    public class JUsabilidad
    {
        private string caracteristica;
        private string perspectiva;
        private string[] subcaracteristicas;
        private JMetrica[] comprensibilidad;
        private JMetrica[] aprendizaje;
        private JMetrica[] operabilidad;
        private JMetrica[] atractividad;
        private JMetrica[] cumplimientoUsabilidad;

        public JUsabilidad()
        {
            this.caracteristica = "Usabilidad";
            this.subcaracteristicas = new string[] {"Comprensibilidad",
                                                    "Aprendizaje",
                                                    "Operabilidad",
                                                    "Atractividad",
                                                    "Cumplimiento Usabilidad"
                                                   };
        }

        public string Caracteristca { get => caracteristica; set => caracteristica = value; }
        public string Perspectiva { get => perspectiva; set => perspectiva = value; }
        public string[] Subcaracteristicas { get => subcaracteristicas; set => subcaracteristicas = value; }
        public JMetrica[] Comprensibilidad { get => comprensibilidad; set => comprensibilidad = value; }
        public JMetrica[] Aprendizaje { get => aprendizaje; set => aprendizaje = value; }
        public JMetrica[] Operabilidad { get => operabilidad; set => operabilidad = value; }
        public JMetrica[] Atractividad { get => atractividad; set => atractividad = value; }
        public JMetrica[] CumplimientoUsabilidad { get => cumplimientoUsabilidad; set => cumplimientoUsabilidad = value; }
    }
}
