using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Address
    {
        public Address(string street, string houseNr, string zipCode, string city)
        {
            Street = street;
            HouseNr = houseNr;
            ZipCode = zipCode;
            City = city;
        }

        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
