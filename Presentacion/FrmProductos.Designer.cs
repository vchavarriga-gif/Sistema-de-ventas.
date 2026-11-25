namespace Presentacion
{
    partial class FrmProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            grpDatos = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            nudPrecio = new NumericUpDown();
            lblStock = new Label();
            nudStock = new NumericUpDown();
            btnNuevo = new Button();
            btnCrear = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            grpProduccion = new GroupBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnProducir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            grpProduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            //
            // dgvProductos
            //
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Location = new Point(12, 12);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(560, 300);
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            //
            // grpDatos
            //
            grpDatos.Controls.Add(lblId);
            grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblPrecio);
            grpDatos.Controls.Add(nudPrecio);
            grpDatos.Controls.Add(lblStock);
            grpDatos.Controls.Add(nudStock);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnCrear);
            grpDatos.Controls.Add(btnActualizar);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Location = new Point(590, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(270, 300);
            grpDatos.Text = "Datos del producto";
            //
            // lblId
            //
            lblId.AutoSize = true;
            lblId.Location = new Point(15, 33);
            lblId.Name = "lblId";
            lblId.Text = "ID:";
            //
            // txtId
            //
            txtId.Location = new Point(90, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(165, 25);
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(90, 67);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(165, 25);
            //
            // lblPrecio
            //
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(15, 107);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Text = "Precio $:";
            //
            // nudPrecio
            //
            nudPrecio.Location = new Point(90, 104);
            nudPrecio.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(165, 25);
            nudPrecio.ThousandsSeparator = true;
            //
            // lblStock
            //
            lblStock.AutoSize = true;
            lblStock.Location = new Point(15, 144);
            lblStock.Name = "lblStock";
            lblStock.Text = "Stock:";
            //
            // nudStock
            //
            nudStock.Location = new Point(90, 141);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(165, 25);
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(15, 190);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(115, 34);
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnCrear
            //
            btnCrear.Location = new Point(140, 190);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(115, 34);
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            //
            // btnActualizar
            //
            btnActualizar.Location = new Point(15, 235);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(115, 34);
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(140, 235);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(115, 34);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // grpProduccion
            //
            grpProduccion.Controls.Add(lblCantidad);
            grpProduccion.Controls.Add(nudCantidad);
            grpProduccion.Controls.Add(btnProducir);
            grpProduccion.Location = new Point(590, 12);
            grpProduccion.Name = "grpProduccion";
            grpProduccion.Size = new Size(270, 160);
            grpProduccion.Text = "Registrar producción";
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(15, 35);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Text = "Cantidad producida:";
            //
            // nudCantidad
            //
            nudCantidad.Location = new Point(15, 60);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(240, 25);
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnProducir
            //
            btnProducir.Location = new Point(15, 105);
            btnProducir.Name = "btnProducir";
            btnProducir.Size = new Size(240, 34);
            btnProducir.Text = "Sumar al stock";
            btnProducir.UseVisualStyleBackColor = true;
            btnProducir.Click += btnProducir_Click;
            //
            // FrmProductos
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 325);
            Controls.Add(dgvProductos);
            Controls.Add(grpDatos);
            Controls.Add(grpProduccion);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Productos";
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            grpProduccion.ResumeLayout(false);
            grpProduccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductos;
        private GroupBox grpDatos;
        private Label lblId;
        private TextBox txtId;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private NumericUpDown nudPrecio;
        private Label lblStock;
        private NumericUpDown nudStock;
        private Button btnNuevo;
        private Button btnCrear;
        private Button btnActualizar;
        private Button btnEliminar;
        private GroupBox grpProduccion;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnProducir;
    }
}
