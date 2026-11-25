using System.Diagnostics;

namespace Presentacion
{
    // Utilidades comunes de la interfaz. Centraliza el MANEJO DE EXCEPCIONES:
    // cualquier error (BD apagada, RUT duplicado, campo vacío...) llega aquí
    // como un mensaje claro y la aplicación NO se cae.
    internal static class UI
    {
        // Ejecuta una acción y, si falla, muestra el mensaje. Devuelve true si salió bien.
        public static bool Ejecutar(Action accion)
        {
            try
            {
                accion();
                return true;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                // El detalle técnico (MySQL) no se muestra al usuario;
                // aparece en la ventana "Salida" de Visual Studio al depurar.
                if (ex.InnerException != null)
                    Debug.WriteLine($"Detalle: {ex.InnerException.Message}");
                return false;
            }
        }

        public static void Error(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void Info(string mensaje) =>
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static bool Confirmar(string mensaje) =>
            MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes;

        // Muestra la boleta con letra de ancho fijo para que las columnas queden alineadas.
        public static void MostrarBoleta(string texto)
        {
            using Form frm = new Form
            {
                Text = "Boleta",
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(440, 380),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            frm.Controls.Add(new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 10),
                Text = texto
            });
            frm.ShowDialog();
        }
    }
}
