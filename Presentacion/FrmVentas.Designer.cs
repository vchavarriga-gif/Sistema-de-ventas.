namespace Presentacion
{
    partial class FrmVentas
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
            dgvVentas = new DataGridView();
            txtBoleta = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            //
            // dgvVentas
            //
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.Location = new Point(12, 12);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(440, 400);
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
            //
            // txtBoleta
            //
            txtBoleta.Font = new Font("Consolas", 9.5F);
            txtBoleta.Location = new Point(465, 12);
            txtBoleta.Multiline = true;
            txtBoleta.Name = "txtBoleta";
            txtBoleta.ReadOnly = true;
            txtBoleta.ScrollBars = ScrollBars.Vertical;
            txtBoleta.Size = new Size(420, 400);
            //
            // FrmVentas
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 425);
            Controls.Add(dgvVentas);
            Controls.Add(txtBoleta);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ventas registradas";
            Load += FrmVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVentas;
        private TextBox txtBoleta;
    }
}
