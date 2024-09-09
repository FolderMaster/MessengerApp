using System.Net;
using System.Net.Sockets;
using System.Text;

using Model.Interfaces;

namespace Model.Connections
{
    public class ExternalConnection : IExternalConnection
    {
        private Socket? _socket;

        public string Ip { get; set; }

        public int Port { get; set; }

        public bool IsConnected { get; private set; }

        public ExternalConnection()
        {
            Ip = IPAddress.Loopback.ToString();
        }

        public void Connect()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.Connect(new IPEndPoint(IPAddress.Parse(Ip), Port));
            IsConnected = _socket.Connected;
        }

        public void Send(string message)
        {
            var data = Encoding.Default.GetBytes(message);
            var i = _socket?.SendAsync(data);
        }
    }
}
