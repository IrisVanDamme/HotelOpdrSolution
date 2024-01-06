using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.DTOs
{
    public class FullCustomerDTO
    {
        public FullCustomerDTO(int id, string name, string email, string phone, string street, string houseNr, string zipcode, string city)
        {
            Id = id;
            Name = name;
            Email = email;
            Street = street;
            HouseNr = houseNr;
            Zipcode = zipcode;
            City = city;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
