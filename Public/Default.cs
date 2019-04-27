using CefSharp;
using CefSharp.Enums;
using CefSharp.Event;
using CefSharp.Handler;
using CefSharp.Internals;
using CefSharp.ModelBinding;
using CefSharp.SchemeHandler;
using CefSharp.Structs;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using ChromiumApplication;
using ChromiumApplication.ExampleMain.Example.Request;
///

///
using ChromiumApplication.Main;
using ChromiumApplication.Main.Callback;
using ChromiumApplication.Main.Handlers;
using ChromiumApplication.Main.Handler;
using ChromiumApplication.Main.Proxy;
using ChromiumApplication.Properties;
using ChromiumApplication.Main.Ultimate;

using MaterialSkin;
using MaterialSkin.Controls;
using MetroSet_UI.Forms;
using MetroFramework.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Media;
using System.Net;
using System.Net.Cache;
using System.Resources;
using System.Runtime;
using System.Security;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

/// using System.Runtime.InteropServices;


using Xilium.CefGlue;
using Xilium.CefGlue.Wrapper;
using ChromiumApplication.Main.Helper;
using CefSharp.RenderProcess;
using ChromiumApplication.Main.Handler.Extension;

///
/// 
/// <summary>
/// العربية 
/// </summary>
/// 
///






namespace CefSharp
{
    public partial class Form1 : Form
    {
        // c#  Cefsharp Winforms cookie | How to cookie  https://github.com/cefsharp/CefSharp/issues/826

        // c#  Cefsharp Winforms StatusBar

        /// <summary>
        ///     public partial class Form1 : MetroSetForm
        /// </summary>
        /// <summary>
        ///     public partial class Form1 : MaterialForm
        /// </summary>
        /// <summary>
        ///     public partial class Form1 : MetroForm
        /// </summary>

        /// <summary>
        ///      public partial class Form1 : Form 
        /// </summary>

        public ChromiumWebBrowser ChromiumWebBrowser;
        public ChromiumWebBrowser ChromiumBrowser;
        public ChromiumWebBrowser ChromeBrowser;
        public ChromiumWebBrowser Chromium;
        public ChromiumWebBrowser browser;
        public WebBrowser webNO;
        public CefValue NewGO;

        private Action<string, int?> openNewTab;
        private const string DefaultUrlForAddedTabs = "https://www.google.com";

        // Default to a small increment:
        private const double ZoomIncrement = 0.10;

        private bool multiThreadedMessageLoopEnabled;


        public const string BaseUrl = "https://www.";
        public const string DefaultUrl = BaseUrl + "google.com.eg/";
        //public const string DefaultUrl = BaseUrl + "/other_tests.html";
       // public const string PluginsTestUrl = BaseUrl + "/plugins.html";
        public const string TestResourceUrl = "http://test/resource/load";

