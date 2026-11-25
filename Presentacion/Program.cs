namespace Presentacion
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Red de seguridad: si algún error se escapa de un try/catch,
            // se muestra un mensaje en vez de cerrar la aplicación.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
                UI.Error("Ocurrió un error inesperado: " + e.Exception.Message);

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin());
        }
    }
}
