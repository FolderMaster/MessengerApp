using System.Collections.ObjectModel;

using Model.Interfaces;

namespace Model
{
    public class ChatManager
    {
        public ObservableCollection<IMessage> Messages { get; } = new();

        public ChatManager() { }

        public ChatManager(IInternalConnection connection)
        {
            connection.MessageReceived += Connection_MessageReceived;
        }

        public void AddOwnMessage(string content)
        {
            Messages.Add(new Message("", 0, content));
        }

        private void Connection_MessageReceived(object? sender, ReceivedMessageArgs e)
        {
            Messages.Add(new Message(e.Ip, e.Port, e.Message));
        }
    }
}
