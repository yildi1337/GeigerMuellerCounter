/*  
 *  This is the GUI software for visualizing the counts read from the
 *  Geiger-Mueller Counter via the USB interface program.
 *  
 *  Date: 2014-05-19
 *  Author: Phillip Durdaut
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeigerMuellerCounter
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
