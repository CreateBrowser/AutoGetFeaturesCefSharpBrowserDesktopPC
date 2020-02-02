using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;


using CefSharp;
using CefSharp.WinForms.Internals;
using CefSharp.Web;

namespace Win_OS_Forms_Application.Handler.Example
    {
    public class MainAuthenticationIRequestHandler : IRequestHandler, IResourceRequestHandler
        {


        private string userName;
        private string password;

        /// System.Collections.Specialized.NameValueCollection ResponseHeaders { get; set; }
        /// public MainAuthenticationIRequestHandler(string userName, string password)
        /// 
        /// private string originUrl;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>


        public MainAuthenticationIRequestHandler(string userName, string password /* , string originUrl */ )
            {
            this.userName = userName;
            this.password = password;
            /* this.originUrl = originUrl; */
            }

        bool IRequestHandler.OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
            {

            return false;
            }

        bool IRequestHandler.OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {

            /// return false;
            return OnOpenUrlFromTab(chromiumWebBrowser, browser, frame, targetUrl, targetDisposition, userGesture);
            }
        protected virtual bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
            return false;
            }

        IResourceRequestHandler IRequestHandler.GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
            {

            //NOTE: In most cases you examine the request.Url and only handle requests you are interested in

            /// if (request.Url.ToLower().StartsWith("cefsharp://cefsharp/") // https://cefsharp.example
            /// || request.Url.ToLower().StartsWith("mailto:")
            /// || request.Url.ToLower().StartsWith("https://googlechrome.github.io/samples/service-worker/"))
            /// {
            ///  return new CefSharp.Example.Handlers.ExampleResourceRequestHandler();
            ///  }


            return null;
            }


        bool IRequestHandler.GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {

            #region GetAuthCredentials
            // https://stackoverflow.com/questions/55335691/how-to-fix-infinite-dialog-loop-on-closing-when-handling-a-authentication-reque
            //
            // The Requesthandler implementation with "GetAuthCredentials":


            /*

                       bool handled = false;

                        ChromiumWebBrowser b = browserControl as ChromiumWebBrowser;
                        b.BeginInvoke((MethodInvoker)delegate
                        {
                            AuthenticationDialog dlg = new AuthenticationDialog(host);
                            dlg.ShowDialog();

                            if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                callback.Continue(dlg.UserName, dlg.Password);
                                handled = true;
                            }
                        });

                        return handled;
            */

            /*
            CefSharp.WinForms.ChromiumWebBrowser b = chromiumWebBrowser as CefSharp.WinForms.ChromiumWebBrowser; //casts the given browsercontrol as chromiumwebbrowser, to acces the .beginInvoke method
            b.BeginInvoke((MethodInvoker)delegate
                {
                    //creates an instance of the authentication dialog to get the user credentials
                    CefSharp_Web_Browser.AuthenticationDialog dlg = new CefSharp_Web_Browser.AuthenticationDialog(host);
                    dlg.ShowDialog();


                    if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)  //if the sign-in button is clicked
                        {
                        callback.Continue(dlg.UserName, dlg.Password);
                        }
                    else // if the close or cancel button on field is clicked
                        {
                        Cef.Shutdown();
                        callback.Cancel();
                        }
                    });
            return true;
            */
            #endregion



            callback.Continue(userName, password);
            return true;

            // callback.Dispose();
            // callback.Continue(userName, password);
            // return true;
            }

        bool IRequestHandler.OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)

            {
            //NOTE: If you do not wish to implement this method returning false is the default behaviour
            // We also suggest you explicitly Dispose of the callback as it wraps an unmanaged resource.
            //callback.Dispose();
            //return false;

            //NOTE: When executing the callback in an async fashion need to check to see if it's disposed

            ///  if (!callback.IsDisposed)
            ///   {
            ///   using (callback)
            ///       {
            //Accept Request to raise Quota
            //callback.Continue(true);
            //return true;
            ///      }
            ///  }

            return false;
            }

        bool IRequestHandler.OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
            {
            return false;
            }

        bool IRequestHandler.OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
            {

            ///  callback.Dispose();
            // return true;
            return false;

            }
        void IRequestHandler.OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status)
            {
            // TODO: Add your own code here for handling scenarios where the Render Process terminated for one reason or another.
            //  browserControl.Load(CefExample.RenderProcessCrashedUrl);

            // TODO: Add your own code here for handling scenarios where the Render Process terminated for one reason or another.
            /// chromiumWebBrowser.Load(CefExample.RenderProcessCrashedUrl);

            }
        void IRequestHandler.OnPluginCrashed(IWebBrowser chromiumWebBrowser, IBrowser browser, string pluginPath)
            {
            // TODO: Add your own code here for handling scenarios where a plugin crashed, for one reason or another.

            //  PluginPath = pluginPath();

            //pluginPolicy = PluginPolicy.Disable;
            //return true;

            // pluginPath = PluginPolicy.Allow;

            // throw new NotImplementedException();
            // var Allow = 0;
            }

        void IRequestHandler.OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
            {

            }


        /// <summary>
        /// IResourceRequestHandler
        /// </summary>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 



        ICookieAccessFilter IResourceRequestHandler.GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
            {
            return null;
            }

        CefReturnValue IResourceRequestHandler.OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
            {


            //request.InitializePostData();
            //request.Headers.Add(name: "", value: "");
            //
            ///
            //
            //var headers = request.Headers;
            //headers["User-Agent"] = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0_1 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 Mobile/14A403 Safari/602.1";
            //request.Headers = headers;

            return CefReturnValue.Continue;



            #region OnBeforeResourceLoad

            ///   Uri url;
            ///   if (Uri.TryCreate(request.Url, UriKind.Absolute, out url) == false)
            ///   {
            //If we're unable to parse the Uri then cancel the request
            // avoid throwing any exceptions here as we're being called by unmanaged code
            ///      return CefReturnValue.Cancel;
            ///  }

            //Example of how to set Referer
            // Same should work when setting any header

            // For this example only set Referer when using our custom scheme
            ///  if (url.Scheme == CefSharpSchemeHandlerFactory.SchemeName)
            ///  {
            //Referrer is now set using it's own method (was previously set in headers before)
            ///      request.SetReferrer("https://www.google.com", ReferrerPolicy.Default);
            ///  }



            //Example of setting User-Agent in every request.
            //var headers = request.Headers;

            //var userAgent = headers["User-Agent"];
            //headers["User-Agent"] = userAgent + " CefSharp";

            //request.Headers = headers;

            //NOTE: If you do not wish to implement this method returning false is the default behaviour
            // We also suggest you explicitly Dispose of the callback as it wraps an unmanaged resource.
            //callback.Dispose();
            //return false;

            //NOTE: When executing the callback in an async fashion need to check to see if it's disposed

            /*
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    if (request.Method == "POST")
                    {
                        using (var postData = request.PostData)
                        {
                            if (postData != null)
                            {
                                var elements = postData.Elements;

                                var charSet = request.GetCharSet();

                                foreach (var element in elements)
                                {
                                    if (element.Type == PostDataElementType.Bytes)
                                    {
                                        var body = element.GetBody(charSet);
                                    }
                                }
                            }
                        }
                    }
                    */

            //Note to Redirect simply set the request Url
            //if (request.Url.StartsWith("https://www.google.com", StringComparison.OrdinalIgnoreCase))
            //{
            //    request.Url = "https://github.com/";
            //}

            //Callback in async fashion
            //callback.Continue(true);
            //return CefReturnValue.ContinueAsync;


            ///     }
            ///     }
            ///
            /// return CefReturnValue.Continue;

            #endregion


            }

        IResourceHandler IResourceRequestHandler.GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
            {

            return null;
            }

        void IResourceRequestHandler.OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
            {

            }

        bool IResourceRequestHandler.OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
            {
            return false;

            // return true;

            }

        IResponseFilter IResourceRequestHandler.GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
            {
            return null;
            }

        void IResourceRequestHandler.OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            {

            }

        bool IResourceRequestHandler.OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
            {
            //   return request.Url.StartsWith("mailto");

            // return false;


            return true;
            }





        /// <summary>
        /// ICookieAccessFilter
        /// </summary>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="request"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>


        }

    }
    