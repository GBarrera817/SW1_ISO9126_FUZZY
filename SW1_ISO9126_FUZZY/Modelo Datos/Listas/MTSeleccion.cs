
namespace SW1_ISO9126_FUZZY.Modelo_Datos.Listas
{
    /// <summary>
    /// Metrica seleccion: Guarda la seleccion (datos) de una metrica
    /// </summary>

    public class MTSeleccion
    {
        private int id;
        private int proposito;
        private bool estado;

        public MTSeleccion()
        {
            this.id = 0;
            this.proposito = -1;
            this.estado = true;
        }

        public override string ToString()
        {
            string str = "";
            str += "\nID: " + id;
            str += "\nProposito: " + proposito;
            str += "\nEstado: " + estado;

            return str;
        }

        public int Id { get => id; set => id = value; }
        public int Proposito { get => proposito; set => proposito = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
