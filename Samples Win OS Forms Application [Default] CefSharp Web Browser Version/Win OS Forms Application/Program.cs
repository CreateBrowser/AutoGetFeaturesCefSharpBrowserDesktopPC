using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;


namespace Win_OS_Forms_Application
    {
    static class Program
        {

        /// private static Cef GetStart = new Cef();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
            {


            /// <summary>
            /// System.Environment.SetEnvironmentVariable
            /// </summary>
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"Developer.json");

            /// <summary>
            /// The main Google API keys
            /// </summary>
            /// Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
            Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "AIzaSyCwlkDuytn5j5gy3AoGfVGnEzwx7NL2t1Y");
            Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "111513960855-2eod2daojppibikjo6heaorbb9ck4o5g.apps.googleusercontent.com");
            Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "YgjULxxlfRwpMbn1JabGUIW9");

            /// <summary>
            /// EnableHighDPISupport
            /// </summary>
            Cef.EnableHighDPISupport();

            /// <summary>
            /// CefSettings
            /// </summary>
            CefSharp.WinForms.CefSettings settings = new CefSharp.WinForms.CefSettings();


            Cef.RunMessageLoop();
            
            /// <summary>
            /// ExecuteProcess
            /// </summary>
            Cef.ExecuteProcess();

            /// <summary>
            /// CefSettings
            /// </summary>
            /// Cef.GetPlugins();
            Cef.GetGlobalCookieManager();
            Cef.GetGlobalRequestContext();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            }
        }
    }
