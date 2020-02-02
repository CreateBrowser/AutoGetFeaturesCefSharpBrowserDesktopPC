using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace Win_OS_Forms_Application.Handler.Handlers
{
    public class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
        void IRenderProcessMessageHandler.OnFocusedNodeChanged(IWebBrowser browserControl, IBrowser browser, IFrame frame, IDomNode node)
        {
            var message = node == null ? "lost focus" : node.ToString();

            Console.WriteLine("OnFocusedNodeChanged() - " + message);
        }

        void IRenderProcessMessageHandler.OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            // called for every created V8Context, check IFrame.IsMain to determine that V8Context is from Main frame
            if (frame.IsMain)
            {
                //const string script = "document.addEventListener('DOMContentLoaded', function(){ alert('DomLoaded'); });";

                //frame.ExecuteJavaScriptAsync(script);
            }
        }

        void IRenderProcessMessageHandler.OnContextReleased(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //The V8Context is about to be released, use this notification to cancel any long running tasks your might have
        }

        void IRenderProcessMessageHandler.OnUncaughtException(IWebBrowser browserControl, IBrowser browser, IFrame frame, JavascriptException exception)
        {
            Console.WriteLine("OnUncaughtException() - " + exception.Message);
        }
    }
}
