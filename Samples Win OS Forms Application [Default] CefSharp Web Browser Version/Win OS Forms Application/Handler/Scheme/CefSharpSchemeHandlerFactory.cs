// Copyright © 2013 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.IO;
using CefSharp;

using Win_OS_Forms_Application.Properties;


namespace Win_OS_Forms_Application.Handler.Scheme
    {
    public class CefSharpSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public const string SchemeName = "custom";
      ///  public const string SchemeNameTest = "test";

        private static readonly IDictionary<string, string> ResourceDictionary;

        static CefSharpSchemeHandlerFactory()
        {
            ResourceDictionary = new Dictionary<string, string>
            {
               // { "/home.html", Resources.home_html },
              //  { "/other_tests.html", Resources.other_tests_html }

              ///  { "/assets/css/shCore.css", Resources.assets_css_shCore_css },
              ///  { "/ExceptionTest.html", Resources.ExceptionTest },
              ///  { "/PopupTest.html", Resources.PopupTest },
              ///  { "/SchemeTest.html", Resources.SchemeTest }
               
            };
        }

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            //Notes:
            // - The 'host' portion is entirely ignored by this scheme handler.
            // - If you register a ISchemeHandlerFactory for http/https schemes you should also specify a domain name
            // - Avoid doing lots of processing in this method as it will affect performance.
            // - Use the Default ResourceHandler implementation

            var uri = new Uri(request.Url);
            var fileName = uri.AbsolutePath;

            //Load a file directly from Disk
            if (fileName.EndsWith("CefSharp.Core.xml", StringComparison.OrdinalIgnoreCase))
            {
                //Convenient helper method to lookup the mimeType
                var mimeType = ResourceHandler.GetMimeType(".xml");
                //Load a resource handler for CefSharp.Core.xml
                //mimeType is optional and will default to text/html
                return ResourceHandler.FromFilePath("CefSharp.Core.xml", mimeType, autoDisposeStream: true);
            }

            if (uri.Host == "cefsharp.com" && schemeName == "https" && (string.Equals(fileName, "/PostDataTest.html", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fileName, "/PostDataAjaxTest.html", StringComparison.OrdinalIgnoreCase)))
            {
                return new CefSharpSchemeHandler();
            }

            if (string.Equals(fileName, "/EmptyResponseFilterTest.html", StringComparison.OrdinalIgnoreCase))
            {
                return ResourceHandler.FromString("", ".html");
            }

            string resource;
            if (ResourceDictionary.TryGetValue(fileName, out resource) && !string.IsNullOrEmpty(resource))
            {
                var fileExtension = Path.GetExtension(fileName);
                return ResourceHandler.FromString(resource, includePreamble: true, mimeType: ResourceHandler.GetMimeType(fileExtension));
            }

            return null;
        }
    }
}