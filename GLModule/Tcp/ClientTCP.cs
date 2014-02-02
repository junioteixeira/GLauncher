//********************************************************//
//                GLauncher (GLModule)                    //
//                       GTeam                            //
//  Este é um projeto Open Source, mantenha os créditos   //
//               MeTaL,Oxyfgp,tDarkFall                   //
//                                                        //
//                  LAUS DEO SEMPER!                      //
//********************************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using Newtonsoft.Json;

using GLModule.Constants;
using GLModule.Tcp.TcpData;
using GLModule.Warnings;
using GLModule.Warnings.Hardware;

namespace GLModule.Tcp
{
    public class ClientTCP
    {
        Socket socket;
        NetworkStream netWorkStream;
        Thread thread;
        IPEndPoint ipEndPoint;

        #region Eventos
        /// <summary>
        /// Dados recebidos
        /// </summary>
        public event DataReceivedHandle DataReceived;

        /// <summary>
        /// Dados enviados
        /// </summary>
        public event DataSentHandle DataSent;

        /// <summary>
        /// Evento Login, retorna os dados do servidor após efetuar o login
        /// </summary>
        public event EventLoginHandle EventLogin;

        /// <summary>
        /// Evento Deslogar, retorna os dados do servidor após tentar deslogar
        /// </summary>
        public event EventUnloginHandle EventUnlogin;

        /// <summary>
        /// Evento conectar, retorna os dados do servidor após tentar se conectar a ele
        /// </summary>
        public event EventConnectHandle EventConnect;

        /// <summary>
        /// Evento desconectar, invocado quando o client foi desconectado do servidor
        /// </summary>
        public event EventHandler EventDisconnect;

        /// <summary>
        /// Evento dos plugins seguros recebidos diretamente do servidor
        /// </summary>
        public event EventSafePluginsHandle EventSafePlugins;

        /// <summary>
        /// Evento de informação do hardware, recebe os avisos que prejudicam a jogabilidade
        /// </summary>
        public event EventHardwareInfoHandle EventHardwareInfo;
        #endregion

        public IPAddress IP
        { get { return ipEndPoint.Address; } }

        public int Port
        { get { return ipEndPoint.Port; } }

