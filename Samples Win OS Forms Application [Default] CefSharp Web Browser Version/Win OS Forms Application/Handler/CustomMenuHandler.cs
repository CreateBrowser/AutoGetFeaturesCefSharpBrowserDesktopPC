/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using System.Windows.Forms;
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Win_OS_Forms_Application.Properties;


using CefSharp;
using CefSharp.WinForms;

using Win_OS_Forms_Application.Handler.Example.Customize;
using Win_OS_Forms_Application.Handler.Example.Customize.Request;




//using OSIRT.UI.ViewSource;
//using OSIRT.Helpers;

namespace Win_OS_Forms_Application.Handler
    {
    public class CustomMenuHandler : IContextMenuHandler    {

        string UnfilteredLinkUrl { get; }
        public int Find { get; private set; }
        public int CanTranslate { get; private set; }
        public int OpenLinkInNewTab { get; private set; }

        private string copyFrameUrl;
        private const int SaveImageGet = 26500;
        private const int ShowDevTools = 50;
        private const int CloseDevTools = 51;
        private const int SaveImageAs = 26503;
        private const int SaveAsPdf = 26504;
        private const int SaveLinkAs = 26505;
        private const int CopyLinkAddress = 26506;
        private const int CefSharpSupportedChromeExtensions = 30;
        private const int CefSharpVersion = 31;
        private const int translate = 34;
        private const int find = 67;
        private const int AddToDictionary = 68;

        ///  private const int not = 66;
        /// private const int Print = 660;
        /// 
        //   private const int OpenPopupFromLink  = 35;
        //   private const int OpenLinkInNewTab = 26507;


        //  private const int CopyImgLocation = 63;

        public event EventHandler OpenInNewTabContextMenu = delegate { };
        //  public event EventHandler CopyImageLocation = delegate { };


        private string lastSelText = " Get New ";
      //  private const string home_url = "http://github.com/cefsharp/CefSharp";


        Form1 myForm;

        public CustomMenuHandler(Form1 form)
        {
            myForm = form;
        }

        public CustomMenuHandler()
        {
         }

        /// <summary>
        /// Event happens before context menu appears
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {

            //set defaults from premade context menu


            /*
            if (parameters.UnfilteredLinkUrl != "")
            {

            }

            if (parameters.SelectionText != "")
            {

            }
            */

            // Miscellaneous.

            Find = 130;
            CanTranslate = 1 << 7;
            OpenLinkInNewTab = 80;

            // Remove any existent option using the Clear method of the model

            //    // Edit 

            //  model.Clear();

            model.Clear();



           


            // save text
            lastSelText = parameters.SelectionText;

            //  Console.WriteLine("Context menu opened !");

            Console.Write("Context menu opened !");


            //Add new custom menu items
           

            if (!string.IsNullOrEmpty(parameters.UnfilteredLinkUrl))
            {
                //model.AddItem((CefMenuCommand)OpenLinkInNewTab, "Open link in new tab");
                //  model.AddItem((CefMenuCommand)26507, "Open link in new tab");
               // model.AddSeparator();

            }



            // You can add a separator in case that there are more items on the list
            if (model.Count > 0)
            {
                model.AddSeparator();
            }
            //Add new custom menu items
            if (parameters.FrameUrl != null)
            {
                copyFrameUrl = parameters.FrameUrl;


            }

            // Removing existing menu item
            // bool removed = model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            if (parameters.LinkUrl != "")
            {
                //  model.AddItem((CefMenuCommand)SaveLinkAs, "Save As Link");
                  model.AddItem((CefMenuCommand)SaveImageAs, "Save as images");
                 model.AddItem((CefMenuCommand)CopyLinkAddress, "Copy Link Address");
                // model.AddItem((CefMenuCommand)OpenLinkInNewTab, "Open link in new tab");

                // model.AddItem((CefMenuCommand)50, "Developer Tools");
                //  model.AddItem((CefMenuCommand)51, "Close Developer Tools");
                //    model.AddSeparator();

               
                model.AddSeparator();


            }

            





            // Add another example item
            model.AddItem((CefMenuCommand)60, "Back");
            model.AddItem((CefMenuCommand)61, "Forward");
            model.AddItem((CefMenuCommand)62, "Reload");
            model.AddItem((CefMenuCommand)64, "Stop");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)67, "Find");
            model.AddItem((CefMenuCommand)63, "View Page Source");
            model.AddItem((CefMenuCommand)ShowDevTools, "Developer Tools");
           /// model.AddSeparator();
           /// model.AddItem((CefMenuCommand)68, "Add To Dictionary");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)SaveImageAs, "Save As Images");
            model.AddItem((CefMenuCommand)SaveImageGet, "Save As Page");
            model.AddItem((CefMenuCommand)SaveLinkAs, "Save As Link");

            model.AddSeparator();

            model.AddItem((CefMenuCommand)5, "Cut");
            model.AddItem((CefMenuCommand)6, "Copy");
            model.AddItem((CefMenuCommand)7, "Paste");
            model.AddItem((CefMenuCommand)8, "Delete");
            model.AddItem((CefMenuCommand)9, "SelectAll");

            model.AddSeparator();

            model.AddItem((CefMenuCommand)10, "Undo");
            model.AddItem((CefMenuCommand)11, "Redo");                        

            model.AddSeparator();

            model.AddItem((CefMenuCommand)CefSharpSupportedChromeExtensions, "CefSharp Supported Chrome Extensions");
            model.AddItem((CefMenuCommand)CefSharpVersion, "CefSharp Version");

           // model.AddSeparator();

           // model.AddItem((CefMenuCommand)1, "Translate");
           // model.AddItem((CefMenuCommand)130, "Find");

            model.AddSeparator();

            model.AddItem((CefMenuCommand)12, "Baidu Search Chinese");
            model.AddItem((CefMenuCommand)13, "Google Search Chinese");
            model.AddItem((CefMenuCommand)14, "Google Search Egypt");

            // model.AddItem((CefMenuCommand)translate, "Translate");
            // model.AddItem((CefMenuCommand)00, "@");
           //  model.AddItem((CefMenuCommand)34, "GetPlugins");


            //settings.CefCommandLineArgs.Add("enable-translate", "1");

            /*
            model.AddItem((CefMenuCommand)13, "@");

            model.AddSeparator();
            model.AddSeparator();
            model.AddSeparator();
            model.AddSeparator();
            model.AddSeparator();
            model.AddSeparator();
            model.AddSeparator();
            model.AddSeparator();

            */


            //  model.AddItem((CefMenuCommand)12, "Google CN");

            /*
            model.AddItem((CefMenuCommand)13, "#");
            model.AddItem((CefMenuCommand)14, "#");
            model.AddItem((CefMenuCommand)15, "#");
            model.AddItem((CefMenuCommand)16, "#");
            model.AddItem((CefMenuCommand)17, "#");
            model.AddItem((CefMenuCommand)18, "#");
            model.AddItem((CefMenuCommand)19, "#");
            model.AddItem((CefMenuCommand)20, "#");
            */

            //    model.AddSeparator();

            // Add a new item to the list using the AddItem method of the model
            // model.AddItem((CefMenuCommand)26501, "Show DevTools");
            // model.AddItem((CefMenuCommand)26502, "Close DevTools");

            //   model.AddItem((CefMenuCommand)50, "Show DevTools");
            //   model.AddItem((CefMenuCommand)51, "Close DevTools");

            // Add a separator
            //  model.AddSeparator();

            // Add another example item
            // model.AddSeparator();
            //  model.AddItem((CefMenuCommand)26504, "Back");
            //  model.AddItem((CefMenuCommand)26505, "Forward");



        }


        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            ////
            
           // if (parameters.HasImageContents && parameters.SourceUrl.CheckIfValid())
            {

                // RIGHT CLICKED ON IMAGE

            }
            

            if (parameters.SelectionText != null)
            {

                // TEXT IS SELECTED

            }
            //////




            //////

            int id = (int)commandId;
            if (id == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if (id == CloseDevTools)
            {
                browser.CloseDevTools();
            }
            if (id == SaveImageAs)
            {
                browser.GetHost().StartDownload(parameters.SourceUrl);
                return true;

            }
            if (id == SaveLinkAs)
            {
                browser.GetHost().StartDownload(parameters.LinkUrl);
                return true;
            }
            if (id == OpenLinkInNewTab)
            {
                //  Form1.browserTabControl.Controls.Add(tpage);
               //  ChromiumWebBrowser newBrowser = myForm.AddNewBrowserTab(parameters.LinkUrl, false, browser.MainFrame.Url);

            }
            if (id == CopyLinkAddress)
            {
                Clipboard.SetText(parameters.LinkUrl);
            }

            if (id == SaveImageGet)
            {
                browser.GetHost().StartDownload(parameters.PageUrl);

                return true;
            }
            if (commandId == (CefMenuCommand)00) //26501
            {
             //   browser.GetHost().StartDownload(parameters.DictionarySuggestions);

                return true;
            }
            //false, 
            ////

            if (commandId == (CefMenuCommand)30) //
            {          /// CefSharp Supported Chrome Extensions
                browser.MainFrame.LoadUrl("chrome://extensions-support/");
                return true;
            }
            if (commandId == (CefMenuCommand)31) //
            {          /// CefSharp Version
                browser.MainFrame.LoadUrl("chrome://version/"  /** "chrome://chrome-urls/" **/);
                return true;
            }

            // React to the first ID (show dev tools method)
            if (commandId == (CefMenuCommand)32) /// 26501
            {          //          CefSharp Version
                browser.GetHost().ShowDevTools();
                return true;
            }
            if (commandId == (CefMenuCommand)33) /// 26502
            {          
                browser.GetHost().CloseDevTools();
                return true;
            }
            // React to the second ID (Close dev tools method)


            if (commandId == (CefMenuCommand)34)
            {
                if (browser.IsPopup)
                {
                    return false;
                }
                // Cef.RefreshWebPlugins();

                //  Cef.GetPlugins();
                return true;
            }

            if (commandId == (CefMenuCommand)35) 
            {
               
                return true;
            }
            if (commandId == (CefMenuCommand)50) //
            {
               
                return true;
            }

            if (commandId == (CefMenuCommand)51) //
            {          
              //  browser.MainFrame.LoadUrl("chrome://chrome-urls/");
                return true;
            }
            if (commandId == (CefMenuCommand)52) //
            {         
              //  browser.MainFrame.LoadUrl("chrome://chrome-urls/");
                return true;
            }

            if (commandId == (CefMenuCommand)90) //
            {
               // browser.MainFrame.LoadStringForUrl("");
                //   browser.MainFrame.Browser
                return true;
            }

            if (commandId == (CefMenuCommand)60) //
            {
                if (browser.CanGoBack)
                    browser.GoBack();
                return true;
            }
            if (commandId == (CefMenuCommand)61) //
            {
                if (browser.CanGoForward)
                    browser.GoForward();
                return true;
            }
            if (commandId == (CefMenuCommand)62) //
            {
                browser.MainFrame.Browser.Reload();
                return true;
            }
            if (commandId == (CefMenuCommand)63) //
            {
                browser.MainFrame.ViewSource();
                return true;
            }
            if (commandId == (CefMenuCommand)64) //
            {
                browser.StopLoad();
                return true;
            }
            if (commandId == (CefMenuCommand)67) //
            {
                browser.GetHost().Find(0, parameters.SelectionText, true, false, false);

                return true;
            }

            if (commandId == (CefMenuCommand)68) //
            {
                browser.GetHost().AddWordToDictionary(parameters.MisspelledWord);
                return true;
            }

            // React to the third ID (browser)

            if (commandId == (CefMenuCommand)1) //26504
            {
               
                return true;
            }
            if (commandId == (CefMenuCommand)2) //26505
            {
                

                return true;
            }
            if (commandId == (CefMenuCommand)3) //
            {
               

                return true;
            }
            if (commandId == (CefMenuCommand)4) //
            {
               
                return true;
            }
            if (commandId == (CefMenuCommand)5) //
            {
                browser.MainFrame.Cut();
                return true;
            }
            if (commandId == (CefMenuCommand)6) //
            {
                browser.MainFrame.Copy();
                return true;
            }
            if (commandId == (CefMenuCommand)7) //
            {
                browser.MainFrame.Paste();
                return true;
            }
            if (commandId == (CefMenuCommand)8) //
            {
                browser.MainFrame.Delete();
                return true;
            }
            if (commandId == (CefMenuCommand)9) //
            {
                browser.MainFrame.SelectAll();
                return true;
            }
            if (commandId == (CefMenuCommand)10) //
            {
                browser.MainFrame.Undo();
                return true;
            }
            if (commandId == (CefMenuCommand)11) //
            {
                browser.MainFrame.Redo();
                return true;
            }

            if (commandId == (CefMenuCommand)12) //
            {
                browser.MainFrame.LoadUrl("https://www.baidu.com/");
                return true;
            }

            if (commandId == (CefMenuCommand)13) //
            {
                browser.MainFrame.LoadUrl("https://www.google.com.hk");
                return true;
            }
            if (commandId == (CefMenuCommand)14) //
            {

                browser.MainFrame.LoadUrl("https://www.google.com.eg");

                // browser.GetHost().NotifyScreenInfoChanged();
                //   browser.SetZoomLevel();
                // browser.GetHost().SetZoomLevel(50.0);
                // browser.GetHost().SetZoomLevel(100.00);
                return true;
            }
            if (commandId == (CefMenuCommand)15) //
            {

                return true;
            }

            if (commandId == (CefMenuCommand)80) //
            {
              // OpenLinkInNewTab?.Invoke(this, new NewTabEventArgs(parameters.UnfilteredLinkUrl));
                return true;
            }


            /// OpenLinkInNewTab

            if ((int)commandId == OpenLinkInNewTab)
            {
                //browser.ShowDevTools();
               // OpenInNewTabContextMenu?.Invoke(this, new NewTabEventArgs(parameters.UnfilteredLinkUrl));
            }
            

            /*
            if ((int)commandId == SaveYouTubeVideo)
            {
                DownloadYouTubeVideo?.Invoke(this, null);   //we have the address, anyway, so don't need to pass it via event args.
            }
           */

            // Any new item should be handled through a new if statement


            // Return false should ignore the selected option of the user !
            return false;
        }



        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }


 

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }

}


       
