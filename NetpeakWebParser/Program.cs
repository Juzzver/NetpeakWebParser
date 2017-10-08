using NetpeakWebParser.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetpeakWebParser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             DBWebPageInitializator db = new DBWebPageInitializator();
              db.InitializeDatabase(new WebPageContext());

            //  Database.SetInitializer(new DBWebPageInitializator());

          //  Database.SetInitializer<WebPageContext>(null);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
