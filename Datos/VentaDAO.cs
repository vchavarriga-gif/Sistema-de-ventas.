using System.Data;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class VentaDAO
    {
        // Guarda la venta, sus detalles y descuenta el stock en UNA transacción.
        // Si algo falla (por ejemplo, falta stock), se deshace todo con Rollback.
        public int Registrar(Venta venta)
        {
            using MySqlConnection cn = Conexion.ObtenerConexion();
            Conexion.Abrir(cn);
            using MySqlTransaction tx = cn.BeginTransaction();
            try
            {
                int idVenta;
                using (MySqlCommand cmd = new MySqlCommand(
                    @"INSERT INTO Venta (Fecha, Total, RutTrabajador) VALUES (@fecha, @total, @rut);
                      SELECT LAST_INSERT_ID();", cn, tx))
                {
                    cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@total", venta.Total);
                    cmd.Parameters.AddWithValue("@rut", venta.RutTrabajador);
                    idVenta = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (DetalleVenta d in venta.Detalles)
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario)
                          VALUES (@idVenta, @idProducto, @cantidad, @precio)", cn, tx))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        cmd.Parameters.AddWithValue("@idProducto", d.Producto.IdProducto);
                        cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@precio", d.PrecioUnitario);
                        cmd.ExecuteNonQuery();
                    }

                    // Solo descuenta si hay stock suficiente en la BBDD en ese momento.
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"UPDATE Producto SET Stock = Stock - @cantidad
                          WHERE IdProducto = @idProducto AND Stock >= @cantidad", cn, tx))
                    {
                        cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@idProducto", d.Producto.IdProducto);
                        if (cmd.ExecuteNonQuery() == 0)
                            throw new DatosException($"Stock insuficiente de '{d.Producto.Nombre}'.");
                    }
                }

                tx.Commit();
                venta.IdVenta = idVenta;
                return idVenta;
            }
            catch (DatosException)
            {
                tx.Rollback();
                throw;
            }
            catch (MySqlException ex)
            {
                tx.Rollback();
                throw new DatosException("Error al registrar la venta. No se guardó nada.", ex);
            }
        }

        public List<Venta> Listar()
        {
            const string sql = "SELECT IdVenta, Fecha, Total, RutTrabajador FROM Venta ORDER BY IdVenta DESC";
            List<Venta> lista = new List<Venta>();
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                Conexion.Abrir(cn);
                using MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(new Venta(dr.GetInt32(0), dr.GetDateTime(1), dr.GetInt32(2), dr.GetString(3)));
                return lista;
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al listar las ventas.", ex);
            }
        }

        // Carga una venta con todos sus detalles (para volver a emitir la boleta).
        public Venta? BuscarPorId(int idVenta)
        {
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                Conexion.Abrir(cn);

                Venta? venta = null;
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT IdVenta, Fecha, Total, RutTrabajador FROM Venta WHERE IdVenta = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", idVenta);
                    using MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        venta = new Venta(dr.GetInt32(0), dr.GetDateTime(1), dr.GetInt32(2), dr.GetString(3));
                }
                if (venta == null)
                    return null;

                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT p.IdProducto, p.Nombre, p.Precio, p.Stock, d.Cantidad, d.PrecioUnitario
                      FROM DetalleVenta d
                      INNER JOIN Producto p ON p.IdProducto = d.IdProducto
                      WHERE d.IdVenta = @id
                      ORDER BY p.Nombre", cn))
                {
                    cmd.Parameters.AddWithValue("@id", idVenta);
                    using MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Producto p = new Producto(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetInt32(3));
                        venta.CargarDetalle(new DetalleVenta(p, dr.GetInt32(4), dr.GetInt32(5)));
                    }
                }
                return venta;
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al buscar la venta.", ex);
            }
        }
    }
}
