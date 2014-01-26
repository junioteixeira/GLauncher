namespace GLModule.PluginJS
{
    public enum FunctionsEnum
    {
        //Computar arquivos para Update
        ComputeFileCompleted = 0xF890, //(string[] FilesToUpdate);
        ComputeFileProgressed = 0xCD40, //(int Percentage, string File);
        ComputeFileStarted = 0x0DAC, //(int TotalFiles);

        //Update dos arquivos
        UpdateFileCompleted = 0xAED8, //(int TotalFilesDownloaded, int PercetageTotal);
        UpdateFileProgressed = 0x7854, //(DownloadProgress e);
        UpdateFileStarted = 0xB890 //(string NameFile);
    }
}
