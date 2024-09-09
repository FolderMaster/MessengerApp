namespace Model.Interfaces
{
    public interface IMessage
    {
        public string Ip { get; }

        public int Port { get; }

        public string Content { get; }
    }
}
