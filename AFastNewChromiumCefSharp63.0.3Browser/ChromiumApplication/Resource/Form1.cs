using CefSharp;
using CefSharp.Internals;
using CefSharp.Handler;
using CefSharp.Structs;
using CefSharp.ModelBinding;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Management;
using System.Media;
using System.Security;
using System.Web;
using System.Xml;
using System.Resources;
using System.Net.Cache;
using System.Diagnostics;
using Microsoft.VisualBasic;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroSet_UI.Forms;

// Xilium
// using Xilium.CefGlue;

using ChromiumApplication;
using ChromiumApplication.Properties;
using CefSharp.WinForms.Internals;
using MetroSet_UI.Interfaces;
using System.Security.Policy;
using System.Security.Principal;
using System.Globalization;

/// <summary>
/// العربية
/// </summary>

namespace CefSharp
{
    public partial class Form1 : Form
    {

        /// <summary>
        ///     public partial class Form1 : MaterialForm
        /// </summary>

        /// <summary>
        ///     public partial class Form1 : MetroSetForm
        /// </summary>

        /// <summary>
        ///      public partial class Form1 : Form 
        /// </summary>










        public Form1()
        {
            InitializeComponent();

            // Start the browser after initialize global component
            InitializeChromium();

            // Register an object in javascript named "cefCustomObject" with function of the CefCustomObject class :3
            // CefSharp V53.0.1 - CefCustomObject.cs //  
            //  chromeBrowser.RegisterJsObject("cefCustomObject", new CefCustomObject(chromeBrowser, this));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        /// <summary>
        /// GO
        /// </summary>
        public class DownloadHandler : IDownloadHandler
        {
            public event EventHandler<DownloadItem> OnBeforeDownloadFired;

            public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

            public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
            {
                var handler = OnBeforeDownloadFired;

                if (handler != null)
                {
                    handler(this, downloadItem);
                }

                if (!callback.IsDisposed)
                {
                    using (callback)
                    {
                        callback.Continue(downloadItem.SuggestedFileName, showDialog: true);

                    }
                }
            }

            public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
            {
                var handler = OnDownloadUpdatedFired;
                if (handler != null)
                {
                    handler(this, downloadItem);
                }
            }
        }

        /// <summary>
        /// GO
        /// </summary>

        public static void Init(bool osr, bool multiThreadedMessageLoop, IBrowserProcessHandler browserProcessHandler)
        {
            // Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
            // Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "");
            // Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "");
            // Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "");



            // Widevine CDM registration - pass in directory where Widevine CDM binaries and manifest.json are located.
            // For more information on support for DRM content with Widevine see: https://github.com/cefsharp/CefSharp/issues/1934
            //Cef.RegisterWidevineCdm(@".\WidevineCdm");
            //Chromium Command Line args
            //http://peter.sh/experiments/chromium-command-line-switches/
            //NOTE: Not all relevant in relation to `CefSharp`, use for reference purposes only.
            //The location where cache data will be stored on disk. If empty an in-memory cache will be used for some features and a temporary disk cache for others.
            //HTML5 databases such as localStorage will only persist across sessions if a cache path is specified. 

            // var settings = new CefSettings();
            // settings.CachePath = "cache";
            //settings.UserAgent = "CefSharp Browser" + Cef.CefSharpVersion; // Example User Agent
            //  settings.CefCommandLineArgs.Add("renderer-process-limit", "1");
            //settings.CefCommandLineArgs.Add("renderer-startup-dialog", "1");
            //   settings.CefCommandLineArgs.Add("enable-media-stream", "1"); //Enable WebRTC
            //settings.CefCommandLineArgs.Add("no-proxy-server", "1"); //Don't use a proxy server, always make direct connections. Overrides any other proxy server flags that are passed.
            //settings.CefCommandLineArgs.Add("debug-plugin-loading", "1"); //Dumps extra logging about plugin loading to the log file.
            //settings.CefCommandLineArgs.Add("disable-plugins-discovery", "1"); //Disable discovering third-party plugins. Effectively loading only ones shipped with the browser plus third-party ones as specified by --extra-plugin-dir and --load-plugin switches
            //settings.CefCommandLineArgs.Add("enable-system-flash", "1"); //Automatically discovered and load a system-wide installation of Pepper Flash.
            //settings.CefCommandLineArgs.Add("allow-running-insecure-content", "1"); //By default, an https page cannot run JavaScript, CSS or plugins from http URLs. This provides an override to get the old insecure behavior. Only available in 47 and above.

            // settings.CefCommandLineArgs.Add("enable-logging", "1"); //Enable Logging for the Renderer process (will open with a cmd prompt and output debug messages - use in conjunction with setting LogSeverity = LogSeverity.Verbose;)
            //settings.LogSeverity = LogSeverity.Verbose; // Needed for enable-logging to output messages

            //settings.CefCommandLineArgs.Add("disable-extensions", "1"); //Extension support can be disabled
            //settings.CefCommandLineArgs.Add("disable-pdf-extension", "1"); //The PDF extension specifically can be disabled

            //Load the pepper flash player that comes with Google Chrome - may be possible to load these values from the registry and query the dll for it's version info (Step 2 not strictly required it seems)
            //settings.CefCommandLineArgs.Add("ppapi-flash-path", @"C:\Program Files (x86)\Google\Chrome\Application\47.0.2526.106\PepperFlash\pepflashplayer.dll"); //Load a specific pepper flash version (Step 1 of 2)
            //settings.CefCommandLineArgs.Add("ppapi-flash-version", "20.0.0.228"); //Load a specific pepper flash version (Step 2 of 2)

            //NOTE: For OSR best performance you should run with GPU disabled:
            // `--disable-gpu --disable-gpu-compositing --enable-begin-frame-scheduling`
            // (you'll loose WebGL support but gain increased FPS and reduced CPU usage).
            // http://magpcss.org/ceforum/viewtopic.php?f=6&t=13271#p27075
            // https://bitbucket.org/chromiumembedded/cef/commits/e3c1d8632eb43c1c2793d71639f3f5695696a5e8

            //NOTE: The following function will set all three params
            //settings.SetOffScreenRenderingBestPerformanceArgs();
            //settings.CefCommandLineArgs.Add("disable-gpu", "1");
            //settings.CefCommandLineArgs.Add("disable-gpu-compositing", "1");
            //settings.CefCommandLineArgs.Add("enable-begin-frame-scheduling", "1");

            //settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1"); //Disable Vsync

            //Disables the DirectWrite font rendering system on windows.
            //Possibly useful when experiencing blury fonts.
            //settings.CefCommandLineArgs.Add("disable-direct-write", "1");





        }

        ////      private CefSettings settings;
        public ChromiumWebBrowser ChromiumWebBrowser;
        public ChromiumWebBrowser ChromiumBrowser;
        public ChromiumWebBrowser ChromeBrowser;
        public ChromiumWebBrowser Chromium;
        public ChromiumWebBrowser browser;

        void OnFullscreenModeChange(IWebBrowser browserControl, IBrowser ChromiumWebBrowser, bool fullscreen) { }
        void OnFaviconUrlChange(IWebBrowser browserControl, IBrowser ChromiumWebBrowser, IList<string> urls) { }
        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e) { this.Invoke(new MethodInvoker(() => { toolStripTextBoxAddress.Text = e.Address; })); }
        private void Chrome_TitleChanged(object sender, TitleChangedEventArgs e) { this.Invoke(new MethodInvoker(() => { browserTabControl.SelectedTab.Text = e.Title; })); }

