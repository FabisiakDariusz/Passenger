using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _driver = new HashSet<Driver>();

        public void Add(Driver driver)
        {
            _driver.Add(driver);
        }

        public Driver Get(Guid userId)
            => _driver.Single(x => x.UserId == userId);

        public IEnumerable<Driver> GetAll()
            => _driver;

        public void Update(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
