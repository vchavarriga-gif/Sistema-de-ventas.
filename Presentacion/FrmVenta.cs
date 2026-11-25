using Entidades;
using Negocio;

namespace Presentacion
{
    // Registrar una venta: se arma en memoria (objeto Venta con sus DetalleVenta)
    // y al confirmar se guarda todo junto en una TRANSACCIÓN (capa de Datos).
    public partial class FrmVenta : Form
    {
        private readonly VentaNegocio ventaNegocio = new VentaNegocio();
        private readonly ProductoNegocio productoNegocio = new ProductoNegocio();
        private readonly Usuario usuario;
        private Venta? venta;

        public FrmVenta(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void FrmVenta_Load(object? sender, EventArgs e)
        {
            bool ok = UI.Ejecutar(() =>
            {
                venta = ventaNegocio.IniciarVenta(usuario);   // valida que sea Trabajador
                CargarProductos();
            });
            if (!ok)
                BeginInvoke(new Action(Close));   // no se puede vender: se cierra el formulario
        }

        private void CargarProductos()
        {
            // Sin DisplayMember, el ComboBox usa Producto.ToString() (método sobrescrito).
            cboProducto.DataSource = productoNegocio.Listar();
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (venta == null || cboProducto.SelectedItem is not Producto seleccionado)
            {
                UI.Error("Seleccione un producto.");
                return;
            }
            bool ok = UI.Ejecutar(() =>
            {
                // Se vuelve a leer el producto para tener el stock actualizado.
                Producto p = productoNegocio.Buscar(seleccionado.IdProducto);
                ventaNegocio.AgregarProducto(venta, p, (int)nudCantidad.Value);
            });
            if (ok)
            {
                RefrescarDetalle();
                nudCantidad.Value = 1;
            }
        }

        private void RefrescarDetalle()
        {
            if (venta == null)
                return;
            dgvDetalle.DataSource = venta.Detalles
                .Select(d => new
                {
                    Producto = d.Producto.Nombre,
                    d.Cantidad,
                    Precio = d.PrecioUnitario,
                    d.Subtotal
                })
                .ToList();
            lblTotal.Text = $"Total: ${venta.Total:N0}";
        }

        private void btnConfirmar_Click(object? sender, EventArgs e)
        {
            if (venta == null)
                return;
            if (venta.Detalles.Count == 0)
            {
                UI.Error("Agregue al menos un producto.");
                return;
            }
            if (!UI.Confirmar($"Total ${venta.Total:N0}. ¿Confirmar la venta?"))
                return;

            if (UI.Ejecutar(() => ventaNegocio.Confirmar(venta)))
            {
                UI.MostrarBoleta(venta.EmitirBoleta());
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
