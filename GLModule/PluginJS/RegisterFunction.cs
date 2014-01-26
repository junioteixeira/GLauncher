using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using GLModule.Constants;
using Jint;
using Jint.Native;

namespace GLModule.PluginJS
{
    public static class RegisterFunction
    {
        public static Dictionary<FunctionsEnum, List<JsFunction>> FunctionsJS = new Dictionary<FunctionsEnum, List<JsFunction>>();

        public static void LoadFunctions()
        {
            if (!Directory.Exists("PluginJS")) { return; }
            bool ErroPlugins = false;
            JintEngine Engine = new JintEngine()
                .SetFunction("RegisterFunc", new Action<JsFunction, double>(RegisterFunc));
            string[] FilesJS = Directory.GetFiles("PluginJS\\", "*.js", SearchOption.AllDirectories);
            for (int i = 0; i < FilesJS.Length; i++)
            {
                string Script = File.ReadAllText(FilesJS[i]);
                try
                {
                    Engine.Run(Script);
                    Engine.CallFunction("Register");
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

        public static void RegisterFunc(JsFunction jsFunc, double functionEnum)
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
                            FunctionsJS[funcEnum].Add(jsFunc);
                        else
                            FunctionsJS.Add(funcEnum, new List<JsFunction> { jsFunc });
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
