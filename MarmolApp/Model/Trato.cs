using System;

namespace MarmolApp.Model
{
    class Trato 
    {
        public int IdTrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int FK_IdPersonal { get; set; }
        public int FK_IdCliente { get; set; }

        public Persona Persona { get; set; }
        public Cliente Cliente { get; set; }
        public Fallecido Fallecido { get; set; }
        public TratoProducto TratoProducto { get; set; }

    }
}
