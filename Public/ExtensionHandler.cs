using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace ChromiumApplication.Main.Handler.Extension
{
    public class ExtensionHandler : IExtensionHandler
    {
        public Func<IExtension, bool, IBrowser> GetActiveBrowser;
        public Action<string> LoadExtensionPopup;

        public void Dispose()
        {
            GetActiveBrowser = null;
            LoadExtensionPopup = null;
        }

        /// <summary>
        /// https://chrome.google.com/webstore/detail/screencastify-screen-vide/mmeijimgabbpbgpdklnllpncmdofkcpn?hl=en
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="browser"></param>
        /// <param name="includeIncognito"></param>
        /// <param name="targetBrowser"></param>
        /// <returns></returns>

        bool IExtensionHandler.CanAccessBrowser(IExtension extension, IBrowser browser, bool includeIncognito, IBrowser targetBrowser)
        {
            /// return false;
            /// 
            return true;
        }

        IBrowser IExtensionHandler.GetActiveBrowser(IExtension extension, IBrowser browser, bool includeIncognito)
        {
            return GetActiveBrowser?.Invoke(extension, includeIncognito);
            return null;
        }

        bool IExtensionHandler.GetExtensionResource(IExtension extension, IBrowser browser, string file, IGetExtensionResourceCallback callback)
        {
            ///  return false;
            ///  
            return true;
        }

        bool IExtensionHandler.OnBeforeBackgroundBrowser(IExtension extension, string url, IBrowserSettings settings)
        {
           ///   return false;
            ///  
            return true;
        }

        bool IExtensionHandler.OnBeforeBrowser(IExtension extension, IBrowser browser, IBrowser activeBrowser, int index, string url, bool active, IWindowInfo windowInfo, IBrowserSettings settings)
        {


            // return false;
            ///
            /// 
            /// https://chrome.google.com/webstore/detail/screencastify-screen-vide/mmeijimgabbpbgpdklnllpncmdofkcpn?hl=en
            /// 
            /// chrome-extension://mmeijimgabbpbgpdklnllpncmdofkcpn
            ///
             return true;
        }

        void IExtensionHandler.OnExtensionLoaded(IExtension extension)
        {             
                var manifest = extension.Manifest;
                var browserAction = manifest["browser_action"].GetDictionary();
                if (browserAction.ContainsKey("default_popup"))
                {
                    var popupUrl = browserAction["default_popup"].GetString();

                    popupUrl = "chrome-extension://" + extension.Identifier + "/" + popupUrl;
 
                    LoadExtensionPopup?.Invoke(popupUrl);
                }
 


            //var manifest = extension.Manifest;
            //var browserAction = manifest["browser_action"].GetDictionary();
            //if (browserAction.ContainsKey("default_popup"))
            //{
            //    var popupUrl = browserAction["default_popup"].GetString();

            //    popupUrl = "chrome-extension://" + extension.Identifier + "/" + popupUrl;

            //    LoadExtensionPopup?.Invoke(popupUrl);
            //}

            //// var popupUrl = "chrome-extension://" + extension.Identifier + "/";
            //// LoadExtensionPopup?.Invoke(popupUrl);

        }

        void IExtensionHandler.OnExtensionLoadFailed(CefErrorCode errorCode)
        {

        }

        void IExtensionHandler.OnExtensionUnloaded(IExtension extension)
        {
            return;

        }
    }
}
