using SW1_ISO9126_FUZZY.Subcaracteristicas;

namespace SW1_ISO9126_FUZZY.Caracteristicas {

    class clsCaracteristica {

        private clsFuncionalidad funcionalidad;
        private clsMantenibilidad mantenibilidad;
        private clsUsabilidad usabilidad;

        public clsCaracteristica(clsFuncionalidad funcionalidad, clsMantenibilidad mantenibilidad, clsUsabilidad usabilidad) {

            this.funcionalidad = funcionalidad;
            this.mantenibilidad = mantenibilidad;
            this.usabilidad = usabilidad;
        }
    }
}
