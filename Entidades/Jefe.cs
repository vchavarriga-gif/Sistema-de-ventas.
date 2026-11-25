namespace Entidades
{
    // HERENCIA: Jefe "es un" Usuario.
    public class Jefe : Usuario
    {
        private int nivelAcceso;

        // AGREGACIÓN: el jefe tiene trabajadores, pero los trabajadores
        // pueden existir sin el jefe (no se destruyen con él).
        private List<Trabajador> trabajadores = new List<Trabajador>();

        public Jefe(string rut, string nombre, string clave, int nivelAcceso)
            : base(rut, nombre, clave)
        {
            NivelAcceso = nivelAcceso;
        }

        public int NivelAcceso
        {
            get { return nivelAcceso; }
            set
            {
                if (value < 1 || value > 3)
                    throw new ArgumentException("El nivel de acceso debe estar entre 1 y 3.");
                nivelAcceso = value;
            }
        }

        public List<Trabajador> Trabajadores
        {
            get { return trabajadores; }
        }

        // + administrarUsuarios(): agrega un trabajador a su equipo.
        public void AdministrarUsuarios(Trabajador trabajador)
        {
            trabajador.RutJefe = Rut;
            trabajadores.Add(trabajador);
        }

        // + actualizarPrecios(): cambia el precio de un producto.
        public void ActualizarPrecios(Producto producto, int nuevoPrecio)
        {
            producto.Precio = nuevoPrecio;
        }

        public override string ObtenerRol()
        {
            return "Jefe";
        }

        // POLIMORFISMO: el Jefe sí puede administrar (sobrescribe el método del padre).
        public override bool PuedeAdministrar()
        {
            return true;
        }
    }
}
