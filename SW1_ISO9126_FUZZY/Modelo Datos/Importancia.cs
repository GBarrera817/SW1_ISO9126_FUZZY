using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Modelo_Datos
{
    public class Importancia
    {
        private bool estFuncionalidad;
        private bool estAdecuacion;
        private bool estExactitud;
        private bool estInteroperabilidad;
        private bool estSeguridadAcceso;
        private bool estCumplimientoFuncional;

        private double funcionalidad;
        private double adecuacion;
        private double exactitud;
        private double interoperabilidad;
        private double seguridadAcceso;
        private double cumplimientoFuncional;

        private bool estUsabilidad;
        private bool estComprensibilidad;
        private bool estAprendizaje;
        private bool estOperabilidad;
        private bool estAtractividad;
        private bool estCumplimientoUsabilidad;

        private double usabilidad;
        private double comprensibilidad;
        private double aprendizaje;
        private double operabilidad;
        private double atractividad;
        private double cumplimientoUsabilidad;

        private bool estMantenibilidad;
        private bool estAnalizabilidad;
        private bool estModificabilidad;
        private bool estEstabilidad;
        private bool estTesteabilidad;
        private bool estCumplimientoMantenibilidad;

        private double mantenibilidad;
        private double analizabilidad;
        private double modificabilidad;
        private double estabilidad;
        private double testeabilidad;
        private double cumplimientoMantenibilidad;


        public Importancia()
        {
            this.estFuncionalidad = false;
            this.estAdecuacion = false;
            this.estExactitud = false;
            this.estInteroperabilidad = false;
            this.estSeguridadAcceso = false;
            this.estCumplimientoFuncional = false;

            this.funcionalidad = 0.0;
            this.adecuacion = 0.0;
            this.exactitud = 0.0;
            this.interoperabilidad = 0.0;
            this.seguridadAcceso = 0.0;
            this.cumplimientoFuncional = 0.0;

            this.estUsabilidad = false;
            this.estComprensibilidad = false;
            this.estAprendizaje = false;
            this.estOperabilidad = false;
            this.estAtractividad = false;
            this.estCumplimientoUsabilidad = false;

            this.usabilidad = 0.0;
            this.comprensibilidad = 0.0;
            this.aprendizaje = 0.0;
            this.operabilidad = 0.0;
            this.atractividad = 0.0;
            this.cumplimientoUsabilidad = 0.0;

            this.estMantenibilidad = false;
            this.estAnalizabilidad = false;
            this.estModificabilidad = false;
            this.estEstabilidad = false;
            this.estTesteabilidad = false;
            this.estCumplimientoMantenibilidad = false;

            this.mantenibilidad = 0.0;
            this.analizabilidad = 0.0;
            this.modificabilidad = 0.0;
            this.estabilidad = 0.0;
            this.testeabilidad = 0.0;
            this.cumplimientoMantenibilidad = 0.0;
        }


        public bool EstFuncionalidad { get => estFuncionalidad; set => estFuncionalidad = value; }
        public bool EstAdecuacion { get => estAdecuacion; set => estAdecuacion = value; }
        public bool EstExactitud { get => estExactitud; set => estExactitud = value; }
        public bool EstInteroperabilidad { get => estInteroperabilidad; set => estInteroperabilidad = value; }
        public bool EstSeguridadAcceso { get => estSeguridadAcceso; set => estSeguridadAcceso = value; }
        public bool EstCumplimientoFuncional { get => estCumplimientoFuncional; set => estCumplimientoFuncional = value; }

        public double Funcionalidad { get => funcionalidad; set => funcionalidad = value; }
        public double Adecuacion { get => adecuacion; set => adecuacion = value; }
        public double Exactitud { get => exactitud; set => exactitud = value; }
        public double Interoperabilidad { get => interoperabilidad; set => interoperabilidad = value; }
        public double SeguridadAcceso { get => seguridadAcceso; set => seguridadAcceso = value; }
        public double CumplimientoFuncional { get => cumplimientoFuncional; set => cumplimientoFuncional = value; }

        public bool EstUsabilidad { get => estUsabilidad; set => estUsabilidad = value; }
        public bool EstComprensibilidad { get => estComprensibilidad; set => estComprensibilidad = value; }
        public bool EstAprendizaje { get => estAprendizaje; set => estAprendizaje = value; }
        public bool EstOperabilidad { get => estOperabilidad; set => estOperabilidad = value; }
        public bool EstAtractividad { get => estAtractividad; set => estAtractividad = value; }
        public bool EstCumplimientoUsabilidad { get => estCumplimientoUsabilidad; set => estCumplimientoUsabilidad = value; }

        public double Usabilidad { get => usabilidad; set => usabilidad = value; }
        public double Comprensibilidad { get => comprensibilidad; set => comprensibilidad = value; }
        public double Aprendizaje { get => aprendizaje; set => aprendizaje = value; }
        public double Operabilidad { get => operabilidad; set => operabilidad = value; }
        public double Atractividad { get => atractividad; set => atractividad = value; }
        public double CumplimientoUsabilidad { get => cumplimientoUsabilidad; set => cumplimientoUsabilidad = value; }

        public bool EstMantenibilidad { get => estMantenibilidad; set => estMantenibilidad = value; }
        public bool EstAnalizabilidad { get => estAnalizabilidad; set => estAnalizabilidad = value; }
        public bool EstModificabilidad { get => estModificabilidad; set => estModificabilidad = value; }
        public bool EstEstabilidad { get => estEstabilidad; set => estEstabilidad = value; }
        public bool EstTesteabilidad { get => estTesteabilidad; set => estTesteabilidad = value; }
        public bool EstCumplimientoMantenibilidad { get => estCumplimientoMantenibilidad; set => estCumplimientoMantenibilidad = value; }

        public double Mantenibilidad { get => mantenibilidad; set => mantenibilidad = value; }
        public double Analizabilidad { get => analizabilidad; set => analizabilidad = value; }
        public double Modificabilidad { get => modificabilidad; set => modificabilidad = value; }
        public double Estabilidad { get => estabilidad; set => estabilidad = value; }
        public double Testeabilidad { get => testeabilidad; set => testeabilidad = value; }
        public double CumplimientoMantenibilidad { get => cumplimientoMantenibilidad; set => cumplimientoMantenibilidad = value; }
    }
}
