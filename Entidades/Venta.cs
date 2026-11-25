using System.Text;

namespace Entidades
{
    public class Venta
    {
        private int idVenta;
        private int total;
        private DateTime fecha;
        private string rutTrabajador;   // Trabajador 1 ---- N Venta (REGISTRA)

        // COMPOSICIÓN: los detalles pertenecen a la venta. Se crean DENTRO de la venta
        // (en AgregarDetalle) y no tienen sentido sin ella.
        private List<DetalleVenta> detalles = new List<DetalleVenta>();

        public Venta(string rutTrabajador)
        {
            this.rutTrabajador = rutTrabajador;
            fecha = DateTime.Now;
        }

        // Constructor usado al leer una venta ya guardada en la BBDD.
        public Venta(int idVenta, DateTime fecha, int total, string rutTrabajador)
        {
            this.idVenta = idVenta;
            this.fecha = fecha;
            this.total = total;
            this.rutTrabajador = rutTrabajador;
        }

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public int Total { get { return total; } }
        public DateTime Fecha { get { return fecha; } }
        public string RutTrabajador { get { return rutTrabajador; } }

        // Se devuelve como solo lectura para que nadie agregue detalles por fuera.
        public IReadOnlyList<DetalleVenta> Detalles
        {
            get { return detalles; }
        }

        public void AgregarDetalle(Producto producto, int cantidad)
        {
            // Si el producto ya está en la venta, se suma la cantidad.
            DetalleVenta? existente = detalles.Find(d => d.Producto.IdProducto == producto.IdProducto);
            int cantidadTotal = cantidad + (existente?.Cantidad ?? 0);

            if (cantidadTotal > producto.Stock)
                throw new InvalidOperationException(
                    $"Stock insuficiente de '{producto.Nombre}'. Disponible: {producto.Stock}.");

            if (existente != null)
                detalles.Remove(existente);

            detalles.Add(new DetalleVenta(producto, cantidadTotal));
            CalcularTotal();
        }

        // Usado por la capa de Datos al cargar detalles guardados.
        public void CargarDetalle(DetalleVenta detalle)
        {
            detalles.Add(detalle);
        }

        // + calcularTotal(): int
        public int CalcularTotal()
        {
            total = 0;
            foreach (DetalleVenta d in detalles)
                total += d.Subtotal;
            return total;
        }

        // + emitirBoleta(): devuelve el texto de la boleta.
        public string EmitirBoleta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==============================================");
            sb.AppendLine($"  BOLETA N° {idVenta}");
            sb.AppendLine($"  Fecha: {fecha:dd-MM-yyyy HH:mm}");
            sb.AppendLine($"  Atendido por: {rutTrabajador}");
            sb.AppendLine("----------------------------------------------");
            // Se ordena por nombre para que la boleta salga igual al emitirla
            // y al volver a consultarla desde la BBDD.
            foreach (DetalleVenta d in detalles.OrderBy(d => d.Producto.Nombre))
                sb.AppendLine("  " + d);
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine($"  TOTAL: ${total}");
            sb.AppendLine("==============================================");
            return sb.ToString();
        }
    }
}
