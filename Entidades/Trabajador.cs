namespace Entidades
{
    // HERENCIA: Trabajador "es un" Usuario.
    public class Trabajador : Usuario
    {
        // Valores permitidos (los mismos del CHECK CK_Trabajador_Turno de la BBDD).
        public static readonly string[] TurnosValidos = { "MAÑANA", "TARDE", "NOCHE" };

        private string turno = "";
        private string? rutJefe;

        public Trabajador(string rut, string nombre, string clave, string turno, string? rutJefe)
            : base(rut, nombre, clave)
        {
            Turno = turno;   // pasa por la validación
            this.rutJefe = rutJefe;
        }

        // ENCAPSULAMIENTO: el set valida antes de guardar.
        public string Turno
        {
            get { return turno; }
            set
            {
                string valor = (value ?? "").Trim().ToUpper();
                if (!TurnosValidos.Contains(valor))
                    throw new ArgumentException("Turno inválido. Use MAÑANA, TARDE o NOCHE.");
                turno = valor;
            }
        }

        // Jefe 1 ---- N Trabajador: cada trabajador guarda el RUT de su jefe.
        public string? RutJefe
        {
            get { return rutJefe; }
            set { rutJefe = value; }
        }

        // + registrarVenta(): crea una venta nueva a nombre de este trabajador.
        public Venta RegistrarVenta()
        {
            return new Venta(Rut);
        }

        // + registrarProduccion(): el trabajador produce unidades y aumenta el stock.
        public void RegistrarProduccion(Producto producto, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad producida debe ser mayor a 0.");
            producto.ActualizarStock(cantidad);
        }

        public override string ObtenerRol()
        {
            return "Trabajador";
        }

        public override string ToString()
        {
            return base.ToString() + $" - Turno: {Turno}";
        }
    }
}
