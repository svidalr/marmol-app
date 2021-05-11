using System;

namespace MarmolApp.Model
{
    public class TratoProducto : EntityBase
    { 
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }


        public string  IdTrato { get; set; }
        public string IdPrecio { get; set; }

    }
}
