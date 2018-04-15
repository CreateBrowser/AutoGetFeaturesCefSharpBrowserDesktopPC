using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromiumApplication.Properties;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace ChromiumApplication
{
    public class CefSharpSchemeHandlerFactory : ISchemeHandlerFactory
    {

        


        public const string SchemeName = "custom";

        private static readonly IDictionary<string, string> ResourceDictionary;

        static CefSharpSchemeHandlerFactory()
        {
            ResourceDictionary = new Dictionary<string, string> {
            { "Resources/home.html", Resources.home_html },
            { "Resources/bootstrap/bootstrap.min.css", Resources.bootstrap_min_css },
            { "Resources/bootstrap/bootstrap.min.js", Resources.bootstrap_min_js },
            { "Resources/BindingTest.html", Resources.BindingTest },
            { "Resources/ExceptionTest.html", Resources.ExceptionTest },
            { "Resources/PopupTest.html", Resources.PopupTest },
            { "Resources/SchemeTest.html", Resources.SchemeTest } };
        }

        public static string SchemeNameTest { get; internal set; }
        public string fileExtension { get; private set; }
        public string htmlString { get; private set; }
        public string mimeType { get; private set; }
        public Stream stream { get; private set; }

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            //Notes:

            ResourceHandler.FromStream(stream, mimeType);
            ResourceHandler.FromString(htmlString, includePreamble: true, mimeType: ResourceHandler.GetMimeType(fileExtension));
            ResourceHandler.FromFilePath("CefSharp.Core.xml", mimeType);

            // - The 'host' portion is entirely ignored by this scheme handler.
            // - If you register a ISchemeHandlerFactory for http/https schemes you should also specify a domain name
            // - Avoid doing lots of processing in this method as it will affect performance.
            // - Uses the Default ResourceHandler implementation

            var uri = new Uri(request.Url);
            var fileName = uri.AbsolutePath;

            string resource;
            if (ResourceDictionary.TryGetValue(fileName, out resource) && !string.IsNullOrEmpty(resource))
            {
                var fileExtension = Path.GetExtension(fileName);
                return ResourceHandler.FromString(resource, fileExtension);
            }

            return null;
        }
    }

    class CustomRequestContextHandler : RequestContextSettings
    {
    }
}


  //  public class CefSharpSchemeHandlerFactory : ISchemeHandlerFactory { public const string SchemeName = "custom"; public const string SchemeNameTest = "test";
  //Display the debug.log file in the browser  // return ResourceHandler.FromFileName("CefSharp.Core.xml", ".xml");
  //  public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request) { if (schemeName == SchemeName && request.Url.EndsWith("CefSharp.Core.xml", System.StringComparison.OrdinalIgnoreCase)) { } return new CefSharp.Example.CefSharpSchemeHandler(); }  }  }