        public static String favXml = "favorits.xml", linksXml = "links.xml";
        String settingsXml = "settings.xml", historyXml = "history.xml";
        List<String> urls = new List<String>();
        XmlDocument settings = new XmlDocument();
        String homePage;
        CultureInfo currentCulture;


        public void InitializeChromium()
        {

           
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);


           


            toolStripTextBoxAddress.Text = "file:///Resources/other_tests.html";
             ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text)
            { BrowserSettings = { DefaultEncoding = "UTF-8", FileAccessFromFileUrls = CefState.Enabled, TabToLinks = CefState.Default, UniversalAccessFromFileUrls = CefState.Default, Javascript = CefState.Default, Databases = CefState.Enabled, WebSecurity = CefState.Enabled, LocalStorage = CefState.Enabled, ImageLoading = CefState.Default, ApplicationCache = CefState.Enabled, Plugins = CefState.Enabled, WebGl = CefState.Disabled } };
            ChromiumWebBrowser.Dock = DockStyle.Fill;
            ChromiumWebBrowser.AddressChanged += Chrome_AddressChanged; ChromiumWebBrowser.TitleChanged += Chrome_TitleChanged;
            TabPage tpage = new TabPage(); tpage.Text = "New Tab CN";
            tpage.Show();
            browserTabControl.Controls.Add(tpage);
            ChromiumWebBrowser.Parent = tpage;

