using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Member
    {
        public Member(string name, DateOnly birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
