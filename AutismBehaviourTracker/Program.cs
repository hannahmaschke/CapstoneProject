using System;
using System.Windows.Forms;

namespace AutismBehaviourTracker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // start the application with the main menu form
            Application.Run(new mainMenu());
        }
    }
}