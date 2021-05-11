using System;

namespace MarmolApp.Model
{

    public class Trato : EntityBase
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaEntrega { get; set; }

        public string IdCliente { get; set; }
        public string  IdPersona { get; set; }
        public string IdFallecido { get; set; }
        public string IdTratoProducto { get; set; }

    }
}
