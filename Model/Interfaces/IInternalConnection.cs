namespace Model.Interfaces
{
    public interface IInternalConnection : IConnection
    {
        public bool IsAvailable { get; }

        public event EventHandler<ReceivedMessageArgs> MessageReceived;
    }
}
