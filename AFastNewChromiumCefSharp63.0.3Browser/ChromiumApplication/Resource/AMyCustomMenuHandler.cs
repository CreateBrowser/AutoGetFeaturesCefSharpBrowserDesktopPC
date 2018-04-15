using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using System.Windows.Forms;

namespace ChromiumApplication
{
    public class AMyCustomMenuHandler : IContextMenuHandler
    {

        private string copyFrameUrl;



        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            // Remove any existent option using the Clear method of the model

            //    // Edit 

            //  model.Clear();

              model.Clear();


          //  Console.WriteLine("Context menu opened !");

            Console.Write("Context menu opened !");


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




            // Add another example item
            model.AddItem((CefMenuCommand)1, "Back");
            model.AddItem((CefMenuCommand)2, "Forward");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)3, "Reload");
            model.AddItem((CefMenuCommand)52, "Stop Load");
            model.AddItem((CefMenuCommand)50, "Show DevTools");
            model.AddItem((CefMenuCommand)51, "Close DevTools");
            model.AddItem((CefMenuCommand)4, "View Source");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)10, "Undo");
            model.AddItem((CefMenuCommand)11, "Redo");

            model.AddItem((CefMenuCommand)5, "Cut");
            model.AddItem((CefMenuCommand)6, "Copy");
            model.AddItem((CefMenuCommand)7, "Paste");
            model.AddItem((CefMenuCommand)8, "Delete");
            model.AddItem((CefMenuCommand)9, "SelectAll");
            model.AddSeparator();

            model.AddItem((CefMenuCommand)12, "Google CN");
            model.AddItem((CefMenuCommand)13, "#");
            model.AddItem((CefMenuCommand)14, "#");
            model.AddItem((CefMenuCommand)15, "#");
            model.AddItem((CefMenuCommand)16, "#");
            model.AddItem((CefMenuCommand)17, "#");
            model.AddItem((CefMenuCommand)18, "#");
            model.AddItem((CefMenuCommand)19, "#");
            model.AddItem((CefMenuCommand)20, "#");

            model.AddSeparator();

            // Add a new item to the list using the AddItem method of the model
           // model.AddItem((CefMenuCommand)26501, "Show DevTools");
           // model.AddItem((CefMenuCommand)26502, "Close DevTools");

         //   model.AddItem((CefMenuCommand)50, "Show DevTools");
         //   model.AddItem((CefMenuCommand)51, "Close DevTools");

            // Add a separator
            model.AddSeparator();

            // Add another example item
            // model.AddSeparator();
          //  model.AddItem((CefMenuCommand)26504, "Back");
          //  model.AddItem((CefMenuCommand)26505, "Forward");



        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            // React to the first ID (show dev tools method)
            if (commandId == (CefMenuCommand)50) //26501
            {
                browser.GetHost().ShowDevTools();
                return true;
            }

            // React to the second ID (show dev tools method)
            if (commandId == (CefMenuCommand)51) //26502
            {
                browser.GetHost().CloseDevTools();
                return true;
            }
            if (commandId == (CefMenuCommand)52) //
            {
                browser.StopLoad();
                return true;
            }

            // React to the third ID (browser)

            if (commandId == (CefMenuCommand)1) //26504
            {
                if (browser.CanGoBack)
                    browser.GoBack();
                return true;
            }
            if (commandId == (CefMenuCommand)2) //26505
            {
                if (browser.CanGoForward)
                    browser.GoForward();

                return true;
            }
            if (commandId == (CefMenuCommand)3) //
            {
                browser.MainFrame.Browser.Reload();

                return true;
            }
            if (commandId == (CefMenuCommand)4) //
            {
                browser.MainFrame.ViewSource();
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
            {   browser.MainFrame.Undo();
                return true;
            }
            if (commandId == (CefMenuCommand)11) //
            {
                browser.MainFrame.Redo();
                return true;
            }

            if (commandId == (CefMenuCommand)12) //
            {
                browser.MainFrame.LoadUrl("https://www.google.com.hk");
                return true;
            }
            if (commandId == (CefMenuCommand)13) //
            {                //   browser.SetZoomLevel();
               // browser.GetHost().SetZoomLevel(50.0);

                return true;
            }
            if (commandId == (CefMenuCommand)14) //
            {
               // browser.GetHost().SetZoomLevel(100.00);
                return true;
            }
            if (commandId == (CefMenuCommand)15) //
            {
                
                return true;
            }




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