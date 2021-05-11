namespace MarmolApp.Model
{
    public class Persona 
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Celular { get; set; }
        public string Correo { get; set; }

        public Trato Trato { get; set; }

    }
}
