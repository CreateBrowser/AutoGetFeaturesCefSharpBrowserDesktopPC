using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace #
public partial class Form1 : Form    
{     
public Form1(){
InitializeComponent();
//// Set Google API keys, used for Geolocation requests sans GPS.  See http://www.chromium.org/developers/how-tos/api-keys
     Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "#");
     Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_ID", "#");
     Environment.SetEnvironmentVariable("GOOGLE_DEFAULT_CLIENT_SECRET", "#");
//  Text = "CefSharp Web Browser";
ShowIcon = false;
}
}
