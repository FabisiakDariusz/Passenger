using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using System;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverDto Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);
            return new DriverDto
            {
                //
            };
        }

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
    }
}
