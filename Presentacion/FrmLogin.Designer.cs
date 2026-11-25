namespace Presentacion
{
    partial class FrmLogin
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
            lblTitulo = new Label();
            lblRut = new Label();
            txtRut = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Sistema de Ventas";
            //
            // lblRut
            //
            lblRut.AutoSize = true;
            lblRut.Location = new Point(30, 75);
            lblRut.Name = "lblRut";
            lblRut.Text = "RUT:";
            //
            // txtRut
            //
            txtRut.Location = new Point(110, 72);
            txtRut.Name = "txtRut";
            txtRut.PlaceholderText = "12345678-9";
            txtRut.Size = new Size(210, 25);
            txtRut.TabIndex = 0;
            //
            // lblClave
            //
            lblClave.AutoSize = true;
            lblClave.Location = new Point(30, 115);
            lblClave.Name = "lblClave";
            lblClave.Text = "Clave:";
            //
            // txtClave
            //
            txtClave.Location = new Point(110, 112);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(210, 25);
            txtClave.TabIndex = 1;
            txtClave.UseSystemPasswordChar = true;
            //
            // btnIngresar
            //
            btnIngresar.Location = new Point(110, 160);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(100, 34);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            //
            // btnSalir
            //
            btnSalir.Location = new Point(220, 160);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(100, 34);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // FrmLogin
            //
            AcceptButton = btnIngresar;
            CancelButton = btnSalir;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 220);
            Controls.Add(lblTitulo);
            Controls.Add(lblRut);
            Controls.Add(txtRut);
            Controls.Add(lblClave);
            Controls.Add(txtClave);
            Controls.Add(btnIngresar);
            Controls.Add(btnSalir);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblRut;
        private TextBox txtRut;
        private Label lblClave;
        private TextBox txtClave;
        private Button btnIngresar;
        private Button btnSalir;
    }
}
