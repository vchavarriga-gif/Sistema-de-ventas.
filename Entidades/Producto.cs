namespace Entidades
{
    public class Producto
    {
        private int idProducto;
        private string nombre;
        private int precio;
        private int stock;

        public Producto(int idProducto, string nombre, int precio, int stock)
        {
            if (stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            this.idProducto = idProducto;
            this.nombre = "";
            Nombre = nombre;   // ENCAPSULAMIENTO: pasa por la validación de la propiedad
            Precio = precio;   // idem
            this.stock = stock;
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del producto no puede estar vacío.");
                nombre = value;
            }
        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio debe ser mayor a 0.");
                precio = value;
            }
        }

        // El stock NO tiene set público: solo cambia con ActualizarStock().
        public int Stock
        {
            get { return stock; }
        }

        // + actualizarStock(cantidad: int): positivo suma, negativo resta.
        public void ActualizarStock(int cantidad)
        {
            if (stock + cantidad < 0)
                throw new InvalidOperationException(
                    $"Stock insuficiente de '{nombre}'. Disponible: {stock}.");
            stock += cantidad;
        }

        // + obtenerPrecio(): int
        public int ObtenerPrecio()
        {
            return precio;
        }

        public override string ToString()
        {
            return $"[{IdProducto}] {Nombre} - ${Precio} - Stock: {Stock}";
        }
    }
}
