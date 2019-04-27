using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.RenderProcess;

namespace ChromiumApplication.Main.AGET
{
    public class IV8Exception : V8Exception //IV8Context
    {
        public IV8Exception(int endColumn, int endPosition, int lineNumber, string message, string scriptResourceName, string sourceLine, int startColumn, int startPosition) : base(endColumn, endPosition, lineNumber, message, scriptResourceName, sourceLine, startColumn, startPosition)
        { return;
        }

        public bool Execute(string code, string scriptUrl, int startLine, out V8Exception exception)
        {

           // return;
              throw new NotImplementedException();
        }
    }
}
