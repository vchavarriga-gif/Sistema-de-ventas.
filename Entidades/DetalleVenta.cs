namespace Entidades
{
    public class DetalleVenta
    {
        private Producto producto;   // DetalleVenta N ---- 1 Producto
        private int cantidad;
        private int precioUnitario;  // se guarda el precio del momento de la venta
        private int subtotal;

        public DetalleVenta(Producto producto, int cantidad)
            : this(producto, cantidad, producto.ObtenerPrecio())
        {
        }

        // Constructor usado al leer desde la BBDD (con el precio histórico).
        public DetalleVenta(Producto producto, int cantidad, int precioUnitario)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");

            this.producto = producto;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            CalcularSubtotal();
        }

        public Producto Producto { get { return producto; } }
        public int Cantidad { get { return cantidad; } }
        public int PrecioUnitario { get { return precioUnitario; } }
        public int Subtotal { get { return subtotal; } }

        // + calcularSubtotal(): int
        public int CalcularSubtotal()
        {
            subtotal = cantidad * precioUnitario;
            return subtotal;
        }

        public override string ToString()
        {
            return $"{producto.Nombre,-20} x{cantidad,3}  ${precioUnitario,7}  = ${subtotal,8}";
        }
    }
}
