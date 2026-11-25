using System.Configuration;
using MySql.Data.MySqlClient;

namespace Datos
{
    // Centraliza la conexión. La cadena NO está escrita en el código:
    // se lee desde App.config (proyecto Presentacion), sección <connectionStrings>.
    // Si cambias de PC o de servidor, solo se modifica App.config, sin recompilar.
    public static class Conexion
    {
        private const string NombreCadena = "SistemaVentas";

        public static MySqlConnection ObtenerConexion()
        {
            string? cadena = ConfigurationManager.ConnectionStrings[NombreCadena]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cadena))
                throw new DatosException(
                    $"No se encontró la cadena de conexión '{NombreCadena}' en App.config.");
            return new MySqlConnection(cadena);
        }

        // Abre la conexión y, si MySQL no responde, lanza un mensaje claro en español.
        public static void Abrir(MySqlConnection cn)
        {
            try
            {
                cn.Open();
            }
            catch (MySqlException ex)
            {
                throw new DatosException(
                    "No se pudo conectar a la base de datos. Verifique que MySQL esté iniciado.", ex);
            }
        }
    }

    // Códigos de error de MySQL que la aplicación traduce a mensajes claros.
    internal static class ErroresSql
    {
        public const int ClaveDuplicada = 1062;   // viola PRIMARY KEY o UNIQUE
        public const int IndiceUnico = 1062;      // (mismo código en MySQL)
        public const int ConflictoFK = 1451;     // no se puede borrar: otra tabla lo referencia (FK)

        public static bool EsDuplicado(MySqlException ex) =>
            ex.Number == ClaveDuplicada || ex.Number == IndiceUnico;
    }

    // Excepción propia de la capa de Datos: así las otras capas no dependen de MySqlException.
    public class DatosException : Exception
    {
        public DatosException(string mensaje, Exception? interna = null)
            : base(mensaje, interna)
        {
        }
    }
}
