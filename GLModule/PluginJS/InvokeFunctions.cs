using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using GLModule.Constants;
using Microsoft.ClearScript;

namespace GLModule.PluginJS
{
    public static class InvokeFunctions
    {
        /// <summary>
        /// Invocar métodos dos plugins
        /// </summary>
        /// <param name="functionEnum">Quais métodos invocar</param>
        /// <param name="Arguments">Argumentos da função</param>
        public static void Invoke(FunctionsEnum functionEnum, params object[] Arguments)
        {
            if (!RegisterFunction.FunctionsJS.ContainsKey(functionEnum))
                return;

            Dictionary<String, Object> Plugins = RegisterFunction.FunctionsJS[functionEnum];
            foreach (String File in Plugins.Keys)
            {
                try
                {
                    dynamic Function = Plugins[File];
                    Function(
                               Arguments.Length > 0 ? Arguments[0] : null,
                               Arguments.Length > 1 ? Arguments[1] : null,
                               Arguments.Length > 2 ? Arguments[2] : null,
                               Arguments.Length > 3 ? Arguments[3] : null,
                               Arguments.Length > 4 ? Arguments[4] : null,
                               Arguments.Length > 5 ? Arguments[5] : null,
                               Arguments.Length > 6 ? Arguments[6] : null,
                               Arguments.Length > 7 ? Arguments[7] : null,
                               Arguments.Length > 8 ? Arguments[8] : null,
                               Arguments.Length > 9 ? Arguments[9] : null
                            );
                }
                catch (Exception ex)
                {
                    ConsoleConstants.WriteInConsole("Erro ao carregar função\n" + ex.Message + "\nPlugin: " + File
                        , System.Drawing.Color.DarkRed);
                }
            }
        }

        /// <summary>
        /// Invocar métodos dos plugins seguros (SafePlugins)
        /// </summary>
        /// <param name="functionEnum">Quais métodos invocar</param>
        /// <param name="Arguments">Argumentos da função</param>
        public static void InvokeSafeFunction(FunctionsEnum functionEnum, params object[] Arguments)
        {
            if (!RegisterFunction.SafeFunctionsJS.ContainsKey(functionEnum))
                return;

            List<Object> SafeFunctions = RegisterFunction.SafeFunctionsJS[functionEnum];
            for (int i = 0; i < SafeFunctions.Count; i++)
            {
                try
                {
                    dynamic Function = SafeFunctions[i];
                    Function(
                               Arguments.Length > 0 ? Arguments[0] : null,
                               Arguments.Length > 1 ? Arguments[1] : null,
                               Arguments.Length > 2 ? Arguments[2] : null,
                               Arguments.Length > 3 ? Arguments[3] : null,
                               Arguments.Length > 4 ? Arguments[4] : null,
                               Arguments.Length > 5 ? Arguments[5] : null,
                               Arguments.Length > 6 ? Arguments[6] : null,
                               Arguments.Length > 7 ? Arguments[7] : null,
                               Arguments.Length > 8 ? Arguments[8] : null,
                               Arguments.Length > 9 ? Arguments[9] : null
                            );
                }

                catch (Exception ex)
                {
                    ConsoleConstants.WriteInConsole(
                        "Erro ao carregar SafeFunction\nErro: " + ex.Message
                        , System.Drawing.Color.DarkRed);
                }
            }
        }

        /// <summary>
        /// Invocar funções anônimas recebidas do servidor
        /// </summary>
        /// <param name="Script">Script que contém a função e outras coisas que serão chamados</param>
        /// <param name="NameFunction">Nome da função a ser chamada</param>
        /// <param name="Arguments">Argumentos da função</param>
        public static void InvokeAnonymousSafePlugin(string Script, string NameFunction, params object[] Arguments)
        {
            try
            {
                Engines.EngineSafePlugins.Execute(Script);
                dynamic Function = Engines.EngineSafePlugins.Script[NameFunction];
                Function(
                           Arguments.Length > 0 ? Arguments[0] : null,
                           Arguments.Length > 1 ? Arguments[1] : null,
                           Arguments.Length > 2 ? Arguments[2] : null,
                           Arguments.Length > 3 ? Arguments[3] : null,
                           Arguments.Length > 4 ? Arguments[4] : null,
                           Arguments.Length > 5 ? Arguments[5] : null,
                           Arguments.Length > 6 ? Arguments[6] : null,
                           Arguments.Length > 7 ? Arguments[7] : null,
                           Arguments.Length > 8 ? Arguments[8] : null,
                           Arguments.Length > 9 ? Arguments[9] : null
                        );
            }
            catch (Exception ex)
            {
                ConsoleConstants.WriteInConsole("Erro ao carregar função segura\n" + ex.Message, System.Drawing.Color.Red);
            }
        }
    }
}
