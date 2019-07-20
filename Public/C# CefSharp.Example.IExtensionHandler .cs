using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace CefSharp.Example.IExtensionHandler
    {


    public class IExtensionHandler
        {


        public class ExtensionHandler : IExtensionHandler
            {

            public Func<IExtension, bool, IBrowser> GetActiveBrowser;
            public Action<string> LoadExtensionPopup;

            public bool CanAccessBrowser(IExtension extension, IBrowser browser, bool includeIncognito, IBrowser targetBrowser)
                {
                return true;
                }
            IBrowser IExtensionHandler.GetActiveBrowser(IExtension extension, IBrowser browser, bool includeIncognito)
                {
                return GetActiveBrowser?.Invoke(extension, includeIncognito);
                return null;
                }
            public void Dispose()
                {
                GetActiveBrowser = null;
                LoadExtensionPopup = null;
                }

            public bool GetExtensionResource(IExtension extension, IBrowser browser, string file, IGetExtensionResourceCallback callback)
                {
                return true;
                }

            public bool OnBeforeBackgroundBrowser(IExtension extension, string url, IBrowserSettings settings)
                {
                return true;
                }

            public bool OnBeforeBrowser(IExtension extension, IBrowser browser, IBrowser activeBrowser, int index, string url, bool active, IWindowInfo windowInfo, IBrowserSettings settings)
                {
                 return false;

                // return true;
                }

            public void OnExtensionLoaded(IExtension extension)
                {
                var manifest = extension.Manifest;
                var browserAction = manifest["browser_action"].GetDictionary();
                if (browserAction.ContainsKey("default_popup"))
                    {
                    var popupUrl = browserAction["default_popup"].GetString();

                    popupUrl = "chrome-extension://" + extension.Identifier + "/" + popupUrl;

                    LoadExtensionPopup?.Invoke(popupUrl);
                    }
                }

            public void OnExtensionLoadFailed(CefErrorCode errorCode)
                {
                throw new NotImplementedException();
                }

            public void OnExtensionUnloaded(IExtension extension)
                {
                throw new NotImplementedException();
                }

            }


        }
    }