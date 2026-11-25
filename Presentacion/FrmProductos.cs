using Entidades;
using Negocio;

namespace Presentacion
{
    // CRUD de Producto. El formulario NO valida reglas ni usa SQL:
    // solo toma datos de los controles y se los pasa a ProductoNegocio.
    public partial class FrmProductos : Form
    {
        private readonly ProductoNegocio productoNegocio = new ProductoNegocio();
        private readonly Usuario usuario;

        public FrmProductos(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            // POLIMORFISMO: el Jefe ve el CRUD; el Trabajador ve "Registrar producción".
            bool esJefe = usuario.PuedeAdministrar();
            grpDatos.Visible = esJefe;
            grpProduccion.Visible = !esJefe;
        }

        private void FrmProductos_Load(object? sender, EventArgs e)
        {
            CargarProductos();
            Limpiar();
        }

        // READ
        private void CargarProductos()
        {
            UI.Ejecutar(() => dgvProductos.DataSource = productoNegocio.Listar());
        }

        // Producto de la fila seleccionada (la grilla está enlazada a una List<Producto>).
        private Producto? Seleccionado =>
            dgvProductos.SelectedRows.Count > 0
                ? dgvProductos.SelectedRows[0].DataBoundItem as Producto
                : null;

        private void dgvProductos_SelectionChanged(object? sender, EventArgs e)
        {
            Producto? p = Seleccionado;
            if (p == null)
                return;
            txtId.Text = p.IdProducto.ToString();
            txtNombre.Text = p.Nombre;
            nudPrecio.Value = p.Precio;
            nudStock.Value = p.Stock;
            nudStock.Enabled = false;   // el stock solo cambia con producción o ventas
        }

        private void Limpiar()
        {
            dgvProductos.ClearSelection();
            txtId.Clear();
            txtNombre.Clear();
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            nudStock.Enabled = true;    // al crear sí se indica el stock inicial
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            Limpiar();
        }

        // CREATE
        private void btnCrear_Click(object? sender, EventArgs e)
        {
            bool ok = UI.Ejecutar(() =>
            {
                int id = productoNegocio.Crear(txtNombre.Text, (int)nudPrecio.Value, (int)nudStock.Value);
                UI.Info($"Producto creado con ID {id}.");
            });
            if (ok)
            {
                CargarProductos();
                Limpiar();
            }
        }

        // UPDATE
        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            Producto? p = Seleccionado;
            if (p == null)
            {
                UI.Error("Seleccione un producto de la lista.");
                return;
            }
            bool ok = UI.Ejecutar(() =>
                productoNegocio.Actualizar(usuario, p.IdProducto, txtNombre.Text, (int)nudPrecio.Value));
            if (ok)
            {
                UI.Info("Producto actualizado.");
                CargarProductos();
            }
        }

        // DELETE
        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            Producto? p = Seleccionado;
            if (p == null)
            {
                UI.Error("Seleccione un producto de la lista.");
                return;
            }
            if (!UI.Confirmar($"¿Eliminar el producto '{p.Nombre}'?"))
                return;

            if (UI.Ejecutar(() => productoNegocio.Eliminar(p.IdProducto)))
            {
                UI.Info("Producto eliminado.");
                CargarProductos();
                Limpiar();
            }
        }

        // Trabajador: registrar producción (aumenta el stock).
        private void btnProducir_Click(object? sender, EventArgs e)
        {
            Producto? p = Seleccionado;
            if (p == null)
            {
                UI.Error("Seleccione un producto de la lista.");
                return;
            }
            bool ok = UI.Ejecutar(() =>
                productoNegocio.RegistrarProduccion(usuario, p.IdProducto, (int)nudCantidad.Value));
            if (ok)
            {
                UI.Info("Producción registrada. Stock actualizado.");
                CargarProductos();
            }
        }
    }
}
