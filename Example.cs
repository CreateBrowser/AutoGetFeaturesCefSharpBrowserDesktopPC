# Example CefSharp Web Browser.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
namespace CefSharp_Web_Browser
public partial class Form1 : Form    
{     
public ChromiumWebBrowser CefSharp_Web_Browser;
public Form1()
{
InitializeComponent();
//  Text = "CefSharp Web Browser";
ShowIcon = false;
//// Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
     Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "#");
     Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "#");
     Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "#");
CefSettings settings = new CefSettings();            
settings.BrowserSubprocessPath = System.IO.Path.GetFullPath("CefSharp.BrowserSubprocess.exe");
Cef.Initialize(settings);
 /*
             ChromiumWebBrowser CefSharp_Web_Browser = new ChromiumWebBrowser("https://www.google.com/")
             {
                 BrowserSettings = { DefaultEncoding = "UTF-8", Databases = CefState.Disabled,  JavascriptCloseWindows = CefState.Default,  JavascriptDomPaste = CefState.Disabled, Javascript = CefState.Enabled, ApplicationCache = CefState.Disabled, FileAccessFromFileUrls = CefState.Enabled, TabToLinks = CefState.Default, UniversalAccessFromFileUrls = CefState.Default, WebSecurity = CefState.Enabled, LocalStorage = CefState.Disabled, ImageLoading = CefState.Default, TextAreaResize = CefState.Default, JavascriptAccessClipboard = CefState.Enabled, ImageShrinkStandaloneToFit = CefState.Default, Plugins = CefState.Enabled, WebGl = CefState.Disabled   }
             };

             CefSharp_Web_Browser.Dock = DockStyle.Fill;
             TabControl browserTabControl = new TabControl(); TabPage tpage = new TabPage();
             tpage.Text = " App CefSharp Web Browser ";  tpage.Show();  browserTabControl.Controls.Add(tpage);
         */
}
