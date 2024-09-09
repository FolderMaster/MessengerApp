using Model.Interfaces;

namespace Model
{
    public class User : IUser
    {
        private List<IConnection> _connections = new();

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IConnection> Connections => _connections;

        public IInternalConnection CurrentConnection { get; private set; }

        public User(IInternalConnection connection)
        {
            CurrentConnection = connection;
            _connections.Add(connection);
        }
    }
}
