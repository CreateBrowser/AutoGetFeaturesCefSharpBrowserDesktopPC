ublic void loadUrl()
        {
            
            #region //Preference for Proxy
            if (proxyChechbox.IsChecked == true)
            {
                currentproxyaddress = Convert.ToString(proxyListbox.SelectedValue);
 
 
                
 
                Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    var rc = Browser.GetBrowser().GetHost().RequestContext;
                    var v = new Dictionary<string, object>();
                    v["mode"] = "fixed_servers";
                    v["server"] = "" + currentproxyaddress;
                    string error;
                    bool success = rc.SetPreference("proxy", v, out error);
                    rc.GetAllPreferences(true);
                    Trace.WriteLine("Loading Page with PROXY SERVER: " + currentproxyaddress);   
                });
 
                
 
            }
            else
            {
                currentproxyaddress = "direct://";
 
                Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    var rc = Browser.GetBrowser().GetHost().RequestContext;
                    var v = new Dictionary<string, object>();
                    v["mode"] = "fixed_servers";
                    v["server"] = "" + currentproxyaddress;
                    string error;
                    bool success = rc.SetPreference("proxy", v, out error);
                    rc.GetAllPreferences(true);
                    Trace.WriteLine("Loading with NO PROXY over " + currentproxyaddress);
 
                });
            }
 
            #endregion
 
            //populate Browser Address and reload the goatcanon
            Browser.Address = txtBox_loadUrl.Text;
            Browser.Load(txtBox_loadUrl.Text);
 
        }






        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            if (targetDisposition == WindowOpenDisposition.NewPopup)
            {

                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

                ChromiumWebBrowser chromiumBrowser = null;

                var windowX = (windowInfo.X == int.MinValue) ? double.NaN : windowInfo.X;
                var windowY = (windowInfo.Y == int.MinValue) ? double.NaN : windowInfo.Y;
                var windowWidth = (windowInfo.Width == int.MinValue) ? double.NaN : windowInfo.Width;
                var windowHeight = (windowInfo.Height == int.MinValue) ? double.NaN : windowInfo.Height;

                chromiumWebBrowser.Dispatcher.Invoke(() =>
                {
                    var owner = Window.GetWindow(chromiumWebBrowser);
                    chromiumBrowser = new ChromiumWebBrowser
                    {
                        Address = targetUrl,
                    };

                    chromiumBrowser.SetAsPopup();
                    chromiumBrowser.LifeSpanHandler = this;

                    var popup = new Window
                    {
                        Left = windowX,
                        Top = windowY,
                        Width = windowWidth,
                        Height = windowHeight,
                        Content = ChromiumWebBrowser,
                        Owner = owner,
                        Title = targetFrameName
                    };

                    var windowInteropHelper = new WindowInteropHelper(popup);
                    //Create the handle Window handle (In WPF there's only one handle per window, not per control)
                    var handle = windowInteropHelper.EnsureHandle();

                    //The parentHandle value will be used to identify monitor info and to act as the parent window for dialogs,
                    //context menus, etc. If parentHandle is not provided then the main screen monitor will be used and some
                    //functionality that requires a parent window may not function correctly.
                    windowInfo.SetAsWindowless(handle, true);

                    popup.Closed += (o, e) =>
                    {
                        var w = o as Window;
                        if (w != null && w.Content is IWebBrowser)
                        {
                            (w.Content as IWebBrowser).Dispose();
                            w.Content = null;
                        }
                    };
                });

                newBrowser = ChromiumWebBrowser;

                return true;
            }
            else
            {

                return false;
            }
        }















CefSharp Nuget Package

C#

CefSharp V53.0.1 (CefCustomObject.cs) details

  public Form1()
        {
            InitializeComponent();

      // Start the browser after initialize global component
     // Register an object in javascript named "cefCustomObject" with function of the CefCustomObject class :3

            InitializeChromium();

           chromeBrowser.RegisterJsObject("cefCustomObject", new CefCustomObject(chromeBrowser, this));
        }


