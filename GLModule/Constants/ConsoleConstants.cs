using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GLModule.Constants
{
    public static class ConsoleConstants
    {
        /// <summary>
        /// Permitir o ConsoleWindow
        /// </summary>
        public const bool AllowConsoleWindow = true;

        /// <summary>
        /// Teclas para abrir ou fechar o console
        /// </summary>
        public const Keys KeyConsoleWindow = (Keys.Control | Keys.E); // CTRL + E

        /// <summary>
        /// Escrever no console, caso esteja habilitado
        /// <para>arg1 = Mensagem para escrever</para>
        /// arg2 = Cor
        /// </summary>
        public static Action<string, Color> WriteInConsole;
    }
}
