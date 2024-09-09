using Model.Interfaces;

namespace Model
{
    public class Message : IMessage
    {
        public string Ip { get; private set; }

        public int Port { get; private set; }

        public string Content { get; private set; }

        public Message(string ip, int port, string content)
        {
            Ip = ip;
            Port = port;
            Content = content;
        }
    }
}
