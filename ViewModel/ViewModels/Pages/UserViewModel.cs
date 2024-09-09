using Model;
using Model.Connections;
using Model.Interfaces;

namespace ViewModel.ViewModels.Pages;

public class UserViewModel : PageViewModel
{
    public IUser User { get; }

    public UserViewModel(object metadata, IUser user) : base(metadata) =>
        User = user;

    public UserViewModel() : this("Connection", new User(new InternalConnection())) { }
}
