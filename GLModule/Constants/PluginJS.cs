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
        public const bool AllowPluginGS = true;

        /// <summary>
        /// Local dos plugins em JavaScript
        /// </summary>
        public const string PathPluginGS = "PluginJS\\";

        public static JintEngine EnginePluginsJS = new JintEngine();
    }
}
