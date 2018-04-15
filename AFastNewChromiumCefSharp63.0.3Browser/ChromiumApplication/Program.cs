using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// using System.Runtime;
using ChromiumApplication;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.Structs;
using CefSharp.SchemeHandler;
using CefSharp.Internals;
using CefSharp.Handler;



namespace CefSharp
{

    static class Program
    {
       // private static string url;

        //   public static bool PersistSessionCookies { get; private set; }
        ////      private CefSettings settings;

        //   public static object CachePath { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            Cef.GetPlugins(); Cef.GetGlobalRequestContext(); // Cef.GetGlobalCookieManager();
            Cef.ExecuteProcess();  CefSettings settings = new CefSettings();
            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();




         

            //   settings.CachePath = "GPUCache/GO"
            //      Cef.Initialize(new CefSettings { CachePath = "GPUCache/Cache", PersistSessionCookies = true });
            //     Cef.GetGlobalCookieManager().SetStoragePath("GPUCache/Cookie", true);

            //  Cef.Initialize(new CefSettings { CachePath = "MyCachePath", PersistSessionCookies = true });
            //  Cef.GetGlobalCookieManager().SetStoragePath("MyCookiePath", true);






            Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form1());

        }    }    }