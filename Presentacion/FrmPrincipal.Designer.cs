namespace Presentacion
{
    partial class FrmPrincipal
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
            lblBienvenida = new Label();
            flpMenu = new FlowLayoutPanel();
            btnProductos = new Button();
            btnTrabajadores = new Button();
            btnNuevaVenta = new Button();
            btnVentas = new Button();
            btnCerrarSesion = new Button();
            flpMenu.SuspendLayout();
            SuspendLayout();
            //
            // lblBienvenida
            //
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBienvenida.Location = new Point(20, 18);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Text = "Bienvenido/a";
            //
            // flpMenu
            //
            flpMenu.Controls.Add(btnProductos);
            flpMenu.Controls.Add(btnTrabajadores);
            flpMenu.Controls.Add(btnNuevaVenta);
            flpMenu.Controls.Add(btnVentas);
            flpMenu.Controls.Add(btnCerrarSesion);
            flpMenu.FlowDirection = FlowDirection.TopDown;
            flpMenu.Location = new Point(20, 55);
            flpMenu.Name = "flpMenu";
            flpMenu.Size = new Size(260, 260);
            flpMenu.WrapContents = false;
            //
            // btnProductos
            //
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(250, 42);
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            //
            // btnTrabajadores
            //
            btnTrabajadores.Name = "btnTrabajadores";
            btnTrabajadores.Size = new Size(250, 42);
            btnTrabajadores.Text = "Trabajadores";
            btnTrabajadores.UseVisualStyleBackColor = true;
            btnTrabajadores.Click += btnTrabajadores_Click;
            //
            // btnNuevaVenta
            //
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(250, 42);
            btnNuevaVenta.Text = "Registrar venta";
            btnNuevaVenta.UseVisualStyleBackColor = true;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            //
            // btnVentas
            //
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(250, 42);
            btnVentas.Text = "Ver ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            //
            // btnCerrarSesion
            //
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(250, 42);
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            //
            // FrmPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 330);
            Controls.Add(lblBienvenida);
            Controls.Add(flpMenu);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú principal";
            flpMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private FlowLayoutPanel flpMenu;
        private Button btnProductos;
        private Button btnTrabajadores;
        private Button btnNuevaVenta;
        private Button btnVentas;
        private Button btnCerrarSesion;
    }
}
