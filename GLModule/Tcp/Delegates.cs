using System;
using System.Collections.Generic;
using GLModule.Tcp.TcpData;
using GLModule.Warnings;

namespace GLModule.Tcp
{
    /// <summary>
    /// Dados recebidos
    /// </summary>
    /// <param name="Command">Tipo do comando</param>
    /// <param name="ArgumentsReceived">Argumentos recebidos</param>
    public delegate void DataReceivedHandle(TypeCommand Command, params object[] ArgumentsReceived);

    /// <summary>
    /// Dados enviados
    /// </summary>
    /// <param name="Command">Tipo do comando</param>
    /// <param name="ArgumentsSent">Argumentos enviados</param>
    public delegate void DataSentHandle(TypeCommand Command, params object[] ArgumentsSent);

    /// <summary>
    /// Evento Login, retorna os dados do servidor após efetuar o login
    /// </summary>
    /// <param name="SucessLogin">Indica se o login ocorreu com sucesso</param>
    /// <param name="MsgErro">Mensagem informando o motivo do erro</param>
    public delegate void EventLoginHandle(bool SucessLogin, string MsgErro);

    /// <summary>
    /// Evento Deslogar, retorna os dados do servidor após tentar deslogar
    /// </summary>
    /// <param name="SucessUnlogin">Indica se o Login foi realizado com sucesso</param>
    /// <param name="MsgErro">Mensagem informando o motivo do erro</param>
    public delegate void EventUnloginHandle(bool SucessUnlogin, string MsgErro);

    /// <summary>
    /// Evento conectar, retorna os dados do servidor após tentar se conectar a ele
    /// </summary>
    /// <param name="SucessConnect">Indica se a conexão foi realizada com sucesso</param>
    /// <param name="MsgErro">Mensagem informando o motivo do erro</param>
    public delegate void EventConnectHandle(bool SucessConnect, string MsgErro);

    /// <summary>
    /// Evento dos plugins seguros recebidos diretamente do servidor
    /// </summary>
    /// <param name="SafePlugins">Scripts</param>
    /// <param name="LibsImport">Libs para exportar para os scripts</param>
    public delegate void EventSafePluginsHandle(string[] SafePlugins, string[] LibsImport);

    /// <summary>
    /// Evento de informação do hardware, recebe os avisos que prejudicam a jogabilidade
    /// </summary>
    /// <param name="Warnings">Avisos</param>
    public delegate void EventHardwareInfoHandle(List<IWarning> Warnings);
}