using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class ContactInfo
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public ContactInfo ContactInfoKlant { get; set; }
    }
}
