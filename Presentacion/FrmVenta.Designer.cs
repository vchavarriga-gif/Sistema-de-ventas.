namespace Presentacion
{
    partial class FrmVenta
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
            lblProducto = new Label();
            cboProducto = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnAgregar = new Button();
            dgvDetalle = new DataGridView();
            lblTotal = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            //
            // lblProducto
            //
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(12, 17);
            lblProducto.Name = "lblProducto";
            lblProducto.Text = "Producto:";
            //
            // cboProducto
            //
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducto.Location = new Point(85, 13);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(330, 25);
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(425, 17);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Text = "Cant.:";
            //
            // nudCantidad
            //
            nudCantidad.Location = new Point(475, 14);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(70, 25);
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnAgregar
            //
            btnAgregar.Location = new Point(555, 10);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 32);
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            //
            // dgvDetalle
            //
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.Location = new Point(12, 52);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(653, 270);
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotal.Location = new Point(12, 340);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Total: $0";
            //
            // btnConfirmar
            //
            btnConfirmar.Location = new Point(435, 335);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(110, 36);
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(555, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 36);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FrmVenta
            //
            AcceptButton = btnAgregar;
            CancelButton = btnCancelar;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 385);
            Controls.Add(lblProducto);
            Controls.Add(cboProducto);
            Controls.Add(lblCantidad);
            Controls.Add(nudCantidad);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDetalle);
            Controls.Add(lblTotal);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmVenta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar venta";
            Load += FrmVenta_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProducto;
        private ComboBox cboProducto;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private DataGridView dgvDetalle;
        private Label lblTotal;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}
