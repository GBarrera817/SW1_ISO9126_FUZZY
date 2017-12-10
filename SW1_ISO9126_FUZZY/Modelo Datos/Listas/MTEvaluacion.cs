﻿
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    /// Metricas Evaluacion: Guarda la evaluacion (datos) de una metrica
    /// </summary>

    public class MTEvaluacion
    {
        private int id;
        private string formula;
        private string[] parametros;
        private double[] valores;
        private int mejorValor;
        private int peorValor;

        public MTEvaluacion() { }

        public int Id { get => id; set => id = value; }
        public string Formula { get => formula; set => formula = value; }
        public string[] Parametros { get => parametros; set => parametros = value; }
        public double[] Valores { get => valores; set => valores = value; }
        public int MejorValor { get => mejorValor; set => mejorValor = value; }
        public int PeorValor { get => peorValor; set => peorValor = value; }
    }
}
