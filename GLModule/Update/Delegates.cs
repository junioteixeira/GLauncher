using System;
using System.Collections.Generic;
using System.Net;
namespace GLModule.Update
{
    public delegate void ComputeFilesCompletedHandle(List<string> FilesToUpdate);
    public delegate void ComputeFileProgressedHandle(int Percentage, string File);
    public delegate void ComputeFileStartedHandle(int TotalFiles);

    public delegate void UpdateFileCompletedHandle(int TotalFilesDownloaded, int PercetageTotal);
    public delegate void UpdateFileProgressedHandle(DownloadProgressChangedEventArgs e);
    public delegate void UpdateFileStartedHandle(string NameFile);
}
