using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.JSON
{
    public class JMantenibilidad
    {
        private string perspectiva;
        private string[] subcaracteristicas;
        private JMetrica[] analizabilidad;
        private JMetrica[] modificabilidad;
        private JMetrica[] estabilidad;
        private JMetrica[] testeabilidad;
        private JMetrica[] cumplimientoMantenibilidad;

        public JMantenibilidad()
        {
            this.subcaracteristicas = new string[] {"Analizabilidad",
                                                    "Modificabilidad",
                                                    "Estabilidad",
                                                    "Testeabilidad",
                                                    "Cumplimiento Mantenibilidad"
                                                   };
        }

        public string Perspectiva { get => perspectiva; set => perspectiva = value; }
        public string[] Subcaracteristicas { get => subcaracteristicas; set => subcaracteristicas = value; }
        public JMetrica[] Analizabilidad { get => analizabilidad; set => analizabilidad = value; }
        public JMetrica[] Modificabilidad { get => modificabilidad; set => modificabilidad = value; }
        public JMetrica[] Estabilidad { get => estabilidad; set => estabilidad = value; }
        public JMetrica[] Testeabilidad { get => testeabilidad; set => testeabilidad = value; }
        public JMetrica[] CumplimientoMantenibilidad { get => cumplimientoMantenibilidad; set => cumplimientoMantenibilidad = value; }

    }

}
