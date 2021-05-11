using System.Collections.Generic;

namespace MarmolApp.Model
{
    public class Producto : EntityBase
    {
        public double Peso { get; set; }
        public string Dimensiones { get; set; }
        public string Tipo { get; set; }

    }
}
