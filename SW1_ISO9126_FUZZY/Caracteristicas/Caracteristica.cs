using SW1_ISO9126_FUZZY.Subcaracteristicas;

namespace SW1_ISO9126_FUZZY.Caracteristicas {

    class Caracteristica {

        private Funcionalidad funcionalidad;
        private Mantenibilidad mantenibilidad;
        private Usabilidad usabilidad;

        public Caracteristica(Funcionalidad funcionalidad, Mantenibilidad mantenibilidad, Usabilidad usabilidad) {

            this.funcionalidad = funcionalidad;
            this.mantenibilidad = mantenibilidad;
            this.usabilidad = usabilidad;
        }
    }
}
