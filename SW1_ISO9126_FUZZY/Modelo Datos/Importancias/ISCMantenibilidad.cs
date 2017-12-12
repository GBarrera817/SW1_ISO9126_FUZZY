
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Importancias
{
    /// <summary>
    /// Importancia SubCaracteristica Mantenibilidad: Grados de importancia subcaracteristicas Mantenibilidad
    /// </summary>

    public class ISCMantenibilidad
    {
        private double analizabilidad;
        private double modificabilidad;
        private double estabilidad;
        private double testeabilidad;
        private double cumplimientoMantenibilidad;

        public ISCMantenibilidad()
        {
            this.analizabilidad = 0.0;
            this.modificabilidad = 0.0;
            this.estabilidad = 0.0;
            this.testeabilidad = 0.0;
            this.cumplimientoMantenibilidad = 0.0;
        }

        public double Analizabilidad { get => analizabilidad; set => analizabilidad = value; }
        public double Modificabilidad { get => modificabilidad; set => modificabilidad = value; }
        public double Estabilidad { get => estabilidad; set => estabilidad = value; }
        public double Testeabilidad { get => testeabilidad; set => testeabilidad = value; }
        public double CumplimientoMantenibilidad { get => cumplimientoMantenibilidad; set => cumplimientoMantenibilidad = value; }
    }
}
