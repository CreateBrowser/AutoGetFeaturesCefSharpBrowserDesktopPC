/*using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using CefSharp.Structs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
*/
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using CefSharp.Enums;
using CefSharp.Event;
using CefSharp.Handler;
using CefSharp.Internals;
using CefSharp.ModelBinding;
using CefSharp.SchemeHandler;
using CefSharp.Structs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Size = CefSharp.Structs.Size;
using Win_OS_Forms_Application.Object;

namespace Win_OS_Forms_Application.Handler
    {
    public class DisplayHandler : IDisplayHandler //, IDisposable
    {
        private Control parent;
        private Form fullScreenForm;

      //  public event Action<System.Drawing.Region> RegionsChanged;

            /*
      //  public event  IList<string> FaviconUrlChange;
        void IDisposable.Dispose()
            {
          //  FaviconUrlChange = null;
            }
            */


        /*
        private Form1 statusLabel;
        private Form1 toolStripTextBoxAddress;
        private Form Message;
        private Form1 toolStripProgressBar1;
        // private Form1 ProgressBar1;
        private ToolStrip ProgressBar1;
        private double progress;
       // private string urls;
        IList<string> urls = new List<string>();
       // private Control control;
       // private Action action;
       */
        // private Form1 browserTabControl;
        //  private Form  SelectedTab;
        // private ChromiumWebBrowser OnStatusMessage;


        void IDisplayHandler.OnFullscreenModeChange(IWebBrowser browserControl, IBrowser browser, bool fullscreen)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.InvokeOnUiThreadIfRequired(() =>
            {
                if (fullscreen)
                {
                    parent = chromiumWebBrowser.Parent;
                    parent.Controls.Remove(chromiumWebBrowser);
                    fullScreenForm = new Form();
                    fullScreenForm.FormBorderStyle = FormBorderStyle.None;
                    fullScreenForm.WindowState = FormWindowState.Maximized;
                    fullScreenForm.Controls.Add(chromiumWebBrowser);
                    fullScreenForm.ShowDialog(parent.FindForm());
                }
                else
                {
                    fullScreenForm.Controls.Remove(chromiumWebBrowser);
                    parent.Controls.Add(chromiumWebBrowser);
                    fullScreenForm.Close();
                    fullScreenForm.Dispose();
                    fullScreenForm = null;
                }
            });
        }
        void IDisplayHandler.OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {
          //  this.InvokeOnUiThreadIfRequired(() => toolStripTextBoxAddress.Text = addressChangedArgs.Address);

        }

        void IDisplayHandler.OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
        {
          //  this.InvokeOnUiThreadIfRequired(() => browserTabControl.SelectedTab.Text = titleChangedArgs.Title);
        }
        // browserControl //chromiumWebBrowser
        void IDisplayHandler.OnFaviconUrlChange(IWebBrowser browserControl, IBrowser browser, IList<string> urls) 
        {
           // var handler = FaviconUrlChange;

           
            }

        void IDisplayHandler.OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
        {          
           // double ProgressBar = 0;
          //  this.InvokeOnUiThreadIfRequired(() => progress = ProgressBar);

            // this.InvokeOnUiThreadIfRequired(() => ProgressBar1 = progress);
            // string e = null;

        }

        void IDisplayHandler.OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
        {
            // this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = statusMessageArgs.Value);
        }             
       
        bool IDisplayHandler.OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            /// return false;
            return true;
        }
        bool IDisplayHandler.OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
        {
            /// text = "Sample text (true)";
           /// return true;

            /// text = "Sample text(false)";
            /// 
             return false;
        }
        bool IDisplayHandler.OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, Size newSize)
        {
             return false;

            /// return true;
        }

       

        /*
       private void InvokeOnUiThreadIfRequired(Action p)
       {

            if ( control.InvokeRequired)
           {
               control.BeginInvoke(action); //(p)action
           }
           else
           {
               action.Invoke(); //(p)action
           }
       }
       */

        }
    }


