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

namespace GLModule.PluginJS.Clear
{
    public static class RegisterFunctionClear
    {
        public static Dictionary<FunctionsEnum, Dictionary<string, Object>> FunctionsJS = new Dictionary<FunctionsEnum, Dictionary<string, object>>();
        private static string CurrentFile = String.Empty;

        public static void Teste()
        {
            if (!Directory.Exists("PluginJS")) { return; }
            V8ScriptEngine Engine = new V8ScriptEngine();
            var LibsExport = new HostTypeCollection("mscorlib", "System", "System.Core", "GLResourceModule");
            Engine.AddHostObject("clr", LibsExport);
            Engine.AddHostObject("MessageBox", new Func<string, string, DialogResult>(MessageBox.Show));

            bool ErroPlugins = false;
            string[] FilesJS = Directory.GetFiles("PluginJS\\", "*.js", SearchOption.AllDirectories);
            for (int i = 0; i < FilesJS.Length; i++)
            {
                CurrentFile = FilesJS[i];
                string Script = File.ReadAllText(FilesJS[i]);
                try
                {
                    Engine.AddHostObject("RegisterFunc", new Action<Object, int>(RegisterFunc));
                    Engine.Execute(Script);
                    Engine.Script.Register();
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
        }

        public static void RegisterFunc(Object jsFunc, int functionEnum)
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
                            FunctionsJS[funcEnum].Add(CurrentFile,jsFunc);
                        else
                            FunctionsJS.Add(funcEnum, new Dictionary<string, Object> { { CurrentFile, jsFunc } });
                    }
                    break;

                default:
                    {
                        ConsoleConstants.WriteInConsole(
                            "Função informada num JavaScript não corresponde a alguma função correta"
                           + "\nCódigo informado: " + functionEnum
                           , System.Drawing.Color.DarkRed);
                    }
                    break;
            }
        }
    }
}
