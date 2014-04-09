using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;
using System.Threading;
using GLModule.Constants;
using System.Net;
using GLModule.PluginJS;

namespace GLModule.Update
{
    public static class UpdateFiles
    {
        /// <summary>
        /// Evento que informa quando a leitura de um novo arquivo para o update começa
        /// </summary>
        public static event ComputeFileStartedHandle ComputeFileStarted;

        /// <summary>
        /// Evento que informa o progresso do arquivo que está sendo lido
        /// </summary>
        public static event ComputeFileProgressedHandle ComputeFileProgressed;

        /// <summary>
        /// Evento que informa quando o arquivo foi lido totalmente e computado
        /// </summary>
        public static event ComputeFilesCompletedHandle ComputeFileCompleted;

        /// <summary>
        /// Informa quando o update de um novo arquivo começa
        /// </summary>
        public static event UpdateFileStartedHandle UpdateFileStarted;

        /// <summary>
        /// Informações do progresso de download do arquivo atual
        /// </summary>
        public static event UpdateFileProgressedHandle UpdateFileProgressed;

        /// <summary>
        /// Informa quando o download do arquivo atual está concluído
        /// </summary>
        public static event UpdateFileCompletedHandle UpdateFileCompleted;

        /// <summary>
        /// Computar arquivos no client para verificação de update
        /// <para/>Verifica quais arquivos necessitam de atualização
        /// </summary>
        /// <param name="DataUpdate">Dictionary recebida do servidor contendo nome e hash dos arquivos para update</param>
        public static void ComputeFilesInfo(List<FileControlUpdate> DataUpdate, string UrlUpdate)
        {
            new Thread(delegate()
            {
                int TotalFiles = DataUpdate.Count;
                OnComputeFileStarted(TotalFiles);
                List<string> FilesToUpdate = new List<string>();
                for (int i = 0; i < TotalFiles; i++)
                {
                    if (DataUpdate[i].FileValidation == TypeFileValidation.NoVerify) { continue; }
                    if (!File.Exists(DataUpdate[i].Name))
                        FilesToUpdate.Add(DataUpdate[i].Name);
                    else if(DataUpdate[i].FileValidation == TypeFileValidation.Sync)
                    {
                        using (FileStream fileStream = File.Open(DataUpdate[i].Name, FileMode.Open))
                        {
                            byte[] HashFile = UpdateConstants.TypeHash.ComputeHash(fileStream);
                            string Hash = BitConverter.ToString(HashFile).Replace("-", string.Empty);
                            if (Hash != DataUpdate[i].Hash)
                                FilesToUpdate.Add(DataUpdate[i].Name);
                        }
                    }
                    OnComputeFileProgressed(((i * 100) / TotalFiles), DataUpdate[i]);
                }
                OnComputeFileCompleted(FilesToUpdate, UrlUpdate);
            }).Start();
        }

        /// <summary>
        /// IMPORTANTE: Invocar esse método dentro do escopo do evento ComputeFileCompleted e passar o mesmo parâmetro recebido para dar início ao update
        /// <para/>Atualiza os arquivos necessários
        /// </summary>
        /// <param name="FilesToUpdate">List com o nome dos arquivos que devem ser atualizados</param>
        public static void InitializeUpdate(List<string> FilesToUpdate, string UrlUpdate)
        {
            new Thread(delegate()
            {
                using (WebClient update = new WebClient())
                {
                    update.DownloadProgressChanged += (sender, e) => OnUpdateFileProgressed(e);
                    for (int i = 0; i < FilesToUpdate.Count; i++)
                    {
                        OnUpdateFileStarted(FilesToUpdate[i]);
                        update.DownloadFile(UrlUpdate, FilesToUpdate[i]);
                        OnUpdateFileCompleted(i, (i * 100) / FilesToUpdate.Count);
                    }
                }
            }).Start();
        }

        private static void OnUpdateFileStarted(string NameFile)
        {
            InvokeFunctions.Invoke(FunctionsEnum.UpdateFileStarted, NameFile);
            Control control = UpdateFileStarted.Target as Control;
            if (control.InvokeRequired)
                control.Invoke(UpdateFileStarted, NameFile);
            else
                UpdateFileStarted(NameFile);
        }

        private static void OnUpdateFileProgressed(DownloadProgressChangedEventArgs e)
        {
            InvokeFunctions.Invoke(FunctionsEnum.UpdateFileProgressed, e);
            Control control = UpdateFileProgressed.Target as Control;
            if (control.InvokeRequired)
                control.Invoke(UpdateFileProgressed, e);
            else
                UpdateFileProgressed(e);
        }

        private static void OnUpdateFileCompleted(int TotalFilesDownloaded, int PercetageTotal)
        {
            InvokeFunctions.Invoke(FunctionsEnum.UpdateFileCompleted, TotalFilesDownloaded, PercetageTotal);
            Control control = UpdateFileCompleted.Target as Control;
            if (control.InvokeRequired)
                control.Invoke(UpdateFileCompleted, TotalFilesDownloaded, PercetageTotal);
            else
                UpdateFileCompleted(TotalFilesDownloaded, PercetageTotal);
        }

        private static void OnComputeFileStarted(int TotalFiles)
        {
            InvokeFunctions.Invoke(FunctionsEnum.ComputeFileStarted, TotalFiles);
            Control control = ComputeFileStarted.Target as Control;
            if (control.InvokeRequired)
                control.Invoke(ComputeFileStarted, TotalFiles);
            else
                ComputeFileStarted(TotalFiles);
        }

        private static void OnComputeFileProgressed(int Percentage, FileControlUpdate File)
        {
            InvokeFunctions.Invoke(FunctionsEnum.ComputeFileProgressed, Percentage, File);
            Control control = ComputeFileProgressed.Target as Control;
            if (control.InvokeRequired)
                control.Invoke(ComputeFileProgressed, Percentage, File);
            else
                ComputeFileProgressed(Percentage, File);
        }

        private static void OnComputeFileCompleted(List<string> FilesToUpdate, string UrlUpdate)
        {
            InvokeFunctions.Invoke(FunctionsEnum.ComputeFileCompleted, FilesToUpdate.ToArray());
            Control control = ComputeFileCompleted.Target as Control;
            if (control.InvokeRequired)
                control.Invoke(ComputeFileCompleted, FilesToUpdate,UrlUpdate);
            else
                ComputeFileCompleted(FilesToUpdate, UrlUpdate);
        }
    }
}
