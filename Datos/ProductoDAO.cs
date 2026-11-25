using System.Data;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos
{
    // CRUD completo de Producto. Todas las consultas son PARAMETRIZADAS (@param)
    // para evitar inyección SQL: el valor viaja separado del texto SQL.
    public class ProductoDAO
    {
        // CREATE: devuelve el Id generado por IDENTITY.
        public int Insertar(Producto p)
        {
            const string sql = @"INSERT INTO Producto (Nombre, Precio, Stock)
                                 VALUES (@nombre, @precio, @stock);
                                 SELECT LAST_INSERT_ID();";
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                Conexion.Abrir(cn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex) when (ErroresSql.EsDuplicado(ex))
            {
                throw new DatosException($"Ya existe un producto llamado '{p.Nombre}'.", ex);
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al insertar el producto.", ex);
            }
        }

        // READ (todos)
        public List<Producto> Listar()
        {
            const string sql = "SELECT IdProducto, Nombre, Precio, Stock FROM Producto ORDER BY IdProducto";
            List<Producto> lista = new List<Producto>();
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                Conexion.Abrir(cn);
                using MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(Mapear(dr));
                return lista;
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al listar los productos.", ex);
            }
        }

        // READ (uno)
        public Producto? BuscarPorId(int id)
        {
            const string sql = "SELECT IdProducto, Nombre, Precio, Stock FROM Producto WHERE IdProducto = @id";
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", id);
                Conexion.Abrir(cn);
                using MySqlDataReader dr = cmd.ExecuteReader();
                return dr.Read() ? Mapear(dr) : null;
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al buscar el producto.", ex);
            }
        }

        // UPDATE
        public bool Actualizar(Producto p)
        {
            const string sql = @"UPDATE Producto
                                 SET Nombre = @nombre, Precio = @precio, Stock = @stock
                                 WHERE IdProducto = @id";
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@id", p.IdProducto);
                Conexion.Abrir(cn);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex) when (ErroresSql.EsDuplicado(ex))
            {
                throw new DatosException($"Ya existe un producto llamado '{p.Nombre}'.", ex);
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al actualizar el producto.", ex);
            }
        }

        // DELETE
        public bool Eliminar(int id)
        {
            const string sql = "DELETE FROM Producto WHERE IdProducto = @id";
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", id);
                Conexion.Abrir(cn);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex) when (ex.Number == ErroresSql.ConflictoFK)
            {
                throw new DatosException("No se puede eliminar: el producto tiene ventas registradas.", ex);
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al eliminar el producto.", ex);
            }
        }

        private static Producto Mapear(MySqlDataReader dr)
        {
            return new Producto(
                dr.GetInt32(0),
                dr.GetString(1),
                dr.GetInt32(2),
                dr.GetInt32(3));
        }
    }
}
