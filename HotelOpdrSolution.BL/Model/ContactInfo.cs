using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class ContactInfo
    {
        public ContactInfo(string email, string phone, Address addressInfo)
        {
            Email = email;
            Phone = phone;
            AddressInfo = addressInfo;
        }

        public string Email { get; set; }
        public string Phone { get; set; }
        public Address AddressInfo { get; set; }
    }
}
