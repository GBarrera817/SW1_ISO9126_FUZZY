using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    public class Evaluacion
    {
        private Software informacion;
        private Importancia grados;
        private Seleccion eleccion;
        private Respuesta fomulario;
        private Calculo resultados;
        private EstadoModulo modulos;
        private EstadoModulo evaluacion;

        public Evaluacion()
        {

        }

        public Evaluacion(Software informacion, Importancia grados, Seleccion eleccion, Respuesta fomulario, Calculo resultados, EstadoModulo modulos, EstadoModulo evaluacion)
        {
            this.Informacion = informacion;
            this.Grados = grados;
            this.Eleccion = eleccion;
            this.Fomulario = fomulario;
            this.Resultados = resultados;
            this.Modulos = modulos;
            this.Evaluacion = evaluacion;
        }

        public Software Informacion { get => informacion; set => informacion = value; }
        public Importancia Grados { get => grados; set => grados = value; }
        public Seleccion Eleccion { get => eleccion; set => eleccion = value; }
        public Respuesta Fomulario { get => fomulario; set => fomulario = value; }
        public Calculo Resultados { get => resultados; set => resultados = value; }
        public EstadoModulo Modulos { get => modulos; set => modulos = value; }
        public EstadoModulo Evaluacion { get => evaluacion; set => evaluacion = value; }
    }
}
