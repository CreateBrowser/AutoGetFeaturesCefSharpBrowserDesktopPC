using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CefSharp;

namespace Example.Handler
{
    public class RequestContext : IRequestContext
    {
      
    public Func<IExtension, bool, IBrowser> GetActiveBrowser;
        
     /*
     private RequestContextSettings requestContextSettings;

        public RequestContext(RequestContextSettings requestContextSettings)
        {
            this.requestContextSettings = requestContextSettings;
        }
        */

        public string CachePath
        {
            get
            {
                return null;
              //  throw new NotImplementedException();
            }
        }

        public bool IsGlobal
        {
            get
            {
                return true;
               // throw new NotImplementedException();
            }
        }

        public bool CanSetPreference(string name)
        {
            return true;
          //  return false;
         ///   throw new NotImplementedException();
        }

        public void ClearCertificateExceptions(ICompletionCallback callback)
        {
           /// return;
            throw new NotImplementedException();
        }

        public bool ClearSchemeHandlerFactories()
        {
            return false;
            ///    throw new NotImplementedException();
        }

        public void CloseAllConnections(ICompletionCallback callback)
        {
            throw new NotImplementedException();
        }

        public bool DidLoadExtension(string extensionId)
        {

            ///  return false;
            ///  
            return true;



            // return DidLoadExtension(extensionId);
            ///  string StringUtils = null;
            /// return RequestContext.DidLoadExtension(string, ToNative(extensionId));


            ///    throw new NotImplementedException();
        }

        public void Dispose()
        {

             GetActiveBrowser = null;
        }

        public IDictionary<string, object> GetAllPreferences(bool includeDefaults)
        {
            return null;
            /// throw new NotImplementedException();
        }

        public ICookieManager GetDefaultCookieManager(ICompletionCallback callback)
        {
            return null;
            //throw new NotImplementedException();
        }

        public IExtension GetExtension(string extensionId)
        {
            return null;
         //   throw new NotImplementedException();
        }

        public bool GetExtensions(out IList<string> extensionIds)
        {
          //  int CefString = 0;
         //  bool extensions = true;
           //<CefString>
          // extensions;
           //   var success = extensions;
            /// bool ToClr = false;
          //  bool extensionIds = true;
           // extensionIds = extensions;

          ///  bool success = true;
         //  return success;
            /// extensionIds.Add();

            ///  return GetActiveBrowser();
            throw new NotImplementedException();
        }

        public object GetPreference(string name)
        {
            return true;
         ///   throw new NotImplementedException();
        }

        public bool HasExtension(string extensionId)
        {
             return true;
           ///  return false;
            ///    throw new NotImplementedException();
        }

        public bool HasPreference(string name)
        {
            return true;
         ///   throw new NotImplementedException();
        }

        public bool IsSame(IRequestContext context)
        {
            return true;
           ///  return false;
            /// 
            ///    throw new NotImplementedException();
        }

        public bool IsSharingWith(IRequestContext context)
        {
            return true;
           ///  return false;
            ///    throw new NotImplementedException();
        }

        public void LoadExtension(string rootDirectory, string manifestJson, IExtensionHandler handler)
        { 
        
             return;

            //    bool manifest = false;       

            /// CefRefPtr
            //         < CefDictionaryValue > manifest;
            //
            //      object value = null;
            //          manifest = value->GetDictionary();

            //        Exception gcnew = null;
            // throw gcnew int errorCode = 0;
            // object errorMessage = null;
            // Exception("Unable to parse JSON ErrorCode:" + Convert::ToString((int)errorCode) + "; ErrorMessage:" + StringUtils::ToClr(errorMessage));


              throw new NotImplementedException();
        }

        public void PurgePluginListCache(bool reloadPages)
        {
            throw new NotImplementedException();
        }

        public bool RegisterSchemeHandlerFactory(string schemeName, string domainName, ISchemeHandlerFactory factory)
        {
            return true;
            /// return false;
            ///   throw new NotImplementedException();
        }

        public Task<ResolveCallbackResult> ResolveHostAsync(Uri origin)
        {

            throw new NotImplementedException();
        }

        public CefErrorCode ResolveHostCached(Uri origin, out IList<string> resolvedIpAddresses)
        {
            throw new NotImplementedException();
        }

        public bool SetPreference(string name, object value, out string error)
        {
           //// return null;
            throw new NotImplementedException();
        }
    }
}
