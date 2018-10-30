using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public Guid Id { get; protected set; }
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public string Seats { get; protected set; }
    }
}
