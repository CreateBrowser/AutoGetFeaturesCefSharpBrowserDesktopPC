using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CefSharp
{
    class CefCustomObject
    {


        // Declare a local instance of chromium and the main form in order to execute things from here in the main thread
        private static ChromiumWebBrowser _instanceBrowser = null;
        // The form class needs to be changed according to yours
        private static Form1 _instanceMainForm = null;

        public CefCustomObject(ChromiumWebBrowser originalBrowser, Form1 mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;

        }

        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

       


    }
}
