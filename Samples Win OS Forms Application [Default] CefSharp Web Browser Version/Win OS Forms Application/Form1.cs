using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_OS_Forms_Application;
using Win_OS_Forms_Application.Object;


/// <summary>
/// 
/// </summary>

using CefSharp;
using CefSharp.Web;
using CefSharp.Enums;
using CefSharp.Event;
using CefSharp.Handler;
using CefSharp.Internals;
using CefSharp.SchemeHandler;
using CefSharp.Structs;
using CefSharp.RenderProcess;
using CefSharp.ModelBinding;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using Win_OS_Forms_Application.Handler;

/// <summary>
/// 
/// </summary>




namespace Win_OS_Forms_Application
    {
    public partial class Form1 : Form
        {
       
        /// public ChromiumWebBrowser browser;
        /// public IWinFormsWebBrowser Browser;

        /// <summary>
        /// 
        /// </summary>

        private bool multiThreadedMessageLoopEnabled;

        public ChromiumWebBrowser ChromiumWebBrowser;
        public IWinFormsWebBrowser Browser { get; private set; }



        /// <summary>
        /// 
        /// </summary>

        public Form1()
            {
            InitializeComponent();




            /// <summary>
            /// System.Environment.SetEnvironmentVariable
            /// </summary>
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"Developer.json");

            /// Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
            Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "AIzaSyCwlkDuytn5j5gy3AoGfVGnEzwx7NL2t1Y");
            Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "111513960855-2eod2daojppibikjo6heaorbb9ck4o5g.apps.googleusercontent.com");
            Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "YgjULxxlfRwpMbn1JabGUIW9");

            CefSharp.WinForms.CefSettings settings = new CefSharp.WinForms.CefSettings();

            /// <summary>
            /// 
            /// </summary>
            /// 

            #region CEF Settings Browser

            CefSharpSettings.LegacyJavascriptBindingEnabled = true; //true
            CefSharpSettings.ConcurrentTaskExecution = true; //true
            CefSharpSettings.FocusedNodeChangedEnabled = true;
            CefSharpSettings.WcfEnabled = true; //true

            /// <summary>
            /// 
            /// </summary>
            /// 

            // BrowserSubprocessPath
            // settings.BrowserSubprocessPath = @"CefSharp.BrowserSubprocess.exe";

            /// UserAgent
            settings.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36 CefSharp_Web_Browser/79.0.3945.130";

            /// AcceptLanguageList
            settings.AcceptLanguageList = "en-US,en,ar,zh-CN,zh-TW,ko,ja,en-GB";

            /// <summary>
            /// 
            /// </summary>
            /// 
            ///
            /// WidevineCdm
            /// 
            //
           /// Cef.RegisterWidevineCdm(@"WidevineCdm\");
           /// Cef.RegisterWidevineCdmAsync(@"WidevineCdm\");

           /// settings.CefCommandLineArgs.Add("enable-widevine", "1");
           /// settings.CefCommandLineArgs.Add("enable-widevine-cdm", "1");

           /// settings.CefCommandLineArgs.Add("--enable-widevine-cdm --widevine-cdm-path", @"WidevineCdm\widevinecdm.dll"); //
           /// settings.CefCommandLineArgs.Add("--register-pepper-plugins", @"WidevineCdm\widevinecdm.dll");
           /// Cef.RegisterWidevineCdm(@".\WidevineCdm");
            //
            /// <summary>
            /// 
            /// </summary>
            /// 

            settings.ApplicationClientIdForFileScanning = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";

            // settings Arguments
            settings.ResourcesDirPath = System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase).LocalPath);
            settings.RemoteDebuggingPort = 8090;
            settings.LogSeverity = LogSeverity.Verbose;
            string JavascriptFlags = null;
            settings.JavascriptFlags = JavascriptFlags;
            string ResourcesDirPath = null;
            settings.ResourcesDirPath = ResourcesDirPath;
            settings.PersistSessionCookies = true;       //true and false // settings.PersistSessionCookies = false; 
            settings.PersistUserPreferences = true;       //true and false
            settings.IgnoreCertificateErrors = true;      //true
            settings.MultiThreadedMessageLoop = true;     //true 
            settings.WindowlessRenderingEnabled = true;   //true
  


            #endregion

            #region Custom  Command - line  Example

            /* Work Custom Command - line options */

            settings.CefCommandLineArgs.Add("disable-session-storage", "1");
            settings.CefCommandLineArgs.Add("disable-application-cache", "1");
            settings.CefCommandLineArgs.Add("enable-automatic-password-saving", "enable-automatic-password-saving");
            settings.CefCommandLineArgs.Add("enable-password-save-in-page-navigation", "enable-password-save-in-page-navigation");
            settings.CefCommandLineArgs.Add("enable-begin-frame-scheduling", "1");
            settings.CefCommandLineArgs.Add("renderer-process-limit", "1");
            settings.CefCommandLineArgs.Add("persist_session_cookies", "1");

            /* Disable Custom Command - line options */

            settings.CefCommandLineArgs.Add("disable-web-security", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-compositing", "1");
            settings.CefCommandLineArgs.Add("disable-gpu", "1");      // enable-gpu

            /* Enable Custom Command - line options */
            settings.CefCommandLineArgs.Add("compile-shader-always-succeeds", "1");

            /// --plugin-policy
            settings.CefCommandLineArgs.Add("plugin-policy", "allow");
            settings.CefCommandLineArgs.Add("debug-plugin-loading", "1");
            settings.CefCommandLineArgs.Add("allow-outdated-plugins", "1");
            settings.CefCommandLineArgs.Add("always-authorize-plugins", "1");
            ///

            settings.CefCommandLineArgs.Add("enable-extensions", "1");        //disable-extensions
            settings.CefCommandLineArgs.Add("enabled-new-style-notification", "1");
            settings.CefCommandLineArgs.Add("enable-web-notification-custom-layouts", "1");

            settings.CefCommandLineArgs.Add("enable-webgl", "1");
            settings.CefCommandLineArgs.Add("enable-npapi", "1");
            settings.CefCommandLineArgs.Add("enable-system", "1");
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.CefCommandLineArgs.Add("enable-pdf-extension", "1");
            settings.CefCommandLineArgs.Add("enable-translate", "1");
            settings.CefCommandLineArgs.Add("enable-translate-new-ux", "1");
            settings.CefCommandLineArgs.Add("enable-media-streams", "1");
            ///
            settings.CefCommandLineArgs.Add("translate-script-url", "1");
            settings.CefCommandLineArgs.Add("enable-network-service", "1");
            settings.CefCommandLineArgs.Add("enable-notification-service", "1");
            ///
            /// Enable Features
            settings.CefCommandLineArgs.Add("flag-switches-begin", "1");
            settings.CefCommandLineArgs.Add("enable-features", "Network-Service, Mobile, Chrome, NetworkService, NotificationService, Widevine-Cdm, MediaSessionService,NativeNotifications,NewStyleNotifications,NewTabLoadingAnimation,SystemWebApps,TabHoverCards,TranslateUI,google-password-manager,try-chrome-again,system-developer-mode,install-chrome-app,force-overlay-fullscreen-video,enable-extensions,enable-plugins");
            settings.CefCommandLineArgs.Add("flag-switches-end", "1");
            /// Enable Features

            settings.CefCommandLineArgs.Add("high-dpi-support", "1");
            settings.CefCommandLineArgs.Add("enable-site-settings", "1");
            settings.CefCommandLineArgs.Add("enable-profile-shortcut-manager", "1");
            settings.CefCommandLineArgs.Add("enable-main-frame-before-activation", "1");
            settings.CefCommandLineArgs.Add("enable-speech-input", "1");
            settings.CefCommandLineArgs.Add("enable-video-player-chromecast-support", "1");
            settings.CefCommandLineArgs.Add("enable-experimental-web-platform-features", "1");
            settings.CefCommandLineArgs.Add("enable-precise-memory-info", "1");
            settings.CefCommandLineArgs.Add("enable-experimental-fullscreen-exit-ui", "1");
            settings.CefCommandLineArgs.Add("enable-fullscreen-app-list", "1");
            settings.CefCommandLineArgs.Add("enable-fullscreen", "1");
            settings.CefCommandLineArgs.Add("enable-trace-app-source", "1");
            settings.CefCommandLineArgs.Add("enable-webrtc-event-logging-from-extension", "1");
            settings.CefCommandLineArgs.Add("enable-wifi-credential-sync", "1");
            settings.CefCommandLineArgs.Add("enable-zip-archiver-on-file-manager", "1");
            settings.CefCommandLineArgs.Add("enable-win7-webrtc-hw-h264-decoding", "1");
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capture", "1");
            settings.CefCommandLineArgs.Add("enable-webgl-image-chromium", "1");
            settings.CefCommandLineArgs.Add("enable-media-suspend", "1");
            settings.CefCommandLineArgs.Add("enable-drive-search-in-app-launcher", "1");
            settings.CefCommandLineArgs.Add("enable-google-branded-context-menu", "1");
            settings.CefCommandLineArgs.Add("enable-use-zoom-for-dsf", "1");
            settings.CefCommandLineArgs.Add("enable-browser-task-scheduler", "1");
            settings.CefCommandLineArgs.Add("enable-embedded-extension-options", "1");
            settings.CefCommandLineArgs.Add("enable-crx-hash-check", "1");


            /// <summary>
            /// 
            /// </summary>
            /// 


            /*  CEF init with custom settings */

            settings.CefCommandLineArgs.Add("material", "1");
            settings.CefCommandLineArgs.Add("force-overlay-fullscreen-video", "1");
            settings.CefCommandLineArgs.Add("crash-server-url", "1");
            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream", "1");
            settings.CefCommandLineArgs.Add("allow-running-insecure-content", "1");
            settings.CefCommandLineArgs.Add("apps-keep-chrome-alive-in-tests", "1");
            settings.CefCommandLineArgs.Add("create-browser-on-startup-for-tests", "1");
            settings.CefCommandLineArgs.Add("create-default-gl-context", "1");
            settings.CefCommandLineArgs.Add("fullscreen-enabled", "1");
            settings.CefCommandLineArgs.Add("allow-nacl-crxfs-api", "1");
            settings.CefCommandLineArgs.Add("allow-legacy-extension-manifests", "1");
            settings.CefCommandLineArgs.Add("native-crx-bindings", "1");
            settings.CefCommandLineArgs.Add("auto-select-desktop-capture-source", "1");
            settings.CefCommandLineArgs.Add("webview-enable-safebrowsing-support", "1");
            settings.CefCommandLineArgs.Add("embedded-extension-options", "1");
            settings.CefCommandLineArgs.Add("show-component-extension-options", "1");
            settings.CefCommandLineArgs.Add("task-manager-show-extra-renderers", "1");
            settings.CefCommandLineArgs.Add("custom-launcher-page", "1");
            settings.CefCommandLineArgs.Add("app-id", "1");
            settings.CefCommandLineArgs.Add("extensions-install-verification", "1");
            settings.CefCommandLineArgs.Add("extension-content-verification", "1");
            settings.CefCommandLineArgs.Add("extension-process", "1");
            settings.CefCommandLineArgs.Add("extensions-multi-account", "1");
            settings.CefCommandLineArgs.Add("app-auto-launched", "1");
            settings.CefCommandLineArgs.Add("apps-gallery-url", "1");
            settings.CefCommandLineArgs.Add("apps-gallery-update-url", "1");
            settings.CefCommandLineArgs.Add("apps-gallery-download-url", "1");
            settings.CefCommandLineArgs.Add("chrome-home-swipe-logic", "1");
            settings.CefCommandLineArgs.Add("auth-ext-path", "1");
            settings.CefCommandLineArgs.Add("bootstrap", "1");
            settings.CefCommandLineArgs.Add("bwsi", "1");
            settings.CefCommandLineArgs.Add("d3d9", "1");
            settings.CefCommandLineArgs.Add("d3d10", "1");
            settings.CefCommandLineArgs.Add("d3d11", "1");
            settings.CefCommandLineArgs.Add("d3d12", "1");
            settings.CefCommandLineArgs.Add("d3d-support", "1");
            settings.CefCommandLineArgs.Add("app", "1");
            settings.CefCommandLineArgs.Add("playback-mode", "1");
            settings.CefCommandLineArgs.Add("app-mode-auth-code", "1");
            settings.CefCommandLineArgs.Add("app-mode-oauth-token", "1");
            settings.CefCommandLineArgs.Add("apps-checkout-url", "1");
            settings.CefCommandLineArgs.Add("app-list-start-page-url", "1");
            settings.CefCommandLineArgs.Add("sync-url", "1");
            settings.CefCommandLineArgs.Add("sync-enable-get-update-avoidance", "1");
            settings.CefCommandLineArgs.Add("auto-launch-at-startup", "1");
            settings.CefCommandLineArgs.Add("unlimited-storage", "1");
            settings.CefCommandLineArgs.Add("enable-show-modal-dialog", "1");
            settings.CefCommandLineArgs.Add("easy-unlock-app-path", "1");
            settings.CefCommandLineArgs.Add("enable-apps-file-associations", "1");
            settings.CefCommandLineArgs.Add("enable-app-list", "1");
            settings.CefCommandLineArgs.Add("enable-settings-window", "1");
            settings.CefCommandLineArgs.Add("permission-request-api-scope", "1");
            settings.CefCommandLineArgs.Add("permission-request-api-url", "1");
            settings.CefCommandLineArgs.Add("enable-website-settings-manager", "1");
            settings.CefCommandLineArgs.Add("enable-accessibility-tab-switcher", "1");
            settings.CefCommandLineArgs.Add("enable-app-install-alerts", "1");
            settings.CefCommandLineArgs.Add("enable-spelling-auto-correct", "1");
            settings.CefCommandLineArgs.Add("spelling-service-feedback-interval-seconds", "1");
            settings.CefCommandLineArgs.Add("filemgr-ext-path", "1");
            settings.CefCommandLineArgs.Add("viewer-launch-via-appid", "1");
            settings.CefCommandLineArgs.Add("crashpad-handler", "1");
            settings.CefCommandLineArgs.Add("enable-accelerated-2d-canvas", "1");
            settings.CefCommandLineArgs.Add("enable-accelerated-vpx-decode", "1");
            settings.CefCommandLineArgs.Add("autoplay-policy=no-user-gesture-required", "1");
            settings.CefCommandLineArgs.Add("enable-bookmark-reordering", "1");
            settings.CefCommandLineArgs.Add("allow-cross-origin-auth-prompt", "1");

            /// @ Command Line Args
            settings.CefCommandLineArgs.Add("component-updater", "1");
            settings.CefCommandLineArgs.Add("arc-availability", "1");
            settings.CefCommandLineArgs.Add("arc-available", "1");
            settings.CefCommandLineArgs.Add("enable-fullscreen-tab-detaching", "1");
            settings.CefCommandLineArgs.Add("register-font-files", "1");
            settings.CefCommandLineArgs.Add("register-pepper-plugins", "1");
            settings.CefCommandLineArgs.Add("whitelisted-extension-id", "1");
            settings.CefCommandLineArgs.Add("enabled-webrtc-nonproxied-udp", "1");
            settings.CefCommandLineArgs.Add("enable-accelerated-video-decode", "1");
            settings.CefCommandLineArgs.Add("voice-interaction-supported-locales", "1");
            settings.CefCommandLineArgs.Add("video-image-texture-target", "1");
            settings.CefCommandLineArgs.Add("video-threads", "1");
            settings.CefCommandLineArgs.Add("process-per-site", "1");
            settings.CefCommandLineArgs.Add("process-per-tab", "1");
            settings.CefCommandLineArgs.Add("enable-permissions-api", "1");
            settings.CefCommandLineArgs.Add("use-mobile-user-agent", "1");
            settings.CefCommandLineArgs.Add("use-file-for-fake-audio-capture", "1");
            settings.CefCommandLineArgs.Add("use-file-for-fake-video-capture", "1");
            settings.CefCommandLineArgs.Add("use-first-display-as-internal", "1");
            settings.CefCommandLineArgs.Add("help", "1");
            settings.CefCommandLineArgs.Add("use-gl", "1");
            settings.CefCommandLineArgs.Add("zygote", "1");
            settings.CefCommandLineArgs.Add("enable-webrtc", "1");
            settings.CefCommandLineArgs.Add("enable_webrtc", "1");
            settings.CefCommandLineArgs.Add("custom_summary", "1");
            /// @ Command Line Args


            #endregion
            
            #region CefSharp Web Browser Domain Custom HostName | cefsharp://cefsharp/default.html  
            /*
            // chrome://cefsharp/settings.html
            // WebCustom://cefsharp/default.html
            // default://web/default.html
            // Use Register to Domain Custom 
            settings.RegisterScheme(new CefCustomScheme
                {
                SchemeName = "https",
                SchemeHandlerFactory = new Win_OS_Forms_Application.Handler.Scheme.CefSharpSchemeHandlerFactory(),
                DomainName = "cefsharp.com",
                IsSecure = true //treated with the same security rules as those applied to "https" URLs
                });


            // cefsharp://cefsharp/default.html
            settings.RegisterScheme(new CefCustomScheme
                {
                SchemeName = "cefsharp", // http   //cefsharp //browser // custom
                SchemeHandlerFactory = new FolderSchemeHandlerFactory(rootFolder: @"Resources\CefSharp.Web.Browser.Domain.Custom.HostName", /// // CefSharp.Web.Domain.Browser.Custom.HostName.Domain",  // CefSharp.Web.Domain.Browser\Web.Custom.HostName.Domain //@"..\..\..\..\CefSharp.Example\Resources", // WebCustom.HostName.Domain
                                                                  schemeName: "cefsharp",                                                 /// // http //cefsharp // browser // custom //Optional param no schemename checking if null
                                                                    hostName: "cefsharp",                                                 /// custom //cefsharp //Optional param no hostname checking if null
                                                                 defaultPage: "default.html")                                         /// //default.html // settings/settings.html // home.html //Optional param will default to index.html

                });
                */
            #endregion
            


            #region  Cef.Initialize(settings); End
            Cef.Initialize(settings);
            #endregion


            Text = "CefSharp Web Browser";
            ShowIcon = false;

            toolStripTextBoxAddress.Text = "https://www.google.com/";///"http://paypal.me/MohamedOsama914/2";
            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text) { BrowserSettings = { DefaultEncoding = "UTF-8", Databases = CefState.Disabled, /* Javascript Close Windows */  JavascriptCloseWindows = CefState.Default, /* JavascriptCloseWindows */  JavascriptDomPaste = CefState.Disabled, Javascript = CefState.Enabled, ApplicationCache = CefState.Disabled, FileAccessFromFileUrls = CefState.Enabled, TabToLinks = CefState.Default, UniversalAccessFromFileUrls = CefState.Default, WebSecurity = CefState.Enabled, LocalStorage = CefState.Disabled, ImageLoading = CefState.Default, TextAreaResize = CefState.Default, JavascriptAccessClipboard = CefState.Enabled, ImageShrinkStandaloneToFit = CefState.Default, Plugins = CefState.Enabled, WebGl = CefState.Disabled   /* ,   DefaultFontSize = 12 */ } };
            ChromiumWebBrowser.Dock = DockStyle.Fill;
            ChromiumWebBrowser.TitleChanged += OnBrowserTitleChanged;
            ChromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;
            ChromiumWebBrowser.StatusMessage += OnStatusMessageChanged;


            /// toolStripComboBoxAddress.SelectedText = "https://www.google.com/";
            /// ChromiumWebBrowser Browser = new ChromiumWebBrowser(toolStripComboBoxAddress.SelectedText) { BrowserSettings = { DefaultEncoding = "UTF-8", Databases = CefState.Disabled, /* Javascript Close Windows */  JavascriptCloseWindows = CefState.Default, /* JavascriptCloseWindows */  JavascriptDomPaste = CefState.Disabled, Javascript = CefState.Enabled, ApplicationCache = CefState.Disabled, FileAccessFromFileUrls = CefState.Enabled, TabToLinks = CefState.Default, UniversalAccessFromFileUrls = CefState.Default, WebSecurity = CefState.Enabled, LocalStorage = CefState.Disabled, ImageLoading = CefState.Default, TextAreaResize = CefState.Default, JavascriptAccessClipboard = CefState.Enabled, ImageShrinkStandaloneToFit = CefState.Default, Plugins = CefState.Enabled, WebGl = CefState.Disabled   /* ,   DefaultFontSize = 12 */ } };
            /// ChromiumWebBrowser.AddressChanged += OnBrowserComboBoxAddressChanged;



            TabPage tpage = new TabPage(); tpage.Text = " CefSharp Web Browser "; /* Ultimate CefSharp Web Browser */ tpage.Show();
            browserTabControl.Controls.Add(tpage); ChromiumWebBrowser.Parent = tpage; ChromiumWebBrowser.FocusHandler = null;


            /* Customize Handler */
            ChromiumWebBrowser.DownloadHandler = new Win_OS_Forms_Application.Handler.DownloadHandler();
            ChromiumWebBrowser.DisplayHandler = new Win_OS_Forms_Application.Handler.DisplayHandler();
            ChromiumWebBrowser.MenuHandler = new Win_OS_Forms_Application.Handler.Example.MenuHandler();

            /* ChromiumWebBrowser.DragHandler = new ChromiumApplication.Main.Handler.Example.DragHandler();    */            
            /* ChromiumWebBrowser.RequestHandler = new WinFormsRequestHandler(openNewTab);    */
             ChromiumWebBrowser.RequestHandler = new RequestHandler();

            /* Customize Handler */
            RequestContextSettings requestContextSettings = new RequestContextSettings();
            requestContextSettings.AcceptLanguageList = "en-US,en,ar,zh-CN,zh-TW,ko,ja,en-GB";
            requestContextSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";


            requestContextSettings.PersistSessionCookies = true;
            requestContextSettings.PersistUserPreferences = true;
            requestContextSettings.IgnoreCertificateErrors = true;
            
            ChromiumWebBrowser.RequestContext = new RequestContext(requestContextSettings);


            /* GET */
            ChromiumWebBrowser.RequestHandler = new Handler.Example.MainAuthenticationIRequestHandler("actual_username", "actual_password");
            ChromiumWebBrowser.LifeSpanHandler = new Win_OS_Forms_Application.Handler.LifeSpanHandler();
            ChromiumWebBrowser.RenderProcessMessageHandler = new Handler.Handlers.RenderProcessMessageHandler();
            /* GET */
            ChromiumWebBrowser.JavascriptObjectRepository.Register("bound", new BoundObject(), isAsync: false, options: BindingOptions.DefaultBinder);
            ChromiumWebBrowser.JavascriptObjectRepository.Register("boundAsync", new BoundObject.AsyncBoundObject(), isAsync: true, options: BindingOptions.DefaultBinder);


            #region Default RequestContext


            string error;
            string errorMessage;
            string ErrorDefault;
            string SettingsPreference;
            /// string plugins;


            Cef.UIThreadTaskFactory.StartNew(delegate
                {

                    ChromiumWebBrowser.RequestContext.SetPreference("spellcheck.dictionaries", new
                    List<object> { "en-US", "en", "ar", "zh-tw", "zh-CN", "ja" }, out error);

                    ChromiumWebBrowser.RequestContext.SetPreference("spellcheck.dictionary", "en-US", out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("spellcheck.use_spelling_service", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.enable_spellchecking", true, out errorMessage);

                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.plugins_enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.allow_running_insecure_content", true, out errorMessage);






                    /*
                       ChromiumWebBrowser.RequestContext.GetExtension(extensionId: "");
                    */





                    ///
                    ///
                    ///
                    #region
                    /// 
                    /// https://chromium.googlesource.com/chromium/src/+/32352ad08ee673a4d43e8593ce988b224f6482d3/chrome/common/pref_names.cc#2048
                    //
                    // Dictionary<String, Object> plugin = new Dictionary<String, Object>(); plugin.Add("enabled", true);
                    // ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out plugins);
                    // new WebPluginInfo(name: "Web", description: "Plugin", path: @"C:\Program Files (x86)\", version: "1.0")  }, out error);


                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", new List<object> {
                     new WebPluginInfo(name: "VLC Web Plugin", description: "VLC Player Web Plugin", path: @"C:\Program Files (x86)\VideoLAN\VLC\npvlc.dll", version: "3.0.3"),
                     new WebPluginInfo(name: "WidevineCdm", description: "Widevine Content Decryption Module", path: @".\WidevineCdm\widevinecdm.dll", version: "4.10.1303.2"),
                     new WebPluginInfo(name: "WidevineCdm Web Adapter", description: "Widevine Content Decryption Module - widevinecdmadapter.dll", path: @".\WidevineCdm\widevinecdmadapter.dll", version: "1.4.9.1088")

                        }, out error); //  List (".....",".........") }, out error);




                    // ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out SettingsPreference);
                    // ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out SettingsPreference); //1

                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.enabled_nacl", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.show_details", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_enabled", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.last_internal_directory", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out SettingsPreference); //New


                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.allow_outdated", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.always_authorize", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.metadata", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.last_internal_directory.plugins_list", 1, out SettingsPreference); //1


                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.allow_displaying_insecure_content", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("terms_of_service.url", 1, out SettingsPreference); //https

                    // touch_virtual_keyboard_enabled
                    ChromiumWebBrowser.RequestContext.SetPreference("ui.touch_virtual_keyboard_enabled", 1, out SettingsPreference);
                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("background_contents.registered", 1, out SettingsPreference);
                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_on_desktop", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_in_quick_launch_bar", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.show_update_promotion_info_bar", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.pepper_flash_settings_enabled", 1, out SettingsPreference); //https



                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("googlegeolocationaccess.enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.access_token", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("media.default_video_capture_Device", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.audio_capture_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.audio_capture_allowed_urls", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.video_capture_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.video_capture_allowed_urls", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hotword.always_on_search_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("intl.hardware_keyboard", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("device_status.location", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("DeviceRegistered", 1, out SettingsPreference); //https
                                                                                                                    // ChromiumWebBrowser.RequestContext.SetPreference("options_window.last_tab_index", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.last_tab_index", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("task_manager.window_placement", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("local_discovery.notifications_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("autofill.wallet_location_disclosure", 1, out SettingsPreference); //https




                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.fonts.standard.Arab", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.tabs_to_links.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.tabs_to_links.http://*,*.last_used", 1, out SettingsPreference); //https

                    #endregion

                    /// <example></example>

                    // string ip = "IP";
                    // string port = "PORT";
                    // var dict = new Dictionary<string, object>();
                    // dict.Add("mode", "fixed_servers");
                    // dict.Add("server", "" + ip + ":" + port + "");
                    // ChromiumWebBrowser.RequestContext.SetPreference("proxy", dict, out error);

                    /// <example>
                    ///

                    /* 
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation", new List<object> {
                     new WebPluginInfo(name: "VLC Web Plugin", description: "VLC Player Web Plugin", path: @"C:\Program Files (x86)\VideoLAN\VLC\npvlc.dll", version: "3.0.3"),
                   new WebPageTraceListener()

                        }, out error); //  List (".....",".........") }, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.exceptions.important_site_info", new List<object> {
                     new WebPluginInfo(name: "VLC Web Plugin", description: "VLC Player Web Plugin", path: @"C:\Program Files (x86)\VideoLAN\VLC\npvlc.dll", version: "3.0.3"),
                   new TaskWebPluginInfoVisitor(: "","")

                        }, out error); //  List (".....",".........") }, out error);
                    */


                    /// 
                    /// </example>

                    ///
                    ///
                    ///



                    ///
                    ///
                    ///
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.geolocation", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.exceptions.geolocation.https://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.exceptions.geolocation.https://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.geolocation.'https://tinder.com:443,'.setting", "1", out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.geolocation.'https://tinder.com:443,'.setting", 1, out SettingsPreference);

                    ///
                    ///
                    ///
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.plugin_whitelist", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.plugins_list", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.plugins.plugins_list", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_plugins_allowed_for_urls", 1, out SettingsPreference); //1

                    // with this chrome still asks for permission
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.usb_guard", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.media_stream", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.media_stream_camera", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.media_stream_mic", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.Images", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.plugins", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.notifications", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.javascript", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.geolocation", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.important_site_info", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.accessibility_events", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.protocol_handler", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.app_banner", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.site_engagement", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.payment_handler", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.cookies", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.geolocation", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation", 1, out SettingsPreference); //1


                    //

                    // Settings Preference
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.cookies.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.cookies.http://*,*.last_used", 1, out SettingsPreference); //https

                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.javascript.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.javascript.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.protocol_handler.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.protocol_handler.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.app_banner.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.app_banner.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.site_engagement.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.site_engagement.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.payment_handler.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.payment_handler.http://*,*.last_used", 1, out SettingsPreference); //https

                    // Background sync
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.background_sync", 1, out SettingsPreference); //1

                    // Settings Preference Background sync
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.background_sync.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.background_sync.http://*,*.last_used", 1, out SettingsPreference); //https

                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.accessibility_events.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.accessibility_events.http://*,*.last_used", 1, out SettingsPreference); //https

                    // and this prevents chrome from starting
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_mic.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_mic.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_camera.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_camera.http://*,*.last_used", 1, out SettingsPreference); //https

                    // Permission
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.important_site_info.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.important_site_info.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.plugins.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.plugins.http://*,*.last_used", 1, out SettingsPreference); //https   
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation.http://*,*.last_used", 1, out SettingsPreference); //https

                    // and this prevents chrome from starting as well
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.pattern_pairs.http://*,*.media_stream.video", "Allow", out SettingsPreference); //https
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.pattern_pairs.http://*,*.media_stream.audio", "Allow", out SettingsPreference); //https

                    // change default camera using
                    ////  ChromiumWebBrowser.RequestContext.SetPreference("media.default_video_capture_Device", "\\\\?\\root#media#0002#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\\global", out SettingsPreference);


                    //// https ("profile.content_settings.exceptions.media_stream_camera.'https://somewebsite.com:443,'.setting", "1"); 
                    //// https ("profile.content_settings.exceptions.media_stream_mic.'https://somewebsite.com:443,'.setting", "1");




                    /// pref_names.cc
                    ///
                    ///
                    ///
                    ///
                    /// pref_names.cc
                    /// https://github.com/adobe/chromium/blob/master/chrome/common/pref_names.cc
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.enabled_settings", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.geolocation_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.media_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.global.javascript_enabled", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.global.plugins_enabled", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.media_enabled", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.java_enabled", 1, out SettingsPreference);

                    ///
                    /// ChromiumWebBrowser.RequestContext.SetPreference("translate.enabled", true, out errorMessage);
                    /// ChromiumWebBrowser.RequestContext.SetPreference("translate.enabled", new List<object> { "en-US", "ar", "zh-CN", "ru", "ja" }, out error);
                    /// 

                    ChromiumWebBrowser.RequestContext.SetPreference("translate.enabled", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.password_manager_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.password_manager_allow_show_passwords", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.notifications_default_content_setting", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.desktop_notification_position", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.plugin_whitelist", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.whitelist_version", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.shortcut_created", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.default_content_setting", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.content_settings", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("import_bookmarks", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("webstore.enterprise_store_url", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("webstore.enterprise_store_name", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.local_profile_id", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.last_active_profiles", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.last_tab_index", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("task_manager.window_placement", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("preferences.window_placement", 1, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("download.extensions_to_open", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.window_placement", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.browseractions.container.width", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.install.allowlist", true, out errorMessage);
                    // Time of the last, and next scheduled, extensions auto-update checks.
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.autoupdate.last_check", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.autoupdate.next_check", true, out error);
                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_on_desktop", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_in_apps_menu", 1, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_in_quick_launch_bar", 1, out errorMessage);
                    // Preferences that are exclusively used to store managed values for default
                    // content settings.
                    // Dictionary of schemes used by the external protocol handler.
                    // List of protocol handlers.
                    ChromiumWebBrowser.RequestContext.SetPreference("custom_handlers.registered_protocol_handlers", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("custom_handlers.enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("custom_handlers.ignored_protocol_handlers", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("protocol_handler.excluded_schemes", true, out error);

                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("default_apps_installed", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("default_apps", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("apps_promo_counter", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("intl.app_locale", true, out ErrorDefault);
                    ChromiumWebBrowser.RequestContext.SetPreference("component_updater.state", true, out error);

                    // The metrics client GUID and session ID.
                    ChromiumWebBrowser.RequestContext.SetPreference("user_experience_metrics.client_id", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("user_experience_metrics.session_id", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.media_stream_camera_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.notifications_enabled", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.geolocation_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.important_site_info_enabled", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("search.suggest_enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("default_search_provider.enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("bookmark_bar.show_on_all_tabs", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("safebrowsing.enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("policy.url_whitelist", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("default_apps_install_state", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.touchpad.enable_tap_to_click", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.language.pinyin_correct_pinyin", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.accessibility", 1, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.labs.advanced_filesystem", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.labs.mediaplayer", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.internet.show_plan_notifications", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.theme.use_system", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.theme.pack", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.theme.id", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.ui.developer_mode", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.toolbarsize", true, out errorMessage);


                    ChromiumWebBrowser.RequestContext.SetPreference("browser.default_browser_setting_enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.custom_chrome_frame", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.internet.show_plan_notifications", true, out errorMessage);

                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("extensions.enabled_extensions", true, out error);

                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings_window", new List<object> { "notifications", "geolocation", "important_site_info", "media_stream_camera", "site_engagement" }, out error);
                    // ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.exceptions", new List<object> { "notifications", "geolocation", "important_site_info", "media_stream_camera", "site_engagement" }, out error);
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.exceptions", new List<object> { "notifications", "geolocation", "important_site_info", "media_stream_camera", "site_engagement" }, out error);
                    // ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.allow_running_insecure_content", true, out errorMessage);
                    // ChromiumWebBrowser.RequestContext.SetPreference("webkit.webrtc.multiple_routes_enabled", true); // false
                    // ChromiumWebBrowser.RequestContext.SetPreference("webkit.webrtc.nonproxied_udp_enabled", true); // false


                    ///
                    });


            this.multiThreadedMessageLoopEnabled = multiThreadedMessageLoopEnabled;

            #endregion


            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);




            }


        #region Tab Pages ChromiumWebBrowser
        private void Focus_ChromiumWebBrowser(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser.CanFocus)
                ChromiumWebBrowser.Focus();

            favicon();

            }
        private void Go_ChromiumWebBrowser(object sender, EventArgs e)
            {        
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser != null)
                ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);

            favicon();
            }
        private void Back_ChromiumWebBrowser(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser.CanGoBack)
                ChromiumWebBrowser.Back();

            //favicon();
            }

        private void Forward_ChromiumWebBrowser(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser.CanGoForward)
                ChromiumWebBrowser.Forward();

            //favicon();
            }

        private void Reload_ChromiumWebBrowser(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
                ChromiumWebBrowser.Reload();

            favicon();

            }
        private void Refresh_ChromiumWebBrowser(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Refresh();

            favicon();

            }
        private void Stop_ChromiumWebBrowser(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            ChromiumWebBrowser.Stop();

            favicon();

            }

     
        private void RemovesAllTabPages(object sender, EventArgs e)
            {// Removes all the tabs: //  ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;

            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            browserTabControl.TabPages.Clear();
            favicon();
            }

        private void RemoveTabPage(object sender, EventArgs e)
            {// Removes the selected tab:  
            ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            browserTabControl.TabPages.Remove(browserTabControl.SelectedTab);
            favicon();
            }

        #endregion TabPages



        #region toolStripComboBoxAddress_KeyUp
        private void toolStripComboBoxAddress_KeyUp(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                if (!string.IsNullOrEmpty(toolStripComboBox2.SelectedText))
                    {
                    if (!toolStripComboBox2.SelectedText.Contains("."))
                        {
                        // ChromiumWebBrowser.Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                        // WebgetCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                        // getCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load("https://www.google.com/search?q=" + toolStripComboBox2.SelectedText);


                        }
                    else
                        { //ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);
                        //  WebgetCurrentBrowser().Load(toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load(toolStripComboBox2.SelectedText);

                        }
                    }
                }
            }





        /*
        private void GoChromiumWebBrowserAComboBox(object sender, EventArgs e)
            {
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (ChromiumWebBrowser != null)
                ChromiumWebBrowser.Load(toolStripComboBoxAddress.SelectedText);
            }
        */

        #endregion


        #region NewTab Default




        /// <summary>
        /// addNewTab
        /// </summary>
        public void addNewTab()
            {

            TabPage tpage = new TabPage();
            tpage.Text = "New Tab";
            browserTabControl.Controls.Add(tpage);
            toolStripTextBoxAddress.Text = "https://www.google.com/";
            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text);
            ChromiumWebBrowser.Parent = tpage;
            ChromiumWebBrowser.Dock = DockStyle.Fill;

            ChromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;
            ChromiumWebBrowser.TitleChanged += OnBrowserTitleChanged;
            ChromiumWebBrowser.StatusMessage += OnStatusMessageChanged;

            ChromiumWebBrowser.ActivateBrowserOnCreation = true;

            
            /// Customize Handler 
            ///
            ChromiumWebBrowser.DownloadHandler = new Handler.DownloadHandler();
            ChromiumWebBrowser.DisplayHandler = new Handler.DisplayHandler();
            ChromiumWebBrowser.MenuHandler = new Win_OS_Forms_Application.Handler.CustomMenuHandler();
            ChromiumWebBrowser.LifeSpanHandler = new Handler.LifeSpanHandler();
            ChromiumWebBrowser.RequestHandler = new RequestHandler();

            /// requestContextSettings
            /// 
            RequestContextSettings requestContextSettings = new RequestContextSettings();
            requestContextSettings.AcceptLanguageList = "en-US,en,ar,zh-CN,zh-TW,ko,ja,en-GB";
            requestContextSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";

            requestContextSettings.PersistSessionCookies = true;
            requestContextSettings.PersistUserPreferences = true;
            requestContextSettings.IgnoreCertificateErrors = true;
            ChromiumWebBrowser.RequestContext = new RequestContext(requestContextSettings);


            favicon();

            }



        public void NewTab_Default(object sender, EventArgs e)
            {


            favicon();
            NewTabBar();
            addNewTab();


            //
            // tpage.Text = "New Tab Bar Default Custom [ CefSharp Web Browser ]";
            //
            ///////////////////////

            TabPage tpage = new TabPage();

            tpage.Text = "New Tab Default [ CefSharp Web Browser ]";
            browserTabControl.Controls.Add(tpage);
            toolStripTextBoxAddress.Text = "https://www.google.com"; //"https://mail.yahoo.com/"; // chrome://version // cefsharp://cefsharp/PayPal.html
            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text)
                {
                BrowserSettings = {
                    DefaultEncoding = "UTF-8", Databases = CefState.Default, JavascriptCloseWindows = CefState.Default, JavascriptDomPaste = CefState.Disabled, Javascript = CefState.Enabled, ApplicationCache = CefState.Disabled, FileAccessFromFileUrls = CefState.Enabled, TabToLinks = CefState.Default, UniversalAccessFromFileUrls = CefState.Default, WebSecurity = CefState.Enabled, LocalStorage = CefState.Disabled, ImageLoading = CefState.Default, TextAreaResize = CefState.Default, JavascriptAccessClipboard = CefState.Enabled, ImageShrinkStandaloneToFit = CefState.Default, Plugins = CefState.Enabled, WebGl = CefState.Enabled }
                }; //WebGl = CefState.Disabled 

            /* Javascript Close Windows */ //  JavascriptCloseWindows = CefState.Default , /* JavascriptCloseWindows */ 


            ChromiumWebBrowser.Parent = tpage;
            ChromiumWebBrowser.Dock = DockStyle.Fill;
            ChromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;
            ChromiumWebBrowser.TitleChanged += OnBrowserTitleChanged;
            ChromiumWebBrowser.StatusMessage += OnStatusMessageChanged;

           
            //favicon();


            /// ChromiumWebBrowser.HandleCreated += OnBrowserHandleCreated;


            /* Customize Handler */
            ChromiumWebBrowser.DownloadHandler = new Handler.DownloadHandler();
            ChromiumWebBrowser.MenuHandler = new Handler.Example.MenuHandler();

            //
            ChromiumWebBrowser.DisplayHandler = new Handler.DisplayHandler();

            ///  ChromiumWebBrowser.DragHandler = new ChromiumApplication.ExampleControl.Handler.RegionIHandler(); //DragHandler();

            ///
            /// ChromiumWebBrowser.DisplayHandler = new CustomizeFormNotHandler();
            ///


            // ChromiumWebBrowser.RequestHandler = new RequestHandler();
            ChromiumWebBrowser.LifeSpanHandler = new Handler.LifeSpanHandler();
            ChromiumWebBrowser.JavascriptObjectRepository.Register("bound", new BoundObject(), isAsync: false, options: BindingOptions.DefaultBinder);
            ChromiumWebBrowser.JavascriptObjectRepository.Register("boundAsync", new BoundObject.AsyncBoundObject(), isAsync: true, options: BindingOptions.DefaultBinder);

            ///
            ///
            // ChromiumWebBrowser.DragHandler = new DragHandler();
        
            //////   browserProcessHandler = new ChromiumApplication.Main.Handlers.BrowserProcessHandler();


            /// <example> </example>
        /////    ChromiumWebBrowser.RequestHandler = new OnResourceLoadCompleteHandler("actual_username", "actual_password");
            /// <example> </example>


            /// ChromiumWebBrowser.DialogHandler = new DialogHandler();
            /// ChromiumWebBrowser.KeyboardHandler = new KeyboardHandler();
            RequestContextSettings requestContextSettings = new RequestContextSettings();
            requestContextSettings.AcceptLanguageList = "en-US,en,ar,zh-CN,zh-TW,ko,ja,en-GB";
            requestContextSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";
            requestContextSettings.PersistSessionCookies = true;
            requestContextSettings.PersistUserPreferences = true;
            requestContextSettings.IgnoreCertificateErrors = true;
            
            ChromiumWebBrowser.RequestContext = new RequestContext(requestContextSettings);



            // ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text);
            // ChromiumWebBrowser.LoadingStateChanged += OnLoadingStateChanged;
            string error;
            string errorMessage;
            string SettingsPreference;
            // string plugins;
            // string plugin;

            #region Get

            Cef.UIThreadTaskFactory.StartNew(delegate
                {

                    ChromiumWebBrowser.RequestContext.SetPreference("spellcheck.dictionaries", new
                    List<object> { "en-US", "en", "ar", "zh", "zh-CN", "ja" }, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("spellcheck.dictionary", "en-US", out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.plugins_enabled", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("spellcheck.use_spelling_service", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.enable_spellchecking", true, out errorMessage);



                    ///
                    ///
                    ///
                    #region
                    /// 
                    /// https://chromium.googlesource.com/chromium/src/+/32352ad08ee673a4d43e8593ce988b224f6482d3/chrome/common/pref_names.cc#2048
                    //
                    // Dictionary<String, Object> plugin = new Dictionary<String, Object>(); plugin.Add("enabled", true);
                    // ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out plugins); //plugins




                    //  ChromiumWebBrowser.RequestContext.SetPreference("plugins.last_internal_directory", new List<object> { "name", "WidevineCdm" }, out error);
                    //             new WebPluginInfo(name: "", description: "", path: @"", version: "");


                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", new List<object> {
                     new WebPluginInfo(name: "VLC Web Plugin", description: "VLC Player Web Plugin", path: @"C:\Program Files (x86)\VideoLAN\VLC\npvlc.dll", version: "3.0.3"),
                     new WebPluginInfo(name: "WidevineCdm", description: "Widevine Content Decryption Module", path: @".\WidevineCdm\widevinecdm.dll", version: "4.10.1303.2"),
                     new WebPluginInfo(name: "WidevineCdm Web Adapter", description: "Widevine Content Decryption Module - widevinecdmadapter.dll", path: @".\WidevineCdm\widevinecdmadapter.dll", version: "1.4.9.1088")

                        }, out error); //  List (".....",".........") }, out error);


                    // ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out SettingsPreference);
                    //ChromiumWebBrowser.RequestContext.SetPreference("plugins.enabled_nacl", 1, out SettingsPreference);
                    //ChromiumWebBrowser.RequestContext.SetPreference("plugins.show_details", 1, out SettingsPreference);
                    //ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_enabled", 1, out SettingsPreference);
                    // ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.last_internal_directory", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.plugins_list", 1, out SettingsPreference); //New

                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.allow_outdated", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.always_authorize", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.metadata", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("plugins.last_internal_directory.plugins_list", 1, out SettingsPreference); //1


                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.allow_displaying_insecure_content", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("terms_of_service.url", 1, out SettingsPreference); //https

                    // touch_virtual_keyboard_enabled
                    ChromiumWebBrowser.RequestContext.SetPreference("ui.touch_virtual_keyboard_enabled", 1, out SettingsPreference);
                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("background_contents.registered", 1, out SettingsPreference);
                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_on_desktop", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.web_app.create_in_quick_launch_bar", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.show_update_promotion_info_bar", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.pepper_flash_settings_enabled", 1, out SettingsPreference); //https



                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("googlegeolocationaccess.enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("media.default_video_capture_Device", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.audio_capture_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.audio_capture_allowed_urls", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.video_capture_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hardware.video_capture_allowed_urls", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("hotword.always_on_search_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("intl.hardware_keyboard", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("device_status.location", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("DeviceRegistered", 1, out SettingsPreference); //https
                                                                                                                    //  ChromiumWebBrowser.RequestContext.SetPreference("options_window.last_tab_index", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.last_tab_index", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("task_manager.window_placement", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("local_discovery.notifications_enabled", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("autofill.wallet_location_disclosure", 1, out SettingsPreference); //https




                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.fonts.standard.Arab", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.tabs_to_links.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.tabs_to_links.http://*,*.last_used", 1, out SettingsPreference); //https

                    #endregion



                    ///
                    ///
                    ///
                    ///
                    /// <example></example>

                    // string ip = "IP";
                    // string port = "PORT";
                    // var dict = new Dictionary<string, object>();
                    // dict.Add("mode", "fixed_servers");
                    // dict.Add("server", "" + ip + ":" + port + "");
                    // ChromiumWebBrowser.RequestContext.SetPreference("proxy", dict, out error);

                    /// <example></example>
                    ///
                    ///
                    ///
                    ///

                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.geolocation", 1, out SettingsPreference);
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.exceptions.geolocation.https://*,*.setting", 1, out SettingsPreference); //https
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.exceptions.geolocation.https://*,*.last_used", 1, out SettingsPreference); //https
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.geolocation.'https://tinder.com:443,'.setting", "1", out SettingsPreference);
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings.geolocation.'https://tinder.com:443,'.setting", 1, out SettingsPreference);
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation", 1, out SettingsPreference); //1

                    ///
                    ///
                    ///

                    // with this chrome still asks for permission
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.usb_guard", 1, out SettingsPreference);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.media_stream", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.media_stream_camera", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.media_stream_mic", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.Images", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.plugins", 1, out SettingsPreference); //1

                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.javascript", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.geolocation", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.important_site_info", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.accessibility_events", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.protocol_handler", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.app_banner", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.site_engagement", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.payment_handler", 1, out SettingsPreference); //1
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.cookies", 1, out SettingsPreference); //1

                    //

                    // Settings Preference
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.plugins.plugins_list", 1, out SettingsPreference); //1
                                                                                                                                                                 // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.plugins.plugins_list.http://*,*.setting", 1, out SettingsPreference); //https
                                                                                                                                                                 // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.plugins.plugins_list.http://*,*.last_used", 1, out SettingsPreference); //https


                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.cookies.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.cookies.http://*,*.last_used", 1, out SettingsPreference); //https


                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.javascript.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.javascript.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.protocol_handler.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.protocol_handler.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.app_banner.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.app_banner.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.site_engagement.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.site_engagement.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.payment_handler.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.payment_handler.http://*,*.last_used", 1, out SettingsPreference); //https

                    // Background sync
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.managed_default_content_settings.background_sync", 1, out SettingsPreference); //1

                    // Settings Preference Background sync
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.background_sync.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.background_sync.http://*,*.last_used", 1, out SettingsPreference); //https

                    //
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.accessibility_events.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.accessibility_events.http://*,*.last_used", 1, out SettingsPreference); //https

                    // and this prevents chrome from starting
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_mic.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_mic.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_camera.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.media_stream_camera.http://*,*.last_used", 1, out SettingsPreference); //https

                    // Permission
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.important_site_info.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.important_site_info.http://*,*.last_used", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.plugins.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.plugins.http://*,*.last_used", 1, out SettingsPreference); //https   
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation.http://*,*.setting", 1, out SettingsPreference); //https
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.exceptions.geolocation.http://*,*.last_used", 1, out SettingsPreference); //https

                    // and this prevents chrome from starting as well
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.pattern_pairs.http://*,*.media_stream.video", "Allow", out SettingsPreference); //https
                    // ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.pattern_pairs.http://*,*.media_stream.audio", "Allow", out SettingsPreference); //https

                    // change default camera using
                    /// ChromiumWebBrowser.RequestContext.SetPreference("media.default_video_capture_Device", "\\\\?\\root#media#0002#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\\global", out SettingsPreference);


                    //// https ("profile.content_settings.exceptions.media_stream_camera.'https://somewebsite.com:443,'.setting", "1"); 
                    //// https ("profile.content_settings.exceptions.media_stream_mic.'https://somewebsite.com:443,'.setting", "1");




                    /// pref_names.cc
                    ///
                    ///
                    ///
                    ///
                    /// pref_names.cc
                    /// https://github.com/adobe/chromium/blob/master/chrome/common/pref_names.cc
                    ChromiumWebBrowser.RequestContext.SetPreference("settings.enabled_settings", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.geolocation_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("content_settings_window.media_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.global.javascript_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.global.plugins_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.media_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("webkit.webprefs.java_enabled", 1, out error);

                    ChromiumWebBrowser.RequestContext.SetPreference("translate.enabled", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.password_manager_enabled", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.password_manager_allow_show_passwords", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.notifications_default_content_setting", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("browser.desktop_notification_position", true, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.default_content_settings", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.plugin_whitelist", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.content_settings.whitelist_version", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("profile.shortcut_created", true, out errorMessage);
                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.default_content_setting", 1, out error);
                    ChromiumWebBrowser.RequestContext.SetPreference("geolocation.content_settings", 1, out error);


                    });

            #endregion






            }




        public void NewTabBar()
            {
            TabPage tpage = new TabPage();
            tpage.Text = "New Tab Bar Custom Browser";
            browserTabControl.Controls.Add(tpage);
            toolStripTextBoxAddress.Text = "https://www.google.com/";
            ChromiumWebBrowser ChromiumWebBrowser = new ChromiumWebBrowser(toolStripTextBoxAddress.Text)
                {
                BrowserSettings = { Javascript = CefState.Default, Plugins = CefState.Default, Databases = CefState.Default, LocalStorage = CefState.Default }
                };

            ChromiumWebBrowser.Parent = tpage;
            ChromiumWebBrowser.Dock = DockStyle.Fill;

            ChromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;
            ChromiumWebBrowser.TitleChanged += OnBrowserTitleChanged;
            ChromiumWebBrowser.StatusMessage += OnStatusMessageChanged;

            /* Customize Handler */
            ChromiumWebBrowser.DownloadHandler = new Handler.DownloadHandler();
            ChromiumWebBrowser.MenuHandler = new Handler.Example.MenuHandler();
            ChromiumWebBrowser.LifeSpanHandler = new Handler.LifeSpanHandler();
            ChromiumWebBrowser.RequestHandler = new RequestHandler();
            ChromiumWebBrowser.DisplayHandler = new Handler.DisplayHandler();

            ChromiumWebBrowser.ActivateBrowserOnCreation = true;


            favicon();


            // ChromiumWebBrowser.RequestHandler = new MainAuthenticationIRequestHandler("actual_username", "actual_password");             
            // ChromiumWebBrowser.DragHandler = new DragHandler();
            // ChromiumWebBrowser.DialogHandler = new DialogHandler();
            // ChromiumWebBrowser.KeyboardHandler = new KeyboardHandler();
            RequestContextSettings requestContextSettings = new RequestContextSettings();
            requestContextSettings.AcceptLanguageList = "en-US,en,ar,zh-CN,zh-TW,ko,ja,ru,en-GB";
            requestContextSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.AppPathProfileUserDataCefSharp";
            requestContextSettings.PersistSessionCookies = true;
            requestContextSettings.PersistUserPreferences = true;
            requestContextSettings.IgnoreCertificateErrors = true;

            ChromiumWebBrowser.RequestContext = new RequestContext(requestContextSettings);

            }



        #endregion


        #region getCurrentBrowser

        private ChromiumWebBrowser getCurrentBrowser() { return (ChromiumWebBrowser)browserTabControl.SelectedTab.Controls[0]; }

        private void browserTabControl_SelectedIndexChanged(object sender, EventArgs e)
            {
            //  ChromiumWebBrowser = tabControl1.SelectedTab.Controls[ - 0] as ChromiumWebBrowser;
            //  ChromiumWebBrowser currentBrowser = getCurrentBrowser();

            ChromiumWebBrowser currentBrowser = getCurrentBrowser();
            toolStripTextBoxAddress.Text = currentBrowser.Address;
            }

        private void toolStripTextBoxAddress_KeyUp(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                if (!string.IsNullOrEmpty(toolStripTextBoxAddress.Text))
                    {
                    if (!toolStripTextBoxAddress.Text.Contains("."))
                        {
                        // ChromiumWebBrowser.Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                        // WebgetCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                        // getCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load("https://www.google.com/search?q=" + toolStripTextBoxAddress.Text);


                        }
                    else
                        { //ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);
                        //  WebgetCurrentBrowser().Load(toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load(toolStripTextBoxAddress.Text);

                        }
                    }
                }
            }


        /* toolStripComboBoxAddress_KeyUp
        private void toolStripComboBoxAddress_KeyUp(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                if (!string.IsNullOrEmpty(toolStripComboBoxAddress.SelectedText))
                    {
                    if (!toolStripComboBoxAddress.SelectedText.Contains("."))
                        {
                        // ChromiumWebBrowser.Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                        // WebgetCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);
                        // getCurrentBrowser().Load("https://www.google.com.hk/search?q=" + toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load("https://www.google.com/search?q=" + toolStripComboBoxAddress.SelectedText);


                        }
                    else
                        { //ChromiumWebBrowser.Load(toolStripTextBoxAddress.Text);
                        //  WebgetCurrentBrowser().Load(toolStripTextBoxAddress.Text);

                        getCurrentBrowser().Load(toolStripComboBoxAddress.SelectedText);

                        }
                    }
                }
            }

            */


        #endregion


        #region ImageList

        /// <summary>
        /// ImageList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TabCustom(object sender, EventArgs e)
            {
            // browserTabControl.ImageList = myimg;

            browserTabControl.ImageList = myimg;
            favicon();


            // webGetbrowser = new WebBrowser();
            //  toolStripTextBoxAddress.Text = "http://paypal.me/MohamedOsama914/5";
            //  webGetbrowser.Url = new Uri(toolStripTextBoxAddress.Text);


            // webGetbrowser.Url = new Uri("http://paypal.me/MohamedOsama914/5");
            // webGetbrowser.Visible = true;
            // TabPage tpage = new TabPage();
            // tpage.Text = "TabPageNewBarCustom";
            // browserTabControl.Controls.Add(tpage);
            // browserTabControl.Dock = DockStyle.Fill;
            // browserTabControl.SelectTab(i);
            // i += 1;
            //   ChromiumWebBrowser.MenuHandler = new ChromiumApplication.Main.Handler.Example.MenuHandler();

            }
        private Bitmap CloseImage;
        private string memorystream;

        // Image CloseImage;
        // private ImageList myimg;

        public void favicon()
            {

            // favicon
            // How to change favicon when tab page changes in c# browser?
            //
            // https://stackoverflow.com/questions/45919131/how-to-change-favicon-when-tab-page-changes-in-c-sharp-browser
            //
            //


            System.Net.WebClient wc = new System.Net.WebClient();
            System.IO.MemoryStream memorystream = new System.IO.MemoryStream(wc.DownloadData("http://" + new Uri(getCurrentBrowser().Address.ToString()).Host + "/favicon.ico")); /// http:// /// getCurrentBrowser()
            Icon icon = new Icon(memorystream);
            string i = Convert.ToString(myimg.Images.Count);
            myimg.Images.Add(i, icon.ToBitmap());
            browserTabControl.ImageList = myimg;
            browserTabControl.SelectedTab.ImageIndex = myimg.Images.Count - 1; // - 1


            //             favicon();
            ChromiumWebBrowser ChromiumWebBrowser = browserTabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;

            }


        #endregion




        #region OnBrowser

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
            {
            this.InvokeOnUiThreadIfRequired(() => browserTabControl.SelectedTab.Text = args.Title);
            }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
            {
            this.InvokeOnUiThreadIfRequired(() => toolStripTextBoxAddress.Text = args.Address);
            }

        /*
        private void OnBrowserComboBoxAddressChanged(object sender, AddressChangedEventArgs args)
            {
            this.InvokeOnUiThreadIfRequired(() => toolStripComboBoxAddress.SelectedText = args.Address);
            }
        */

        private void OnStatusMessageChanged(object sender, StatusMessageEventArgs args)
            {
            this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
            }

        #endregion


        #region Form1_FormClosing | Cef.Shutdown();
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
            DialogResult dr = MessageBox.Show(this, " (Application Yes Exit) Button - Yes  |  (Application No Exit) Button + No ", "Application CefSharp Web Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                {

                Cef.Shutdown();
                Cef.ShutdownWithoutChecks();

                }
            else
                {
                ///  cancel the closure of the form.
                e.Cancel = true;

                ///  
                /// 
                /// Application.Exit();
                /// Application Exit

                }

            }
        #endregion




        




        }
    }
