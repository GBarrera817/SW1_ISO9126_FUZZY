using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos.Etiquetas
{
    public class ColorEstado
    {
        private string[] estados = new string[] { "INACTIVA", "REALIZAR", "COMPLETAR", "FINALIZADO" };
        private string[] colores = new string[] { "#FF000033", "#FFCC0000", "#FFE6E600", "#FF00802B" };

        private string etiqueta;
        private string color;

        public ColorEstado()
        {
            this.etiqueta = estados[0];
            this.color = colores[0];
        }

        public void cambiarEstado (int estadoNum)
        {
            etiqueta = estados[estadoNum];
            color = colores[estadoNum];
        }

        public string Etiqueta { get => etiqueta; set => etiqueta = value; }
        public string Color { get => color; set => color = value; }
    }
}
