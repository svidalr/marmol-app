using System;
using System.Collections.Generic;

namespace MarmolApp.Model
{
    public class Fallecido : EntityBase
    {
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaDefuncion { get; set; }
        public string Epitafio { get; set; }

        public List<string> IdTrato { get; set; }
    }
}
