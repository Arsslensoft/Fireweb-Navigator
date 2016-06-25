using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Fireweb
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,ex.StackTrace);
            }
        }
    }
}
