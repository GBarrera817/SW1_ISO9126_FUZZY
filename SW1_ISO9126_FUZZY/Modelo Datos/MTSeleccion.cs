using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    public class MTSeleccion
    {
        private int id;
        private int proposito;
        private bool estado;

        public MTSeleccion() {}

        public int Id { get => id; set => id = value; }
        public int Proposito { get => proposito; set => proposito = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
