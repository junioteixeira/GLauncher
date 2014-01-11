using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace GLModule.Constants
{
    public static class SettingsGameConstants
    {
        public static Type TypeSettingsClass = typeof(SettingsGame.Settings);

        /// <summary>
        /// Diretório de Registro para armazenar as configurações
        /// </summary>
        public static RegistryKey PathRegistryKey = Registry.CurrentUser.CreateSubKey("Software\\GameGLauncher\\Settings");

        /// <summary>
        /// Caminho do arquivo externo para armazenar as configurações
        /// </summary>
        public const string PathExternFile = "Settings.glaunche";

        /// <summary>
        /// Serialização base das configurações do jogo
        /// Colocar o campo cujo se deseja substituir da seguinte forma {Campo}
        /// Exemplo:
        /// [DataGame]
        /// EnableWindowMode = {WindowMode}
        /// </summary>
        public static string ExternFileBaseSerialization = 
            "[DataGame]\n"+
            "EnableWindowMode = {WindowMode}";

        /// <summary>
        /// Parâmetros para iniciar o jogo, também válidos para inserir configurações
        /// Caso haja uma propriedade IP na classe de Configurações,
        /// ele irá substituir o que há no parâmetros escrito {IP}
        /// </summary>
        public static string ParamStartGame = "/p{IP} /ca{Porta}";
    }
}
