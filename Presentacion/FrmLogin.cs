using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        // La presentación solo conoce la capa de NEGOCIO.
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            Usuario? usuario = null;
            bool ok = UI.Ejecutar(() => usuario = usuarioNegocio.IniciarSesion(txtRut.Text, txtClave.Text));
            if (!ok)
                return;   // ya se mostró el error (BD apagada, campos vacíos...)

            if (usuario == null)
            {
                UI.Error("RUT o clave incorrectos.");
                txtClave.Clear();
                txtClave.Focus();
                return;
            }

            // Se oculta el login mientras se usa el sistema; al cerrar sesión vuelve.
            Hide();
            using (FrmPrincipal frm = new FrmPrincipal(usuario))
                frm.ShowDialog();

            txtRut.Clear();
            txtClave.Clear();
            Show();
            txtRut.Focus();
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
