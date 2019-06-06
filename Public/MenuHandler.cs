using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace Example.Handler
{
    internal class MenuHandler : IContextMenuHandler
    {
        private string lastSelText = "";
        private const int ShowDevTools = 26501;
        private const int CloseDevTools = 26502;
        private const int SaveImageAs = 26503;
        private const int SaveAsPage = 26504;
        private const int SaveLinkAs = 26505;
        private const int CopyLinkAddress = 26506;
        private const int CefSharpSupportedChromeExtensions = 30;
        private const int CefSharpVersion = 31;
        private const int BaiduSearchChinese = 32;
        private const int GoogleSearchChinese = 33;
        private const int GoogleSearchEgypt = 34;
        private const int ViewPageSource = 35;
        private const int Back = 36;
        private const int Forward = 37;
        private const int Reload = 38;
        private const int Stop = 39;
        private const int Find = 40;
          private const int Undo = 41;
          private const int Redo = 42;
          private const int Cut = 43;
          private const int Copy = 44;
          private const int Paste = 45;
          private const int Delete = 46;
          private const int SelectAll = 47;
	  private const int Print = 48;
          ///
        private const int All = 4;
        private const int Good = 5;
        private const int source = 6;
	//
        //  private const int All = 48;
        //  private const int All = 49;
        //  private const int All = 50;
        //  private const int All = 51;
        //  private const int All = 52;

        private string url;
        private string img;
        private string Video;



        Form1 myForm;
        public MenuHandler(Form1 form) { myForm = form; }
        public MenuHandler() { }


        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //To disable the menu then call clear
            // model.Clear();

           // for (int i = 0; i < model.Count; i++) if ((int)model.GetCommandIdAt(i) == 234)
             model.Clear();   //About Adobe Flash
           // if (model.Count == 0) return;  // return;  No menu if 0 items (flash)

            // save text
            lastSelText = parameters.SelectionText;

            if (!string.IsNullOrEmpty(parameters.UnfilteredLinkUrl))
            {
            }

            if (model.Count > 0)
            {
                model.AddSeparator();
            }

            if (parameters.FrameUrl != null)
            {
               // copyFrameUrl = parameters.FrameUrl;
               //  model.AddSeparator();
            }

            ///
            ///
            ///

            bool BackNoT = model.Remove(CefMenuCommand.Back); // Remove "Back" option
            bool ForwardNOT = model.Remove(CefMenuCommand.Forward); // Remove "Forward" option
            bool PrintNot = model.Remove(CefMenuCommand.Print); // Remove "Print" option
            bool ViewSourceNOT = model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            //Removing existing menu item
            //bool removed = model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            if (parameters.LinkUrl != "")
            {
                model.AddItem((CefMenuCommand)SaveLinkAs, "Save As Link");
             // model.AddItem((CefMenuCommand)SaveImageAs, "Save as images");
                model.AddItem((CefMenuCommand)CopyLinkAddress, "Copy Link Address");
                model.AddSeparator();
            }

           
              url = parameters.LinkUrl;
              if (parameters.MediaType == ContextMenuMediaType.Image)
              {
                img = parameters.SourceUrl;
                model.AddItem((CefMenuCommand)5010, "Save as images"); // Save image // Save as images
                model.AddSeparator();
              }
              if (parameters.MediaType == ContextMenuMediaType.Video)
              {
                Video = parameters.SourceUrl;
                model.AddItem((CefMenuCommand)5011, "Save as File Video");
                model.AddSeparator();
              }
              if (parameters.MediaType == ContextMenuMediaType.Audio)
              {
                Video = parameters.SourceUrl;
                model.AddItem((CefMenuCommand)5012, "Save as File Audio ");
                model.AddSeparator();
              }

            if (parameters.TypeFlags.HasFlag(ContextMenuType.Media) && parameters.HasImageContents)
            {
                /*
                if (parameters.MediaType == ContextMenuMediaType.Plugin)
                {
                    Video = parameters.SourceUrl;
                    model.AddItem((CefMenuCommand)5013, "Plugin File ");
                    model.AddSeparator();
                }
                */

                // model.AddSeparator();
            }



            // Add new menu example items
            model.AddItem((CefMenuCommand)Back, "Back");
            model.AddItem((CefMenuCommand)Forward, "Forward");
            model.AddItem((CefMenuCommand)Reload, "Reload");
            model.AddItem((CefMenuCommand)Stop, "Stop");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)ViewPageSource, "View Page Source");
            model.AddItem((CefMenuCommand)ShowDevTools, "Developer Tools");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)SaveImageAs, "Save As Images");
            model.AddItem((CefMenuCommand)SaveAsPage, "Save As Page");
            model.AddItem((CefMenuCommand)SaveLinkAs, "Save As Link");

           
            model.AddSeparator();
            model.AddItem((CefMenuCommand)Cut, "Cut");
            model.AddItem((CefMenuCommand)Copy, "Copy");
            model.AddItem((CefMenuCommand)Paste, "Paste");
            model.AddItem((CefMenuCommand)Delete, "Delete");
            model.AddItem((CefMenuCommand)SelectAll, "SelectAll");
			model.AddSeparator();
            model.AddItem((CefMenuCommand)Undo, "Undo");
            model.AddItem((CefMenuCommand)Redo, "Redo");
            

            model.AddSeparator();
            model.AddItem((CefMenuCommand)CefSharpSupportedChromeExtensions, "CefSharp Supported Chrome Extensions");
            model.AddItem((CefMenuCommand)CefSharpVersion, "CefSharp Version");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)BaiduSearchChinese, "Baidu Search Chinese");
            model.AddItem((CefMenuCommand)GoogleSearchChinese, "Google Search Chinese");
            model.AddItem((CefMenuCommand)GoogleSearchEgypt, "Google Search Egypt");
        }

        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if ((int)commandId == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if ((int)commandId == CloseDevTools)
            {
                browser.CloseDevTools();
            }
            if ((int)commandId == SaveImageAs)
            {
                browser.GetHost().StartDownload(parameters.SourceUrl);
                return true;

            }
            if ((int)commandId == SaveLinkAs)
            {
                browser.GetHost().StartDownload(parameters.LinkUrl);
                return true;
            }           
            if ((int)commandId == CopyLinkAddress)
            {
                Clipboard.SetText(parameters.LinkUrl);
            }

            if ((int)commandId == SaveAsPage)
            {
                browser.GetHost().StartDownload(parameters.PageUrl);

                return true;
            }

            if ((int)commandId == CefSharpVersion)
            {
                browser.MainFrame.LoadUrl("chrome://chrome-urls/");
                 return true;
            }
            if ((int)commandId == CefSharpSupportedChromeExtensions)
            {
                browser.MainFrame.LoadUrl("chrome://extensions-support/");

                return true;
            }
            if ((int)commandId == BaiduSearchChinese)
            {
                browser.MainFrame.LoadUrl("https://www.baidu.com/");

                return true;
            }
            if ((int)commandId == GoogleSearchChinese)
            {
                browser.MainFrame.LoadUrl("https://www.google.com.hk");

                return true;
            }
            if ((int)commandId == GoogleSearchEgypt)
            {
                browser.MainFrame.LoadUrl("https://www.google.com.eg");

                return true;
            }
            if ((int)commandId == Back)
            {
                browser.GoBack();

                return true;
            }
            if ((int)commandId == Forward)
            {
                browser.GoForward();

                return true;
            }
            if ((int)commandId == Reload)
            {
                browser.MainFrame.Browser.Reload();

                return true;
            }
            if ((int)commandId == Stop)
            {
                browser.StopLoad();

                return true;
            }
	    
	     if ((int)commandId == Print)
            {
                browser.Print();
                return true;
            }
	    
            if ((int)commandId == ViewPageSource)
            {
                browser.MainFrame.ViewSource();

                return true;
            }
            if ((int)commandId == Find)
            {
                browser.GetHost().Find(0, parameters.SelectionText, true, false, false);
                return true;
            }


            if ((int)commandId == Undo)
            {
                browser.MainFrame.Undo();

                return true;
            }
            if ((int)commandId == Redo)
            {
                browser.MainFrame.Redo();

                return true;
            }

            if ((int)commandId == Cut)
            {
                browser.MainFrame.Cut();

                return true;
            }
            if ((int)commandId == Copy)
            {
                browser.MainFrame.Copy();

                return true;
            }
            if ((int)commandId == Paste)
            {
                browser.MainFrame.Paste();

                return true;
            }
            if ((int)commandId == Delete)
            {
                browser.MainFrame.Delete();

                return true;
            }
            if ((int)commandId == SelectAll)
            {
                browser.MainFrame.SelectAll();

                return true;
            }

///
///

            if (commandId == (CefMenuCommand)5010)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "image.png";
                dialog.Filter = "Png image (*.png)|*.png|ICO image (*.ico)|*.ico|Gif Image (*.gif)|*.gif|JPEG image (*.jpg)|*.jpg|SVG image (*.svg)|*.svg";

                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Console.WriteLine("writing to: " + dialog.FileName);

                    var wClient = new System.Net.WebClient();
                    wClient.DownloadFile(img, dialog.FileName);
                }
            }
            if (commandId == (CefMenuCommand)5011)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "Save All File Videos.mp4";
                dialog.Filter = "MP4 (*.mp4)|*.mp4|MKV (*.mkv)|*.mkv|WEBM (*.webm)|*.webm|M3U (*.m3u)|*.m3u|All File (*.*)|*.*";

                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Console.WriteLine("writing to: " + dialog.FileName);

                    var wClient = new System.Net.WebClient();
                    wClient.DownloadFile(img, dialog.FileName);
                }
            }
            if (commandId == (CefMenuCommand)5012)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "Save All File Audio.mp3";
                dialog.Filter = "MP3 (*.mp3)|*.mp3|Flac (*.flac)|*.flac|WAV (*.wav)|*.wav|All File (*.*)|*.*";

                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Console.WriteLine("writing to: " + dialog.FileName);

                    var wClient = new System.Net.WebClient();
                    wClient.DownloadFile(img, dialog.FileName);
                }
            }

             /*
            if (commandId == (CefMenuCommand)5013)
            {              
            }
            */
///
///

            if ((int)commandId == Good)
            {
                browser.GetHost().RequestContext.GetExtension(@"Resources\Extensions\");

                return true;
            }


            return false;
        }

        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
