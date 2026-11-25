namespace Presentacion
{
    partial class FrmTrabajadores
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
            dgvTrabajadores = new DataGridView();
            grpDatos = new GroupBox();
            lblRut = new Label();
            txtRut = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            lblTurno = new Label();
            cboTurno = new ComboBox();
            btnNuevo = new Button();
            btnRegistrar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrabajadores).BeginInit();
            grpDatos.SuspendLayout();
            SuspendLayout();
            //
            // dgvTrabajadores
            //
            dgvTrabajadores.AllowUserToAddRows = false;
            dgvTrabajadores.AllowUserToDeleteRows = false;
            dgvTrabajadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrabajadores.Location = new Point(12, 12);
            dgvTrabajadores.MultiSelect = false;
            dgvTrabajadores.Name = "dgvTrabajadores";
            dgvTrabajadores.ReadOnly = true;
            dgvTrabajadores.RowHeadersVisible = false;
            dgvTrabajadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrabajadores.Size = new Size(540, 300);
            dgvTrabajadores.SelectionChanged += dgvTrabajadores_SelectionChanged;
            //
            // grpDatos
            //
            grpDatos.Controls.Add(lblRut);
            grpDatos.Controls.Add(txtRut);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblClave);
            grpDatos.Controls.Add(txtClave);
            grpDatos.Controls.Add(lblTurno);
            grpDatos.Controls.Add(cboTurno);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnRegistrar);
            grpDatos.Controls.Add(btnActualizar);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Location = new Point(570, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(280, 300);
            grpDatos.Text = "Datos del trabajador";
            //
            // lblRut
            //
            lblRut.AutoSize = true;
            lblRut.Location = new Point(15, 33);
            lblRut.Name = "lblRut";
            lblRut.Text = "RUT:";
            //
            // txtRut
            //
            txtRut.Location = new Point(95, 30);
            txtRut.MaxLength = 12;
            txtRut.Name = "txtRut";
            txtRut.PlaceholderText = "12345678-9";
            txtRut.Size = new Size(170, 25);
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
            txtNombre.Location = new Point(95, 67);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(170, 25);
            //
            // lblClave
            //
            lblClave.AutoSize = true;
            lblClave.Location = new Point(15, 107);
            lblClave.Name = "lblClave";
            lblClave.Text = "Clave:";
            //
            // txtClave
            //
            txtClave.Location = new Point(95, 104);
            txtClave.MaxLength = 50;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(170, 25);
            txtClave.UseSystemPasswordChar = true;
            //
            // lblTurno
            //
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(15, 144);
            lblTurno.Name = "lblTurno";
            lblTurno.Text = "Turno:";
            //
            // cboTurno
            //
            cboTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTurno.Location = new Point(95, 141);
            cboTurno.Name = "cboTurno";
            cboTurno.Size = new Size(170, 25);
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(15, 190);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(120, 34);
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnRegistrar
            //
            btnRegistrar.Location = new Point(145, 190);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(120, 34);
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // btnActualizar
            //
            btnActualizar.Location = new Point(15, 235);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 34);
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(145, 235);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 34);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // FrmTrabajadores
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 325);
            Controls.Add(dgvTrabajadores);
            Controls.Add(grpDatos);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmTrabajadores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trabajadores";
            Load += FrmTrabajadores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTrabajadores).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTrabajadores;
        private GroupBox grpDatos;
        private Label lblRut;
        private TextBox txtRut;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblTurno;
        private ComboBox cboTurno;
        private Button btnNuevo;
        private Button btnRegistrar;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}
