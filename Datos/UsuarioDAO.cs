using System.Data;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class UsuarioDAO
    {
        // Busca un usuario por RUT y devuelve un Jefe o un Trabajador según su tipo.
        // (El llamador recibe un "Usuario": aquí se aplica POLIMORFISMO.)
        public Usuario? BuscarPorRut(string rut)
        {
            const string sql = @"SELECT u.Rut, u.Nombre, u.Clave, u.Tipo,
                                        j.NivelAcceso, t.Turno, t.RutJefe
                                 FROM Usuario u
                                 LEFT JOIN Jefe j       ON j.Rut = u.Rut
                                 LEFT JOIN Trabajador t ON t.Rut = u.Rut
                                 WHERE u.Rut = @rut";
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@rut", rut);
                Conexion.Abrir(cn);
                using MySqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                    return null;

                string tipo = dr.GetString(3);
                if (tipo == "JEFE")
                    return new Jefe(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(4));

                return new Trabajador(dr.GetString(0), dr.GetString(1), dr.GetString(2),
                                      dr.GetString(5), dr.IsDBNull(6) ? null : dr.GetString(6));
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al buscar el usuario.", ex);
            }
        }

        // ---------------- CRUD de Trabajador ----------------

        // CREATE: inserta en Usuario y en Trabajador dentro de una TRANSACCIÓN
        // (o se guardan las dos filas, o ninguna).
        public void InsertarTrabajador(Trabajador t)
        {
            using MySqlConnection cn = Conexion.ObtenerConexion();
            Conexion.Abrir(cn);
            using MySqlTransaction tx = cn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO Usuario (Rut, Nombre, Clave, Tipo) VALUES (@rut, @nombre, @clave, 'TRABAJADOR')", cn, tx))
                {
                    cmd.Parameters.AddWithValue("@rut", t.Rut);
                    cmd.Parameters.AddWithValue("@nombre", t.Nombre);
                    cmd.Parameters.AddWithValue("@clave", t.ObtenerClaveParaGuardar());
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO Trabajador (Rut, Turno, RutJefe) VALUES (@rut, @turno, @rutJefe)", cn, tx))
                {
                    cmd.Parameters.AddWithValue("@rut", t.Rut);
                    cmd.Parameters.AddWithValue("@turno", t.Turno);
                    cmd.Parameters.AddWithValue("@rutJefe", (object?)t.RutJefe ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                tx.Commit();
            }
            catch (MySqlException ex)
            {
                tx.Rollback();
                if (ErroresSql.EsDuplicado(ex))
                    throw new DatosException($"Ya existe un usuario con RUT {t.Rut}.", ex);
                throw new DatosException("Error al registrar el trabajador.", ex);
            }
        }

        // READ
        public List<Trabajador> ListarTrabajadores()
        {
            const string sql = @"SELECT u.Rut, u.Nombre, u.Clave, t.Turno, t.RutJefe
                                 FROM Usuario u
                                 INNER JOIN Trabajador t ON t.Rut = u.Rut
                                 ORDER BY u.Nombre";
            List<Trabajador> lista = new List<Trabajador>();
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                Conexion.Abrir(cn);
                using MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Trabajador(dr.GetString(0), dr.GetString(1), dr.GetString(2),
                                             dr.GetString(3), dr.IsDBNull(4) ? null : dr.GetString(4)));
                }
                return lista;
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al listar los trabajadores.", ex);
            }
        }

        // UPDATE
        public bool ActualizarTrabajador(Trabajador t)
        {
            using MySqlConnection cn = Conexion.ObtenerConexion();
            Conexion.Abrir(cn);
            using MySqlTransaction tx = cn.BeginTransaction();
            try
            {
                int filas;
                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE Usuario SET Nombre = @nombre WHERE Rut = @rut", cn, tx))
                {
                    cmd.Parameters.AddWithValue("@nombre", t.Nombre);
                    cmd.Parameters.AddWithValue("@rut", t.Rut);
                    filas = cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE Trabajador SET Turno = @turno WHERE Rut = @rut", cn, tx))
                {
                    cmd.Parameters.AddWithValue("@turno", t.Turno);
                    cmd.Parameters.AddWithValue("@rut", t.Rut);
                    cmd.ExecuteNonQuery();
                }
                tx.Commit();
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                tx.Rollback();
                throw new DatosException("Error al actualizar el trabajador.", ex);
            }
        }

        // DELETE (borra de Usuario; ON DELETE CASCADE borra también de Trabajador)
        public bool EliminarTrabajador(string rut)
        {
            const string sql = "DELETE FROM Usuario WHERE Rut = @rut AND Tipo = 'TRABAJADOR'";
            try
            {
                using MySqlConnection cn = Conexion.ObtenerConexion();
                using MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@rut", rut);
                Conexion.Abrir(cn);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex) when (ex.Number == ErroresSql.ConflictoFK)
            {
                throw new DatosException("No se puede eliminar: el trabajador tiene ventas registradas.", ex);
            }
            catch (MySqlException ex)
            {
                throw new DatosException("Error al eliminar el trabajador.", ex);
            }
        }
    }
}
