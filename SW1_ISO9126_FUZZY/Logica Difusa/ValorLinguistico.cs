﻿using SW1_ISO9126_FUZZY.Logica_Difusa.Funciones_Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
    /// <summary>
    /// Clase para lod valores linguisticos de la logica difusa.
    /// </summary>
    public class ValorLinguistico
    {
        private string nombre;
        private FuncionPertenencia fp;
        private double gradoPertenencia;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="fp"></param>
        public ValorLinguistico(string nombre, FuncionPertenencia fp)
        {
            Nombre = nombre;
            Fp = fp;
            GradoPertenencia = -1; // grado de pertenencia por defecto.
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="fp"></param>
        /// <param name="grado"></param>
        public ValorLinguistico(string nombre, FuncionPertenencia fp, double grado)
        {
            Nombre = nombre;
            Fp = fp;
            GradoPertenencia = grado; // grado de pertenencia por defecto.
        }

        /// <summary>
        /// Calcula el grado de pertenencia del valor linguistico.
        /// </summary>
        /// <param name="valor"></param>
        public void CalcularGradoPertenencia(double valor)
        {
            GradoPertenencia = Fp.GradoPertenencia(valor);
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public FuncionPertenencia Fp
        {
            get { return fp; }
            set { fp = value; }
        }

        public double GradoPertenencia
        {
            get { return gradoPertenencia; }
            set { gradoPertenencia = value; }
        }
    }
}
