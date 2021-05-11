using System;

namespace MarmolApp.Model
{
    public class Precio 
    {
        public int IdPrecio { get; set; }
        public DateTime Fecha { get; set; }
        public int FK_IdProducto { get; set; }

        public TratoProducto TratoProducto { get; set; }
        public Producto Producto { get; set; }

    }
}
