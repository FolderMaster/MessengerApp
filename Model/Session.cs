using System.Collections.ObjectModel;

namespace Model
{
    public class Session
    {
        public User CurrentUser { get; set; }

        public ObservableCollection<User> Users { get; } = new();
    }
}
