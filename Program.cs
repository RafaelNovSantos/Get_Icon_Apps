using System;
using System.Windows.Forms;

namespace Get_Icon_Apps
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configurar o aplicativo para usar o estilo visual moderno.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar o formulário principal
            Application.Run(new Form1());
        }
    }
}