        /// <summary>
        /// Classe responsável pela conexão TCP com o servidor
        /// </summary>
        /// <param name="ContinueReceive">Indica se a conexão estará sempre recebendo dados</param>
        public ClientTCP(bool ContinueReceive)
        {
            ipEndPoint = new IPEndPoint(TcpConstants.IP, TcpConstants.Port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            netWorkStream = new NetworkStream(socket);
            DataReceived += DataReceivedCore;
            thread = new Thread(() => ReceiveData(ContinueReceive));
            thread.Start();
        }

        private void ReceiveData(bool ContinueReceive)
        {
            bool Sucess;
            while (ContinueReceive)
            {
                //Receber o tipo do comando (2 bytes)
                TypeCommand Command = (TypeCommand)(netWorkStream.ReadSpecific<ushort>(out Sucess));
                if (!Sucess) { break; }

                //Continuar a receber dados?
                bool ContinueReceiveData = netWorkStream.ReadSpecific<bool>(out Sucess);
                if (!ContinueReceiveData)
                {
                    OnDataReceived(Command);
                    break;
                }

                //Tem argumentos?
                bool HasArguments = netWorkStream.ReadSpecific<bool>(out Sucess);
                if (!HasArguments)
                {
                    OnDataReceived(Command);
                    continue;
                }

                //Receber Argumentos serializados
                string TypeArgumentsSerialized = netWorkStream.ReadSpecific<string>(out Sucess);
                if (!Sucess) { break; }

                //Leitura dos tipos de argumentos
                Object[] Arguments = JsonConvert.DeserializeObject<Object[]>(TypeArgumentsSerialized);

                OnDataReceived(Command, Arguments);
            }
        }

        /// <summary>
        /// Enviar dados através da Stream
        /// </summary>
        /// <param name="Command">Tipo do comando a ser enviado</param>
        /// <param name="Arguments">Argumentos do comando. Caso não tenha, deixe-o vazio</param>
        /// <returns>Informa se os dados foram enviados corretamente</returns>
        public bool SendData(TypeCommand Command, params object[] Arguments)
        {
            lock (this)
            {
                bool ReturnMethod = true;
                bool HasArguments = Arguments.Length > 0;

                ReturnMethod &= netWorkStream.WriteSpecific<ushort>((ushort)(Command));
                ReturnMethod &= netWorkStream.WriteSpecific<bool>(HasArguments);

                if (HasArguments)
                    ReturnMethod &= netWorkStream.WriteSpecific<string>(JsonConvert.SerializeObject(Arguments));

                return ReturnMethod;
            }
        }

        public void Disconnect()
        {
            OnEventDisconnect(EventArgs.Empty);
            netWorkStream.Close();
            netWorkStream.Dispose();
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket.Dispose();
            if (thread.IsAlive)
                thread.Abort();
        }

        private void DataReceivedCore(TypeCommand Command, params object[] ArgumentsReceived)
        {
            switch (Command)
            {
                case TypeCommand.Connect:
                case TypeCommand.Login:
                case TypeCommand.Unlogin:
                    {
                        bool Sucess = (bool)ArgumentsReceived[0];
                        string MsgErro = (string)ArgumentsReceived[1];

                        if (Command == TypeCommand.Unlogin)
                            OnEventUnlogin(Sucess, MsgErro);

                        else if (Command == TypeCommand.Login)
                            OnEventLogin(Sucess, MsgErro);

                        else
                            OnEventConnect(Sucess, MsgErro);
                    }
                    break;

                case TypeCommand.HardwareInfo:
                    {
                        List<IWarning> Warnings = ArgumentsReceived[0] as List<IWarning>;
                        OnEventHardwareInfo(Warnings);
                    }
                    break;

                default:
                    ConsoleConstants.WriteInConsole(
                        "Comando recebido do servidor é desconhecido." +
                        "\nCódigo do comando: " + Convert.ToString((uint)Command, 16), Color.DarkRed);
                    break;
            }
        }

        #region Eventos
        protected virtual void OnDataReceived(TypeCommand Command, params object[] Arguments)
        {
            Control control = DataReceived.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(DataReceived, Command, Arguments);
            }
            else
            {
                DataReceived(Command, Arguments);
            }
        }

        protected virtual void OnDataSent(TypeCommand Command, params object[] Arguments)
        {
            Control control = DataSent.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(DataSent, Command, Arguments);
            }
            else
            {
                DataSent(Command, Arguments);
            }
        }

        protected virtual void OnEventDisconnect(EventArgs e)
        {
            Control control = EventDisconnect.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(EventDisconnect, this, e);
            }
            else
            {
                EventDisconnect(this, e);
            }
        }

        protected virtual void OnEventLogin(bool Sucess, string MsgErro)
        {
            Control control = EventLogin.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(EventLogin, Sucess, MsgErro);
            }
            else
            {
                EventLogin(Sucess, MsgErro);
            }
        }

        protected virtual void OnEventUnlogin(bool Sucess, string MsgErro)
        {
            Control control = EventUnlogin.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(EventUnlogin, Sucess, MsgErro);
            }
            else
            {
                EventUnlogin(Sucess, MsgErro);
            }
        }

        protected virtual void OnEventConnect(bool Sucess, string MsgErro)
        {
            Control control = EventConnect.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(EventConnect, Sucess, MsgErro);
            }
            else
            {
                EventConnect(Sucess, MsgErro);
            }
        }

        protected virtual void OnEventSafePlugins(string[] SafePlugins, string[] LibsImport)
        {
            Control control = EventSafePlugins.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(EventSafePlugins, SafePlugins,LibsImport);
            }
            else
            {
                EventSafePlugins(SafePlugins,LibsImport);
            }
        }

        protected virtual void OnEventHardwareInfo(List<IWarning> Warnings)
        {
            Control control = EventHardwareInfo.Target as Control;
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(EventHardwareInfo, Warnings);
            }
            else
            {
                EventHardwareInfo(Warnings);
            }
        }
        #endregion
    }
}
