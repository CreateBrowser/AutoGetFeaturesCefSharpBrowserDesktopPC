using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Internals;
using CefSharp.Handler;
using CefSharp.Structs;
using CefSharp.ModelBinding;
using CefSharp.WinForms;

namespace ChromiumApplication
{
    public class LifeSpanHandler : ILifeSpanHandler
    {
        public LifeSpanHandler PopupReques { get; internal set; }

        public event Action<string> PopupRequest;
     //   public event Action<string> life_PopupRequest;

        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        //The other members of this interface I leave empty
        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IWindowInfo windowInfo, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            if (PopupRequest != null)
                PopupRequest(targetUrl);
            newBrowser = browserControl; // here I think is a problem
            return true;
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            throw new NotImplementedException();
        }
    }
}
public class BrowserLifeSpanHandler : ILifeSpanHandler
{
    public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName,
        WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo,
        IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
    {
        newBrowser = null;
        return true;
    }

    public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
    {
        //
    }

    public bool DoClose(IWebBrowser browserControl, IBrowser browser)
    {
        return false;
    }

    public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
    {
        //nothing
    }
}

