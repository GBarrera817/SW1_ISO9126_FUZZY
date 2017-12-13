
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    /// Metrica seleccion: Guarda el calculo (datos) de una metrica
    /// </summary>

    public class MTCalculo
    {
        private int id;
        private double resultado;

        public MTCalculo()
        {
            this.Id = 0;
            this.Resultado = 0;
        }

        public override string ToString()
        {
            string str = "";
            str += "\nID: " + id;
            str += "\nResultado: " + resultado;

            return str;
        }

        public int Id { get => id; set => id = value; }
        public double Resultado { get => resultado; set => resultado = value; }
    }
}
