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

using System.Net;
using System.Net.Sockets;
using System.Threading;
using GLModule.Constants;
using GLModule.Tcp.TcpData;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace GLModule.Tcp
{
    public class ClientTCP
    {
        Socket socket;
        NetworkStream netWorkStream;
        Thread thread;
        IPEndPoint ipEndPoint;

        public event DataReceivedHandle DataReceived;
        public event DataSentHandle DataSent;
        public event DisconnectedHandle Disconnected;
        public event ConnectedHandle Connected;

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
            thread = new Thread(() => ReceiveData(ContinueReceive));
            thread.Start();
        }

        private void ReceiveData(bool ContinueReceive)
        {
            bool Sucess;
            while (ContinueReceive)
            {
                //Receber o tipo do comando (2 bytes), Continuar a receber pacotes(bool), Tem argumento(s)(bool)
                TypeCommand Command = (TypeCommand)(netWorkStream.ReadSpecific<ushort>(out Sucess));
                if (!Sucess) { break; }

                //Continuar a receber pacotes?
                if (!netWorkStream.ReadSpecific<bool>(out Sucess))
                {
                    OnDataReceived(Command, null);
                    break;
                }

                //Tem argumento(s)?
                if (!netWorkStream.ReadSpecific<bool>(out Sucess))
                {
                    OnDataReceived(Command, null);
                    continue;
                }

                //Receber Tipo de Argumentos serializados
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
        /// <param name="Arguments">Argumentos do comando. Caso não tenha, deixe-o null</param>
        /// <returns>Informa se os dados foram enviados corretamente</returns>
        public bool SendData(TypeCommand Command, params object[] Arguments)
        {
            bool ReturnMethod = true;
            bool HasArguments = Arguments.Length > 0;

            ReturnMethod &= netWorkStream.WriteSpecific<ushort>((ushort)(Command));
            ReturnMethod &= netWorkStream.WriteSpecific<bool>(HasArguments);

            if (HasArguments)
                ReturnMethod &= netWorkStream.WriteSpecific<string>(JsonConvert.SerializeObject(Arguments));

            return ReturnMethod;
        }

        public void Disconnect()
        {
            OnDisconnected(new EventArgs());
            netWorkStream.Close();
            netWorkStream.Dispose();
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket.Dispose();
            if (thread.IsAlive)
                thread.Abort();
        }


        public virtual void OnDataReceived(TypeCommand Command, params object[] Arguments)
        {
            Control control = DataReceived.Target as Control;
            if (control.InvokeRequired)
            {
                control.Invoke(DataReceived, Command, Arguments);
            }
            else
            {
                DataReceived(Command, Arguments);
            }
        }

        public virtual void OnDataSent(TypeCommand Command, params object[] Arguments)
        {
            Control control = DataSent.Target as Control;
            if (control.InvokeRequired)
            {
                control.Invoke(DataSent, Command, Arguments);
            }
            else
            {
                DataSent(Command, Arguments);
            }
        }

        public virtual void OnDisconnected(EventArgs e)
        {
            Control control = Disconnected.Target as Control;
            if (control.InvokeRequired)
            {
                control.Invoke(Disconnected, e);
            }
            else
            {
                Disconnected(e);
            }
        }

        public virtual void OnConnected(EventArgs e)
        {
            Control control = Connected.Target as Control;
            if (control.InvokeRequired)
            {
                control.Invoke(Connected, e);
            }
            else
            {
                Connected(e);
            }
        }
    }
}
