using System;

namespace MarmolApp.Model
{
    class Fallecido 
    {
        public int IdFallecido { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaDefuncion { get; set; }
        public string Epitafio { get; set; }

        public Trato Trato { get; set; }
    }
}
