// Os comandos estão seguidos de uma informação breve e abaixo os argumentos

namespace GLModule.Tcp.TcpData
{
    public enum TypeCommand
    {
        /// <summary>
        /// Indica que o client iniciou o jogo
        /// </summary>
        Play = (0xACDA),

        /// <summary>
        /// Logar
        /// Client = string Login, string Senha |
        /// Server = bool SucessLogin, string MsgErro
        /// </summary>
        Login = (0xFCE4),

        /// <summary>
        /// Deslogar
        /// Client = null |
        /// Server = bool SucessUnlogin, string MsgErro
        /// </summary>
        Unlogin = (0xCA86),

        /// <summary>
        /// Se conectar ao Host
        /// Client = string MAC Address |
        /// Server = bool SucessConnect, string MsgErro
        /// </summary>
        Connect = (0x8CD0),

        /// <summary>
        /// Informações do Hardware do Client
        /// Client = HardwareInformation |
        /// Server = List(IWarning) Warnings  
        /// </summary>
        HardwareInfo = (0xEE8C),

        /// <summary>
        /// Download de Plugins seguros, têm todos os privilégios do .NET
        /// Client = null |
        /// Server = string[] SafePlugins, string[] LibsImport
        /// </summary>
        SafePlugins = (0xCDD8),
    }
}