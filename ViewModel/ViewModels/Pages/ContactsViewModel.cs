using ReactiveUI;
using System.Reactive;

using Model;
using Model.Connections;
using Model.Interfaces;

namespace ViewModel.ViewModels.Pages;

public class ContactsViewModel : PageViewModel
{
    public IUser OtherUser { get; }

    public IUser User { get; }

    public IExternalConnection Connection { get; } = new ExternalConnection();

    public string Message { get; set; }

    public ChatManager Chat { get; private set; }

    public ReactiveCommand<Unit, Unit> ConnectCommand { get; }
    
    public ReactiveCommand<Unit, Unit> SendCommand { get; }

    public ContactsViewModel(object metadata, IUser user, ChatManager chat) : base(metadata)
    {
        ConnectCommand = ReactiveCommand.Create(Connect);
        SendCommand = ReactiveCommand.Create(Send);
        User = user;
        Chat = chat;
    }

    public ContactsViewModel() : this("Contacts", new User(new InternalConnection()), new()) { }

    private void Connect() => Connection.Connect();

    private void Send()
    {
        Chat.AddOwnMessage(Message);
        Connection.Send(Message);
    }
}
