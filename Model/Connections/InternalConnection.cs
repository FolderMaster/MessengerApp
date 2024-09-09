using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

using Model.Interfaces;

namespace Model.Connections
{
    public class InternalConnection : IInternalConnection
    {
        private Socket? _socket;

        private string _ip;

        private int _port;

        public int Port
        {
            get => _port;
            set
            {
                if(_port != value)
                {
                    _port = value;
                    CreateSocket(_port);
                }
            }
        }

        public string Ip { get; private set; }

        public bool IsAvailable { get; private set; }

        public event EventHandler<ReceivedMessageArgs> MessageReceived;

        public InternalConnection()
        {
            UpdateIp();
            CreateSocket();
        }

        public void UpdateIp()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces().
                Where(ni => ni.OperationalStatus == OperationalStatus.Up).
                OrderByDescending(ni => ni.NetworkInterfaceType).
                ThenByDescending(ni => ni.Speed);
            foreach (var ni in networkInterfaces)
            {
                foreach (var ip in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork && !ip.Address.Equals(IPAddress.Loopback))
                    {
                        Ip = ip.Address.ToString();
                        break;
                    }
                }
            }
        }

        private void CreateSocket(int port = 0)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
            ReceiveMessageAsync(_socket);
            if(port == 0)
            {
                var localEndPoint = (IPEndPoint)_socket.LocalEndPoint;
                _port = localEndPoint.Port;
            }
            else
            {
                _port = port;
            }
        }

        private async Task ReceiveMessageAsync(Socket receiver)
        {
            var data = new byte[65535];
            while (receiver == _socket)
            {
                var result = await receiver.ReceiveFromAsync(data, new IPEndPoint(IPAddress.Any, 0));
                var message = Encoding.Default.GetString(data, 0, result.ReceivedBytes);
                var endPoint = (IPEndPoint)result.RemoteEndPoint;
                MessageReceived?.Invoke(this, new ReceivedMessageArgs(endPoint.Address.ToString(), endPoint.Port, message));
            }
        }
    }
}
