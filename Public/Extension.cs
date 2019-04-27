using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace Example.Handler.Extension
{
    public class Extension : IExtension
    {
        private string showModalDialog;
        private string v;

        public Extension(string v, string showModalDialog)
        {
            this.v = v;
            this.showModalDialog = showModalDialog;
        }

        public string Identifier
        {
            get
            {
                return null;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return true;
                //                throw new NotImplementedException();
            }
        }

        public IRequestContext LoaderContext
        {
            get
            {
                return null;
                //  throw new NotImplementedException();
            }
        }

        public IDictionary<string, IValue> Manifest
        {
            get
            {
                return null;
             //   throw new NotImplementedException();
            }
        }

        public string Path
        {
            get
            {
                return null;
                // throw new NotImplementedException();
            }
        }

        public bool IsSame(IExtension that)
        {
            return true;
            /// throw new NotImplementedException();
        }

        public void Unload()
        {
           /// return;
            // throw new NotImplementedException();
        }
    }
}
