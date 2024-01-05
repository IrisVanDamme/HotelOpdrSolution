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

        private string _email;
        public string Email { get => _email;
            set{
                if (!value.Contains("@"))
                    throw new ArgumentException("Email moet een \"@\"-karakter bevatten");
                _email = value;
            }
        }
        private string _phone;
        public string Phone { get => _phone;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Telefoonnummer mag niet leeg zijn");
                _phone = value;
            }
        }
        public Address AddressInfo { get; set; }
    }
}
