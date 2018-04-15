using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromiumApplication
{
    public class ASchemeHandler
    {
        internal IEnumerable<IUriInterceptor> _interceptors { get; private set; }

        public bool ProcessRequestAsync(IRequest request, SchemeHandlerResponse response, OnRequestCompletedHandler requestCompletedCallback)
        {
            Uri uri = new Uri(request.Url);

            foreach (IUriInterceptor interceptor in _interceptors)
            {

                if (interceptor.canHandle(uri))
                {
                    interceptor.handleRequest(request, response);
                    requestCompletedCallback.Invoke();
                    return true;
                }
            }

            return false;
        }
    }

    internal interface IUriInterceptor
    {
        bool canHandle(Uri uri);
        void handleRequest(IRequest request, SchemeHandlerResponse response);
    }

    public class OnRequestCompletedHandler
    {
        internal void Invoke()
        {
            throw new NotImplementedException();
        }
    }

    public class SchemeHandlerResponse
    {
    }
}
