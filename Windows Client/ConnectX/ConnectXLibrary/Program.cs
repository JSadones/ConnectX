using System;
using System.IO;
using System.Windows.Forms;

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