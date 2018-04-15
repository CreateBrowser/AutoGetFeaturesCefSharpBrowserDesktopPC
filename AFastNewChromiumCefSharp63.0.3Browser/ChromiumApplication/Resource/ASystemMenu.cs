
// ChromeDevToolsSystemMenu

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using CefSharp;
using CefSharp.SchemeHandler;
using System.Windows.Forms;
using Process.NET.Native;
using CefSharp.WinForms;

namespace ChromiumApplication
{
    public class ASystemMenu
    {

        // P/Invoke constants
        public const int WM_SYSCOMMAND = 0x112;

        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;

        // ID for the Chrome dev tools item on the system menu
        public const int SYSMENU_CHROME_DEV_TOOLS = 0x1;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        public static void CreateSysMenu(Form frm)
        {
            // in your form override the OnHandleCreated function and call this method e.g:
            // protected override void OnHandleCreated(EventArgs e)
            // {
            //     ChromeDevToolsSystemMenu.CreateSysMenu(frm,e);
            // }

            // Get a handle to a copy of this form's system (window) menu
            var hSysMenu = GetSystemMenu(frm.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item        // You can customize the message instead dev tools
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_CHROME_DEV_TOOLS, "&Chrome Dev Tools"); }


        /// <summary>
        ///  Note that the <chromeBrowser> variable needs to be replaced by your own instance of  ChromiumWebBrowser
        /// </summary>



    }
}
