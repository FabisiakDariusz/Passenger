using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UdateAt { get; protected set; }

        protected Node(string address, string longitude, string latitude)
        {

        }

        public void SetAddress(string address)
        {
            Address = address;
            UdateAt = DateTime.UtcNow;
        }

        public void SetLongitude(double longitude)
        {
            if (double.IsNaN(longitude))
            {
                throw new Exception("Longitude must by a number");
            }
            if (Longitude == longitude)
            {
                return;
            }

            Longitude = longitude;
            UdateAt = DateTime.UtcNow;
        }

        public void SetLatitude(double latitude)
        {
            if (double.IsNaN(latitude))
            {
                throw new Exception("Longitude must by a number");
            }
            if (Latitude == latitude)
            {
                return;
            }

            Latitude = latitude;
            UdateAt = DateTime.UtcNow;
        }

        public static Node Create(string address, string longitude, string latitude)
            => new Node(address, longitude, latitude);
    }
}
