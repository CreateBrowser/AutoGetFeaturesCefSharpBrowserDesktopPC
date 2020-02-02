using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace Win_OS_Forms_Application.Handler.Example.Customize
    {

    public class AMyCustomMenuHandler : IContextMenuHandler
        {

        string UnfilteredLinkUrl { get; }

        private string copyFrameUrl;

        private const int SaveImageGet = 26500;
        private const int ShowDevTools = 50;
        private const int CloseDevTools = 51;
        private const int SaveImageAs = 26503;
        private const int SaveAsPdf = 26504;
        private const int SaveLinkAs = 26505;
        private const int CopyLinkAddress = 26506;
        private const int OpenLinkInNewTab = 26507;

        private string lastSelText = "";


        Form1 myForm;
        public AMyCustomMenuHandler(Form1 form)
            {
            myForm = form;
            }

        public AMyCustomMenuHandler()
            {
            }

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
            {

            //set defaults from premade context menu




            // Remove any existent option using the Clear method of the model

            //    // Edit 

            //  model.Clear();

            model.Clear();



            // save text
            lastSelText = parameters.SelectionText;

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



                }



            // Add another example item
            model.AddItem((CefMenuCommand)1, "Back");
            model.AddItem((CefMenuCommand)2, "Forward");
            model.AddItem((CefMenuCommand)3, "Reload");
            model.AddItem((CefMenuCommand)52, "Stop");
            model.AddItem((CefMenuCommand)4, "View Page Source");
            model.AddItem((CefMenuCommand)ShowDevTools, "Developer Tools");

            model.AddSeparator();
            model.AddItem((CefMenuCommand)SaveImageAs, "Save As Images");
            model.AddItem((CefMenuCommand)SaveImageGet, "Save As Page");
            model.AddItem((CefMenuCommand)SaveLinkAs, "Save As Link");

            model.AddSeparator();
            //   model.AddItem((CefMenuCommand)00, "@");

            model.AddItem((CefMenuCommand)10, "Undo");
            model.AddItem((CefMenuCommand)11, "Redo");

            model.AddItem((CefMenuCommand)5, "Cut");
            model.AddItem((CefMenuCommand)6, "Copy");
            model.AddItem((CefMenuCommand)7, "Paste");
            model.AddItem((CefMenuCommand)8, "Delete");
            model.AddItem((CefMenuCommand)9, "SelectAll");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)12, "Baidu Search Chinese");
            model.AddItem((CefMenuCommand)13, "Google Search Chinese");
            model.AddItem((CefMenuCommand)14, "Google Search Egypt");


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
            if (parameters.HasImageContents && parameters.SourceUrl.CheckIfValid())
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

