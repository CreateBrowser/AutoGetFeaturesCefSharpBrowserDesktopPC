using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromiumApplication
{



    public class CookieVisitor : ICookieVisitor
    {
        public CookieVisitor()
        {
            IsReady = true;
        }

        public CookieVisitor(Func<object, object> p)
        {
            this.p = p;
        }

        public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
        {
            lock (this)
            {
                if (_cookies.ContainsKey(cookie.Name))
                {
                    _cookies[cookie.Name] = new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
                    _cookies[cookie.Name].Name = cookie.Name;
                    _cookies[cookie.Name].Value = cookie.Value;
                    _cookies[cookie.Name].Path = cookie.Path;
                    _cookies[cookie.Name].Domain = cookie.Domain;
                }
                else _cookies.Add(cookie.Name, new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                //fire when complete
                IsReady = count == total - 1;   //
            }
            return true;
        }

        public void Dispose()
        {
            return;
        }

        Dictionary<string, System.Net.Cookie> _cookies = new Dictionary<string, System.Net.Cookie>();
        private Func<object, object> p;

        public Dictionary<string, System.Net.Cookie> AllCookies { get { return _cookies; } }
        public bool IsReady { get; set; }
        public System.Net.Cookie this[string name]
        {
            get { return _cookies.ContainsKey(name) ? _cookies[name] : null; }
        }
        ~CookieVisitor()
        {
        }
    }


}