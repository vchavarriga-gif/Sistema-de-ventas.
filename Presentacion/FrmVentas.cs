using Entidades;
using Negocio;

namespace Presentacion
{
    // Lista las ventas y muestra la boleta de la venta seleccionada.
    public partial class FrmVentas : Form
    {
        private readonly VentaNegocio ventaNegocio = new VentaNegocio();

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object? sender, EventArgs e)
        {
            bool ok = UI.Ejecutar(() => dgvVentas.DataSource = ventaNegocio.Listar());
            if (ok && dgvVentas.Columns.Count > 0)
            {
                // La lista de detalles no se muestra en la grilla (va en la boleta).
                if (dgvVentas.Columns.Contains("Detalles"))
                    dgvVentas.Columns["Detalles"]!.Visible = false;
                dgvVentas.Columns["IdVenta"]!.HeaderText = "N°";
                dgvVentas.Columns["IdVenta"]!.DisplayIndex = 0;
                dgvVentas.Columns["Fecha"]!.DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
                dgvVentas.Columns["RutTrabajador"]!.HeaderText = "Vendedor";
            }
        }

        private void dgvVentas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count == 0 ||
                dgvVentas.SelectedRows[0].DataBoundItem is not Venta v)
                return;

            // Se carga la venta completa (con detalles) para emitir la boleta.
            UI.Ejecutar(() => txtBoleta.Text = ventaNegocio.Buscar(v.IdVenta).EmitirBoleta());
        }
    }
}
