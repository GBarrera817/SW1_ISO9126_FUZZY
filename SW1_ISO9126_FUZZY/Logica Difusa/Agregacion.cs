﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW1_ISO9126_FUZZY.Logica_Difusa
{
    /// <summary>
    /// Clase para la agregacion.
    /// </summary>
    public static class Agregacion
    {
        /// <summary>
        /// Realiza la agregacion, recibe los consecuentes agrupados por 
        /// los diferentes valores linguisticos.
        /// </summary>
        /// <param name="consecuentes"></param>
        /// <returns></returns>
        public static List<ValorLinguistico> Ejecutar(Dictionary<string, List<ValorLinguistico>> consecuentes)
        {
            List<ValorLinguistico> resultado = new List<ValorLinguistico>();
            foreach (KeyValuePair<string, List<ValorLinguistico>> consecuente in consecuentes)
            {
                List<double> gradosPertenencias = new List<double>();
                ValorLinguistico valorLinguistico = null;
                //Console.WriteLine("Consecuente : " + consecuente.Key);
                foreach (ValorLinguistico valor in consecuente.Value)
                {
                    // Obtenemos el valor linguistico en la primera iteracion.
                    if ( valorLinguistico == null )
                        valorLinguistico = new ValorLinguistico(valor.Nombre, valor.Fp);
                    //Console.WriteLine("Grado pertenencia : " + valor.GradoPertenencia);
                    gradosPertenencias.Add(valor.GradoPertenencia);
                }
                // Obtenemos el maximo y agregamos el valor linguistico al conjunto difuso resultante.
                if (valorLinguistico != null)
                {
                    valorLinguistico.GradoPertenencia = gradosPertenencias.Max();
                    valorLinguistico.Fp.ValorCorte = valorLinguistico.GradoPertenencia;
                    //Console.WriteLine("Max : " + valorLinguistico.GradoPertenencia);
                    resultado.Add(valorLinguistico);
                }
            }

            return resultado;
        }
    }
}
