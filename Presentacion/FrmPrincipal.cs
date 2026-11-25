using Entidades;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private readonly Usuario usuario;

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            // POLIMORFISMO: la variable es de tipo Usuario, pero ObtenerRol() y
            // PuedeAdministrar() responden según el objeto real (Jefe o Trabajador).
            lblBienvenida.Text = $"Bienvenido/a, {usuario.Nombre} ({usuario.ObtenerRol()})";
            Text = $"Menú {usuario.ObtenerRol()}";

            bool esJefe = usuario.PuedeAdministrar();
            btnTrabajadores.Visible = esJefe;    // solo el Jefe administra trabajadores
            btnNuevaVenta.Visible = !esJefe;     // solo el Trabajador registra ventas
        }

        private void btnProductos_Click(object? sender, EventArgs e)
        {
            using FrmProductos frm = new FrmProductos(usuario);
            frm.ShowDialog(this);
        }

        private void btnTrabajadores_Click(object? sender, EventArgs e)
        {
            if (usuario is Jefe jefe)
            {
                using FrmTrabajadores frm = new FrmTrabajadores(jefe);
                frm.ShowDialog(this);
            }
        }

        private void btnNuevaVenta_Click(object? sender, EventArgs e)
        {
            using FrmVenta frm = new FrmVenta(usuario);
            frm.ShowDialog(this);
        }

        private void btnVentas_Click(object? sender, EventArgs e)
        {
            using FrmVentas frm = new FrmVentas();
            frm.ShowDialog(this);
        }

        private void btnCerrarSesion_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
