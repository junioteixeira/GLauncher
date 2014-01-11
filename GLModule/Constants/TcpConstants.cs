/**********************************************************
 *                GLauncher (GLModule)                    *
 *                       GTeam                            *
 *  Este é um projeto Open Source, mantenha os créditos   *
 *               MeTaL,Oxyfgp,tDarkFall                   *
 *                                                        *
 *                  LAUS DEO SEMPER!                      *
 **********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
namespace GLModule.Constants
{
    public static class TcpConstants
    {
        /// <summary>
        /// IP do servidor a qual o client tentará se conectar
        /// </summary>
        public readonly static IPAddress IP = IPAddress.Parse("127.0.0.1");

        /// <summary>
        /// Porta do servidor a qual o client tentará se concetar
        /// </summary>
        public const ushort Port = 31057;
    }
}
