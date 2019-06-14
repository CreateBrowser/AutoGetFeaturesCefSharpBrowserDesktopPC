 // Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser 
// (Register now for your free entry ticket!) https://engine.passapp.io/ict-form-embed
//
// More
//



<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>

CefSharp Web Browser | Example Release CefSharp Version | 73.0.130 | 

 

```md 

                                                    Developer Pack
   The developer pack is used by software developers to create applications that run on .NET Framework, typically using Visual Studio.

 
 ```
 
Example Chromium Browser | Release CefSharp Version | 63.0.3 | 71.0.2 (71.0.3578.98) | 73.0.130 | 
Example Chromium Browser | Release Pro CefSharp Version | v65.0.0-pre01 | v69.0.0-pre01 | v73.0.120-pre01 | 

 
 
 
 Chromium Application.sln
Application Settings System
Group Custom Path Configuration Desktop PC 
<VB>
New | Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser
</VB>
Start the browser after initialize global component CefSharp v65.0.0-pre01
"GO"

\\\\\\\\\\\\\\\

<cs>
<vb>

| mf_helpers.cc(14)] | Error in dxva_video_decode_accelerator_win.cc | on line 511 |

/*      mf_helpers.cc(14)] Error in dxva_video_decode_accelerator_win.cc on line 511 */

</vb>
</cs>

|GO|
       

/* <startup> <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7" /> </startup>*/


| CustomMenuHandler |

<cs> 

|
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
using CefSharp;
using System.Windows.Forms;
using CefSharp.WinForms;
using Example;

namespace Example
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
                browser.GetHost().NotifyScreenInfoChanged();

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


       

|
</cs> 


     
  <cs> <script async src=""></script>  |  <img alt="" style="max-width:160px;" src="https://www.keepvid.info/images/paypay%402x.png" > | </cs>
        
    |    <cs> DownloadHandler.cs <cs>
        
        <cs>
        public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;

            if (handler != null)
            {
                handler(this, downloadItem);
            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);

                }
            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            /*
            if (downloadItem.IsComplete || downloadItem.IsCancelled)
            {
                //do stuff
            }
            */

            var handler = OnDownloadUpdatedFired;
            if (handler != null)
            {
                handler(this, downloadItem);
            }
        }
    }
        <cs> |
            
            
            
            <cs>|
 <Window
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Done"
        xmlns:ControlzEx="clr-namespace:ControlzEx;assembly=MaterialDesignThemes.Wpf" xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes" x:Class="Done.MainWindow"
        mc:Ignorable="d"
        xmlns:wpf="clr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf"
        Title="MainWindow" Height="400" Width="600">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="251*"/>
            <ColumnDefinition Width="71*"/>
        </Grid.ColumnDefinitions>
        <Button x:Name="button" Content="Button" HorizontalAlignment="Left" Height="55" Margin="57,47,0,0" VerticalAlignment="Top" Width="141"/>

    </Grid>

</Window>

<cs>

<cs>
    
namespace Done
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            byte[] bytes = { 0x00, 0x55, 0, 0x86 };

            // If the system architecture is little-endian (that is, little end first), 
            // reverse the byte array. 
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            UInt16 i = BitConverter.ToUInt16(bytes, 0);
            
        }            
            |</cs>
            
            
             
             

<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>
<cs> - Example Custom Desktop Project C# CefSharp A Example Auto Get Fast Browser - </cs>

