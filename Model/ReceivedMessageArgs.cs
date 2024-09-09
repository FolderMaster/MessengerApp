namespace Model
{
    public class ReceivedMessageArgs
    {
        public string Ip { get; private set; }

        public int Port { get; private set; }

        public string Message { get; private set; }

        public ReceivedMessageArgs(string ip, int port, string message)
        {
            Ip = ip;
            Port = port;
            Message = message;
        }
    }
}
