namespace Model.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IConnection> Connections { get; }

        public IInternalConnection CurrentConnection { get; }
    }
}
