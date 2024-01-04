using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }
        public List<Registration> Registrations { get; set; }
        public ContactInfo ContactInfoCustomer { get; set; }
    }
}
