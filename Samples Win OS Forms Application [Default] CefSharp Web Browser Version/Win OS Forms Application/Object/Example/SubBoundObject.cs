using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_OS_Forms_Application.Object
    {
    public class SubBoundObject
    {
        public string SimpleProperty { get; set; }

        public SubBoundObject()
        {
            SimpleProperty = "This is a very simple property.";
        }

        public string GetMyType()
        {
            return "My Type is " + GetType();
        }

        public string EchoSimpleProperty()
        {
            return SimpleProperty;
        }
    }
}
