using System;
using System.Security.Cryptography.X509Certificates;
using CefSharp;
using CefSharp.Handler;
using CefSharp.SchemeHandler;
using CefSharp.Structs;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace ChromiumApplication
{
    public class BoundObject
    {
        public class AsyncBoundObject
        {
            //We expect an exception here, so tell VS to ignore
            [System.Diagnostics.DebuggerHidden]
            public void Error()
            {
                throw new Exception("This is an exception coming from C#");
            }

            //We expect an exception here, so tell VS to ignore
            [System.Diagnostics.DebuggerHidden]
            public int Div(int divident, int divisor)
            {
                return divident / divisor;
            }
        }
    }

    class JsDialogHandler : IJsDialogHandler
    {
        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            throw new NotImplementedException();
        }

        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            throw new NotImplementedException();
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {
            throw new NotImplementedException();
        }
    }
    public class API
    {
        public void AddApp()
        {
            Console.WriteLine("something");
        }
    }
    class args
    {
        public static string Title { get; internal set; }
    }


    class account
    {
        public static string id { get; internal set; }
    }

    class myForm
    {
        internal static IWebBrowser NewPage(string targetUrl)
        {
            throw new NotImplementedException();
        }
    }
}