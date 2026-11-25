namespace Entidades
{
    // ABSTRACCIÓN: Usuario es abstracta, no se puede crear un "Usuario" suelto,
    // solo un Jefe o un Trabajador (las clases hijas).
    public abstract class Usuario
    {
        // ENCAPSULAMIENTO: los atributos son privados (-) y se accede a ellos con propiedades.
        private string rut;
        private string nombre;
        private string clave;

        protected Usuario(string rut, string nombre, string clave)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.clave = clave;
        }

        public string Rut
        {
            get { return rut; }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        // La clave solo se puede leer desde la misma clase o clases hijas (#protected).
        protected string Clave
        {
            get { return clave; }
        }

        // Se usa en la capa de Datos para guardar la clave en la BBDD.
        public string ObtenerClaveParaGuardar()
        {
            return clave;
        }

        // + iniciarSesion(): boolean  (del diagrama de clases)
        public bool IniciarSesion(string claveIngresada)
        {
            return clave == claveIngresada;
        }

        // POLIMORFISMO: cada clase hija responde distinto a estos métodos.
        public abstract string ObtenerRol();

        public virtual bool PuedeAdministrar()
        {
            return false;
        }

        public override string ToString()
        {
            return $"{Rut} - {Nombre} ({ObtenerRol()})";
        }
    }
}
