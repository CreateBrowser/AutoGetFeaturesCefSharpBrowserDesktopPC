Example Chromium Browser CefSharp v63.0.3 ^ v65.0.0-pre01
Chromium Application.sln
Application Settings System
Group Custom Path Configuration Desktop PC 

/* <startup> <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7" /> </startup>*/

Start the browser after initialize global component CefSharp v65.0.0-pre01



     
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
