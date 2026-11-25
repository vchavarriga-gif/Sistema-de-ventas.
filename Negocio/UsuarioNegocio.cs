using Datos;
using Entidades;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDAO dao = new UsuarioDAO();

        // Devuelve el usuario si el RUT y la clave son correctos; si no, null.
        public Usuario? IniciarSesion(string rut, string clave)
        {
            if (string.IsNullOrWhiteSpace(rut) || string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("Ingrese RUT y clave.");

            Usuario? usuario = dao.BuscarPorRut(rut.Trim());
            if (usuario != null && usuario.IniciarSesion(clave))
                return usuario;
            return null;
        }

        public List<Trabajador> ListarTrabajadores()
        {
            return dao.ListarTrabajadores();
        }

        public void RegistrarTrabajador(Jefe jefe, string rut, string nombre, string clave, string turno)
        {
            rut = rut.Trim();
            turno = turno.Trim().ToUpper();

            if (!RutValido(rut))
                throw new ArgumentException("RUT inválido. Formato esperado: 12345678-9");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");
            if (clave.Length < 4)
                throw new ArgumentException("La clave debe tener al menos 4 caracteres.");
            if (!Trabajador.TurnosValidos.Contains(turno))
                throw new ArgumentException("Turno inválido. Use MAÑANA, TARDE o NOCHE.");

            Trabajador nuevo = new Trabajador(rut, nombre.Trim(), clave, turno, null);
            jefe.AdministrarUsuarios(nuevo);   // el jefe lo asigna a su equipo
            dao.InsertarTrabajador(nuevo);
        }

        public void ActualizarTrabajador(string rut, string nuevoNombre, string nuevoTurno)
        {
            // Busca solo ese RUT en la BD (no trae todos los trabajadores).
            if (dao.BuscarPorRut(rut.Trim()) is not Trabajador t)
                throw new InvalidOperationException("No existe un trabajador con ese RUT.");

            t.Nombre = nuevoNombre.Trim();   // el setter valida que no esté vacío
            t.Turno = nuevoTurno;            // el setter valida el turno
            dao.ActualizarTrabajador(t);
        }

        public void EliminarTrabajador(string rut)
        {
            if (!dao.EliminarTrabajador(rut.Trim()))
                throw new InvalidOperationException("No existe un trabajador con ese RUT.");
        }

        // Valida el formato y el dígito verificador del RUT chileno (módulo 11).
        public static bool RutValido(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            string[] partes = rut.Split('-');
            if (partes.Length != 2 || partes[1].Length != 1 || !int.TryParse(partes[0], out int numero))
                return false;

            int suma = 0, multiplicador = 2;
            while (numero > 0)
            {
                suma += (numero % 10) * multiplicador;
                numero /= 10;
                multiplicador = multiplicador == 7 ? 2 : multiplicador + 1;
            }
            int resto = 11 - (suma % 11);
            string dv = resto == 11 ? "0" : resto == 10 ? "K" : resto.ToString();
            return partes[1] == dv;
        }
    }
}
