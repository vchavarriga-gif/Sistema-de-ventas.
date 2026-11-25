using Datos;
using Entidades;

namespace Negocio
{
    public class ProductoNegocio
    {
        private readonly ProductoDAO dao = new ProductoDAO();

        public List<Producto> Listar()
        {
            return dao.Listar();
        }

        public Producto Buscar(int id)
        {
            return dao.BuscarPorId(id)
                ?? throw new InvalidOperationException($"No existe el producto con ID {id}.");
        }

        public int Crear(string nombre, int precio, int stock)
        {
            if (stock < 0)
                throw new ArgumentException("El stock inicial no puede ser negativo.");
            // El constructor de Producto valida nombre y precio.
            Producto p = new Producto(0, (nombre ?? "").Trim(), precio, stock);
            return dao.Insertar(p);
        }

        // UPDATE: solo el Jefe puede modificar nombre y precio (regla de negocio).
        // El stock NO se edita aquí: solo cambia con producción o con ventas.
        public void Actualizar(Usuario usuario, int id, string nuevoNombre, int nuevoPrecio)
        {
            if (usuario is not Jefe jefe)
                throw new UnauthorizedAccessException("Solo un jefe puede modificar productos.");

            Producto p = Buscar(id);
            p.Nombre = (nuevoNombre ?? "").Trim();     // el setter valida que no esté vacío
            jefe.ActualizarPrecios(p, nuevoPrecio);    // el setter de Precio valida > 0
            dao.Actualizar(p);
        }

        // El trabajador registra producción: aumenta el stock.
        public void RegistrarProduccion(Usuario usuario, int id, int cantidad)
        {
            if (usuario is not Trabajador trabajador)
                throw new UnauthorizedAccessException("Solo un trabajador registra producción.");

            Producto p = Buscar(id);
            trabajador.RegistrarProduccion(p, cantidad);
            dao.Actualizar(p);
        }

        public void Eliminar(int id)
        {
            if (!dao.Eliminar(id))
                throw new InvalidOperationException($"No existe el producto con ID {id}.");
        }
    }
}