            // Download Handler 
            ChromiumWebBrowser.DownloadHandler = new DownloadHandler();
            // Download Handler  

            //  ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text)
            //              ChromiumWebBrowser.RegisterJsObject("bound", new BoundObject());
            // ChromiumWebBrowser.RequestHandler = new MyRequestHandler("actual_userName", "actual_password");
            // Cef.Initialize(new CefSettings() // { CachePath = "Cache" + account.id });


            var contextSettings = new RequestContextSettings();
            contextSettings.CachePath = "GPUCache/cachePath";
            browserSettings = new BrowserSettings();
            requestContextSettings = new RequestContextSettings { CachePath = @"GPUCache\GO\" + account.id };
            ChromiumWebBrowser.RequestContext = new RequestContext(new RequestContextSettings()
            {
                CachePath = System.IO.Directory.GetCurrentDirectory() + @"\GPUCache\GO" + DateTime.Now.ToLongTimeString()
            });


            settings.CachePath = "GPUCache/GO" + account.id;
            settings.LocalesDirPath = @"locales\"; settings.Locale = "ZH-CN"; settings.UserDataPath = @"UserData\";
            settings.LocalesDirPath = Application.StartupPath + @"\locales"; settings.Locale = "jp";
            settings.PersistSessionCookies = false;      //false
            settings.PersistUserPreferences = true;     //true and false
            settings.IgnoreCertificateErrors = true;    //true
            settings.MultiThreadedMessageLoop = true;   //true 
            settings.FocusedNodeChangedEnabled = true;  //true
            settings.WindowlessRenderingEnabled = true; //true
            settings.CommandLineArgsDisabled = false;    //false
            settings.LogSeverity = LogSeverity.Verbose;
            settings = new CefSettings { RemoteDebuggingPort = 8088 };
            settings.ResourcesDirPath = System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase).LocalPath);

            // CefSharpSchemeHandlerFactory
            //  settings.RegisterScheme(new CefCustomScheme { SchemeName = "custom", SchemeHandlerFactory = new CefSharpSchemeHandlerFactory() });
            //  settings.RegisterScheme(new CefCustomScheme { SchemeName = CefSharpSchemeHandlerFactory.SchemeNameTest, SchemeHandlerFactory = new CefSharpSchemeHandlerFactory(), IsSecure = true });
            // settings.RegisterScheme(new CefCustomScheme { SchemeName = "https", SchemeHandlerFactory = new CefSharpSchemeHandlerFactory(), DomainName = "cefsharp.com", IsSecure = true });
            // ChromiumWebBrowser.RequestContext = new RequestContext(); requestContextSettings = new RequestContextSettings { CachePath = cachePath }; ChromiumWebBrowser.RequestContext = new RequestContext(new CustomRequestContextHandler());

            //   settings.LogFile = "GO.log";
            // var
            // settings.BrowserSubprocessPath = "CefSharp.BrowserSubprocess.exe";
            // settings.MultiThreadedMessageLoop = CefRuntime.Platform == CefRuntimePlatform.Windows;
            // settings.ReleaseDCheckEnabled = true;
            //NOTE: Set this before any calls to Cef.Initialize to specify a proxy with username and password
            //One set this cannot be changed at runtime. If you need to change the proxy at runtime (dynamically) then
            //see https://github.com/cefsharp/CefSharp/wiki/General-Usage#proxy-resolution
            //  Proxy 
            //Legacy Binding Behaviour doesn't work for cross-site navigation (navigating to a different domain)
            //See issue https://github.com/cefsharp/CefSharp/issues/1203 for details
            CefSharpSettings.LegacyJavascriptBindingEnabled = true; //true
            CefSharpSettings.ConcurrentTaskExecution = true; //true
            CefSharpSettings.WcfEnabled = true; //true
                                                // CefSharpSettings.Proxy = new ProxyOptions(ip: "localhost", port: "80", username: "CefSharp", password: "CefSharp");            
                                                // Cef.AddCrossOriginWhitelistEntry(BaseUrl, "https", "cefsharp.com", true); //false
                                                // CefSharp.BrowserSettings browser_setting = new CefSharp.BrowserSettings();
                                                // browser_setting.FileAccessFromFileUrlsAllowed = true; browser_setting.UniversalAccessFromFileUrlsAllowed = true;browser_setting.WebSecurityDisabled = true;
                                                // ChromiumWebBrowser.BrowserSettings = browser_setting;

            // Allow the use of local resources in the browser
            // BrowserSettings browserSettings = new BrowserSettings(); browserSettings.FileAccessFromFileUrls = CefState.Enabled; browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            // ChromiumWebBrowser.BrowserSettings = browserSettings;
            // ChromiumWebBrowser.Parent = tabControl1.SelectedTab;
            // this.metroSetTabControl1.Controls.Add(chromeBrowser);
            // this.materialTabSelector1.Controls.Add(chromeBrowser);
            // this.materialTabSelector1.Controls.Add(chromeBrowser);
            // ChromiumWebBrowser.SetAsPopup();
            // Get Settings 
            // settings.LocalesDirPath = "locales";  settings.Locale = "ar";
            // settings.LocalesDirPath = Application.StartupPath + "\\locales"; 
            // settings.LocalesDirPath = Application.StartupPath + "locales";  settings.Locale = "jp"; 



            // Initialize cef with the provided settings
            // Create a browser component
            // CefSettings settingsBrowser = new CefSettings(); settingsBrowser.Locale = "ar";  Cef.Initialize(settingsBrowser);
            // chromeBrowser.ExecuteScriptAsync("Local Settings/User Data/CefSharpBrowserGPU/Cache");
            // By default CEF uses an in memory cache, to save cached data e.g. passwords you need to specify a cache path
            // NOTE: The executing user must have sufficent privileges to write to this folder.
            // settings.CachePath = "cache";
            // settings.CachePath = "Local/Settings/UserData/CefSharpBrowserGPU/Cache";


            // txtUrl.Text = "file:///Resources/Home.html"; chromeBrowser = new ChromiumWebBrowser(txtUrl.Text);
            // chromeBrowser = new ChromiumWebBrowser("chrome://version");
            // chromeBrowser = new ChromiumWebBrowser("chrome://version"){ BrowserSettings = { DefaultEncoding = "UTF-8", WebGl = CefState.Disabled }};

            // Add it to the form and fill it to the form window.
            // this.Controls.Add(chromeBrowser);
            //   this.materialTabControl1.Controls.Add(chromeBrowser); 
            //this.#.Controls.Add(Browser);
            //  materialTabControl1.Controls.Add(chromeBrowser);
            // toolStripContainer1.ContentPanel.Controls.Add(chromeBrowser); 
            // materialTabControl1
            //  this.pContainer.Controls.Add();
            //  chromeBrowser.Dock = DockStyle.Fill;
            //  chrome.AddressChanged += Chrome_AddressChanged;
            //  Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
            //  Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "AIzaSyBS-qjz0jmK4jvZy06Rq4DLs0_AITqo7lw");
            // Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "888034971568-kmdju8hjiem3mqqi3kgjmals6p0l0te4.apps.googleusercontent.com");
            // Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "6fa_ZYlY8KxDd_KDOz1SdENV");


            // Command Line Arguments
            settings.CefCommandLineArgs.Add("renderer-process-limit", "1");
            settings.CefCommandLineArgs.Add("persist_session_cookies", "1");
            // Enable
            settings.CefCommandLineArgs.Add("enable-system", "1");
            // settings.CefCommandLineArgs.Add("enable-system-media", "1");
            // settings.CefCommandLineArgs.Add("enable-system-plugin", "1");
            // settings.CefCommandLineArgs.Add("enable-system-flash", "1");
            settings.CefCommandLineArgs.Add("enable-extensions", "1");
            //  settings.CefCommandLineArgs.Add("enable-browser-side-navigation", "1");

            // settings.CefCommandLineArgs.Add("disable-browser-side-navigation", "1");

            // Enable WebRTC
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");

            //Extension support can be disabled
            settings.CefCommandLineArgs.Add("disable-pdf-extension", "1");

            //The PDF extension specifically can be disabled
            // Disables the DirectWrite font rendering system on windows.
            // Possibly useful when experiencing blury fonts.
            //   settings.CefCommandLineArgs.Add("disable-web-security", "disable-web-security");
            settings.CefCommandLineArgs.Add("disable-web-security", "1");
            //Disable GPU Acceleration
            settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
            settings.CefCommandLineArgs.Add("disable-gpu", "1");

            // Proxy Stuff More Refinement is needed for reaching local IP's
            // Don't use a proxy server, always make direct connections. Overrides any other proxy server flags that are passed.
            // Slightly improves Cef initialize time as it won't attempt to resolve a proxy
            settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            settings.CefCommandLineArgs.Add("proxy-auto-detect", "1");
            settings.CefCommandLineArgs.Add("winhttp-proxy-resolver", "1");

            // Disable Flash | settings.CefCommandLineArgs.Add("disable-system-flash", "1"); settings.CefCommandLineArgs.Add("ppapi-flash-version", "20.0.0.306"); settings.CefCommandLineArgs.Add("ppapi-flash-path", "/Resources/PepperFlash/pepflashplayer.dll");

            ////  Perform <Unhandled Exception>


            //  Perform <Unhandled Exception>
            //    CefRuntime.AddWebPluginPath(@"C:\Program Files (x86)\VideoLAN\VLC\npvlc.dll");
            //    CefRuntime.AddWebPluginDirectory(@"C:\Program Files (x86)\VideoLAN\VLC");
            //    CefRuntime.AddWebPluginPath(@"E:\Program Files\Player\VideoLAN\32-bit\4.0.0\npvlc.dll");
            //    CefRuntime.AddWebPluginDirectory(@"E:\Program Files\Player\VideoLAN\32-bit\4.0.0");
            //     CefRuntime.AddWebPluginDirectory(@"C:\Program Files\Microsoft Silverlight\5.1.20513.0\");
            //     CefRuntime.AddWebPluginDirectory(@"C:\Program Files\Adobe\Reader 9.0\Reader\Browser");
            //     CefRuntime.AddWebPluginDirectory(@"C:\Windows\system32\Macromed\Flash"); CefRuntime.RefreshWebPlugins();
            //  Perform <Unhandled Exception>

        }

        private void ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ApplicationRestart(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CEFNowBack(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Back();
        }

        private void CEFNowForward(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Forward();
        }

        private void CEFNowExit(object sender, EventArgs e)
        {
            Cef.Shutdown();
            Close();
        }

        private void CEFNewUndo(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Undo();
        }

        private void CEFOldRedo(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Redo();
        }

        private void CEFNowCut(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Cut();
        }

        private void CEFNowCopy(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Copy();
        }

        private void CEFNowPaste(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Paste();
        }

        private void CEFNowDelete(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Delete();
        }

        private void CEFNowSelect(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Select();
        }
        private void CEFNowSelectAll(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.SelectAll();
        }


        private void CEFNowStop(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Stop();
        }

        private void CEFNowReload(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Reload();
        }

        private void CEFNowRefresh(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Refresh();
        }

        private void CEFNowShowDevTools(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.ShowDevTools();
        }

        private void CEFNowCloseDevTools(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.CloseDevTools();
        }

        private void CEFNowGithub(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://github.com");
        }
        private void CEFNowGoogle(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://www.google.com");
        }

        private void CEFNowYouTube(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://www.youtube.com");
        }

        private void CEFNowYahooMail(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://mail.yahoo.com");
        }

        private void CEFNowFacebookPC(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://www.facebook.com");
        }

        private void CEFNowFacebookMobile(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://m.facebook.com");
        }

        private void CEFNowCefSharpVersion(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("chrome://chrome-urls/");
        }
        private void CefGPU(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("chrome://gpu/");
        }
        private void CEFNowGoogleTranslate(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://translate.google.com");
        }

        private void CEFNowGoogleTranslateToolkit(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://translate.google.com/toolkit");
        }

        private void BrowserUndo(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (toolStripTextBoxAddress.CanUndo)
                ChromiumWebBrowser.Undo();
        }

        private void BrowserRedo(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Redo();
        }

        private void BrowserCut(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Cut();
        }

        private void BrowserCopy(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Copy();
        }

        private void BrowserPaste(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;

            ChromiumWebBrowser.Paste();
        }

        private void BrowserDelete(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Delete();
        }

        private void BrowserSelect(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser.CanSelect)
                ChromiumWebBrowser.Select();
        }
        private void BrowserSelectAll(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.SelectAll();
        }


        private void DefaultCustomHome(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            //  chromeBrowser.Load("file:///Resources/Home.html");
            //  chromeBrowser.Load("http://test");
            //  ChromiumWebBrowser.Load("file:///Resources/other_tests.html");
            ChromiumWebBrowser.Load("file:///Resources/other_tests.html");

            //  ChromiumWebBrowser.Load("localfolder://cefsharp/");
            //     ChromiumWebBrowser.Load("localfolder://cefsharp/Resources/other_tests.html");
            //  ChromiumWebBrowser.Load("custom://cefsharp");
            //  ChromiumWebBrowser.Load("http://localhost//test//");
            //  ChromiumWebBrowser.Load("custom://cefsharp/home.html");
            //  ChromiumWebBrowser.Load("custom://cefsharp/Resources/home.html");
            //  chromeBrowser.Load("file:///Resources/Home.html");
            // ChromiumWebBrowser.Load("http://test/Resources/Home.html");
            //  chromeBrowser.Load("http://test/resource/");
            //  chromeBrowser.LoadHtml(File.ReadAllText(@"file:///Resources/Home.html"), @"file:///Resources/Home.html");
        }

        private void LocalDiskC(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("C:/");
        }

        private void LocalDiskD(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("D:/");
        }

        private void LocalDiskE(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("E:/");
        }

        private void LocalDiskF(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("F:/");
        }

        private void CEFNowDownloads(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("file:///Resources/storage/downloads.html");
        }

        private void WindowsMediaPlayer(object sender, EventArgs e)
        {
            WindowsMediaPlayer a = new WindowsMediaPlayer();
            a.Show();
        }

        private void CefApplication(object sender, EventArgs e)
        {


            addNewTab();
            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;

        }

        private void localhost(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("http://localhost/");
            //  ChromiumWebBrowser.Load("http://127.0.0.1");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser.CanGoBack)
                ChromiumWebBrowser.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser.CanGoForward)
                ChromiumWebBrowser.Forward();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser != null)
                ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);
        }
        private void GetBookmarks(object sender, EventArgs e)
        {
            BookmarksForm a = new BookmarksForm();
            a.Show();
        }

        private void RemovesAllTabPages(object sender, EventArgs e)
        {// Removes all the tabs: 
            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            browserTabControl.TabPages.Clear();
        }

        private void RemoveTabPage(object sender, EventArgs e)
        {// Removes the selected tab:  
            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            browserTabControl.TabPages.Remove(browserTabControl.SelectedTab);
        }

        private void NewTabPage(object sender, EventArgs e)
        {// New TabPage The Tabs:
            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            // string title = "New Tab " + (tabControl1.TabCount + 1).ToString(); TabPage myTabPage = new TabPage(title); tabControl1.TabPages.Add(myTabPage);
        }

        // cefsharp Bookmarks tab


        // https://stackoverflow.com/questions/45731714/how-to-implement-new-tab-in-cefsharp-with-correct-address-and-title-change

        // new tab function

        private void toolStripTextBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
                if (ChromiumWebBrowser != null)
                {
                    this.ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);
                }
            }
        }
        private void toolStripTextBoxAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(toolStripTextBoxAddress.Text))
                {
                    if (!toolStripTextBoxAddress.Text.Contains("."))
                    {
                        //   ChromiumWebBrowser.Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                    }
                    else
                    {
                        // ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load(toolStripTextBoxAddress.Text);
                    }
                }
            }
        }
        public void addNewTab()
        {
            //   ChromiumWebBrowser ChromiumWebBrowser = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            //  ChromiumWebBrowser ChromiumWebBrowser = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            //  ChromiumWebBrowser.TabIndex = 0;
            //    tabControl1.SelectTab(tabControl1.TabCount - 1);

            TabPage tpage = new TabPage();
            tpage.Text = "New Tab";
            browserTabControl.Controls.Add(tpage);
            toolStripTextBoxAddress.Text = "about:blank";
            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text);
            ChromiumWebBrowser.Parent = tpage;
            ChromiumWebBrowser.Dock = DockStyle.Fill;
            ChromiumWebBrowser.AddressChanged += Chrome_AddressChanged;
            ChromiumWebBrowser.TitleChanged += Chrome_TitleChanged;
        }

        // get current browser
        private ChromiumWebBrowser getCurrentBrowser() { return (ChromiumWebBrowser)browserTabControl.SelectedTab.Controls[0]; }

        private void FaviconTab(object sender, EventArgs e)
        {
            //  ChromiumWebBrowser = tabControl1.SelectedTab.Controls[ - 0] as ChromiumWebBrowser;
            ChromiumWebBrowser currentBrowser = getCurrentBrowser(); toolStripTextBoxAddress.Text = currentBrowser.Address;
        }
        private void GetSource(object sender, EventArgs e)
        {

            browser.GetMainFrame().LoadUrl("about:blank");

            //  ChromiumWebBrowser.GetBrowser().MainFrame.ViewSource();
        }

        private void vikiNew(object sender, EventArgs e)
        {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Load("https://www.viki.com/sign_in");
        }
        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {

            newBrowser = null;
            // open popup in new tab!
            newBrowser = myForm.NewPage(targetUrl);
            targetUrl = "https://www.airtel.in/account/AuthApp/GoogleLogin";
            return true;

        }

        /// <summary>
        ////  public ChromiumWebBrowser chrome;
        public string SetPreference { get; private set; }
        public string cachePath { get; private set; }
        public object context { get; private set; }
        public static bool IsInitialized { get; }
        public static bool CrashReportingEnabled { get; }
        public static string ChromiumVersion { get; }
        public static string CefCommitHash { get; }
        public static BindingOptions DefaultBinder { get; }
        public IBinder Binder { get; set; }
        public IBrowser Browser { get; }
        public static TaskFactory FileThreadTaskFactory { get; set; }
        public static TaskFactory IOThreadTaskFactory { get; set; }
        public static TaskFactory UIThreadTaskFactory { get; set; }
        public virtual CefState Plugins { get; set; }
        public virtual CefState WebGl { get; set; }
        public virtual CefState Databases { get; set; }
        public virtual string AcceptLanguageList { get; set; }
        public virtual CefState ApplicationCache { get; set; }
        public bool CamelCaseJavascriptNames { get; set; }
        public string FilePath { get; }
        public string MimeType { get; set; }
        public string Address { get; }
        public virtual IDictionary<string, string> CefCommandLineArgs { get; }
        public IEnumerable<CefCustomScheme> CefCustomSchemes { get; }
        public virtual IEnumerable<CefExtension> Extensions { get; }
        public string Locale { get; set; }
        public string LocalesDirPath { get; set; }
        public string ResourcesDirPath { get; set; }
        public string JavascriptFlags { get; set; }
        public string AcceptLanguage { get; private set; }
        public object CommandLine { get; private set; }
        public object cefSettings { get; private set; }
        public string BaseUrl { get; private set; }
        public CefSharpSchemeHandlerFactory SchemeHandlerFactory { get; private set; }
        public EventHandler<FrameLoadStartEventArgs> chromeBrowser_FrameLoadStart { get; private set; }
        public bool DebuggingSubProcess { get; private set; }
        public IBrowserProcessHandler browserProcessHandler { get; private set; }
        public object AddressChanged { get; private set; }
        public object LoadingStateChanged { get; private set; }
        public object StatusMessage { get; private set; }
        public object BrowserInitialized { get; private set; }
        public object ConsoleMessage { get; private set; }
        public object FrameLoadEnd { get; private set; }
        public object FrameLoadStart { get; private set; }
        public object LoadError { get; private set; }
        public object CachePath { get; private set; }
        public object Tools { get; private set; }
        public object newtab { get; private set; }
        public EventHandler<TitleChangedEventArgs> OnBrowserTitleChanged { get; private set; }
        public object response { get; private set; }
        public object Account { get; private set; }
        public RequestContextSettings requestContextSettings { get; private set; }
        public BrowserSettings browserSettings { get; private set; }
        public DrawItemEventHandler DisableTab_DrawItem { get; private set; }
        public ChromiumWebBrowser currentBrowser { get; private set; }
     


        private async void button1_Click(object sender, EventArgs e)
        {
           

            CookieVisitor _cookieVisitor = new CookieVisitor();

            var result = await Cef.GetGlobalCookieManager().VisitAllCookiesAsync();
            Console.WriteLine(result.Count.ToString()); // -> Return  0
        }
        public virtual void OnBeforeClose(IWebBrowser ChromiumWebBrowser)
        {
            // DO NOTHING
            Cef.Initialize(new CefSettings { RemoteDebuggingPort = 8088, CachePath = "GPUCache/Cache", PersistSessionCookies = true });
            Cef.GetGlobalCookieManager().SetStoragePath("GPUCache/CookiePath", true);

        }



    }
}



/////
//            TabPage tpage = new TabPage();
//            tpage.Text = "New Tab";
//            tabControl1.Controls.Add(tpage);
//            toolStripTextBoxAddress.Text = "about:blank";
//            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text);
//            ChromiumWebBrowser.Parent = tpage;
//            ChromiumWebBrowser.Dock = DockStyle.Fill;
//            ChromiumWebBrowser.AddressChanged += Chrome_AddressChanged;
//            ChromiumWebBrowser.TitleChanged += Chrome_TitleChanged;
////    ChromiumWebBrowser.PopupRequestChanged += life_PopupRequestChanged;
//   private void life_PopupChanged(object sender, PopupChangedEventArgs e) { this.Invoke(new MethodInvoker(() => { tabControl1.SelectedTab.Text = e.Title; })); }
//



/////


// usage:
