namespace Model.Interfaces
{
    public interface IExternalConnection : IConnection
    {
        public new string Ip { get; set; }

        public bool IsConnected { get; }

        public void Connect();

        public void Send(string message);
    }
}
