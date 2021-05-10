namespace MarmolApp.Model
{
    class Producto 
    {
        public int IdProducto { get; set; }
        public double Peso { get; set; }
        public string Dimensiones { get; set; }
        public string Tipo { get; set; }

        public Precio Precio { get; set; }
    }
}
