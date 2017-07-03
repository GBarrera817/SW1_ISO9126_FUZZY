using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW1_ISO9126_FUZZY.JSON
{
    public class JMetrica
    {
        private int id;
        private string nombre;
        private string[] proposito;
        private string[] metodo;
        private string[] formula;
        private int peor_valor;
        private int mejor_valor;
        private string[] parametros;
        private string[] desc_param;

        public JMetrica() {}

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string[] Proposito { get => proposito; set => proposito = value; }
        public string[] Metodo { get => metodo; set => metodo = value; }
        public string[] Formula { get => formula; set => formula = value; }
        public int Peor_valor { get => peor_valor; set => peor_valor = value; }
        public int Mejor_valor { get => mejor_valor; set => mejor_valor = value; }
        public string[] Parametros { get => parametros; set => parametros = value; }
        public string[] Desc_param { get => desc_param; set => desc_param = value; }
    }
}
