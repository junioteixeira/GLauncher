using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ClearScript.V8;

namespace GLModule.PluginJS
{
    public static class Engines
    {
        /// <summary>
        /// Executar plugins que estão na pasta para Plugins com controle de permissões
        /// </summary>
        public volatile static V8ScriptEngine EnginePlugins = new V8ScriptEngine();

        /// <summary>
        /// Engine para executar plugins recebidos pelo servidor que têm todas as permissões
        /// Essa também vale para os Plugins anônimos
        /// </summary>
        public volatile static V8ScriptEngine EngineSafePlugins = new V8ScriptEngine();
    }
}
