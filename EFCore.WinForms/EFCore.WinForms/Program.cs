using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace WF_ModerUI
{
    static class Program
    {
        public static string UrlApi = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var appSettings = ConfigurationManager.AppSettings;
            UrlApi = appSettings["UrlApi"] ?? "Not Found";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);    
            Application.Run(new frmLogin());
        }
    }
}
