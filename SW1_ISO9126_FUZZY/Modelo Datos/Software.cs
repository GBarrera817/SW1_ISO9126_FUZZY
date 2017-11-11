using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    /// <summary>
    /// Software: Para almacenar datos del Software y del Evaluador
    /// </summary>

    public class Software
    {
        private string evaluador;
        private string tipo;
        private string nombre;
        private string[] desarrollador;
        private string manual;
        private string descripcion;

        public Software() { }

        public string Evaluador { get => evaluador; set => evaluador = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string[] Desarrollador { get => desarrollador; set => desarrollador = value; }
        public string Manual { get => manual; set => manual = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public override string ToString()
        {
            string str = "";
            str += "\nNombre del evaluador: " + evaluador;
            str += "\nTipo de usuario: " + tipo;
            str += "\nNombre del software: " + nombre;

            str += "\n";

            for (int i = 0; i < desarrollador.Length; i++)
            {
                str += "\nDesarrollador: " + desarrollador[i];
            }

            str += "\nManual de usuario: " + manual;
            str += "\nDescripción del software: " + descripcion;

            return str;
        }
    }
}
