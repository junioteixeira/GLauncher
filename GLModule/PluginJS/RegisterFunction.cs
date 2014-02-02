using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLModule.Constants;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;

namespace GLModule.PluginJS
{
    public static class RegisterFunction
    {
        public static Dictionary<FunctionsEnum, Dictionary<string, Object>> FunctionsJS = new Dictionary<FunctionsEnum, Dictionary<string, object>>();
        public static Dictionary<FunctionsEnum, List<Object>> SafeFunctionsJS = new Dictionary<FunctionsEnum, List<Object>>();

        private static string CurrentFile = String.Empty;

        /// <summary>
        /// Carregar plugins
        /// </summary>
        public static void LoadPlugins()
        {
            if (!Directory.Exists(Constants.PluginJS.PathPluginJS)
             || !Constants.PluginJS.AllowPluginJS)
            { return; }

            Engines.EnginePlugins.AddHostObject("RegisterFunc", new Action<Object, int>(RegisterFunc));

            bool ErroPlugins = false;
            string[] FilesJS = Directory.GetFiles(Constants.PluginJS.PathPluginJS, "*.js", SearchOption.AllDirectories);
            for (int i = 0; i < FilesJS.Length; i++)
            {
                CurrentFile = FilesJS[i];
                string Script = File.ReadAllText(FilesJS[i]);
                try
                {
                    Engines.EnginePlugins.Execute(Script);
                    Engines.EnginePlugins.Script.Register();
                }
                catch
                {
                    ErroPlugins = true;
                    ConsoleConstants.WriteInConsole(
                        "Falha ao carregar um plugin\nNome:" +
                         FilesJS[i], Color.DarkRed);
                }
            }

            if (!ErroPlugins)
                ConsoleConstants.WriteInConsole("Plugins em JavaScript, carregados com sucesso", Color.DarkGreen);

            HostTypeCollection LibsExport = new HostTypeCollection("mscorlib", "System", "System.Core", "GLResourceModule");
            Engines.EnginePlugins.AddHostObject("clr", LibsExport);
            Engines.EnginePlugins.AddHostObject("MessageBox", new Func<string, string, DialogResult>(MessageBox.Show));
        }

        private static void RegisterFunc(Object jsFunc, int functionEnum)
        {
            FunctionsEnum funcEnum = (FunctionsEnum)functionEnum;
            switch (funcEnum)
            {
                case FunctionsEnum.ComputeFileCompleted:
                case FunctionsEnum.ComputeFileProgressed:
                case FunctionsEnum.ComputeFileStarted:
                case FunctionsEnum.UpdateFileCompleted:
                case FunctionsEnum.UpdateFileProgressed:
                case FunctionsEnum.UpdateFileStarted:
                    {
                        if (FunctionsJS.ContainsKey(funcEnum))
                            FunctionsJS[funcEnum].Add(CurrentFile, jsFunc);
                        else
                            FunctionsJS.Add(funcEnum, new Dictionary<string, Object> { { CurrentFile, jsFunc } });
                    }
                    break;

                default:
                    {
                        ConsoleConstants.WriteInConsole(
                            "Função informada num JavaScript não corresponde a uma função correta"
                           + "\nCódigo informado: " + functionEnum
                           , System.Drawing.Color.DarkRed);
                    }
                    break;
            }
        }

        private static void RegisterSafeFunc(Object jsFunc, int functionEnum)
        {
            FunctionsEnum funcEnum = (FunctionsEnum)functionEnum;
            switch (funcEnum)
            {
                case FunctionsEnum.ComputeFileCompleted:
                case FunctionsEnum.ComputeFileProgressed:
                case FunctionsEnum.ComputeFileStarted:
                case FunctionsEnum.UpdateFileCompleted:
                case FunctionsEnum.UpdateFileProgressed:
                case FunctionsEnum.UpdateFileStarted:
                    {
                        if (SafeFunctionsJS.ContainsKey(funcEnum))
                            SafeFunctionsJS[funcEnum].Add(jsFunc);
                        else
                            SafeFunctionsJS.Add(funcEnum, new List<Object> { jsFunc });
                    }
                    break;

                default:
                    {
                        ConsoleConstants.WriteInConsole(
                            "Função informada num SafePlugin não corresponde a uma função correta"
                           + "\nCódigo informado: " + functionEnum
                           , System.Drawing.Color.DarkRed);
                    }
                    break;
            }
        }

        /// <summary>
        /// Carregar plugins seguros, recebidos diretamente do servidor
        /// </summary>
        /// <param name="SafePlugins">Scripts</param>
        /// <param name="LibsImport">Libs para exportar para os scripts</param>
        public static void LoadSafePlugins(string[] SafePlugins, string[] LibsImport)
        {
            if (SafePlugins.Length == 0 || !Constants.PluginJS.AllowSafePlugin)
                return;
            if (LibsImport.Length > 0)
            {
                HostTypeCollection Libs = new HostTypeCollection(LibsImport);
                Engines.EngineSafePlugins.AddHostObject("clr", Libs);
            }

            Boolean ErroPlugins = false;
            Engines.EngineSafePlugins.AddHostObject("RegisterFunc", new Action<Object, int>(RegisterSafeFunc));

            for (int i = 0; i < SafePlugins.Length; i++)
            {
                string CurrentScript = SafePlugins[i];
                try
                {
                    Engines.EngineSafePlugins.Execute(CurrentScript);
                    Engines.EngineSafePlugins.Script.Register();
                }
                catch (Exception ex)
                {
                    ErroPlugins = true;
                    ConsoleConstants.WriteInConsole(
                        "Falha ao carregar um SafePlugin\nErro:" +
                         ex.Message, Color.DarkRed);
                }
            }

            if (!ErroPlugins)
                ConsoleConstants.WriteInConsole("SafePlugins carregados com sucesso", Color.DarkGreen);
        }
    }
}