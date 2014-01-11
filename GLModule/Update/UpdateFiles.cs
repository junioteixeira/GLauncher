using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;
using System.Threading;
using GLModule.Constants;
using System.Net;

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
        /// Verifica quais arquivos necessitam de atualização
        /// </summary>
        /// <param name="DataUpdate">Dictionary recebida do servidor contendo nome e hash dos arquivos para update</param>
        public static void ComputeFilesInfo(Dictionary<string, string> DataUpdate)
        {
            new Thread(delegate()
            {
                int TotalFiles = DataUpdate.Count;
                OnComputeFileStarted(TotalFiles);
                string[] Files = DataUpdate.Keys.ToArray();
                List<string> FilesToUpdate = new List<string>();
                for (int i = 0; i < Files.Length; i++)
                {
                    if (!File.Exists(Files[i]))
                        FilesToUpdate.Add(Files[i]);
                    else
                    {
                        using (FileStream fileStream = File.Open(Files[i], FileMode.Open))
                        {
                            byte[] HashFile = UpdateConstants.TypeHash.ComputeHash(fileStream);
                            string Hash = BitConverter.ToString(HashFile).Replace("-", string.Empty);
                            if (Hash != DataUpdate[Files[i]])
                                FilesToUpdate.Add(Files[i]);
                        }
                    }
                    OnComputeFileProgressed(((i * 100) / Files.Length), Files[i]);
                }
                OnComputeFileCompleted(FilesToUpdate);
            }).Start();
        }

        /// <summary>
        /// IMPORTANTE: Invocar esse método dentro do escopo do evento ComputeFileCompleted e passar o mesmo parâmetro recebido para dar início ao update
        /// Atualiza os arquivos necessários
        /// </summary>
        /// <param name="FilesToUpdate">List com o nome dos arquivos que devem ser atualizados</param>
        public static void InitializeUpdate(List<string> FilesToUpdate)
        {
            new Thread(delegate()
            {
                using (WebClient update = new WebClient())
                {
                    update.DownloadProgressChanged += (sender, e) => OnUpdateFileProgressed(e);
                    for (int i = 0; i < FilesToUpdate.Count; i++)
                    {
                        OnUpdateFileStarted(FilesToUpdate[i]);
                        update.DownloadFile(UpdateConstants.UrlUpdate, FilesToUpdate[i]);
                        OnUpdateFileCompleted(i, (i * 100) / FilesToUpdate.Count);
                    }
                }
            }).Start();
        }

        private static void OnUpdateFileStarted(string NameFile)
        {
            InvokeControlDelegate(UpdateFileStarted, NameFile);
        }

        private static void OnUpdateFileProgressed(DownloadProgressChangedEventArgs e)
        {
            InvokeControlDelegate(UpdateFileProgressed, e);
        }

        private static void OnUpdateFileCompleted(int TotalFilesDownloaded, int PercetageTotal)
        {
            InvokeControlDelegate(UpdateFileCompleted, TotalFilesDownloaded, PercetageTotal);
        }

        private static void OnComputeFileStarted(int TotalFiles)
        {
            InvokeControlDelegate(ComputeFileStarted, TotalFiles);
        }

        private static void OnComputeFileProgressed(int Percentage, string File)
        {
            InvokeControlDelegate(ComputeFileProgressed, Percentage, File);
        }

        private static void OnComputeFileCompleted(List<string> FilesToUpdate)
        {
            InvokeControlDelegate(ComputeFileCompleted, FilesToUpdate);
        }

        private static void InvokeControlDelegate(Delegate EventOrDelegate, params object[] Args)
        {
            Control control = EventOrDelegate.Target as Control;
            if (control.InvokeRequired)
            {
                control.Invoke(EventOrDelegate, Args);
            }
            else
            {
                EventOrDelegate.DynamicInvoke(Args);
            }
        }
    }
}
