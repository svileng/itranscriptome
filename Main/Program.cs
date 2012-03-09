using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExperimentsManager.Views;
using ExperimentsManager.Controllers;

namespace ExperimentsManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm(new ExperimentsController());

            Application.Run(mainForm);
        }
    }
}
