using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.JSON
{
    public class JFuncionabilidad
    {
        private string caracteristica;
        private string perspectiva;
        private string[] subcaracteristicas;
        private JMetrica[] adecuacion;
        private JMetrica[] exactitud;
        private JMetrica[] interoperabilidad;
        private JMetrica[] seguridadAcceso;
        private JMetrica[] cumplimientoFuncional;

        public JFuncionabilidad()
        {
            this.caracteristica = "Funcionabilidad";
            this.subcaracteristicas = new string[] {"Adecuación",
                                                    "Exactitud",
                                                    "Interoperabilidad",
                                                    "Seguridad Acceso",
                                                    "Cumplimiento Funcional"
                                                   };
        }

        public string Caracteristca { get => caracteristica; set => caracteristica = value; }
        public string Perspectiva { get => perspectiva; set => perspectiva = value; }
        public string[] Subcaracteristicas { get => subcaracteristicas; set => subcaracteristicas = value; }
        public JMetrica[] Adecuacion { get => adecuacion; set => adecuacion = value; }
        public JMetrica[] Exactitud { get => exactitud; set => exactitud = value; }
        public JMetrica[] Interoperabilidad { get => interoperabilidad; set => interoperabilidad = value; }
        public JMetrica[] SeguridadAcceso { get => seguridadAcceso; set => seguridadAcceso = value; }
        public JMetrica[] CumplimientoFuncional { get => cumplimientoFuncional; set => cumplimientoFuncional = value; } 
    }
}
