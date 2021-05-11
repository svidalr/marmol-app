using System;

namespace MarmolApp.Model
{
    public class TratoProducto 
    {
        public int IdTratoProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int FK_IdTrato { get; set; }
        public int FK_IdPrecio { get; set; }


        public Trato Trato { get; set; }
        public Precio Precio { get; set; }

    }
}
