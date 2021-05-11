namespace MarmolApp.Model
{
    /// <summary>
    /// cliente de marmol
    /// </summary>
    public class Cliente 
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Celular { get; set; }

        public Trato Trato { get; set; }

    }
}
