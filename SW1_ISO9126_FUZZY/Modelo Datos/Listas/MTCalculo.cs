
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    /// Metrica seleccion: Guarda el calculo (datos) de una metrica
    /// </summary>

    public class MTCalculo
    {
        private int id;
        private double resultado;

        public MTCalculo(int id, double resultado)
        {
            this.Id = 0;
            this.Resultado = 0;
        }

        public int Id { get => id; set => id = value; }
        public double Resultado { get => resultado; set => resultado = value; }
    }
}
