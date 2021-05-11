using System.Collections.Generic;

namespace MarmolApp.Model
{
    public class Persona : EntityBase
    {
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Celular { get; set; }
        public string Correo { get; set; }

        public List<string> IdTrato { get; set; }
    }
}
