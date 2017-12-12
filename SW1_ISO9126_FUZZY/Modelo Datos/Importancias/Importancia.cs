
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Importancias
{
    /// <summary>
    /// Importancia: Grados de importancia Caracteristicas y subcaracteristicas
    /// </summary>

    public class Importancia
    {
        private double funcionalidad;
        private ISCFuncionalidad sbcFuncionalidad;
        private double usabilidad;
        private ISCUsabilidad sbcUsabilidad;
        private double mantenibilidad;
        private ISCMantenibilidad sbcMantenibilidad;

        public Importancia()
        { 
            this.funcionalidad = 0.0;
            this.sbcFuncionalidad = new ISCFuncionalidad();
            this.usabilidad = 0.0;
            this.sbcUsabilidad = new ISCUsabilidad();
            this.mantenibilidad = 0.0;
            this.sbcMantenibilidad = new ISCMantenibilidad();
        }

        public double Funcionalidad { get => funcionalidad; set => funcionalidad = value; }
        public ISCFuncionalidad SbcFuncionalidad { get => sbcFuncionalidad; set => sbcFuncionalidad = value; }
        public double Usabilidad { get => usabilidad; set => usabilidad = value; }
        public ISCUsabilidad SbcUsabilidad { get => sbcUsabilidad; set => sbcUsabilidad = value; }
        public double Mantenibilidad { get => mantenibilidad; set => mantenibilidad = value; }
        public ISCMantenibilidad SbcMantenibilidad { get => sbcMantenibilidad; set => sbcMantenibilidad = value; }
    }
}
