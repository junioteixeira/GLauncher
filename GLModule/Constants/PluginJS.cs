using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jint;

namespace GLModule.Constants
{
    public static class PluginJS
    {
        /// <summary>
        /// Permitir o uso de Plugins com JavaScript
        /// </summary>
        public static bool AllowPluginJS = true;

        /// <summary>
        /// Permitir plugins "seguros" recebidos diretamente do servidor
        /// </summary>
        public static bool AllowSafePlugin = true;

        /// <summary>
        /// Permitir plugins anônimos "seguros" recebidos diretamente do servidor
        /// Estes são scripts recebidos do server e chamados diretamente em tempo de execução a escolha do Administrador
        /// </summary>
        public static bool AllowAnonymousSafePlugin = true;

        /// <summary>
        /// Local dos plugins em JavaScript
        /// </summary>
        public const string PathPluginJS = "PluginJS";
    }
}
