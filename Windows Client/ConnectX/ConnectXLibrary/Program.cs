using System;
using System.Windows.Forms;
using System.IO;

namespace ConnectXLibrary
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.Write(Directory.GetCurrentDirectory());

            Application.Run(new Menu());
        }
    }
}