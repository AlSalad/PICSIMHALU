using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroSimulator
{
    static class Program
    {
        //get list of commands
        private static string[] _cmdList;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var simForm = new SimulatorForm();
 

            Application.Run(simForm);
        }
    }
}
