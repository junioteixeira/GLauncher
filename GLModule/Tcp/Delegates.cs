using System;
using GLModule.Tcp.TcpData;

namespace GLModule.Tcp
{
    public delegate void DataReceivedHandle(TypeCommand Command, params object[] ArgumentsReceived);
    public delegate void DataSentHandle(TypeCommand Command, params object[] ArgumentsSent);

    public delegate void ConnectedHandle(EventArgs e);
    public delegate void DisconnectedHandle(EventArgs e);
}