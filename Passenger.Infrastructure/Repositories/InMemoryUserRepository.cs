using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@tmp.pl","user1","user1","salt"),
            new User("user2@tmp.pl","user2","user2","salt"),
            new User("user3@tmp.pl","user3","user3","salt")
        };

        public void Add(User user)  
        {
            _users.Add(user);
        }

        public User Get(Guid id)
            => _users.Single(x => x.Id == id);

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}
