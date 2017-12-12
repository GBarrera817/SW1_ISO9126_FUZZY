
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Importancias
{
    /// <summary>
    /// Importancia SubCaracteristica Funcionabilidad: Grados de importancia subcaracteristicas Funcionabilidad
    /// </summary>

    public class ISCFuncionalidad
    {
        private double adecuacion;
        private double exactitud;
        private double interoperabilidad;
        private double seguridadAcceso;
        private double cumplimientoFuncional;

        public ISCFuncionalidad()
        {
            this.adecuacion = 0.0;
            this.exactitud = 0.0;
            this.interoperabilidad = 0.0;
            this.seguridadAcceso = 0.0;
            this.cumplimientoFuncional = 0.0;
        }

        public double Adecuacion { get => adecuacion; set => adecuacion = value; }
        public double Exactitud { get => exactitud; set => exactitud = value; }
        public double Interoperabilidad { get => interoperabilidad; set => interoperabilidad = value; }
        public double SeguridadAcceso { get => seguridadAcceso; set => seguridadAcceso = value; }
        public double CumplimientoFuncional { get => cumplimientoFuncional; set => cumplimientoFuncional = value; }
    }
}
