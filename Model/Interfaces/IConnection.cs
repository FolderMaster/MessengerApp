namespace Model.Interfaces
{
    public interface IConnection
    {
        public int Port { get; set; }

        public string Ip { get; }
    }
}
