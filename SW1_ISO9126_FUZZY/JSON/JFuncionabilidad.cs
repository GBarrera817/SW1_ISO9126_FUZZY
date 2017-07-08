﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.JSON
{
    public class JFuncionabilidad
    {
        private string perspectiva;
        private JMetrica[] adecuacion;
        private JMetrica[] exactitud;
        private JMetrica[] interoperabilidad;
        private JMetrica[] seguridadAcceso;
        private JMetrica[] cumplimientoFuncional;

        public JFuncionabilidad() { }

        public string Perspectiva { get => perspectiva; set => perspectiva = value; }
        public JMetrica[] Adecuacion { get => adecuacion; set => adecuacion = value; }
        public JMetrica[] Exactitud { get => exactitud; set => exactitud = value; }
        public JMetrica[] Interoperabilidad { get => interoperabilidad; set => interoperabilidad = value; }
        public JMetrica[] SeguridadAcceso { get => seguridadAcceso; set => seguridadAcceso = value; }
        public JMetrica[] CumplimientoFuncional { get => cumplimientoFuncional; set => cumplimientoFuncional = value; }

    }
}