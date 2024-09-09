using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConnectionRequest : IRequest
    {
        public User ConnectionUser { get; set; }

        public void Execute(Session session)
        {
            session.Users.Add(ConnectionUser);
        }
    }
}
