using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GLModule.Constants;
using GLModule.PluginJS.Clear;

namespace GLModule.PluginJS
{
    public static class InvokeFunctions
    {
        public static void Invoke(FunctionsEnum functionEnum, params object[] Arguments)
        {
            Dictionary<String, Object> Plugins = RegisterFunctionClear.FunctionsJS[functionEnum];
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
    }
}
