using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public string Seats { get; protected set; }

        protected Vehicle(string brand, string name, string seats)
        {
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Please provide valid data.");
            }
            if (Brand == brand)
            {
                return;
            }

            Brand = brand;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please provide valid data.");
            }
            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        private void SetSeats(string seats)
        {
            if (string.IsNullOrWhiteSpace(seats))
            {
                throw new Exception("Please provide valid data.");
            }
            if (Seats == seats)
            {
                return;
            }

            Seats = seats;
        }

        public static Vehicle Create(string brand, string name, string seats)
            => new Vehicle(brand, name, seats);
    }
}
