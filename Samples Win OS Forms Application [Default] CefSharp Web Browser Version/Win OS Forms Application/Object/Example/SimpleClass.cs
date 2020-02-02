using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace Win_OS_Forms_Application.Object
    {
    public class SimpleClass
    {
        public IJavascriptCallback Callback { get; set; }
        public string TestString { get; set; }

        public IList<SimpleSubClass> SubClasses { get; set; }
    }
}