 public Form1() { InitializeComponent();

            WinForms.CefSettings settings = new WinForms.CefSettings();

            ///
            ///    Start Browser
            /// 

            // Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
            Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "AIzaSyBS-qjz0jmK4jvZy06Rq4DLs0_AITqo7lw");
            Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "888034971568-kmdju8hjiem3mqqi3kgjmals6p0l0te4.apps.googleusercontent.com");
            Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "6fa_ZYlY8KxDd_KDOz1SdENV");


            CefSharpSettings.LegacyJavascriptBindingEnabled = true; //true
            CefSharpSettings.ConcurrentTaskExecution = true; //true
            CefSharpSettings.FocusedNodeChangedEnabled = true;
            CefSharpSettings.WcfEnabled = true; //true


            // AcceptLanguageList
            settings.AcceptLanguageList = "en-US,ru,ar,zh-CN,zh-TW,ko,ja,en-GB";
            
            Cef.Initialize(settings);

           ///
           ///
           ///

            Text = "CefSharp Chromium Web Browser";
            toolStripTextBoxAddress.Text = "chrome://version";
            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text) { BrowserSettings =
            { DefaultEncoding = "UTF-8", Databases = CefState.Disabled, JavascriptDomPaste = CefState.Disabled, Javascript = CefState.Enabled, ApplicationCache = CefState.Disabled, FileAccessFromFileUrls = CefState.Enabled, TabToLinks = CefState.Default, UniversalAccessFromFileUrls = CefState.Default, WebSecurity = CefState.Enabled, LocalStorage = CefState.Disabled, ImageLoading = CefState.Default, TextAreaResize = CefState.Default, JavascriptAccessClipboard = CefState.Enabled, ImageShrinkStandaloneToFit = CefState.Default, Plugins = CefState.Enabled, WebGl = CefState.Disabled } };

            ChromiumWebBrowser.Dock = DockStyle.Fill;
           /// ChromiumWebBrowser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
           /// ChromiumWebBrowser.LoadingStateChanged += OnLoadingStateChanged;

            ChromiumWebBrowser.TitleChanged += OnBrowserTitleChanged;
            ChromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;
            ChromiumWebBrowser.LoadError += BrowserLoadError;
            ChromiumWebBrowser.StatusMessage += OnStatusMessageChanged;

            // ChromiumWebBrowser.StatusMessage += OnBrowserStatusMessage;
            // ChromiumWebBrowser.LoadingStateChanged += BrowserLoadingStateChanged;


            TabPage tpage = new TabPage(); tpage.Text = " Ultimate Browser Version "; tpage.Show(); browserTabControl.Controls.Add(tpage); ChromiumWebBrowser.Parent = tpage;
            ChromiumWebBrowser.FocusHandler = null;

            /* Customize Handler */
            ChromiumWebBrowser.DownloadHandler = new ChromiumApplication.Main.Handler.DownloadHandler();
            ChromiumWebBrowser.DisplayHandler = new ChromiumApplication.Main.Handler.DisplayHandler();
            ChromiumWebBrowser.MenuHandler = new ChromiumApplication.Main.Handler.Example.MenuHandler();
            ChromiumWebBrowser.RequestHandler = new RequestHandler();
            ChromiumWebBrowser.RequestHandler = new WinFormsRequestHandler(openNewTab);
          
            /* Customize Handler */
            ChromiumWebBrowser.LifeSpanHandler = new ChromiumApplication.Main.Handler.LifeSpanHandler();
              ChromiumWebBrowser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            /// ChromiumWebBrowser.KeyboardHandler = new KeyboardHandler();
            ///  ChromiumWebBrowser.MenuHandler = new CustomMenuHandler();
            /// ChromiumWebBrowser.JsDialogHandler = new ChromiumApplication.Main.Handlers.JsDialogHandler();

            RequestContextSettings requestContextSettings = new RequestContextSettings();
            requestContextSettings.AcceptLanguageList = "en-US,ru,ar,zh-CN,zh-TW,ko,ja,en-GB";
            requestContextSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";
            requestContextSettings.PersistSessionCookies = true;
            requestContextSettings.PersistUserPreferences = true;
            requestContextSettings.IgnoreCertificateErrors = true;
            requestContextSettings.EnableNetSecurityExpiration = true;
            ChromiumWebBrowser.RequestContext = new  RequestContext(requestContextSettings);



            ChromiumWebBrowser.JavascriptObjectRepository.Register("bound", new BoundObject(), isAsync: false, options: BindingOptions.DefaultBinder);
            ChromiumWebBrowser.JavascriptObjectRepository.Register("boundAsync", new BoundObject.AsyncBoundObject(), isAsync: true, options: BindingOptions.DefaultBinder);

            //If you call CefSharp.BindObjectAsync in javascript and pass in the name of an object which is not yet
            //bound, then ResolveObject will be called, you can then register it
            ChromiumWebBrowser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                if (e.ObjectName == "boundAsync2")
                {
                    repo.Register("boundAsync2", new BoundObject.AsyncBoundObject(), isAsync: true, options: BindingOptions.DefaultBinder);
                }
            };
            /// ChromiumWebBrowser.CreateControl();
            settings.RegisterExtension(new V8Extension("showModalDialog", Resources.showModalDialog)); ///CefExtension


            //   settings.RegisterExtension(new CefExtension("showModalDialog", Resources.showModalDialog)); ///CefExtension

            GETExample.RegisterTestResources(ChromiumWebBrowser);
           // ChromiumWebBrowser.RegisterJsObject("bound", new BoundObject());
           // BindingOptions options = null;
           // ChromiumWebBrowser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(), true, options);

            // ChromiumWebBrowser.JsDialogHandler = new ChromiumApplication.Main.Handlers.JsDialogHandler();
            // ChromiumWebBrowser.KeyboardHandler = new KeyboardHandler();


            // ChromiumWebBrowser.DisplayHandler = new ChromiumApplication.Main.Handler.DisplayHandler();
            // Load += Form1_Load;

            //Only perform layout when control has completly finished resizing
            /// ResizeBegin += (s, e) => SuspendLayout();
            ///  ResizeEnd += (s, e) => ResumeLayout(true);

            this.multiThreadedMessageLoopEnabled = multiThreadedMessageLoopEnabled;

            //    ChromiumWebBrowser.NewTabClicked += control_NewTabClicked;
            //  uiBrowserTabControl.SelectedIndexChange += uiBrowserTabControl_SelectedIndexChange;
            // uiBrowserTabControl.Closed += UiBrowserTabControl_Closed;
          //// CefExample.RegisterTestResources(ChromiumWebBrowser);


            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