Background:
  CefSharp is a .Net wrapping library for CEF (Chromium Embedded Framework) https://bitbucket.org/chromiumembedded/cef
  CEF is a C/C++ library that allows developers to embed the HTML content rendering strengths of Google's Chrome open source WebKit engine (Chromium).

Post Installation:
  - Read the release notes for your version https://github.com/cefsharp/CefSharp/releases (Any known issues will be listed here)
  - Set either `x86` or x64` as your target architecture. `AnyCpu` support was added in `51`, please see the release notes for details as additional steps are required to make it work.
  - After installing the `Nuget` package we recommend closing Visual Studio completely and then reopening (This ensures your references show up and you have full intellisense).
  - Check your output `\bin` directory to make sure the appropriate references have been copied.
  - Build fails even though packages are installed. Short term rebuild again and everything should be find. Long term we recommend reading http://www.xavierdecoster.com/migrate-away-from-msbuild-based-nuget-package-restore
  - If you are using `WPF`, please note there is no Designer support at this point in time, see the FAQ for details.
  
Deployment:
  - Make sure `Visual C++ 2013` is installed (`x86` or x64` depending on your build) or you package the runtime dlls with your application, see the FAQ for details.
  
What's New:
  See https://github.com/cefsharp/CefSharp/wiki/ChangeLog
  IMPORTANT NOTE - .NET Framework 4.5.2 is now required.  
  IMPORTANT NOTE - Chromium has removed support for Windows XP/2003 and Windows Vista/Server 2008 (non R2).
  
  The Microsoft .NET Framework 4.5.2 Developer Pack for Visual Studio 2012 and Visual Studio 2013 is available here: 
  https://www.microsoft.com/en-gb/download/details.aspx?id=42637

Basic Troubleshooting:
  - Minimum of .Net 4.5.2
  - Make sure `VC++ 2013 Redist` is installed (either `x86` or `x64` depending on your application)
  - Please ensure your binaries directory contains these required dependencies:
    * libcef.dll (CEF code)
    * icudtl.dat (Unicode Support data)
    * CefSharp.Core.dll, CefSharp.dll, 
      CefSharp.BrowserSubprocess.exe, CefSharp.BrowserSubProcess.Core.dll
        - These are required CefSharp binaries that are the common core logic binaries of CefSharp.
    * One of the following UI presentation approaches:
        * CefSharp.WinForms.dll
        * CefSharp.Wpf.dll
        * CefSharp.OffScreen.dll
  - Additional optional CEF files are described at: https://github.com/cefsharp/cef-binary/blob/master/README.txt#L82
    NOTE: CefSharp does not currently support CEF sandboxing.

For further help please read the following content:
  - CefSharp Tutorials https://github.com/cefsharp/CefSharp.Tutorial
  - CefSharp GitHub https://github.com/cefsharp/CefSharp
  - CefSharp's Wiki on github (https://github.com/cefsharp/CefSharp/wiki)
  - Minimal Example Projects showing the browser in action (https://github.com/cefsharp/CefSharp.MinimalExample)
  - FAQ: https://github.com/cefsharp/CefSharp/wiki/Frequently-asked-questions
  - Troubleshooting guide (https://github.com/cefsharp/CefSharp/wiki/Trouble-Shooting)
  - Google Groups (https://groups.google.com/forum/#!forum/cefsharp) - Historic reference only
  - CefSharp vs Cef (https://github.com/cefsharp/CefSharp/blob/master/CONTRIBUTING.md#cefsharp-vs-cef)
  - Join the active community and ask your question on Gitter Chat (https://gitter.im/cefsharp/CefSharp)
  - If you have a reproducible bug then please open an issue on `GitHub`

Please consider giving back, it's only with your help will this project to continue.

Regards,
CefSharp Team
