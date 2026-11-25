using Entidades;
using Negocio;

namespace Presentacion
{
    // CRUD de Trabajador (solo lo abre un Jefe).
    public partial class FrmTrabajadores : Form
    {
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private readonly Jefe jefe;

        public FrmTrabajadores(Jefe jefe)
        {
            InitializeComponent();
            this.jefe = jefe;
            // Los turnos vienen de la entidad (no se escriben a mano en el formulario).
            cboTurno.Items.AddRange(Trabajador.TurnosValidos);
        }

        private void FrmTrabajadores_Load(object? sender, EventArgs e)
        {
            CargarTrabajadores();
            Limpiar();
        }

        // READ
        private void CargarTrabajadores()
        {
            bool ok = UI.Ejecutar(() => dgvTrabajadores.DataSource = usuarioNegocio.ListarTrabajadores());
            if (ok && dgvTrabajadores.Columns.Count > 0)
            {
                // Orden y títulos de columnas más legibles.
                dgvTrabajadores.Columns["Rut"]!.DisplayIndex = 0;
                dgvTrabajadores.Columns["Nombre"]!.DisplayIndex = 1;
                dgvTrabajadores.Columns["Turno"]!.DisplayIndex = 2;
                dgvTrabajadores.Columns["RutJefe"]!.HeaderText = "RUT Jefe";
            }
        }

        private Trabajador? Seleccionado =>
            dgvTrabajadores.SelectedRows.Count > 0
                ? dgvTrabajadores.SelectedRows[0].DataBoundItem as Trabajador
                : null;

        private void dgvTrabajadores_SelectionChanged(object? sender, EventArgs e)
        {
            Trabajador? t = Seleccionado;
            if (t == null)
                return;
            txtRut.Text = t.Rut;
            txtRut.ReadOnly = true;      // el RUT es la PRIMARY KEY: no se modifica
            txtNombre.Text = t.Nombre;
            cboTurno.SelectedItem = t.Turno;
            txtClave.Clear();
            txtClave.Enabled = false;    // la clave solo se define al registrar
        }

        private void Limpiar()
        {
            dgvTrabajadores.ClearSelection();
            txtRut.Clear();
            txtRut.ReadOnly = false;
            txtNombre.Clear();
            txtClave.Clear();
            txtClave.Enabled = true;
            cboTurno.SelectedIndex = 0;
            txtRut.Focus();
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            Limpiar();
        }

        // CREATE
        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            bool ok = UI.Ejecutar(() =>
                usuarioNegocio.RegistrarTrabajador(jefe, txtRut.Text, txtNombre.Text,
                                                   txtClave.Text, cboTurno.Text));
            if (ok)
            {
                UI.Info("Trabajador registrado.");
                CargarTrabajadores();
                Limpiar();
            }
        }

        // UPDATE
        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            Trabajador? t = Seleccionado;
            if (t == null)
            {
                UI.Error("Seleccione un trabajador de la lista.");
                return;
            }
            bool ok = UI.Ejecutar(() =>
                usuarioNegocio.ActualizarTrabajador(t.Rut, txtNombre.Text, cboTurno.Text));
            if (ok)
            {
                UI.Info("Trabajador actualizado.");
                CargarTrabajadores();
            }
        }

        // DELETE
        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            Trabajador? t = Seleccionado;
            if (t == null)
            {
                UI.Error("Seleccione un trabajador de la lista.");
                return;
            }
            if (!UI.Confirmar($"¿Eliminar al trabajador {t.Nombre}?"))
                return;

            if (UI.Ejecutar(() => usuarioNegocio.EliminarTrabajador(t.Rut)))
            {
                UI.Info("Trabajador eliminado.");
                CargarTrabajadores();
                Limpiar();
            }
        }
    }
}
